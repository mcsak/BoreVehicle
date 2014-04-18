
/* this is for login details matching*/

create proc GetLogin
@UserName varchar(50),
@Password varchar(100)
as
begin
	
	if exists(select UserID,UserType,VehicleID from Users where Active=1 and UserName=@UserName and Password=@Password)
	begin
		select 'Success' As Result,UserID,UserType,VehicleID from Users where Active=1 and UserName=@UserName and Password=@Password
		update Users set LastLoginDateTime=GETDATE() where UserName=@UserName and Active=1
	end
	else
	Select 'NotExists' As Result

end