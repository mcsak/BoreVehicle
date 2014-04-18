<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyExpenses.aspx.cs" Inherits="Source.Report.DailyExpenses" MasterPageFile="~/InnerMaster.Master" %>


<asp:Content ID="OutwardHeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
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
<asp:Content ID="OutwardBodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
<div class="centertitleheader" id="HeaderTitle" runat="server">
           Daily Expenses
        </div>
        <div  class="divViewAllList"  runat="server" id="ViewAllDetails">
            <asp:Button ID="btnViewAll" runat="server" Text="View All"  OnClientClick="return showdetail()" CausesValidation="false"
                 />
        </div>
    <div class="reportcentercontainer" style="width:520px;">
    <div class="divreportsinglecontainer">
            <div class="divreportleftcontainer">
                Date</div>
            <div class="divreportrightcontainer">
                <asp:TextBox runat="server" ID="txtDate" Width="100px" ReadOnly="true"></asp:TextBox>
                       <asp:RequiredFieldValidator runat="server" ID="Required_txtDate" ControlToValidate="txtDate" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>

            </div>
        </div>
       <div class="divreportsinglecontainer">
            <div class="divreportleftcontainer">
                Bill Amount</div>
            <div class="divreportrightcontainer">
                <asp:TextBox runat="server" ID="txtBillAmount" Width="148px"></asp:TextBox>
                  <asp:RequiredFieldValidator runat="server" ID="Required_txtBillAmount" ControlToValidate="txtBillAmount" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                       <asp:CompareValidator ID="Compare_txtBillAmount" runat="server" ControlToValidate="txtBillAmount"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
            </div>
        </div>
         <div class="divreportsinglecontainer">
            <div class="divreportleftcontainer">
                Balance</div>
            <div class="divreportrightcontainer">
                <asp:TextBox runat="server" ID="txtBalance" Width="148px"></asp:TextBox>
                  <asp:RequiredFieldValidator runat="server" ID="Required_txtBalance" ControlToValidate="txtBalance" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                     <asp:CompareValidator ID="Compare_txtBalance" runat="server" ControlToValidate="txtBalance"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
            </div>
        </div>
         <div class="divreportsinglecontainer">
            <div class="divreportleftcontainer">
                Bit Numbers</div>
            <div class="divreportrightcontainer">
                <asp:TextBox runat="server" ID="txtBitQuantity" Width="40px"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ID="Required_txtBitQuantity" ControlToValidate="txtBitQuantity" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                         <asp:CompareValidator ID="Compare_txtBitQuantity" runat="server" ControlToValidate="txtBitQuantity"
                                SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
              
                &nbsp;<asp:TextBox ID="txtBitExpenses" runat="server" Width="100px"></asp:TextBox>
                  <asp:RequiredFieldValidator runat="server" ID="Required_txtBitExpenses" ControlToValidate="txtBitExpenses" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                          <asp:CompareValidator ID="Compare_txtBitExpenses" runat="server" ControlToValidate="txtBitExpenses"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
            </div>
        </div>
         <div class="divreportsinglecontainer">
            <div class="divreportleftcontainer">
                Hammer Numbers</div>
            <div class="divreportrightcontainer">
                 <asp:TextBox runat="server" ID="txtHammerQuantity" Width="40px"></asp:TextBox>
                  <asp:RequiredFieldValidator runat="server" ID="Required_txtHammerQuantity" ControlToValidate="txtHammerQuantity" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                          <asp:CompareValidator ID="Compare_txtHammerQuantity" runat="server" ControlToValidate="txtHammerQuantity"
                                SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                 
                 &nbsp;<asp:TextBox ID="txtHammerExpenses" runat="server" Width="100px"></asp:TextBox>
                  <asp:RequiredFieldValidator runat="server" ID="Required_txtHammerExpenses" ControlToValidate="txtHammerExpenses" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                      <asp:CompareValidator ID="Compare_txtHammerExpenses" runat="server" ControlToValidate="txtHammerExpenses"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
            </div>
        </div>
        <div class="divreportsinglecontainer">
            <div class="divreportleftcontainer">
                Diesel Numbers</div>
            <div class="divreportrightcontainer">
                 <asp:TextBox runat="server" ID="txtDieselQuantity" Width="40px"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ID="Required_txtDieselQuantity" ControlToValidate="txtDieselQuantity" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                       <asp:CompareValidator ID="Compare_txtDieselQuantity" runat="server" ControlToValidate="txtDieselQuantity"
                                SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                 &nbsp;<asp:TextBox runat="server" ID="txtDieselExpense" Width="100px"></asp:TextBox>
                 <asp:RequiredFieldValidator runat="server" ID="Required_txtDieselExpense" ControlToValidate="txtDieselExpense" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                                      <asp:CompareValidator ID="Compare_txtDieselExpense" runat="server" ControlToValidate="txtDieselExpense"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
            </div>
        </div>
        <div class="divreportsinglecontainer">
            <div class="divreportleftcontainer">
                Remarks</div>
            <div class="divreportrightcontainer">
                 <asp:TextBox runat="server" ID="txtRemarks" Width="250px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                   <asp:RequiredFieldValidator runat="server" ID="Required_txtRemarks" ControlToValidate="txtRemarks" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
            </div>
        </div>
         <div class="divreportsinglecontainer">
            <div class="divreportleftcontainer">
                &nbsp;</div>
            <div class="divreportrightcontainer">
               <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                    onclick="btnSubmit_Click" />&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" />
               </div>
        </div>
               
           
    </div>
    <asp:UpdatePanel ID="updpnlPopup" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress_updpnlPopup" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="updpnlPopup">
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
            Daily Expenses Detail
        </div>
        <div class="viewallinnercontainerpopup">  
                        <div id="divDateAndView" >
                <hr style="margin:0 0 0 0;" />
                <div>
                 <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                 <asp:Image ID="imgFromDate" runat="server" ImageUrl="~/Images/calendar.gif" />
        <ajx:CalendarExtender ID="CalendarExtenderFrom" runat="server" TargetControlID="txtFromDate" CssClass="MyCalendarPopup" PopupButtonID="imgFromDate" Format="MM-yyyy" OnClientShown="onCalendarShown">
        
        </ajx:CalendarExtender> &nbsp;&nbsp;<asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
        <asp:Image ID="imgToDate" runat="server" ImageUrl="~/Images/calendar.gif" />
        <ajx:CalendarExtender ID="CalendarExtenderTo" runat="server" TargetControlID="txtToDate" CssClass="MyCalendarPopup" PopupButtonID="imgToDate" Format="MM-yyyy" OnClientShown="onCalendarShown">
        </ajx:CalendarExtender>&nbsp;<asp:Button ID="btnGo" runat="server" Text="Go" CssClass="btnCommonGOstyle" OnClick="BtnGo_Click" CausesValidation="false"/>
        <div style="float:right;text-align:right;color:Red;">Select any one date of your month.</div>
                </div>
                <hr style="margin:0 0 0 0;" />
                <div style="height:10px"></div>
                </div>          
            <div>
                <asp:GridView ID="gvDailyExpensesDetails" runat="server" SkinID="PopupViewAllGrid" Width="100%"
                    PagerStyle-Height="30px">
                    <Columns>
                        <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblno" SkinID="gridlbl" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vehicle Number" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVVehicleNo" runat="server" Text='<%#Eval("VehicleNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Daily Expenses Date" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVExpensesDate" runat="server" Text='<%#Eval("ExpensesDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Amount" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVTotalAmount" runat="server" Text='<%#Eval("BillAmount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Balance Amount" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVBalanceAmount" runat="server" Text='<%#Eval("BalanceAmount") %>'></asp:Label>
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



