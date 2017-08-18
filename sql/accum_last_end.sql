use Power
go

/* ������ �������� ������. 
���������� ��������� �������� (���� ��������) �� ��������� ������� elements_table */
alter proc ParseString_and_FillTempTable 
@cut_string varchar(500)
as
begin
declare @element varchar(20)=null
create Table #elements_table (device_code varchar(100)) 
	WHILE LEN(@cut_string) > 0
		begin
			if PATINDEX('%,%',@cut_string) > 0
			begin
				/* ������� */
				set @element = SUBSTRING(@cut_string,0,PATINDEX('%,%', @cut_string))
				/* ������� ������ */
				set @cut_string = SUBSTRING(@cut_string,
										LEN(@element + ',') + 1,
										len(@cut_string))
			/* ���� �������� ������������ � �������*/
			insert into #elements_table select @element
			end
			else
			begin
				set @element = @cut_string
				set @cut_string = null
			end
		end
/*AccumulatePower*/
declare @tmp_table Table (MeasureTime smalldatetime,DeviceCode varchar(10), P float)
declare @fin_table Table (MeasureTime smalldatetime,DeviceCode varchar(10), P float, TimeLabel int)
declare @sql varchar(500);
declare @device_code int;
begin
	while (select count(*) from  #elements_table) > 0
		begin
			/* ����� ���� ������� ������ */
			set @device_code = ((select top(1) device_code from #elements_table))
			/* ����������� ������� - ������ ������ ��������� ������� */
			delete top(1) #elements_table
			/* �������� 5 ��������� ������� ��� ���������� ������� */	
			set @sql = 'select top 5 * from power_accounting
				where DeviceCode = '+'''E'+ cast(@device_code as varchar(10)) + ''' order by MeasureTime desc'
			insert into @tmp_table exec(@sql)

			/* ������ ������ ��������� ����� ������� �� ������� � ���������� ����� ����������� ������ �������������� */
			insert into @fin_table select MeasureTime,DeviceCode,P,ROW_NUMBER() OVER (ORDER BY MeasureTime) AS TimeLabel
				from @tmp_table 
			
			delete @tmp_table
		end;
	
	select 
		/*������������ �� MeasureTime �� ����, 
		������ ��� ��������� �������� ����� ���� �������� � ���� � ��������� � �������� ��� �������.
		������� ���� ������� ������� �������, � ��������� �������� ����� ����������� ����� ������� */
		avg(DATEPART(MINUTE,MeasureTime)) as min_,
		sum(P) as accum_power 
		from @fin_table group by TimeLabel order by min_ desc
end
end
go

/*alter proc AccumulatePower
as
declare ...
go*/

exec ParseString_and_FillTempTable  '1,3,'
go