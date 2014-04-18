<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/Expenses/OtherExpenses.aspx.cs"
    MasterPageFile="~/InnerMaster.Master" Inherits="Source.Expenses.OtherExpenses" %>

<asp:Content ID="OtherExpensesHeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
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
<asp:Content ID="OtherExpenseBodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <asp:UpdatePanel ID="updpnlMainContentExpenses" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress_updpnlMainContentExpenses" runat="server"
                DisplayAfter="0" AssociatedUpdatePanelID="updpnlMainContentExpenses">
                <ProgressTemplate>
                    <div class="ProgressPageOverlay">
                        <asp:Image ID="imgloaderupdpnlMainContentExpenses" CssClass="ProgressImage" runat="server"
                            ImageUrl="~/Images/loader.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="centermaincontaineryle">
                <div class="centertitleheader" runat="server" id="HeaderTitle">
                    Other Expenses - Add
                </div>
                <div class="divViewAllList" runat="server" id="ViewAllDetails">
                    <asp:Button ID="btnViewOtherExpenses" runat="server" Text="View All" OnClick="btnViewOtherExpenses_Click" CausesValidation="false" />
                </div>
                <div class="mastercentercontainer">
                    <div class="divmastersinglecontainer">
                        <div class="divmasterleftcontainer">
                            Date</div>
                        <div class="divmasterrightcontainer">
                            <asp:TextBox ID="txtDate" runat="server" Width="80px"></asp:TextBox><asp:Image ID="imgDate"
                                runat="server" ImageUrl="~/Images/calendar.gif" />
                            <ajx:CalendarExtender ID="CalendarPayment" runat="server" TargetControlID="txtDate"
                                Format="dd/MM/yyyy" PopupButtonID="imgDate" CssClass="MyCalendar">
                            </ajx:CalendarExtender>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtDate" ControlToValidate="txtDate"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="divmastersinglecontainer">
                        <div class="divmasterleftcontainer">
                            Particulars</div>
                        <div class="divmasterrightcontainer">
                            <asp:TextBox ID="txtParticulars" runat="server" Width="180px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtParticulars" ControlToValidate="txtParticulars"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="divmastersinglecontainer">
                        <div class="divmasterleftcontainer">
                            Amount</div>
                        <div class="divmasterrightcontainer">
                            <asp:TextBox ID="txtAmount" runat="server" Width="180px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtAmount" ControlToValidate="txtAmount"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Compare_txtAmount" runat="server" ControlToValidate="txtAmount"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divmastersinglecontainer">
                        <div class="divmasterleftcontainer">
                            &nbsp;</div>
                        <div class="divmasterrightcontainer">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                               />&nbsp;<asp:Button ID="btnBack" runat="server" Text="Cancel"
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
                    Other Expenses Detail
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
                        <asp:GridView ID="gvOtherExpenseDetails" runat="server" SkinID="PopupViewAllGrid"
                            Width="100%" PagerStyle-Height="30px">
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblno" SkinID="gridlbl" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Expense Date" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblExpenseDate" runat="server" Text='<%#Eval("ExpenseDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Particulars" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblParticulars" runat="server" Text='<%#Eval("Particulars") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
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
