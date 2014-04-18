

Select * from VehicleMaster

set identity_insert VehicleMaster on

insert into VehicleMaster(VehicleID,VehicleNumber,Name,Others,Active)
values(-1,'000-1','Multiple','Multiple vehicles are mapped',0)

insert into VehicleMaster(VehicleID,VehicleNumber,Name,Others,Active)
values(0,'0000','All','All vehicles are mapped',0)



set identity_insert VehicleMaster Off






