use Power
go

alter proc ReqProc
@ids varchar(100)
as
begin
declare @tmp_table Table ([MeasureTime] smalldatetime, [DeviceCode] varchar(14), [P] float)
declare @sql varchar(100)='select top 5 * from power_accounting where DeviceCode in (<IDs>) 
						  order by MeasureTime desc;'
	set @sql = replace(@sql,'<IDs>', @ids)
	insert into @tmp_table exec(@sql)
	select * from @tmp_table order by DeviceCode, MeasureTime  
end;
go

/*exec ReqProc '''E2'',''E3'''*/