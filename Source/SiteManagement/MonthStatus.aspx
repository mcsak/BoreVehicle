<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.Master" AutoEventWireup="true"
    CodeBehind="MonthStatus.aspx.cs" Inherits="Source.SiteManagement.MonthStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <link href="../CSS/Report.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="centermaincontaineryle">
        <div class="centertitleheader">
            Monthly Status of Current Month.
        </div>
        <div id="DivStatusMessge" runat="server" class="centertitleheader">
            <asp:Label ID="lblPageStatusMessage" runat="server"></asp:Label>
        </div>
        <div class="reportcentercontainer">
            <div class="SiteManageMScentercontainer">

             <div class="divSiteManageMSsinglecontainer">
                <div class="divSiteManageMSleftcontainer">
                    Vehicle Name</div>
                <div class="divSiteManageMSrightcontainer">
                   <asp:Label ID="lblVehicleNameVal" runat="server" Font-Size="14px"></asp:Label></div>
            </div> 

             <div class="divSiteManageMSsinglecontainer">
                <div class="divSiteManageMSleftcontainer">
                   Remaining Diesel in ltrs.</div>
                <div class="divSiteManageMSrightcontainer">
                   <asp:TextBox ID="txtRemainingDiesel" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator runat="server" ID="Required_txtRemainingDiesel" ControlToValidate="txtRemainingDiesel" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                   </div>
            </div>               

                <div class="divSiteManageMSsinglecontainer">
                <div class="divSiteManageMSleftcontainer">
                    Remarks</div>
                <div class="divSiteManageMSrightcontainer">
                    <asp:TextBox ID="txtRemarks" runat="server" Width="250px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                      <asp:RequiredFieldValidator runat="server" ID="Required_txtRemarks" ControlToValidate="txtRemarks" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                    </div>
            </div> 
                <%--<br />
                <br />
                <hr />--%>

                <div class="divSiteManageMSsinglecontainer">
                <div class="divSiteManageMSleftcontainer">
                   &nbsp;</div>
                <div class="divSiteManageMSrightcontainer">
                  <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;<asp:Button 
                        ID="btnback" runat="server" Text="Back" onclick="btnback_Click" CausesValidation="false" /></div>
            </div>
                
            </div>
        </div>
    </div>
</asp:Content>
