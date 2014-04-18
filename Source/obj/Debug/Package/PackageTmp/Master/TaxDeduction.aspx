<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaxDeduction.aspx.cs" MasterPageFile="~/InnerMaster.Master" Inherits="Source.Master.TaxDeduction" %>

<asp:Content ID="LabourHeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
    <link href="../CSS/Master.css" rel="Stylesheet" type="text/css" />
        <script language="javascript" type="text/javascript" src="../Scripts/jquery-1.5.1.min.js"></script>
        </asp:Content>
<asp:Content ID="LabourBodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
<asp:UpdatePanel ID="updpnlMainContentTax" runat="server" UpdateMode="Conditional">
<ContentTemplate>
 <asp:UpdateProgress ID="UpdateProgress_updpnlMainContentTax" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="updpnlMainContentTax">
<ProgressTemplate> 
<div class="ProgressPageOverlay">
<asp:Image ID="imgloaderupdpnlMainContentTax" CssClass="ProgressImage" runat="server" ImageUrl="~/Images/loader.gif" />
</div>
</ProgressTemplate>
</asp:UpdateProgress>
   <div class="centermaincontaineryle" >
        <div class="centertitleheader" runat="server" id="HeaderTitle">
            Tax Deduction
        </div>
        
        <div class="mastercentercontainer">
        <div class="divmastersinglecontainer">
                <div class="divmasterleftcontainer">
                   Tax Deduction</div>
                <div class="divmasterrightcontainer">
                    <asp:TextBox ID="txttaxDeduction" runat="server" Width="180px"></asp:TextBox>
                      <asp:RequiredFieldValidator runat="server" ID="Required_txttaxDeduction" ControlToValidate="txttaxDeduction" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                    </div>
            </div>
         
            <div class="divmastersinglecontainer">
                <div class="divmasterleftcontainer">
                    &nbsp;</div>
                <div class="divmasterrightcontainer">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click"  />&nbsp;<asp:Button ID="btnBack"
                        runat="server" Text="Cancel" onclick="btnBack_Click" CausesValidation="false" />
                     
                </div>
            </div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
