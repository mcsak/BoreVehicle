<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/SiteManagement/SiteManagementBilling.aspx.cs"
    MasterPageFile="~/InnerMaster.Master" Inherits="Source.SiteManagement.SiteManagementBilling" %>

<asp:Content ID="RepMonthlyHeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
    <link href="../CSS/Report.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../Scripts/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" language="javascript">
        var drillingcasingval;
        function showdetail() {
            $('.divPopupBackground').css({ 'height': (document.documentElement.scrollHeight | document.body.scrollHeight) + 150 + 'px', 'display': 'block' });
            $('.showviewallDetailpopup').css({
                'top': (document.documentElement.scrollTop | document.body.scrollTop) + 80,
                'left': 330,
                'z-Index': 1000,
                'display': 'block'
            });
            return false;
        }

        function closepopup() {
            $('.showviewallDetailpopup').css({ 'display': 'none' });
            $('.divPopupBackground').css({ 'display': 'none' });
            $('.showdrillingbillingpopup').css({ 'display': 'none' });
            $('.showcasingbillingpopup').css({ 'display': 'none' });
            return false;
        }

        function showdrillcase(value) {

            if (value == 1) {
                $('.divPopupBackground').css({ 'height': (document.documentElement.scrollHeight | document.body.scrollHeight) + 150 + 'px', 'display': 'block' });
                $('.showdrillingbillingpopup').css({
                    'top': (document.documentElement.scrollTop | document.body.scrollTop) + 80,
                    'left': 330,
                    'z-Index': 999,
                    'display': 'block'
                });

                // return true;
            }
            if (value == 2) {
                $('.divPopupBackground').css({ 'height': (document.documentElement.scrollHeight | document.body.scrollHeight) + 150 + 'px', 'display': 'block' });
                $('.showcasingbillingpopup').css({
                    'top': (document.documentElement.scrollTop | document.body.scrollTop) + 80,
                    'left': 330,
                    'z-Index': 999,
                    'display': 'block'
                });
                // return true;
            }
        }

        function Drillingvariationtotalvalue() {
            $('.showdrillingbillingpopup').css({ 'display': 'none' });
            $('.divPopupBackground').css({ 'display': 'none' });
            //            $('#ctl00_ContentPlaceHolderMain_totaldrillingvariation').css({ 'display': 'block' });
            //            $('#ctl00_ContentPlaceHolderMain_drillingdepthrate').css({ 'display': 'none' });
            $('#ctl00_ContentPlaceHolderMain_lblDrillingVariation').html(document.getElementById('ctl00_ContentPlaceHolderMain_txtpopupdrillinggrandtotal').value);

            document.getElementById('ctl00_ContentPlaceHolderMain_txtDrillingDepthRateTotal').value = document.getElementById('ctl00_ContentPlaceHolderMain_txtpopupdrillinggrandtotal').value;
            document.getElementById('ctl00_ContentPlaceHolderMain_rdbdrillingvariationno').checked = false;
            document.getElementById('ctl00_ContentPlaceHolderMain_rdbdrillingvariationyes').checked = true;
        }

        function Casingvariationtotlavalue() {
            $('.showcasingbillingpopup').css({ 'display': 'none' });
            $('.divPopupBackground').css({ 'display': 'none' });
            //            $('#ctl00_ContentPlaceHolderMain_totalcasingvariation').css({ 'display': 'block' });
            //            $('#ctl00_ContentPlaceHolderMain_caseingdepthrate').css({ 'display': 'none' });
            $('#ctl00_ContentPlaceHolderMain_lblCasingVariation').html(document.getElementById('ctl00_ContentPlaceHolderMain_txtpopupcasinggrandtotal').value);
            document.getElementById('ctl00_ContentPlaceHolderMain_txtCasingDepthRateTotal').value = document.getElementById('ctl00_ContentPlaceHolderMain_txtpopupcasinggrandtotal').value;
            document.getElementById('ctl00_ContentPlaceHolderMain_rdbcasingvariationno').checked = false;
            document.getElementById('ctl00_ContentPlaceHolderMain_rdbcasingvariationyes').checked = true;

        }

        function closedrillingvariation() {
            $('.showdrillingbillingpopup').css({ 'display': 'none' });
            $('.divPopupBackground').css({ 'display': 'none' });
            //            $('#ctl00_ContentPlaceHolderMain_totaldrillingvariation').css({ 'display': 'none' });
            //            $('#ctl00_ContentPlaceHolderMain_drillingdepthrate').css({ 'display': 'block' });
            document.getElementById('ctl00_ContentPlaceHolderMain_rdbdrillingvariationno').checked = true;
            document.getElementById('ctl00_ContentPlaceHolderMain_rdbdrillingvariationyes').checked = false;

        }

        function closecasingvariation() {
            $('.showcasingbillingpopup').css({ 'display': 'none' });
            $('.divPopupBackground').css({ 'display': 'none' });
            //            $('#ctl00_ContentPlaceHolderMain_totalcasingvariation').css({ 'display': 'none' });
            //            $('#ctl00_ContentPlaceHolderMain_caseingdepthrate').css({ 'display': 'block' });
            document.getElementById('ctl00_ContentPlaceHolderMain_rdbcasingvariationno').checked = true;
            document.getElementById('ctl00_ContentPlaceHolderMain_rdbcasingvariationyes').checked = false;
        }

        function showtaxdeduction() {
            if (document.getElementById('ctl00_ContentPlaceHolderMain_chkTaxDeduction').checked == true) {
                $('#ctl00_ContentPlaceHolderMain_taxdeduction').css({ 'display': 'block' });
            }
            else {
                $('#ctl00_ContentPlaceHolderMain_taxdeduction').css({ 'display': 'none' });
            }
        }
                     
          
    </script>
