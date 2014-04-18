<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DieselExpenses.aspx.cs"
    Inherits="Source.Expenses.DieselExpenses" MasterPageFile="~/InnerMaster.Master" %>

<asp:Content ID="DieselExpenseHeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
    <link href="CSS/Master.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery-1.5.1.min.js"></script>
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
<asp:Content ID="DieselExpenseBodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <asp:HiddenField runat="server" ID="hdnEndingRPM" />
    <asp:UpdatePanel ID="updpnlMainContentDieselExpenses" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress_updpnlMainContentDieselExpenses" runat="server"
                DisplayAfter="0" AssociatedUpdatePanelID="updpnlMainContentDieselExpenses">
                <ProgressTemplate>
                    <div class="ProgressPageOverlay">
                        <asp:Image ID="imgloaderupdpnlMainContentDieselExpenses" CssClass="ProgressImage"
                            runat="server" ImageUrl="~/Images/loader.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="centermaincontaineryle">
                <div class="centertitleheader" runat="server" id="HeaderTitle">
                    Diesel Expenses - Add
                </div>
                <div class="divViewAllList" runat="server" id="ViewAllDetails">
                    <asp:Button ID="btnViewAll" runat="server" Text="View All" OnClick="btnViewAll_Click"
                        CausesValidation="false" />
                </div>
                <div class="diselexpensesrightcontainer">
                    <div class="divExpensessinglecontainer">
                        <div class="dieselExpensesleftcontainer">
                            Feet</div>
                        <div class="dieselExpensesleftcontainer">
                            <asp:Label ID="lblfeet" runat="server" Text="" Width="100px"></asp:Label>
                        </div>
                    </div>
                    <div class="divExpensessinglecontainer">
                        <div class="dieselExpensesleftcontainer">
                            Diesel Avg</div>
                        <div class="dieselExpensesleftcontainer">
                            <asp:Label ID="lbldieselavg" runat="server" Text="" Width="100px"></asp:Label></div>
                    </div>
                </div>
                <div class="Expensescentercontainer">
                    <div class="divExpensessinglecontainer">
                        <div class="divExpensesleftcontainer">
                            Vehicle No.</div>
                        <div class="divExpensesrightcontainer">
                            <asp:TextBox ID="txtVehicleNumber" runat="server" Width="180px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtVehicleNumber" ControlToValidate="txtVehicleNumber"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="divExpensessinglecontainer">
                        <div class="divExpensesleftcontainer">
                            No.Of liters.</div>
                        <div class="divExpensesrightcontainer">
                            <asp:TextBox ID="txtNooflitr" runat="server" Width="100px" OnTextChanged="txtNooflitr_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtNooflitr" ControlToValidate="txtNooflitr"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                  <asp:CompareValidator ID="Compare_txtNooflitr" runat="server" ControlToValidate="txtNooflitr"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divExpensessinglecontainer">
                        <div class="divExpensesleftcontainer">
                            Date</div>
                        <div class="divExpensesrightcontainer">
                            <asp:TextBox ID="txtDate" runat="server" Width="100px"></asp:TextBox><asp:Image ID="imgDate"
                                runat="server" ImageUrl="~/Images/calendar.gif" />
                                <ajx:CalendarExtender ID="CalendarPayment" runat="server" TargetControlID="txtDate"
                            Format="dd/MM/yyyy" PopupButtonID="imgDate" CssClass="MyCalendar">
                        </ajx:CalendarExtender>
                        <asp:RequiredFieldValidator runat="server" ID="Required_txtDate" ControlToValidate="txtDate"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                        
                    </div>
                    <div class="divExpensessinglecontainer">
                        <div class="divExpensesleftcontainer">
                            RPM</div>
                        <div class="divExpensesrightcontainer">
                            <asp:TextBox ID="txtRpm" runat="server" Width="100px" OnTextChanged="txtRpm_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtRpm" ControlToValidate="txtRpm"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                  <asp:CompareValidator ID="Compare_txtRpm" runat="server" ControlToValidate="txtRpm"
                                SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divExpensessinglecontainer" style="display: none;">
                        <div class="divExpensesleftcontainer">
                            Person Name</div>
                        <div class="divExpensesrightcontainer">
                            <asp:TextBox ID="txtPersonName" runat="server" Width="180px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtPersonName" ControlToValidate="txtPersonName"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="divExpensessinglecontainer">
                        <div class="divExpensesleftcontainer">
                            Amount</div>
                        <div class="divExpensesrightcontainer">
                            <asp:TextBox ID="txtAmount" runat="server" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtAmount" ControlToValidate="txtAmount"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                                      <asp:CompareValidator ID="Compare_txtAmount" runat="server" ControlToValidate="txtAmount"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divExpensessinglecontainer" style="width: 500px;">
                        <div class="divExpensesleftcontainer">
                            Remarks</div>
                        <div class="divExpensesrightcontainer">
                            <asp:TextBox ID="txtRemarks" runat="server" Width="280px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtRemarks" ControlToValidate="txtRemarks"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="divExpensessinglecontainer">
                        <div class="divExpensesleftcontainer">
                            &nbsp;</div>
                        <div class="divExpensesrightcontainer">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;<asp:Button
                                ID="btnBack" CausesValidation="false" runat="server" Text="Cancel" OnClick="btnBack_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <%--<Triggers>
    <asp:AsyncPostBackTrigger ControlID="txtRpm" EventName="TextChanged"/>
    </Triggers>--%>
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
                    Diesel Expenses Detail
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
                                OnClick="BtnGo_Click" CausesValidation="false"/>
                            <div style="float: right; text-align: right; color: Red;">
                                Select any one date of your month.</div>
                        </div>
                        <hr style="margin: 0 0 0 0;" />
                        <div style="height: 10px">
                        </div>
                    </div>
                    <div>
                        <asp:GridView ID="gvDieselExpensesDetails" runat="server" SkinID="PopupViewAllGrid"
                            Width="100%" PagerStyle-Height="30px">
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblno" SkinID="gridlbl" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Expenses Date" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVDate" runat="server" Text='<%#Eval("ExpensesDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RPM" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVRPM" runat="server" Text='<%#Eval("RPM") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vehicle Number" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVVehicleNumber" runat="server" Text='<%#Eval("VehicleNumber") %>'></asp:Label>
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
