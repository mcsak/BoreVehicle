<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DummyBanner.ascx.cs" Inherits="Source.UC.DummyBanner" %>
<link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
<link href="../CSS/Master.css" rel="Stylesheet" type="text/css" />
<div class="bannercontainer">
    <div class="bannerinnercontainer">
        <div class="bannerlogocontainer">
            <asp:ImageButton ID="imgLogo" runat="Server" ImageUrl="~/Images/BoreEsteem-Logo.png" />
        </div>
       <%-- <div style="float:left;width:450px; padding-top:10px;" ><asp:Label ID="lblVehicleSelection" runat="server" Text="Vehicle Number" /> 
            <asp:DropDownList ID="ddlVehicleNumber" runat="server"  
                CssClass="ddlvehicleMaster" AutoPostBack="true"
                onselectedindexchanged="ddlVehicleNumber_SelectedIndexChanged" ></asp:DropDownList><asp:TextBox
                runat="server" ID="txtVehicleNumberMaster" ></asp:TextBox>
                 </div>--%>
        <div class="bannerrightcontainer" style="height: 70px;">
            <div class="bannerhomemenucontainer" style="margin-top: 0px; height: 80px;">
                <div class="bannerhomeimg">
                    <asp:ImageButton ID="imgBannerUser" CssClass="bannerUserImage" runat="server" ImageUrl="~/Images/defaultphoto.gif"  />
                </div>
                <div class="bannerhometxt" id="bannerusername" runat="server" style="text-align: right;">
                    <span style="float: left; width: 93%; text-align: right;" id="SpnUsername" runat="server">User</span>
                </div>
                <div style="float: left; text-align: right; width: 100%;">
                    <asp:LinkButton ID="lnkLogout" CssClass="BannerLogout" runat="server" Text="Logout" SkinID="lnkBanner" PostBackUrl="~/Default.aspx"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <div class="Menus" id="MenuContainer" >
        <div id="Menu" >
            
        </div>
    </div>
</div>
