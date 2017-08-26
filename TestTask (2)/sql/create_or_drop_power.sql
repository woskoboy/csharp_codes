use Power
if exists( 
		select s.name,t.name from sys.schemas as s join sys.tables as t
		ON s.schema_id = t.schema_id
		WHERE s.name = 'dbo' and t.name = 'power_accounting')
		begin
			print 'Table drop'
			drop table power_accounting
		end
else 
	begin
		print 'table create'
		create table power_accounting
	(
		MeasureTime smalldatetime,
		DeviceCode varchar(14),
		P float
	) 
	end