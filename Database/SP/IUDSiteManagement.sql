
ALTER proc IUDSiteManagement
@LeadID bigint,
@PointNo varchar(25),
@DrillerName varchar(200),
@DrillingDepth numeric(18,2),
@CasingDepth numeric(18,2),
@Welding numeric(18,2),
@Cap Numeric(18,2),
@HolesPipe int,
@StartingRPM numeric(18,2),
@EndingRPM numeric(18,2),
@PartyName varchar(200),
@PartyPhoneNumber varchar(250),
@PartyAddress varchar(500),
@Remarks varchar(500),
@VehicleID int,
@UserID int,
@Action tinyint
as
begin

if(@Action=1)
	begin
		Declare @_PointNumber varchar(25)=''
		set @_PointNumber=CONVERT(varchar,DATEPART(MM,Getdate()))+RIGHT(CONVERT(varchar,DATEPART(YY,Getdate())),2)+'-'+
		RIGHT('0000'+CONVERT(varchar,ISNULL((select COUNT(*) from SiteMangementLeads where DATEPART(MM, CreatedDate)=DATEPART(MM,Getdate())),0)+1),6)
		
		insert into SiteMangementLeads(PointNumber,DrillingDepth,CasingDepth,welding,cap,Holespipe,StartingRPM,EndingRPM,DrillerName,
										PartyName,PartyPhoneNumber,PartyAddress,Remarks,VehicleID,CreatedBy)
			values(@_PointNumber,@DrillingDepth,@CasingDepth,@Welding,@Cap,@HolesPipe,@StartingRPM,@EndingRPM,@DrillerName,@PartyName,@PartyPhoneNumber,
					@PartyAddress,@Remarks,@VehicleID,@UserID)
	Select 'S' as Result
	end
else if(@Action=2)
	begin
		update SiteMangementLeads set DrillingDepth=@DrillingDepth,CasingDepth=@CasingDepth,welding=@Welding,cap=@Cap,Holespipe=@HolesPipe,
		StartingRPM=@StartingRPM,EndingRPM=@EndingRPM,DrillerName=@DrillerName,PartyName=@PartyName,PartyPhoneNumber=@PartyPhoneNumber,
		PartyAddress=@PartyAddress,Remarks=@Remarks,ModifiedBy=@UserID,ModifiedDate=GETDATE()
		where LeadID=@LeadID

		Select 'U' as Result
	end
else if(@Action=3)
	begin
		update SiteMangementLeads set Active=0 where LeadID=@LeadID

		Select 'D' as Result
	end
else
	begin
		Select 'NA' as Result
	end
end

