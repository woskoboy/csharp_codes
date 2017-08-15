use Power

declare @sd smalldatetime = '20170605 21:45:00';
declare @n int = 21;
declare @p float;
declare @id int=1;

while @n != 0
	begin
		while @id in (1,2,3,4,5)
			begin
				insert into power_accounting values 
				(@sd, 'E'+CAST(@id as varchar(10)), ABS(Checksum(NewID()) % 30) + 50);
				set @id += 1;	
			end;

		set @sd = DATEADD(mi,1,@sd);
		set @id = 1;
		set @n -= 1;
	end;