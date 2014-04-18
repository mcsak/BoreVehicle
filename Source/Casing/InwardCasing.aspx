<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InwardCasing.aspx.cs" Inherits="Source.Casing.InwardCasing"
    MasterPageFile="~/InnerMaster.Master" %>

<asp:Content ID="InwardHeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
    <link href="../CSS/Report.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../Scripts/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" language="javascript">
        function showdetail() {
            $('.divPopupBackground').css({ 'height': (document.documentElement.scrollHeight | document.body.scrollHeight) + 150 + 'px', 'display': 'block' });
            $('.showviewallDetailpopup').css({
                'top': (document.documentElement.scrollTop | document.body.scrollTop) + 80,
                'left': 330,
                'z-Index': 999,
                'display': 'block'
            });
            return false;
        }

        function closepopup() {
            $('.showviewallDetailpopup').css({ 'display': 'none' });
            $('.divPopupBackground').css({ 'display': 'none' });
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="InwardBodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <asp:UpdatePanel ID="updpnlMainContentCasingInward" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress_updpnlMainContentCasingInward" runat="server"
                DisplayAfter="0" AssociatedUpdatePanelID="updpnlMainContentCasingInward">
                <ProgressTemplate>
                    <div class="ProgressPageOverlay">
                        <asp:Image ID="imgloaderupdpnlMainContentCasingInward" CssClass="ProgressImage" runat="server"
                            ImageUrl="~/Images/loader.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="centermaincontaineryle">
                <div class="centertitleheader" id="HeaderTitle" runat="server">
                    Casing Inward
                </div>
                <div class="divViewAllList" runat="server" id="ViewAllDetails">
                    <asp:Button ID="btnViewAll" runat="server" Text="View All" OnClick="btnViewAll_Click"
                        CausesValidation="false" />
                </div>
                <div class="reportcentercontainer">
                    <div class="divreportsinglecontainer">
                        <div class="divreportleftcontainer">
                            Date</div>
                        <div class="divreportrightcontainer">
                            <asp:TextBox runat="server" ID="txtDate"></asp:TextBox><asp:Image ID="imgDate" runat="server"
                                ImageUrl="~/Images/calendar.gif" />
                            <ajx:CalendarExtender ID="CalendarPayment" runat="server" TargetControlID="txtDate"
                                Format="dd/MM/yyyy" PopupButtonID="imgDate" CssClass="MyCalendar">
                            </ajx:CalendarExtender>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtDate" ControlToValidate="txtDate"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="divreportsinglecontainer">
                        <div class="divreportleftcontainer">
                            Quantity</div>
                        <div class="divreportrightcontainer">
                            <asp:TextBox runat="server" ID="txtQuantity"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtQuantity" ControlToValidate="txtQuantity"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                  <asp:CompareValidator ID="Compare_txtQuantity" runat="server" ControlToValidate="txtQuantity"
                                SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divreportsinglecontainer">
                        <div class="divreportleftcontainer">
                            Bill No</div>
                        <div class="divreportrightcontainer">
                            <asp:TextBox runat="server" ID="txtBillNo"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtBillNo" ControlToValidate="txtBillNo"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                   <asp:CompareValidator ID="Compare_txtBillNo" runat="server" ControlToValidate="txtBillNo"
                                SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divreportsinglecontainer">
                        <div class="divreportleftcontainer">
                            Billed Amount</div>
                        <div class="divreportrightcontainer">
                            <asp:TextBox runat="server" ID="txtBillAmount"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtBillAmount" ControlToValidate="txtBillAmount"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="Compare_txtBillAmount" runat="server" ControlToValidate="txtBillAmount"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divreportsinglecontainer">
                        <div class="divreportleftcontainer">
                            Party Vehicle No</div>
                        <div class="divreportrightcontainer">
                            <asp:TextBox runat="server" ID="txtVehicleNo"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtVehicleNo" ControlToValidate="txtVehicleNo"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            
                        </div>
                    </div>
                    <div class="divreportsinglecontainer">
                        <div class="divreportleftcontainer">
                            Vendor Name</div>
                        <div class="divreportrightcontainer">
                            <asp:DropDownList runat="server" ID="ddlVendorname" Width="137px" Height="25px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="Required_ddlVendorname" runat="server" ControlToValidate="ddlVendorname"
                                InitialValue="<--Select-->" ErrorMessage="*" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="divreportsinglecontainer">
                        <div class="divreportleftcontainer">
                            Remarks</div>
                        <div class="divreportrightcontainer">
                            <asp:TextBox runat="server" ID="txtRemarks" TextMode="MultiLine" Width="260px" Height="50px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtRemarks" ControlToValidate="txtRemarks"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="divreportsinglecontainer">
                        <div class="divreportleftcontainer">
                            &nbsp;</div>
                        <div class="divreportrightcontainer">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;<asp:Button
                                ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="updpnlPopup" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress_updpnlPopup" runat="server" DisplayAfter="0"
                AssociatedUpdatePanelID="updpnlPopup">
                <ProgressTemplate>
                    <div class="ProgressPageOverlay">
                        <asp:Image ID="imgloaderupdpnlPopup" CssClass="ProgressImage" runat="server" ImageUrl="~/Images/loader.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="showviewallDetailpopup">
                <div class="reportclose">
                    <img class="divClose" id="Img1" runat="server" src="~/Images/CloseIcon16.png" alt=""
                        onclick="return closepopup()" />
                </div>
                <div class="viewallpopupheader">
                    Casing Inward Detail
                </div>
                <div class="viewallinnercontainerpopup">
                    <div id="divDateAndView">
                        <hr style="margin: 0 0 0 0;" />
                        <div>
                            <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                            <asp:Image ID="imgFromDate" runat="server" ImageUrl="~/Images/calendar.gif" />
                            <ajx:CalendarExtender ID="CalendarExtenderFrom" runat="server" TargetControlID="txtFromDate"
                                CssClass="MyCalendarPopup" PopupButtonID="imgFromDate" Format="MM-yyyy" OnClientShown="onCalendarShown">
                            </ajx:CalendarExtender>
                            &nbsp;&nbsp;<asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                            <asp:Image ID="imgToDate" runat="server" ImageUrl="~/Images/calendar.gif" />
                            <ajx:CalendarExtender ID="CalendarExtenderTo" runat="server" TargetControlID="txtToDate"
                                CssClass="MyCalendarPopup" PopupButtonID="imgToDate" Format="MM-yyyy" OnClientShown="onCalendarShown">
                            </ajx:CalendarExtender>
                            &nbsp;<asp:Button ID="btnGo" runat="server" Text="Go" CssClass="btnCommonGOstyle"
                                OnClick="BtnGo_Click" CausesValidation="false" />
                            <div style="float: right; text-align: right; color: Red;">
                                Select any one date of your month.</div>
                        </div>
                        <hr style="margin: 0 0 0 0;" />
                        <div style="height: 10px">
                        </div>
                    </div>
                    <div>
                        <asp:GridView ID="gvCasingInwardDetails" runat="server" SkinID="PopupViewAllGrid"
                            Width="100%" PagerStyle-Height="30px">
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblno" SkinID="gridlbl" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Casing Date" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVCasingDate" runat="server" Text='<%#Eval("CasingDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVCasingQuantity" runat="server" Text='<%#Eval("CasingQuantity") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Billed Amount" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVBilledAmount" runat="server" Text='<%#Eval("BilledAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vendor Name" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVVendorName" runat="server" Text='<%#Eval("VendorName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
