<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportMonthlyStatus.aspx.cs" Inherits="Source.Report.ReportMonthly" MasterPageFile="~/InnerMaster.Master" %>

<asp:Content ID="RepMonthlyHeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
    <link href="../CSS/Report.css" rel="Stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="RepMonthlyBodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div class="centermaincontaineryle">
        <div class="centertitleheader">
            Monthly Status Report
        </div>

        <div id="divRbtns" class="divrbtnMonthStatus" >
        <div class="divrbtnMonthStatuscontainer">
            <asp:RadioButton ID="rbtnDieselCalc" Text="Diesel Calculation" runat="server" 
                oncheckedchanged="rbtnDieselCalc_CheckedChanged" /><asp:RadioButton
            ID="rbtnMonthStatus" Text="Month Status" runat="server" 
                oncheckedchanged="rbtnMonthStatus_CheckedChanged" /><asp:RadioButton
            ID="rbtnServiceIntimation" Text="Service Intimation" runat="server" 
                oncheckedchanged="rbtnServiceIntimation_CheckedChanged" />
        </div>
        </div>
        <div class="reportcentercontainer">
        <asp:Panel ID="pnldieselCalculation" runat="server" >
        <asp:GridView ID="GVMonthlyStatus" runat="server" AllowPaging="true" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="#" DataField="" />
            <asp:BoundField HeaderText="Mon/Year" DataField="" />
            <asp:BoundField HeaderText="Vehicle Name" DataField="" />
            <asp:BoundField HeaderText="Diesel Avg." DataField="" />
            <asp:BoundField HeaderText="Drilling Avg." DataField="" />
            <asp:BoundField HeaderText="Responsible" DataField="" />
        </Columns>
        </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="pnlMonthStatus" runat="server" >
        
        </asp:Panel>
        <asp:Panel ID="pnlServiceIntimation" runat="server" >
        
        </asp:Panel>
           <%-- <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    Total No.of Length</div>
                <div class="divreportrightcontainer">
                    <asp:TextBox ID="txtTotallength" runat="server" Width="100px"></asp:TextBox>&nbsp;
                    litres</div>
            </div>
            <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                 For Casing Outward</div>
                <div class="divreportrightcontainer">
                    <asp:TextBox ID="txtCasingOutward" runat="server" Width="100px"></asp:TextBox></div>
            </div>--%>
           <%-- <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    &nbsp;</div>
                <div class="divreportrightcontainer">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" />&nbsp;<asp:Button ID="btnCancel"
                        runat="server" Text="Cancel" />
                </div>
            </div>--%>
        </div>
    </div>
</asp:Content>
