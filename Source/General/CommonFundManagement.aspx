<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommonFundManagement.aspx.cs"
    MasterPageFile="~/InnerMaster.Master" Inherits="Source.General.CommonFundManagement" %>

<asp:Content ID="HeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
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
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <asp:UpdatePanel ID="updpnlMainContentCommonFund" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress_updpnlMainContentCommonFund" runat="server"
                DisplayAfter="0" AssociatedUpdatePanelID="updpnlMainContentCommonFund">
                <ProgressTemplate>
                    <div class="ProgressPageOverlay">
                        <asp:Image ID="imgloaderupdpnlMainContentCommonFund" CssClass="ProgressImage" runat="server"
                            ImageUrl="~/Images/loader.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="centermaincontaineryle">
                <div class="centertitleheader" runat="server" id="HeaderTitle">
                    Fund Transfer - Add
                </div>
                <div class="divViewAllList" runat="server" id="ViewAllDetails" style="display: none;">
                    <asp:Button ID="btnView" runat="server" Text="View All" OnClick="btnView_Click" CausesValidation="false" />
                </div>
                <div class="mastercentercontainer">
                    <div class="divmastersinglecontainer">
                        <div class="divmasterleftcontainer">
                            From Vehicle Number/Common Fund</div>
                        <div class="divmasterrightcontainer">
                            <asp:DropDownList ID="ddlVehicle" runat="server" Width="180px" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlVehicle_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="Required_ddlVehicle" runat="server" ControlToValidate="ddlVehicle"
                                InitialValue="<--Select-->" ErrorMessage="*" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="divmastersinglecontainer">
                        <div class="divmasterleftcontainer">
                            Vehicle Name</div>
                        <div class="divmasterrightcontainer">
                            <asp:Label ID="lblVehicleName" runat="server" Text="" Font-Size="15px"></asp:Label>
                        </div>
                    </div>
                    <div class="divmastersinglecontainer">
                        <div class="divmasterleftcontainer">
                            Available Amount</div>
                        <div class="divmasterrightcontainer">
                            <asp:Label ID="lblAvailableAmount" runat="server" Text="" Font-Size="15px"></asp:Label></div>
                    </div>
                    <div class="divmastersinglecontainer">
                        <div class="divmasterleftcontainer">
                            To Vehicle Number/Common Fund</div>
                        <div class="divmasterrightcontainer">
                            <asp:DropDownList ID="ddlCommonVehicle" runat="server" Width="180px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="Required_ddlCommonVehicle" runat="server" ControlToValidate="ddlCommonVehicle"
                                InitialValue="<--Select-->" ErrorMessage="*" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="divmastersinglecontainer">
                        <div class="divmasterleftcontainer">
                            Transfer Amount</div>
                        <div class="divmasterrightcontainer">
                            <asp:TextBox ID="txtTransferAmount" runat="server" Width="180px"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="Required_txtTransferAmount" ControlToValidate="txtTransferAmount"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Compare_txtTransferAmount" runat="server" ControlToValidate="txtTransferAmount"
                                SetFocusOnError="true" Display="Dynamic" Type="Double" Operator="DataTypeCheck"
                                ErrorMessage="*" ToolTip="Please enter a valid numbers."></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="divmastersinglecontainer">
                        <div class="divmasterleftcontainer">
                            &nbsp;</div>
                        <div class="divmasterrightcontainer">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;<asp:Button
                                ID="btnBack" runat="server" Text="Cancel" PostBackUrl="~/General/CommonFundManagementGrid.aspx"
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
                    Common Fund Detail
                </div>
                <div class="viewallinnercontainerpopup">
                    <div id="divDateAndView" style="display: none;">
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
                        <asp:GridView ID="gvCommonFundDetails" runat="server" SkinID="PopupViewAllGrid" Width="100%"
                            PagerStyle-Height="30px">
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblno" SkinID="gridlbl" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Labour Name" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLName" runat="server" Text='<%#Eval("LaberName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLContact" runat="server" Text='<%#Eval("LaberContact") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLAddress" runat="server" Text='<%#Eval("LaberAddress") %>'></asp:Label>
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
