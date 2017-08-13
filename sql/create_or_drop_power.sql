use Power
if exists(
	select s.name,t.name from sys.schemas as s join sys.tables as t
	ON s.schema_id = t.schema_id
	WHERE s.name = 'dbo' and t.name = 'power_accounting')
	drop table power_accounting;
else
	create table power_accounting
(
	MeasureTime smalldatetime,
	DeviceCode varchar(14),
	P float
)