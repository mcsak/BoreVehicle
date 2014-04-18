<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerPayment.aspx.cs"
    Inherits="Source.HRPayroll.ManagerPayment" MasterPageFile="~/InnerMaster.Master" %>

<asp:Content ID="ManagerPaymentHeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
    <link href="../CSS/Master.css" rel="Stylesheet" type="text/css" />
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
<asp:Content ID="ManagerPaymentBodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <asp:UpdatePanel ID="updpnlMainContentManagerPayment" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress_updpnlMainContentManagerPayment" runat="server"
                DisplayAfter="0" AssociatedUpdatePanelID="updpnlMainContentManagerPayment">
                <ProgressTemplate>
                    <div class="ProgressPageOverlay">
                        <asp:Image ID="imgloaderupdpnlMainContentManagerPayment" CssClass="ProgressImage"
                            runat="server" ImageUrl="~/Images/loader.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="centermaincontaineryle">
                <div class="centertitleheader" runat="server" id="HeaderTitle">
                    Manager Payment - Add
                </div>
                <div class="divViewAllList" runat="server" id="ViewAllDetails">
                    <asp:Button ID="btnViewAll" runat="server" Text="View All" OnClick="btnViewAll_Click"
                        CausesValidation="false" />
                </div>
                <div class="HRpayrollcentercontainer">
                    <div class="divHRpayrollsinglecontainer">
                        <div class="divHRpayrollleftcontainer">
                            Manager Name</div>
                        <div class="divHRpayrollrightcontainer">
                            <asp:TextBox ID="txtManagerName" runat="server" Width="180px" Visible="false"></asp:TextBox>
                            <asp:DropDownList ID="ddlUserName" runat="server" Width="180px" Height="20px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="Required_ddlUserName" runat="server" ControlToValidate="ddlUserName"
                                InitialValue="<--Select-->" ErrorMessage="*" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="divHRpayrollsinglecontainer">
                        <div class="divHRpayrollleftcontainer">
                            Date</div>
                        <div class="divHRpayrollrightcontainer">
                            <asp:TextBox ID="txtDate" runat="server" Width="100px"></asp:TextBox><asp:Image ID="imgDate"
                                runat="server" ImageUrl="~/Images/calendar.gif" />
                        <ajx:CalendarExtender ID="CalendarPayment" runat="server" TargetControlID="txtDate"
                            Format="dd/MM/yyyy" PopupButtonID="imgDate" CssClass="MyCalendar">
                        </ajx:CalendarExtender>
                        <asp:RequiredFieldValidator runat="server" ID="Required_txtDate" ControlToValidate="txtDate"
                            ErrorMessage="*"></asp:RequiredFieldValidator></div>
                    </div>
                    <div class="divHRpayrollsinglecontainer">
                        <div class="divHRpayrollleftcontainer">
                            Advance Amount</div>
                        <div class="divHRpayrollrightcontainer">
                            <asp:TextBox ID="txtAdvanceAmount" runat="server" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtAdvanceAmount" ControlToValidate="txtAdvanceAmount"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Compare_txtAdvanceAmount" runat="server" ControlToValidate="txtAdvanceAmount"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divHRpayrollsinglecontainer">
                        <div class="divHRpayrollleftcontainer">
                            Salary</div>
                        <div class="divHRpayrollrightcontainer">
                            <asp:TextBox ID="txtSalary" runat="server" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtSalary" ControlToValidate="txtSalary"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Compare_txtSalary" runat="server" ControlToValidate="txtSalary"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divHRpayrollsinglecontainer" style="width: 500px;">
                        <div class="divHRpayrollleftcontainer">
                            Remarks</div>
                        <div class="divHRpayrollrightcontainer">
                            <asp:TextBox ID="txtRemarks" runat="server" Width="280px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtRemarks" ControlToValidate="txtRemarks"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="divHRpayrollsinglecontainer" style="width: 500px;">
                        <div class="divHRpayrollleftcontainer">
                            &nbsp;</div>
                        <div class="divHRpayrollrightcontainer" style="width: 300px;">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;<asp:Button
                                ID="btnBack" runat="server" Text="Cancel" OnClick="btnBack_Click" CausesValidation="false" />&nbsp;<asp:Button
                                    ID="btnCloseAccount" runat="server" Text="Close Account" OnClick="btnCloseAccount_Click"
                                    CausesValidation="false" />
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
                    Manager Payment Details
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
                                OnClick="BtnGo_Click"  CausesValidation="false"/>
                            <div style="float: right; text-align: right; color: Red;">
                                Select any one date of your month.</div>
                        </div>
                        <hr style="margin: 0 0 0 0;" />
                        <div style="height: 10px">
                        </div>
                    </div>
                    <div>
                        <asp:GridView ID="gvManagerDetails" runat="server" SkinID="PopupViewAllGrid" Width="100%"
                            PagerStyle-Height="30px">
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblno" SkinID="gridlbl" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date of Payment" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMPayment" runat="server" Text='<%#Eval("DateofPayment") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Advance Amount" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Salary" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalary" runat="server" Text='<%#Eval("Salary") %>'></asp:Label>
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
