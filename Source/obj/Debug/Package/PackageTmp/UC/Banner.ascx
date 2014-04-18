<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Banner.ascx.cs" Inherits="Source.UC.Banner" %>
<link href="../CSS/Common.css" rel="stylesheet" type="text/css" />
<link href="../CSS/Master.css" rel="Stylesheet" type="text/css" />
<div class="bannercontainer">
    <div class="bannerinnercontainer">
        <div class="bannerlogocontainer">
            <asp:ImageButton ID="imgLogo" runat="Server" CausesValidation="false" ImageUrl="~/Images/BoreEsteem-Logo.png" />
        </div>
        <div style="float:left;width:450px; padding-top:10px;" ><asp:Label ID="lblVehicleSelection" runat="server" Text="Vehicle Number" /> 
            <asp:DropDownList ID="ddlVehicleNumber" runat="server"  
                CssClass="ddlvehicleMaster" AutoPostBack="true"
                onselectedindexchanged="ddlVehicleNumber_SelectedIndexChanged" ></asp:DropDownList>
                 </div>
        <div class="bannerrightcontainer" style="height: 70px;">
            <div class="bannerhomemenucontainer" style="margin-top: 0px; height: 80px;">
                <div class="bannerhomeimg">
                    <asp:ImageButton ID="imgBannerUser" CausesValidation="false" CssClass="bannerUserImage" runat="server" ImageUrl="~/Images/defaultphoto.gif"  />
                </div>
                <div class="bannerhometxt" id="bannerusername" runat="server" style="text-align: right;">
                    <span style="float: left; width: 93%; text-align: right;" id="SpnUsername" runat="server">User</span>
                </div>
                <div style="float: left; text-align: right; width: 100%;">
                    <asp:LinkButton ID="lnkLogout" CssClass="BannerLogout" CausesValidation="false" 
                        runat="server" Text="Logout" SkinID="lnkBanner"  
                        onclick="lnkLogout_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <div class="Menus" >
        <div id="Menu" >
            <ul id="menuh">
               <li><a href="#">Site Management</a>
                    <ul>
                      <li>
                            <asp:LinkButton ID="lnkbtnSiteManagement" Text="Site Management" CausesValidation="false" runat="server" PostBackUrl="~/SiteManagement/SiteManagement.aspx"></asp:LinkButton></li>
                              <li>
                            <asp:LinkButton ID="lnkBilling" Text="Billing" runat="server" CausesValidation="false" PostBackUrl="~/SiteManagement/SiteManagementBilling.aspx"></asp:LinkButton></li>
                       <li>
                            <asp:LinkButton ID="lnkReportMonthStatus" Text="Report Month Status" CausesValidation="false" runat="server" PostBackUrl="~/SiteManagement/MonthStatus.aspx"></asp:LinkButton></li>
                       
                          
                    </ul>
                </li>
                
                 <li><a href="#">Expenses</a>
                    <ul>
                      <li>
                            <asp:LinkButton ID="lnkbtnDiesel" Text="Diesel Expenses" runat="server" CausesValidation="false" PostBackUrl="~/Expenses/DieselExpenses.aspx"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkbtnBitExpense" Text="Bit Expenses" runat="server" CausesValidation="false" PostBackUrl="~/Expenses/BitExpenses.aspx"></asp:LinkButton></li>
                         <li>
                            <asp:LinkButton ID="lnkbtnBitReplacement" Text="Bit Replacement" runat="server" CausesValidation="false" PostBackUrl="~/Expenses/BitReplacement.aspx"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkbtnHammerExpense" Text="Hammer Expenses" runat="server" CausesValidation="false" PostBackUrl="~/Expenses/HammerExpenses.aspx"></asp:LinkButton></li>
                            <li>
                            <asp:LinkButton ID="lnkbtnHammerReplacement" Text="Hammer Replacement" runat="server" CausesValidation="false" PostBackUrl="~/Expenses/HammerReplacement.aspx"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkDailyExpense" Text="Daily Expenses" runat="server" CausesValidation="false" PostBackUrl="~/Expenses/DailyExpenses.aspx"></asp:LinkButton></li>

                             <li>
                            <asp:LinkButton ID="lnkOtherExpenses" Text="Other Expenses" runat="server" CausesValidation="false" PostBackUrl="~/Expenses/OtherExpenses.aspx"></asp:LinkButton></li>
                          
                    </ul>
                </li>
                  
                 <li><a href="#">Casing</a>
                    <ul>
                      <li>
                            <asp:LinkButton ID="lnkbtnCasingIn" Text="Casing Inward" runat="server" CausesValidation="false" PostBackUrl="~/Casing/InwardCasing.aspx"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkbtnCasingOut" Text="Casing Outward" runat="server" CausesValidation="false" PostBackUrl="~/Casing/OutwardCasing.aspx"></asp:LinkButton></li>
                        
                          
                    </ul>
                </li>

                <li><a href="#">HR Management</a>
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnkMangerPayment" Text="Mangers Payment" runat="server" CausesValidation="false" PostBackUrl="~/HRPayroll/ManagerPayment.aspx"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkLabourPayment" Text="Labours Payment" runat="server" CausesValidation="false" PostBackUrl="~/HRPayroll/LabourPayment.aspx"></asp:LinkButton></li>
                    </ul>
                </li>

                <li><a href="#">Reports</a>
                    <ul>
                    <li>
                            <asp:LinkButton ID="lnkBalanceLedger" Text="Balance Ledger" runat="server" CausesValidation="false" PostBackUrl="~/Reports/BalanceLedger.aspx"></asp:LinkButton></li>
                     <li>
                            <asp:LinkButton ID="lnkBalance" Text="Pending Bills Report" runat="server" CausesValidation="false" PostBackUrl="~/Reports/Balance.aspx"></asp:LinkButton></li>
                    <li>
                            <asp:LinkButton ID="lnkDieselExpenses" Visible="false" Text="Daily Expenses Report" CausesValidation="false" runat="server" PostBackUrl="~/ReportsDailyExpenses.aspx"></asp:LinkButton></li>
                      <li>
                            <asp:LinkButton ID="lnkDieselCal" Visible="false" Text="Diesel Calculation Report" CausesValidation="false" runat="server" PostBackUrl="~/Reports/DieselCalculation.aspx"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkMonthlyRep" Visible="false" Text="Monthly Report" runat="server" CausesValidation="false" PostBackUrl="~/Reports/ReportMonthly.aspx"></asp:LinkButton></li>
                        <li> 
                            <asp:LinkButton ID="lnkSBit" Text="Available Bit" runat="server" CausesValidation="false" PostBackUrl="~/Reports/StockManagement.aspx?View=Bit"></asp:LinkButton></li>
                        <li> 
                            <asp:LinkButton ID="lnkSHammer" Text="Available Hammer" runat="server" CausesValidation="false" PostBackUrl="~/Reports/StockManagement.aspx?View=Hammer"></asp:LinkButton></li>
                            
                                                  
                    </ul>
                </li>

                 <li><a href="#">Masters</a>
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnkbtnVendor" Text="Vendors" runat="server" CausesValidation="false" PostBackUrl="~/Master/Vendor.aspx"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkbtnLabour" Text="Labours" runat="server" CausesValidation="false" PostBackUrl="~/Master/Labour.aspx"></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkbtnVehicleNumber" Text="Vehicles" runat="server" CausesValidation="false" PostBackUrl="~/Master/Vehicle.aspx"></asp:LinkButton></li>
                             <li>
                            <asp:LinkButton ID="lnkbtnTaxDeduction" Text="Tax Deduction" runat="server" CausesValidation="false" PostBackUrl="~/Master/TaxDeduction.aspx"></asp:LinkButton></li>
                             <li>
                            <asp:LinkButton ID="lnkbtnCommonFund" Text="Common Fund" runat="server" CausesValidation="false" PostBackUrl="~/General/CommonFundManagementGrid.aspx"></asp:LinkButton></li>
                    </ul>
                </li>
            </ul>
        </div>
    </div>
</div>
