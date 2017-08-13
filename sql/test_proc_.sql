alter proc TestProc
	@input int=0,
	@out int output
as
	begin
		set @out = @input*2
		/*return @input*2*/
	end;
go

declare @result int;

/*exec @result = TestProc 15 */
exec TestProc 15, @result output 
print @result;