</asp:Content>
<asp:Content ID="RepMonthlyBodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <asp:UpdatePanel ID="updpnlMainContentBilling" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress_updpnlMainContentBilling" runat="server" DisplayAfter="0"
                AssociatedUpdatePanelID="updpnlMainContentBilling">
                <ProgressTemplate>
                    <div class="ProgressPageOverlay">
                        <asp:Image ID="imgloaderupdpnlMainContentBilling" CssClass="ProgressImage" runat="server"
                            ImageUrl="~/Images/loader.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="centermaincontaineryle">
                <div class="centertitleheader">
                    Billing
                </div>
                <div class="divViewAllList" runat="server" id="ViewAllDetails">
                    <asp:Button ID="btnViewAll" runat="server" Text="View All" OnClick="btnViewAll_Click"
                        CausesValidation="false" />
                </div>
                <div class="SMBillingcentercontainer">
                    <div class="BillingLeftContainer">
                        <div class="divreportsinglecontainer">
                            <div class="divreportleftcontainer">
                                Point No.</div>
                            <div class="divreportrightcontainer">
                                <asp:DropDownList ID="ddlPointNumber" runat="server" Width="170px" Height="25px"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlPointNumber_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="Required_ddlPointNumber" runat="server" ControlToValidate="ddlPointNumber"
                                    InitialValue="<--Select-->" ErrorMessage="*" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="divreportsinglecontainer">
                            <div class="divreportleftcontainer">
                                Drilling Depth Variation</div>
                            <div class="divreportrightcontainer">
                                <asp:RadioButton ID="rdbdrillingvariationyes" runat="server" Text="Yes" GroupName="drillingvariation"
                                    onclick="return showdrillcase(1)" />&nbsp;
                                <asp:RadioButton ID="rdbdrillingvariationno" runat="server" Text="No" GroupName="drillingvariation"
                                    Checked="true" />
                            </div>
                        </div>
                        <div class="divreportsinglecontainer">
                            <div class="divreportleftcontainer">
                                Casing Depth Variation</div>
                            <div class="divreportrightcontainer">
                                <asp:RadioButton ID="rdbcasingvariationyes" runat="server" Text="Yes" GroupName="casingingvariation"
                                    onclick="return showdrillcase(2)" />&nbsp;
                                <asp:RadioButton ID="rdbcasingvariationno" runat="server" Text="No" GroupName="casingingvariation"
                                    Checked="true" />
                            </div>
                        </div>
                        <%--
                         <div class="divreportsinglecontainer" id="totaldrillingvariation"  runat="server">
                            <div class="divreportleftcontainer">
                                Drilling Variation Rate</div>
                            <div class="divreportrightcontainer">
                                <asp:Label ID="lblDrillingVariation" runat="server" Text="0.00" Width="60px" ></asp:Label>
                                <asp:TextBox ID="txtDrillingvariation" runat="server" Text="0.00"  AutoPostBack="true"
                                    ontextchanged="txtDrillingvariation_TextChanged"></asp:TextBox>
                               
                            </div>
                        </div>

                        <div class="divreportsinglecontainer" id="totalcasingvariation"  runat="server">
                            <div class="divreportleftcontainer">
                                Casing Variation Rate</div>
                            <div class="divreportrightcontainer">
                                <asp:Label ID="lblCasingVariation" runat="server" Text="0.00" Width="60px"></asp:Label>
                               <asp:TextBox ID="txtCasingVariation" runat="server" Text="0.00"   AutoPostBack="true"
                                    ontextchanged="txtCasingVariation_TextChanged" ></asp:TextBox>
                            </div>
                        </div>--%>
                        <div class="divreportsinglecontainer" id="drillingdepthrate" runat="server">
                            <div class="divreportleftcontainer">
                                Drilling Depth Rate</div>
                            <div class="divreportrightcontainer">
                                <asp:Label ID="lblDrillingDepth" runat="server" Text="" Width="60px"></asp:Label>
                                <asp:TextBox ID="txtDrillingDepthRate" runat="server" AutoPostBack="true" Width="100px"
                                    OnTextChanged="txtDrillingDepthRate_TextChanged" Text="0.00"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="Required_txtDrillingDepthRate" ControlToValidate="txtDrillingDepthRate"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="Compare_txtDrillingDepthRate" runat="server" ControlToValidate="txtDrillingDepthRate"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                                <asp:TextBox ID="txtDrillingDepthRateTotal" runat="server" Width="100px" Text="0.00"
                                    OnTextChanged="txtDrillingDepthRateTotal_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="Required_txtDrillingDepthRateTotal"
                                    ControlToValidate="txtDrillingDepthRateTotal" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="Comapre_txtDrillingDepthRateTotal" runat="server" ControlToValidate="txtDrillingDepthRateTotal"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="divreportsinglecontainer" id="caseingdepthrate" runat="server">
                            <div class="divreportleftcontainer">
                                Casing Depth Rate</div>
                            <div class="divreportrightcontainer">
                                <asp:Label ID="lblCasingDepth" runat="server" Text="" Width="60px"></asp:Label>
                                <asp:TextBox ID="txtCasingDepthRate" runat="server" AutoPostBack="true" Width="100px"
                                    OnTextChanged="txtCasingDepthRate_TextChanged" Text="0.00"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="Required_txtCasingDepthRate" ControlToValidate="txtCasingDepthRate"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="Compare_txtCasingDepthRate" runat="server" ControlToValidate="txtCasingDepthRate"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                                <asp:TextBox ID="txtCasingDepthRateTotal" runat="server" Width="100px" Text="0.00"
                                    OnTextChanged="txtCasingDepthRateTotal_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="Required_txtCasingDepthRateTotal"
                                    ControlToValidate="txtCasingDepthRateTotal" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="Compare_txtCasingDepthRateTotal" runat="server" ControlToValidate="txtCasingDepthRateTotal"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="divreportsinglecontainer">
                            <div class="divreportleftcontainer">
                                Welding Rate</div>
                            <div class="divreportrightcontainer">
                                <asp:Label ID="lblWeldingDepth" runat="server" Text="" Width="60px"></asp:Label>
                                <asp:TextBox ID="txtWeldingRate" runat="server" AutoPostBack="true" Width="100px"
                                    OnTextChanged="txtWeldingRate_TextChanged" Text="0.00"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="Required_txtWeldingRate" ControlToValidate="txtWeldingRate"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="Compare_txtWeldingRate" runat="server" ControlToValidate="txtWeldingRate"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                                <asp:TextBox ID="txtWeldingRateTotal" runat="server" Width="100px" Text="0.00" OnTextChanged="txtWeldingRateTotal_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="Required_txtWeldingRateTotal" ControlToValidate="txtWeldingRateTotal"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="Compare_txtWeldingRateTotal" runat="server" ControlToValidate="txtWeldingRateTotal"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="divreportsinglecontainer">
                            <div class="divreportleftcontainer">
                                Holes Pipe Rate</div>
                            <div class="divreportrightcontainer">
                                <asp:Label ID="lblHolePipe" runat="server" Text="" Width="60px"></asp:Label>
                                <asp:TextBox ID="txtHolePipeRate" runat="server" AutoPostBack="true" Width="100px"
                                    OnTextChanged="txtHolePipeRate_TextChanged" Text="0.00"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="Required_txtHolePipeRate" ControlToValidate="txtHolePipeRate"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="Compare_txtHolePipeRate" runat="server" ControlToValidate="txtHolePipeRate"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                                <asp:TextBox ID="txtHolePipeRateTotal" runat="server" Width="100px" Text="0.00" OnTextChanged="txtHolePipeRateTotal_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="Required_txtHolePipeRateTotal" ControlToValidate="txtHolePipeRateTotal"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="Compare_txtHolePipeRateTotal" runat="server" ControlToValidate="txtHolePipeRateTotal"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="divreportsinglecontainer">
                            <div class="divreportleftcontainer">
                                Collar Rate</div>
                            <div class="divreportrightcontainer">
                                <asp:Label ID="lblCollar" runat="server" Text="" Width="60px"></asp:Label>
                                <asp:TextBox ID="txtCollarRate" runat="server" AutoPostBack="true" Width="100px"
                                    Text="0.00" OnTextChanged="txtCollar_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="Required_txtCollarRate" ControlToValidate="txtCollarRate"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="Compare_txtCollarRate" runat="server" ControlToValidate="txtCollarRate"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                                <asp:TextBox ID="txtCollarRateTotal" runat="server" Width="100px" Text="0.00" AutoPostBack="true"
                                    OnTextChanged="txtCollarRateTotal_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="Required_txtCollarRateTotal" ControlToValidate="txtCollarRateTotal"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="Compare_txtCollarRateTotal" runat="server" ControlToValidate="txtCollarRateTotal"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            </div>
                        </div>
                        <%--    <div class="divreportsinglecontainer">
                            <div class="radiobuttondiv"><asp:RadioButton ID="rdbdrillingrate" runat="server" Text="Drilling Rate"  GroupName="rate"  onclick="return showdrillcase(1)" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton
                                ID="rdbCasingrate" runat="server" Text="CasingRate"  GroupName="rate"  onclick="return showdrillcase(2)" /></div>
                        </div>--%>
                        <div class="divreportsinglecontainer">
                            <div class="divreportleftcontainer">
                                <asp:CheckBox ID="chkTaxDeduction" runat="server" Text="Tax Deduction" onclick="return showtaxdeduction()" /></div>
                            <div class="divreportrightcontainer">
                            </div>
                        </div>
                        <div class="divreportsinglecontainer" id="taxdeduction" runat="server" style="display: none;">
                            <div class="divreportleftcontainer">
                                Tax Deduction</div>
                            <div class="divreportrightcontainer">
                                <asp:TextBox ID="txtTaxDeduction" runat="server" Width="100px" Text="0.00"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="Required_txtTaxDeduction" ControlToValidate="txtTaxDeduction"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="Compare_txtTaxDeduction" runat="server" ControlToValidate="txtTaxDeduction"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                            </div>
                        </div>
                        <div class="divreportsinglecontainer" style="width: 950px;">
                            <div class="totalsinglerow">
                                <div class="divreportleftcontainer" style="width: 100px; margin-left: 20px;">
                                    Grand Total</div>
                                <div class="divreportrightcontainer" style="width: 150px;">
                                    <asp:TextBox ID="txtGrandTotal" runat="server" Width="100px" Text="0.00"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="Required_txtGrandTotal" ControlToValidate="txtGrandTotal"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="Compare_txtGrandTotal" runat="server" ControlToValidate="txtGrandTotal"
                                        SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                        ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="totalsinglerow">
                                <div class="divreportleftcontainer" style="width: 100px; margin-left: 20px;">
                                    Previous Paid</div>
                                <div class="divreportrightcontainer" style="width: 150px;">
                                    <asp:TextBox ID="txtPreviousPaid" runat="server" Width="100px" Text="0.00"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="Required_txtPreviousPaid" ControlToValidate="txtPreviousPaid"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="Compare_txtPreviousPaid" runat="server" ControlToValidate="txtPreviousPaid"
                                        SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                        ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="totalsinglerow">
                                <div class="divreportleftcontainer" style="width: 100px; margin-left: 20px;">
                                    Amount Paid</div>
                                <div class="divreportrightcontainer" style="width: 150px;">
                                    <asp:TextBox ID="txtAmountPaid" runat="server" Width="100px" Text="0.00"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="Required_txtAmountPaid" ControlToValidate="txtAmountPaid"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="Compare_txtAmountPaid" runat="server" ControlToValidate="txtAmountPaid"
                                        SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                        ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                                </div>
                            </div>
                        </div>
                        <div class="divreportsinglecontainer">
                        </div>
                        <div class="divreportsinglecontainer">
                        </div>
                    </div>
                    <div class="BillingRightContainer">
                        <div class="SMBillinginnercontainer" style="margin: 0 auto; height: 255px; border: 1px solid silver;">
                            <div class="siteManagementleft">
                                <div class="siteManagementRow">
                                    <asp:Label ID="lblPartyname" runat="server" Width="140px" CssClass="divreportleftcontainer"
                                        Text="Party Name"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtpartyname" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="Required_txtpartyname" ControlToValidate="txtpartyname"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="siteManagementleft">
                                <div class="siteManagementRow">
                                    <asp:Label ID="lblPartyNo" runat="server" Width="140px" CssClass="divreportleftcontainer"
                                        Text="Party No"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtPartyno" Width="180px"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="Required_txtPartyno" ControlToValidate="txtPartyno"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="Compare_txtPartyno" runat="server" ControlToValidate="txtPartyno"
                                        SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                        ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="siteManagementRowtextarea">
                                <div class="divColumnleft" style="width: 197px;">
                                    <asp:Label ID="lblAddress" runat="server" CssClass="divreportleftcontainer" Text="Address"></asp:Label>
                                </div>
                                <div class="divColumnright">
                                    <asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine" Width="250px" Height="50px"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="Required_txtAddress" ControlToValidate="txtAddress"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="siteManagementRowtextarea">
                                <div class="divColumnleft" style="width: 197px;">
                                    <asp:Label ID="lblRemarks" runat="server" CssClass="divreportleftcontainer" Text="Remarks"></asp:Label>
                                </div>
                                <div class="divColumnright">
                                    <asp:TextBox runat="server" ID="txtRemarks" TextMode="MultiLine" Width="250px" Height="50px"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="Required_txtRemarks" ControlToValidate="txtRemarks"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="innerContainer" style="float: left; width: 100%; text-align: center;">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                        CausesValidation="false" />
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCancel" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="updpnlPopup" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1_updpnlPopup" runat="server" DisplayAfter="0"
                AssociatedUpdatePanelID="updpnlPopup">
                <ProgressTemplate>
                    <div class="ProgressPageOverlay">
                        <asp:Image ID="imgloaderupdpnlupdpnlPopup" CssClass="ProgressImage" runat="server"
                            ImageUrl="~/Images/loader.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="showviewallDetailpopup">
                <div class="reportclose">
                    <img class="divClose" id="Img1" runat="server" src="~/Images/CloseIcon16.png" alt=""
                        onclick="return closepopup()" />
                </div>
                <div class="viewallpopupheader">
                    Billing Detail
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
                        <asp:GridView ID="gvBillingDetails" runat="server" SkinID="PopupViewAllGrid" Width="100%"
                            PagerStyle-Height="30px">
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblno" SkinID="gridlbl" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Party Name" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVPartyName" runat="server" Text='<%#Eval("PartyName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Party Number" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVPartyPhoneNumber" runat="server" Text='<%#Eval("PartyPhoneNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Amount" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVTotalBillingAmount" runat="server" Text='<%#Eval("TotalBillingAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Paid Amount" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVPaidAmount" runat="server" Text='<%#Eval("PaidAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGo" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="showdrillingbillingpopup" id="drilldepthrate" runat="server">
        <div class="reportclose">
            <img class="divClose" id="closedrill" runat="server" src="~/Images/CloseIcon16.png"
                alt="" onclick="return closedrillingvariation()" />
        </div>
        <asp:UpdatePanel ID="upddrill" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="billingdrillcaseinner">
                    <div class="singlerowbox">
                        Drilling Rate</div>
                    <br />
                    <div class="singlerowbox">
                        Qty</div>
                    <br />
                    <div class="singlerowbox">
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthqtybox1" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthqtybox1_TextChanged"></asp:TextBox>
                                 <asp:CompareValidator ID="Compare_txtDrilldepthqtybox1" runat="server" ControlToValidate="txtDrilldepthqtybox1"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthqtybox2" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthqtybox2_TextChanged"></asp:TextBox>
                                      <asp:CompareValidator ID="Compare_txtDrilldepthqtybox2" runat="server" ControlToValidate="txtDrilldepthqtybox2"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthqtybox3" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthqtybox3_TextChanged"></asp:TextBox>
                                 <asp:CompareValidator ID="Compare_txtDrilldepthqtybox3" runat="server" ControlToValidate="txtDrilldepthqtybox3"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthqtybox4" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthqtybox4_TextChanged"></asp:TextBox>
                                  <asp:CompareValidator ID="Compare_txtDrilldepthqtybox4" runat="server" ControlToValidate="txtDrilldepthqtybox4"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthqtybox5" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthqtybox5_TextChanged"></asp:TextBox>
                                  <asp:CompareValidator ID="Compare_txtDrilldepthqtybox5" runat="server" ControlToValidate="txtDrilldepthqtybox5"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthqtybox6" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthqtybox6_TextChanged"></asp:TextBox>
                                 <asp:CompareValidator ID="Compare_txtDrilldepthqtybox6" runat="server" ControlToValidate="txtDrilldepthqtybox6"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthqtybox7" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthqtybox7_TextChanged"></asp:TextBox>
                                  <asp:CompareValidator ID="Compare_txtDrilldepthqtybox7" runat="server" ControlToValidate="txtDrilldepthqtybox7"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthqtybox8" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthqtybox8_TextChanged"></asp:TextBox>
                                  <asp:CompareValidator ID="Compare_txtDrilldepthqtybox8" runat="server" ControlToValidate="txtDrilldepthqtybox8"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="singlerowbox">
                        Rate</div>
                    <br />
                    <div class="singlerowbox">
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthratebox1" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthratebox1_TextChanged"></asp:TextBox>
                                   <asp:CompareValidator ID="Compare_txtDrilldepthratebox1" runat="server" ControlToValidate="txtDrilldepthratebox1"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthratebox2" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthratebox2_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="Compare_txtDrilldepthratebox2" runat="server" ControlToValidate="txtDrilldepthratebox2"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthratebox3" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthratebox3_TextChanged"></asp:TextBox>
                                 <asp:CompareValidator ID="Compare_txtDrilldepthratebox3" runat="server" ControlToValidate="txtDrilldepthratebox3"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthratebox4" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthratebox4_TextChanged"></asp:TextBox>
                                  <asp:CompareValidator ID="Compare_txtDrilldepthratebox4" runat="server" ControlToValidate="txtDrilldepthratebox4"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthratebox5" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthratebox5_TextChanged"></asp:TextBox>
                                  <asp:CompareValidator ID="Compare_txtDrilldepthratebox5" runat="server" ControlToValidate="txtDrilldepthratebox5"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthratebox6" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthratebox6_TextChanged"></asp:TextBox>
                                 <asp:CompareValidator ID="Compare_txtDrilldepthratebox6" runat="server" ControlToValidate="txtDrilldepthratebox6"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthratebox7" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthratebox7_TextChanged"></asp:TextBox>
                                  <asp:CompareValidator ID="Compare_txtDrilldepthratebox7" runat="server" ControlToValidate="txtDrilldepthratebox7"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtDrilldepthratebox8" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtDrilldepthratebox8_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="Compare_txtDrilldepthratebox8" runat="server" ControlToValidate="txtDrilldepthratebox8"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="singlerowbox">
                        Total</div>
                    <br />
                    <div class="singlerowbox">
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtdrillpopuptotal1" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                                <asp:CompareValidator ID="Compare_txtdrillpopuptotal1" runat="server" ControlToValidate="txtdrillpopuptotal1"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtdrillpopuptotal2" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                             <asp:CompareValidator ID="Compare_txtdrillpopuptotal2" runat="server" ControlToValidate="txtdrillpopuptotal2"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtdrillpopuptotal3" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                              <asp:CompareValidator ID="Compare_txtdrillpopuptotal3" runat="server" ControlToValidate="txtdrillpopuptotal3"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtdrillpopuptotal4" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                             <asp:CompareValidator ID="Compare_txtdrillpopuptotal4" runat="server" ControlToValidate="txtdrillpopuptotal4"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtdrillpopuptotal5" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtdrillpopuptotal5" runat="server" ControlToValidate="txtdrillpopuptotal5"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtdrillpopuptotal6" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                             <asp:CompareValidator ID="Compare_txtdrillpopuptotal6" runat="server" ControlToValidate="txtdrillpopuptotal6"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtdrillpopuptotal7" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                               <asp:CompareValidator ID="Compare_txtdrillpopuptotal7" runat="server" ControlToValidate="txtdrillpopuptotal7"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtdrillpopuptotal8" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                             <asp:CompareValidator ID="Compare_txtdrillpopuptotal8" runat="server" ControlToValidate="txtdrillpopuptotal8"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="singlerowbox" style="text-align: right; width: 100%; margin-top: 10px;">
                        <span class="popupdrilllblbox">
                            <asp:Button ID="btndrillOK" runat="server" Text="OK" OnClientClick="return Drillingvariationtotalvalue()" /></span>&nbsp&nbsp;<span
                                class="drillpopupgrantbox"><asp:TextBox ID="txtpopupdrillinggrandtotal" runat="server"
                                    AutoPostBack="true" Width="100px" Text="0.00"></asp:TextBox></span>&nbsp;&nbsp;<span
                                        class="popupdrilllblbox">Grand Total</span>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div class="showcasingbillingpopup" id="casingdepthrate" runat="server">
        <div class="reportclose">
            <img class="divClose" runat="server" src="~/Images/CloseIcon16.png" alt="" onclick="return closecasingvariation()" />
        </div>
        <asp:UpdatePanel ID="updCasing" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="billingdrillcaseinner">
                    <div class="singlerowbox">
                        Casing Rate</div>
                    <br />
                    <div class="singlerowbox">
                        Qty</div>
                    <br />
                    <div class="singlerowbox">
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthqtybox1" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthqtybox1_TextChanged"></asp:TextBox>
                                  <asp:CompareValidator ID="Compare_txtCasedepthqtybox1" runat="server" ControlToValidate="txtCasedepthqtybox1"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthqtybox2" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthqtybox2_TextChanged"></asp:TextBox>
                                 <asp:CompareValidator ID="Compare_txtCasedepthqtybox2" runat="server" ControlToValidate="txtCasedepthqtybox2"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthqtybox3" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthqtybox3_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="Compare_txtCasedepthqtybox3" runat="server" ControlToValidate="txtCasedepthqtybox3"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthqtybox4" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthqtybox4_TextChanged"></asp:TextBox>
                                  <asp:CompareValidator ID="Compare_txtCasedepthqtybox4" runat="server" ControlToValidate="txtCasedepthqtybox4"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthqtybox5" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthqtybox5_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="Compare_txtCasedepthqtybox5" runat="server" ControlToValidate="txtCasedepthqtybox5"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthqtybox6" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthqtybox6_TextChanged"></asp:TextBox>
                                    <asp:CompareValidator ID="Compare_txtCasedepthqtybox6" runat="server" ControlToValidate="txtCasedepthqtybox6"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthqtybox7" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthqtybox7_TextChanged"></asp:TextBox>
                                   <asp:CompareValidator ID="Compare_txtCasedepthqtybox7" runat="server" ControlToValidate="txtCasedepthqtybox7"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthqtybox8" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthqtybox8_TextChanged"></asp:TextBox>
                                 <asp:CompareValidator ID="Compare_txtCasedepthqtybox8" runat="server" ControlToValidate="txtCasedepthqtybox8"
                                    SetFocusOnError="true" Display="Dynamic" Type="Integer" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="singlerowbox">
                        Rate</div>
                    <br />
                    <div class="singlerowbox">
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthratebox1" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthratebox1_TextChanged"></asp:TextBox>
                                      <asp:CompareValidator ID="Compare_txtCasedepthratebox1" runat="server" ControlToValidate="txtCasedepthratebox1"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthratebox2" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthratebox2_TextChanged"></asp:TextBox>
                                 <asp:CompareValidator ID="Compare_txtCasedepthratebox2" runat="server" ControlToValidate="txtCasedepthratebox2"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthratebox3" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthratebox3_TextChanged"></asp:TextBox>
                                 <asp:CompareValidator ID="Compare_txtCasedepthratebox3" runat="server" ControlToValidate="txtCasedepthratebox3"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthratebox4" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthratebox4_TextChanged"></asp:TextBox>
                                  <asp:CompareValidator ID="Compare_txtCasedepthratebox4" runat="server" ControlToValidate="txtCasedepthratebox4"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthratebox5" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthratebox5_TextChanged"></asp:TextBox>
                                  <asp:CompareValidator ID="Compare_txtCasedepthratebox5" runat="server" ControlToValidate="txtCasedepthratebox5"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthratebox6" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthratebox6_TextChanged"></asp:TextBox>
                                 <asp:CompareValidator ID="Compare_txtCasedepthratebox6" runat="server" ControlToValidate="txtCasedepthratebox6"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthratebox7" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthratebox7_TextChanged"></asp:TextBox>
                                <asp:CompareValidator ID="Compare_txtCasedepthratebox7" runat="server" ControlToValidate="txtCasedepthratebox7"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasedepthratebox8" runat="server" Width="70px" Text="0.00" AutoPostBack="true"
                                OnTextChanged="txtCasedepthratebox8_TextChanged"></asp:TextBox>
                                   <asp:CompareValidator ID="Compare_txtCasedepthratebox8" runat="server" ControlToValidate="txtCasedepthratebox8"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="singlerowbox">
                        Total</div>
                    <br />
                    <div class="singlerowbox">
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasingpopuptotal1" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                             <asp:CompareValidator ID="Compare_txtCasingpopuptotal1" runat="server" ControlToValidate="txtCasingpopuptotal1"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasingpopuptotal2" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtCasingpopuptotal2" runat="server" ControlToValidate="txtCasingpopuptotal2"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasingpopuptotal3" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                              <asp:CompareValidator ID="Compare_txtCasingpopuptotal3" runat="server" ControlToValidate="txtCasingpopuptotal3"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasingpopuptotal4" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtCasingpopuptotal4" runat="server" ControlToValidate="txtCasingpopuptotal4"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasingpopuptotal5" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                               <asp:CompareValidator ID="Compare_txtCasingpopuptotal5" runat="server" ControlToValidate="txtCasingpopuptotal5"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasingpopuptotal6" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                              <asp:CompareValidator ID="Compare_txtCasingpopuptotal6" runat="server" ControlToValidate="txtCasingpopuptotal6"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasingpopuptotal7" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                            <asp:CompareValidator ID="Compare_txtCasingpopuptotal7" runat="server" ControlToValidate="txtCasingpopuptotal7"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                        <div class="singlecolumnbox">
                            <asp:TextBox ID="txtCasingpopuptotal8" runat="server" Width="70px" Text="0.00"></asp:TextBox>
                             <asp:CompareValidator ID="Compare_txtCasingpopuptotal8" runat="server" ControlToValidate="txtCasingpopuptotal8"
                                    SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                    ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="singlerowbox" style="text-align: right; width: 100%; margin-top: 10px;">
                        <span class="popupdrilllblbox">
                            <asp:Button ID="btncasingOk" runat="server" Text="OK" OnClientClick="return Casingvariationtotlavalue()" /></span>&nbsp&nbsp;<span
                                class="drillpopupgrantbox"><asp:TextBox ID="txtpopupcasinggrandtotal" runat="server"
                                    Text="0.00" Width="100px"></asp:TextBox></span>&nbsp;&nbsp;<span class="popupdrilllblbox">Grand
                                        Total</span>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
