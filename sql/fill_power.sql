use Power

declare @sd smalldatetime = '20170605 17:45:00';
declare @n int = 21;
declare @p float;
declare @id int;

while @n != 0
	begin
		set @sd = DATEADD(mi,1,@sd);
		set @n -= 1;

		set @id = 1;
		while @id in (1,2,3,4,5)
			begin
				insert into power_accounting values (@sd, @id,ABS(Checksum(NewID()) % 30) + 50);
				set @id += 1;	
			end;
	end;