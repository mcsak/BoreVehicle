<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BitExpenses.aspx.cs" Inherits="Source.Expenses.BitExpenses"
    MasterPageFile="~/InnerMaster.Master" %>

<asp:Content ID="BitExpenseHeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
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
<asp:Content ID="BitExpenseBodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <asp:UpdatePanel ID="updpnlMainContentBitExpenses" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdUpadteProgress" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="updpnlMainContentBitExpenses">
                <ProgressTemplate>
                    <asp:Image ID="imgloader" runat="server" ImageUrl="~/Images/loader.gif" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="centermaincontaineryle">
                <div class="centertitleheader" id="HeaderTitle" runat="server">
                    Bit Expenses Replacement - Add
                </div>
                <div class="divViewAllList" runat="server" id="ViewAllDetails">
                    <asp:Button ID="btnViewAll" runat="server" Text="View All" OnClick="btnViewAll_Click"
                        CausesValidation="false" />
                </div>
                <div class="BitExpensescentercontainer">
                    <div class="divExpensessinglecontainer" style="display: none;">
                        <div class="divExpensesleftcontainer">
                            Bit No.</div>
                        <div class="divExpensesrightcontainer">
                            <asp:TextBox ID="txtBitNumber" runat="server" Width="180px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtBitNumber" ControlToValidate="txtBitNumber"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Compare_txtBitNumber" runat="server" ControlToValidate="txtBitNumber"
                                SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divExpensessinglecontainer">
                        <div class="divExpensesleftcontainer">
                            Date</div>
                        <div class="divExpensesrightcontainer">
                            <asp:TextBox ID="txtDate" runat="server" Width="100px"></asp:TextBox><asp:Image ID="imgDate"
                                runat="server" ImageUrl="~/Images/calendar.gif" />
                            <ajx:CalendarExtender ID="CalExtDate" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy"
                                PopupButtonID="imgDate" CssClass="MyCalendar">
                            </ajx:CalendarExtender>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtDate" ControlToValidate="txtDate"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="divExpensessinglecontainer">
                        <div class="divExpensesleftcontainer">
                            Total Size</div>
                        <div class="bitExpensestextboxcontainer">
                            <asp:Label ID="lblQty" runat="server" Width="65px" Text="Qty"></asp:Label>
                            <asp:Label ID="lblPrice" runat="server" Width="63px" Text="Price"></asp:Label>
                            <asp:Label ID="lblTotal" runat="server" Width="60px" Text="Total"></asp:Label>
                        </div>
                    </div>
                    <div class="divExpensessinglecontainer">
                        <div class="divExpensesleftcontainer">
                            <asp:DropDownList ID="ddlFirst" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="bitExpensestextboxcontainer">
                            <asp:TextBox ID="txtFirstQty" runat="server" Width="60px" OnTextChanged="txtTotalAmount_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtFirstQty" runat="server" ControlToValidate="txtFirstQty"
                                SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            <asp:TextBox ID="txtFirstRate" runat="server" Width="60px" OnTextChanged="txtFirstRate_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtFirstRate" runat="server" ControlToValidate="txtFirstRate"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            <asp:TextBox ID="txtFirstTotal" runat="server" Width="60px"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtFirstTotal" runat="server" ControlToValidate="txtFirstTotal"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divExpensessinglecontainer">
                        <div class="divExpensesleftcontainer">
                            <asp:DropDownList ID="ddlSecond" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="bitExpensestextboxcontainer">
                            <asp:TextBox ID="txtSecondQty" runat="server" Width="60px" OnTextChanged="txtSecondQty_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtSecondQty" runat="server" ControlToValidate="txtSecondQty"
                                SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            <asp:TextBox ID="txtSecRate" runat="server" Width="60px" OnTextChanged="txtSecRate_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtSecRate" runat="server" ControlToValidate="txtSecRate"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            <asp:TextBox ID="txtSecTotal" runat="server" Width="60px"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtSecTotal" runat="server" ControlToValidate="txtSecTotal"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divExpensessinglecontainer">
                        <div class="divExpensesleftcontainer">
                            <asp:DropDownList ID="ddlThird" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="bitExpensestextboxcontainer">
                            <asp:TextBox ID="txtThirdQty" runat="server" Width="60px" OnTextChanged="txtThirdQty_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtThirdQty" runat="server" ControlToValidate="txtThirdQty"
                                SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            <asp:TextBox ID="txtThirdRate" runat="server" Width="60px" OnTextChanged="txtThirdRate_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtThirdRate" runat="server" ControlToValidate="txtThirdRate"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            <asp:TextBox ID="txtThirdTotal" runat="server" Width="60px"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtThirdTotal" runat="server" ControlToValidate="txtThirdTotal"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divExpensessinglecontainer">
                        <div class="divExpensesleftcontainer">
                            <asp:DropDownList ID="ddlFour" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="bitExpensestextboxcontainer">
                            <asp:TextBox ID="txtFourthQty" runat="server" Width="60px" OnTextChanged="txtFourthQty_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtFourthQty" runat="server" ControlToValidate="txtFourthQty"
                                SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            <asp:TextBox ID="txtFourthRate" runat="server" Width="60px" OnTextChanged="txtFourthRate_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtFourthRate" runat="server" ControlToValidate="txtFourthRate"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            <asp:TextBox ID="txtFourthTotal" runat="server" Width="60px"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtFourthTotal" runat="server" ControlToValidate="txtFourthTotal"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divExpensessinglecontainer">
                        <div class="divExpensesleftcontainer">
                            <asp:DropDownList ID="ddlFive" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="bitExpensestextboxcontainer">
                            <asp:TextBox ID="txtFifthQty" runat="server" Width="60px" OnTextChanged="txtFifthQty_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtFifthQty" runat="server" ControlToValidate="txtFifthQty"
                                SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            <asp:TextBox ID="txtFifthRate" runat="server" Width="60px" OnTextChanged="txtFifthRate_TextChanged"
                                AutoPostBack="true"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtFifthRate" runat="server" ControlToValidate="txtFifthRate"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            <asp:TextBox ID="txtFifthTotal" runat="server" Width="60px"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtFifthTotal" runat="server" ControlToValidate="txtFifthTotal"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divExpensessinglecontainer">
                        <div class="divExpensesleftcontainer">
                            Grand Total</div>
                        <div class="divExpensesrightcontainer" style="float: right; width: 107px;">
                            <asp:TextBox ID="txtGrandtotal" runat="server" Width="100px" Enabled="false"></asp:TextBox>
                                     <asp:RequiredFieldValidator runat="server" ID="Required_txtGrandtotal" ControlToValidate="txtGrandtotal"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Compare_txtGrandtotal" runat="server" ControlToValidate="txtGrandtotal"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                </div>
                <div class="bitVendorDetailContainer">
                    <div class="bitVendorDetailSinglewhole" style="margin-bottom: 10px;">
                        <div class="bitVendorDetailSingle" style="height: 70px;">
                            <div class="bitVendorLeftContainer">
                                Vendor Name</div>
                            <div class="bitVendorRightContainer">
                                <asp:TextBox ID="txtVendorName" runat="server" Width="160px" style="display:none;"></asp:TextBox>
                              
                                <asp:DropDownList ID="ddlVendorName" runat="server" Width="180px" Height="20px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Required_ddlVendorName" runat="server" ControlToValidate="ddlVendorName"
                                    InitialValue="<--Select-->" ErrorMessage="*" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="bitVendorDetailSingle" style="height: 70px; width: 450px;">
                            <div class="bitVendorLeftContainer">
                                Details</div>
                            <div class="bitVendorRightContainer" style="width: 300px;">
                                <asp:TextBox ID="txtDetails" runat="server" Width="280px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="Required_txtDetails" ControlToValidate="txtDetails"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="bitVendorDetailSinglewhole">
                        <div class="bitVendorAmountContainer">
                            <div class="bitVendorAmountLeftContainer">
                                Total Amount</div>
                            <div class="bitVendorAmountRightContainer">
                                <asp:TextBox ID="txtTotalAmount" runat="server" Width="100px" OnTextChanged="txtTotalAmount_TextChanged"
                                    AutoPostBack="true" Text="0.00"></asp:TextBox>
                                      <asp:RequiredFieldValidator runat="server" ID="Required_txtTotalAmount" ControlToValidate="txtTotalAmount"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="Compare_txtTotalAmount" runat="server" ControlToValidate="txtTotalAmount"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="bitVendorAmountContainer">
                            <div class="bitVendorAmountLeftContainer">
                                Paid Amount</div>
                            <div class="bitVendorAmountRightContainer">
                                <asp:TextBox ID="txtPaidAmount" runat="server" Width="100px" OnTextChanged="txtPaidAmount_TextChanged"
                                    AutoPostBack="true" Text="0.00"></asp:TextBox>
                                      <asp:RequiredFieldValidator runat="server" ID="Required_txtPaidAmount" ControlToValidate="txtPaidAmount"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="Compare_txtPaidAmount" runat="server" ControlToValidate="txtPaidAmount"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="bitVendorAmountContainer">
                            <div class="bitVendorAmountLeftContainer">
                                Remaining Amount</div>
                            <div class="bitVendorAmountRightContainer">
                                <asp:TextBox ID="txtRemaining" runat="server" Width="100px" OnTextChanged="txtRemaining_TextChanged"
                                    AutoPostBack="true" Text="0.00"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="Required_txtRemaining" ControlToValidate="txtRemaining"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="Compare_txtRemaining" runat="server" ControlToValidate="txtRemaining"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            </div>
                        </div>
                    </div>
                    <div class="bitVendorDetailSinglewhole" style="margin-bottom: 10px;">
                        <div class="bitVendorLeftContainer">
                            <asp:Label ID="lblRemarks" runat="server" Text="Remarks"></asp:Label></div>
                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="500px" Height="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="Required_txtRemarks" ControlToValidate="txtRemarks"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="bitvendorSubmitbtnContainer">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;<asp:Button
                        ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="updpnlPopup" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress_updpnlPopup" runat="server" DisplayAfter="0"
                AssociatedUpdatePanelID="updpnlPopup">
                <ProgressTemplate>
                    <asp:Image ID="imgloaderupdpnlPopup" runat="server" ImageUrl="~/Images/loader.gif" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="showviewallDetailpopup">
                <div class="reportclose">
                    <img class="divClose" id="Img1" runat="server" src="~/Images/CloseIcon16.png" alt=""
                        onclick="return closepopup()" />
                </div>
                <div class="viewallpopupheader">
                    Bit Expenses Detail
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
                        <asp:GridView ID="gvBitExpensesDetails" runat="server" SkinID="PopupViewAllGrid"
                            Width="100%" PagerStyle-Height="30px">
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblno" SkinID="gridlbl" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vendor Name" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVvendorname" runat="server" Text='<%#Eval("vendorname") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Expenses Date" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVExpensesDate" runat="server" Text='<%#Eval("ExpensesDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Amount" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVTotalAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PaidAmount" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVPaidamount" runat="server" Text='<%#Eval("paidamount") %>'></asp:Label>
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
