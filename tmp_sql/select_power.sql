use Power
declare @uid int=1;

while @uid in (1,2,3)
	begin
		select top 5 * from power_accounting
		where DeviceCode = 'E'+CAST(@uid as varchar(10)) order by MeasureTime desc;
		set @uid += 1;
	end;