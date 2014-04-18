<%@ Page Title="Profile" Language="C#" AutoEventWireup="true" CodeBehind="~/General/Profile.aspx.cs"
    Inherits="Source.General.Profile" MasterPageFile="~/InnerMaster.Master" %>

<asp:Content ID="ContentHeader" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
</asp:Content>
<asp:Content ID="ContentBody" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div class="centermaincontaineryle">
        <div class="centertitleheader">
            Profile
        </div>
        <div class="profilecentercontainer">
            <div class="divprofsinglecontainer">
                <div class="divprofleftcontainer">
                    First Name</div>
                <div class="divprofrightcontainer">
                    <asp:TextBox ID="txtFname" runat="server" Width="180px"></asp:TextBox>
                </div>
            </div>
            <div class="divprofsinglecontainer">
                <div class="divprofleftcontainer">
                    Last Name</div>
                <div class="divprofrightcontainer">
                    <asp:TextBox ID="txtLname" runat="server" Width="180px"></asp:TextBox>
                </div>
            </div>
            <div class="divprofsinglecontainer">
                <div class="divprofleftcontainer">
                    Contact Number</div>
                <div class="divprofrightcontainer">
                    <asp:TextBox ID="txtContact" runat="server" Width="180px"></asp:TextBox>
                </div>
            </div>
            <div class="divprofsinglecontainer">
                <div class="divprofleftcontainer">
                    Email ID</div>
                <div class="divprofrightcontainer">
                    <asp:TextBox ID="txtEmail" runat="server" Width="180px"></asp:TextBox>
                </div>
            </div>
            <div class="divprofsinglecontainer">
                <div class="divprofleftcontainer">
                    Vehicle No.</div>
                <div class="divprofrightcontainer">
                    <asp:TextBox ID="txtVehickeNumber" runat="server" Width="180px"></asp:TextBox>
                </div>
            </div>
            <div class="divprofsinglecontainer" style="font-weight: bold; padding-left: 50px;
                width: 330px;">
                <asp:CheckBox ID="chkChangePwd" runat="server" />&nbsp;
                <asp:Label ID="lblChangePwd" runat="server" Text="Change Password"></asp:Label>
            </div>
            <div class="divprofsinglecontainer">
                <div class="divprofleftcontainer">
                    Current Password</div>
                <div class="divprofrightcontainer">
                    <asp:TextBox ID="txtCurrentPwd" runat="server" Width="180px"></asp:TextBox>
                </div>
            </div>
            <div class="divprofsinglecontainer">
                <div class="divprofleftcontainer">
                    New Password</div>
                <div class="divprofrightcontainer">
                    <asp:TextBox ID="txtNewPwd" runat="server" Width="180px"></asp:TextBox>
                </div>
            </div>
            <div class="divprofsinglecontainer">
                <div class="divprofleftcontainer">
                    Confirm Password</div>
                <div class="divprofrightcontainer">
                    <asp:TextBox ID="txtConfirmPwd" runat="server" Width="180px"></asp:TextBox>
                </div>
            </div>
            <div class="divprofsinglecontainer">
                <div class="divprofleftcontainer">
                    &nbsp;</div>
                <div class="divprofrightcontainer">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" />&nbsp;<asp:Button ID="btnCancel"
                        runat="server" Text="Cancel" /></div>
            </div>
        </div>
    </div>
</asp:Content>
