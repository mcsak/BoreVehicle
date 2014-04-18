<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleSelection.aspx.cs" Inherits="Source.VehicleSelection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Vehicle Selection</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="maincontainer">
        <div class="maininnercontainer">
            <div class="bannermaincontainer">
                
                <UC:DummyBanner ID="DummyBanner" runat="server"/>
            </div>
            <div class="mainbodycontainer" style="padding: 1px 38px 10px 75px;">
            <div style="height:200px;">
    <div style="float:left;width:450px; padding-top:10px;" ><asp:Label ID="lblVehicleSelection" runat="server" Text="Vehicle Number" /> 
            <asp:DropDownList ID="ddlVehicleNumberSelection" runat="server"  
                CssClass="ddlvehicleMaster" AutoPostBack="true"
                onselectedindexchanged="ddlVehicleNumberSelection_SelectedIndexChanged" ></asp:DropDownList>
                 </div>
                 </div>
                 </div>
    </div>
    </div>
    </form>
</body>
</html>



                 
