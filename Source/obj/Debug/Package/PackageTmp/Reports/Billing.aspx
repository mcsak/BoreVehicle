<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="Source.Report.Billing" MasterPageFile="~/InnerMaster.Master" %>



<asp:Content ID="RepMonthlyHeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
    <link href="../CSS/Report.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="RepMonthlyBodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div class="centermaincontaineryle">
        <div class="centertitleheader">
            Billing
        </div>
        <div class="reportcentercontainer">
            <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    Point No.</div>
                <div class="divreportrightcontainer">
                    <asp:DropDownList ID="ddlPointNumber" runat="server" Width="137px" Height="25px">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    Drilling Depth Rate</div>
                <div class="divreportrightcontainer">
                   <asp:TextBox ID="txtDrillingDepthRate" runat="server" Width="180px"></asp:TextBox>
                </div>
            </div>

             <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    Casing Depth Rate</div>
                <div class="divreportrightcontainer">
                   <asp:TextBox ID="txtCasingDepthRate" runat="server" Width="180px"></asp:TextBox>
                </div>
            </div>

             <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    Welding Rate</div>
                <div class="divreportrightcontainer">
                   <asp:TextBox ID="txtWeldingRate" runat="server" Width="180px"></asp:TextBox>
                </div>
            </div>

             <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    Hole Pipe Rate</div>
                <div class="divreportrightcontainer">
                   <asp:TextBox ID="txtHolePipeRate" runat="server" Width="180px"></asp:TextBox>
                </div>
            </div>

             <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    Grand Total</div>
                <div class="divreportrightcontainer">
                   <asp:TextBox ID="txtGrandTotal" runat="server" Width="180px"></asp:TextBox>
                </div>
            </div>

             <div class="divreportsinglecontainer">
                <div class="divreportleftcontainer">
                    Amount Paid</div>
                <div class="divreportrightcontainer">
                   <asp:TextBox ID="txtAmountPaid" runat="server" Width="180px"></asp:TextBox>
                </div>
            </div>

         

        </div>
         <div class="innerContainer" style="margin:0 auto;height:160px;border: 1px solid silver;">
                    <div class="siteManagementleft">
                        <div class="siteManagementRow">
                            <asp:Label ID="lblPartyname" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Party Name"></asp:Label>
                            <asp:TextBox runat="server" ID="txtpartyname"></asp:TextBox>
                        </div>
                    </div>
                    <div class="siteManagementright">
                        <div class="siteManagementRow">
                            <asp:Label ID="lblPartyNo" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Party No"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPartyno"></asp:TextBox>
                        </div>
                    </div>
                    <div class="siteManagementRowtextarea">
                        <div class="divColumnleft" style="width: 197px;">
                            <asp:Label ID="lblAddress" runat="server"  CssClass="divreportleftcontainer"  Text="Address"></asp:Label>
                        </div>
                        <div class="divColumnright">
                            <asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine" Width="350px" Height="50px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="siteManagementRowtextarea">
                        <div class="divColumnleft" style="width: 197px;">
                            <asp:Label ID="lblReasons" runat="server"  CssClass="divreportleftcontainer"  Text="Reasons"></asp:Label>
                        </div>
                        <div class="divColumnright">
                            <asp:TextBox runat="server" ID="txtReason" TextMode="MultiLine" Width="350px" Height="50px"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="innerContainer" style="float: left;width:100%;text-align:center;">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </div>
    </div>
</asp:Content>
