<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/Report/DieselCalculation.aspx.cs"
    Inherits="Source.Report.DieselCalculation" MasterPageFile="~/InnerMaster.Master" %>

<asp:Content ID="RepDeiselCalHeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
    <link href="../CSS/Report.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="RepDeiselCalBodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div class="centermaincontaineryle">
        <div class="centertitleheader">
            Report Diesel Calculation
        </div>
        <div class="reportcentercontainer">
            <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    Total No.of Diesel</div>
                <div class="divreportrightcontainer">
                    <asp:TextBox ID="txtDieselltr" runat="server" Width="100px"></asp:TextBox>&nbsp;
                    litres</div>
            </div>
            <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    Total Drilling Depth</div>
                <div class="divreportrightcontainer">
                    <asp:TextBox ID="txttotaldrilldept" runat="server" Width="100px"></asp:TextBox>&nbsp;&nbsp;feet</div>
            </div>
            <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    Diesel Average</div>
                <div class="divreportrightcontainer">
                    <asp:TextBox ID="txtDieselAvg" runat="server" Width="100px"></asp:TextBox></div>
            </div>
            <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    Total Depth</div>
                <div class="divreportrightcontainer">
                    <asp:TextBox ID="txtTotalDepth" runat="server" Width="100px"></asp:TextBox></div>
            </div>
            <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    Total RPM</div>
                <div class="divreportrightcontainer">
                    <asp:TextBox ID="txtTotalRPM" runat="server" Width="100px"></asp:TextBox></div>
            </div>
            <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    Drilling Average</div>
                <div class="divreportrightcontainer">
                    <asp:TextBox ID="txtDrillingAvg" runat="server" Width="100px"></asp:TextBox></div>
            </div>
            <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    &nbsp;</div>
                <div class="divreportrightcontainer">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                        onclick="btnSubmit_Click" />&nbsp;<asp:Button ID="btnCancel"
                        runat="server" Text="Cancel" onclick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
