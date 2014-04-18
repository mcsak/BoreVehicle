<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteManagement.aspx.cs"
    Inherits="Source.SiteManagement.SiteManagement" MasterPageFile="~/InnerMaster.Master" %>

<asp:Content ID="SiteManagementHeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
    <link href="../CSS/Report.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="SiteManagementBodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div class="centertitleheader" id="HeaderTitle" runat="server">
            Site Management
        </div>
    <div class="outerContainer">
        <div class="mainContainer">
            <div class="innerContainerSiteManagementOut">
                <div class="innerContainerSiteManagement" >
                    <div class="siteManagementleft">
                        <div class="siteManagementRow">
                            <asp:Label ID="lblPointno" runat="server" Width="140px" CssClass="divreportleftcontainer" Text="Point No"></asp:Label>
                            <asp:TextBox runat="server" ID="txtpointno" Width="180px"></asp:TextBox>
                             <asp:RequiredFieldValidator runat="server" ID="Required_txtpointno" ControlToValidate="txtpointno" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                        </div>
                        <div class="siteManagementRow">
                            <asp:Label ID="drillingDepth" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Drilling Depth"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDrillingdepth" Width="180px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtDrillingdepth" ControlToValidate="txtDrillingdepth" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="Compare_txtDrillingdepth" runat="server" ControlToValidate="txtDrillingdepth"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="siteManagementRow">
                            <asp:Label ID="lblWelding" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Welding"></asp:Label>
                            <asp:TextBox runat="server" ID="txtWelding" Width="180px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtWelding" ControlToValidate="txtWelding" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                       <asp:CompareValidator ID="Compare_txtWelding" runat="server" ControlToValidate="txtWelding"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="siteManagementRow">
                            <asp:Label ID="lblCap" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Cap"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCap" Width="180px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtCap" ControlToValidate="txtCap" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                       <asp:CompareValidator ID="Compare_txtCap" runat="server" ControlToValidate="txtCap"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="siteManagementRow">
                            <asp:Label ID="lblBit" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Bit"></asp:Label>
                            <asp:TextBox runat="server" ID="txtBit" Width="180px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtBit" ControlToValidate="txtBit" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                       <asp:CompareValidator ID="Compare_txtBit" runat="server" ControlToValidate="txtBit"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="siteManagementRow">
                            <asp:Label ID="lblStartingrpm" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Starting RPM"></asp:Label>
                            <asp:TextBox runat="server" ID="txtStartingrpm" Width="180px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtStartingrpm" ControlToValidate="txtStartingrpm" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                       <asp:CompareValidator ID="Compare_txtStartingrpm" runat="server" ControlToValidate="txtStartingrpm"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                       
                    </div>
                    <div class="siteManagementright">
                        <div class="siteManagementRow">
                            <asp:Label ID="lblDrillername" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Driller Name"></asp:Label>
                            <asp:TextBox runat="server" ID="txtdrillername" Width="180px"></asp:TextBox>
                              <asp:RequiredFieldValidator runat="server" ID="Required_txtdrillername" ControlToValidate="txtdrillername" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>

                        </div>
                        <div class="siteManagementRow">
                            <asp:Label ID="lblCasingdepth" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Casing Depth"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCasingdepth" Width="180px"></asp:TextBox>
                             <asp:RequiredFieldValidator runat="server" ID="Required_txtCasingdepth" ControlToValidate="txtCasingdepth" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                       <asp:CompareValidator ID="Compare_txtCasingdepth" runat="server" ControlToValidate="txtCasingdepth"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="siteManagementRow">
                            <asp:Label ID="lblHolespipe" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Holes Pipe"></asp:Label>
                            <asp:TextBox runat="server" ID="txtHolespipe" Width="180px"></asp:TextBox>
                             <asp:RequiredFieldValidator runat="server" ID="Required_txtHolespipe" ControlToValidate="txtHolespipe" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                     <asp:CompareValidator ID="Compare_txtHolespipe" runat="server" ControlToValidate="txtHolespipe"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                         <div class="siteManagementRow">
                            <asp:Label ID="lblCollar" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Collar"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCollar" Width="180px"></asp:TextBox>
                             <asp:RequiredFieldValidator runat="server" ID="Required_txtCollar" ControlToValidate="txtCollar" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="Compare_txtCollar" runat="server" ControlToValidate="txtCollar"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="siteManagementRow">
                            <asp:Label ID="lblHammer" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Hammer"></asp:Label>
                            <asp:TextBox runat="server" ID="txtHammer" Width="180px"></asp:TextBox>
                               <asp:RequiredFieldValidator runat="server" ID="Required_txtHammer" ControlToValidate="txtHammer" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="Compare_txtHammer" runat="server" ControlToValidate="txtHammer"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="siteManagementRow">
                            <asp:Label ID="lblEndingrpm" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Ending RPM"></asp:Label>
                            <asp:TextBox runat="server" ID="txtEndinngrpm" Width="180px"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" ID="Required_txtEndinngrpm" ControlToValidate="txtEndinngrpm" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="Compare_txtEndinngrpm" runat="server" ControlToValidate="txtEndinngrpm"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        
                    </div>
                    <div >
                    <div class="siteManagementRow">
                            <asp:Label ID="lblclosedRPM" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Closing RPM"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCloseRPM" Width="180px"></asp:TextBox>
                             <asp:RequiredFieldValidator runat="server" ID="Required_txtCloseRPM" ControlToValidate="txtCloseRPM" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                       <asp:CompareValidator ID="Compare_txtCloseRPM" runat="server" ControlToValidate="txtCloseRPM"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                </div>
                <div class="divheight">
                </div>
                <div class="innerContainerSiteManagementOut" style="float: left; border: 1px solid silver; height:170px" >
                    <div class="siteManagementleft">
                        <div class="siteManagementRow">
                            <asp:Label ID="lblPartyname" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Party Name"></asp:Label>
                            <asp:TextBox runat="server" ID="txtpartyname" Width="180px"></asp:TextBox>
                             <asp:RequiredFieldValidator runat="server" ID="Required_txtpartyname" ControlToValidate="txtpartyname" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="siteManagementright">
                        <div class="siteManagementRow">
                            <asp:Label ID="lblPartyPhoneNo" runat="server" Width="140px" CssClass="divreportleftcontainer"  Text="Party Phone No."></asp:Label>
                            <asp:TextBox runat="server" ID="txtPartyPoneno" Width="180px"></asp:TextBox>
                             <asp:RequiredFieldValidator runat="server" ID="Required_txtPartyPoneno" ControlToValidate="txtPartyPoneno" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="siteManagementRowtextarea">
                        <div class="divColumnleft" style="width: 197px;">
                            <asp:Label ID="lblAddress" runat="server"  CssClass="divreportleftcontainer"  Text="Address"></asp:Label>
                        </div>
                        <div class="divColumnright">
                            <asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine" Width="350px" Height="50px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtAddress" ControlToValidate="txtAddress" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="siteManagementRowtextarea">
                        <div class="divColumnleft" style="width: 197px;">
                            <asp:Label ID="lblRemarks" runat="server"  CssClass="divreportleftcontainer"  Text="Remarks"></asp:Label>
                        </div>
                        <div class="divColumnright">
                            <asp:TextBox runat="server" ID="txtRemarks" TextMode="MultiLine" Width="350px" Height="50px"></asp:TextBox>
                               <asp:RequiredFieldValidator runat="server" ID="Required_txtRemarks" ControlToValidate="txtRemarks" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="innerContainer" style="float: left;text-align:center;">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" CausesValidation="false" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
