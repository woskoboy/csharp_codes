use Power
declare @uid int=1;
declare @tmp_table Table (MeasureTime smalldatetime,DeviceCode varchar(10), P float)
declare @fin_table Table (MeasureTime smalldatetime,DeviceCode varchar(10), P float, TimeLabel int)
declare @sql varchar(1000);

while @uid in (1,2)
	begin
		set @sql = 'select top 5 * from power_accounting
		where DeviceCode = '+'''E'+CAST(@uid as varchar(10)) + ''' order by MeasureTime desc'
		/*exec(@sql)*/
		insert into @tmp_table exec(@sql)
		insert into @fin_table 
			select MeasureTime,DeviceCode,P,ROW_NUMBER() OVER (ORDER BY MeasureTime) AS TimeLabel
			from @tmp_table 
		DELETE FROM @tmp_table
		set @uid += 1;
	end;

select avg(DATEPART(MINUTE,MeasureTime)) as min_,
	   sum(P) as accum_power 
	   from @fin_table group by TimeLabel order by min_ desc


/*ALTER TABLE @tmp_table ADD COLUMN time COUNTER CONSTRAINT id PRIMARY KEY*/
/*select DeviceCode,sum(t.P),DeviceCode from @tmp_table as t group by DeviceCode order by MeasureTime desc*/