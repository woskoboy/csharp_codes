use Power
go

alter proc ReqProc
@id varchar(10)
as
select top 5 * from power_accounting where DeviceCode=''+@id+'' order by MeasureTime desc;
go

/*exec ReqProc 'E3'*/