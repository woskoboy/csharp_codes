use Power
go

alter proc ReqProc
@id int
as
declare @result ;
begin
	select top 5 * from power_accounting
	where DeviceCode = 'E'+CAST(@id as varchar(10)) 
	order by MeasureTime desc;
end;
go

exec ReqProc 2


