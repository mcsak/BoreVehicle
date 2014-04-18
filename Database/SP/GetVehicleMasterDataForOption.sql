
/*This proc will return available vehicle ID and VehicleNumber for User selectale dropdown*/
create proc GetVehicleMasterDataForOption
@UserID int
as
begin
	
	Select VehicleID,VehicleNumber from VehicleMaster
	where Active=1
	--and case when (Select VehicleID from Users where UserID=@UserID)
	Select VehicleID,UserType from Users where Active=1 and UserID=@UserID
	
end

