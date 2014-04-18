
create proc GetSiteMangementLeads
@UserID int,
@VehicleID int,
@SearchFlag tinyint=0,
@SearchText varchar(100)=''
as
begin
	Declare @_UserRole Varchar(25)=(Select UserType from Users Where UserID=@UserID and Active=1)

			
	Select SML.PointNumber,SML.DrillingDepth,SML.CasingDepth,SML.welding,SML.cap,SML.Holespipe,SML.StartingRPM,SML.EndingRPM,SML.DrillerName,BillingStatus
		from SiteMangementLeads SML where SML.Active=1
		and case @SearchFlag when 0 then 1 
			when 1 then case when SML.PointNumber like '%'+@SearchText+'%' then 1 else 0 end
			when 2 then case when Dbo.DateToInteger(SML.CreatedDate)=dbo.DateToInteger(CONVERT(datetime,@SearchText)) then 1 else 0 end
			When 3 then case when BillingStatus like '%'+@SearchText+'%' then 1 else 0 end
			--When -1 then case when LeadID=CONVERT(bigint,@SearchText) then 1 else 0 end -- this case for view/modify select option
			else 0 
			end=1
		and case @_UserRole when 'Admin' then 1 when 'SuperAdmin' then 1 
				else  case when Dbo.DateToInteger(SML.CreatedDate)= Dbo.DateToInteger(GETDATE()) then 1 else 0 end 
			end=1
	
end