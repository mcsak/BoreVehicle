<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vendor.aspx.cs" Inherits="Source.Master.Vendor"
    MasterPageFile="~/InnerMaster.Master" %>

<asp:Content ID="VendorHeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
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
<asp:Content ID="VendorBodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
<asp:UpdatePanel ID="updpnlMainContentVendor" runat="server" UpdateMode="Conditional">
<ContentTemplate>
 <asp:UpdateProgress ID="UpdateProgress_updpnlMainContentVendor" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="updpnlMainContentVendor">
<ProgressTemplate> 
<div class="ProgressPageOverlay">
<asp:Image ID="imgloaderupdpnlMainContentVendor" CssClass="ProgressImage" runat="server" ImageUrl="~/Images/loader.gif" />
</div>
</ProgressTemplate>
</asp:UpdateProgress>
    <div class="centermaincontaineryle">
        <div class="centertitleheader" runat="server" id="HeaderTitle">
            Vendor - Add
        </div>
        <div  class="divViewAllList"  runat="server" id="ViewAllDetails">
            <asp:Button ID="btnViewAll" runat="server" Text="View All"  
                 onclick="btnViewAll_Click" CausesValidation="false"
                 />
        </div>
        <div class="mastercentercontainer">
            <div class="divmastersinglecontainer">
                <div class="divmasterleftcontainer">
                    Vendor Name</div>
                <div class="divmasterrightcontainer">
                    <asp:TextBox ID="txtVendor" runat="server" Width="180px" MaxLength="100"></asp:TextBox>
                     <asp:RequiredFieldValidator runat="server" ID="Required_txtVendor" ControlToValidate="txtVendor" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                    
                    </div>
            </div>
             <div class="divmastersinglecontainer">
                <div class="divmasterleftcontainer">
                    Vendor Contact</div>
                <div class="divmasterrightcontainer">
                    <asp:TextBox ID="txtContact" runat="server" Width="180px" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="Required_txtContact" ControlToValidate="txtContact" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                    </div>
            </div>
             <div class="divmastersinglecontainer">
                <div class="divmasterleftcontainer">
                    Vendor Address</div>
                <div class="divmasterrightcontainer">
                    <asp:TextBox ID="txtAddress" runat="server" Width="240px" Height="50px" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                     <asp:RequiredFieldValidator runat="server" ID="Required_txtAddress" ControlToValidate="txtAddress" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                    </div>
            </div>
             <div class="divmastersinglecontainer">
                <div class="divmasterleftcontainer">
                    Others</div>
                <div class="divmasterrightcontainer">
                    <asp:TextBox ID="txtOthers" runat="server" Width="240px" Height="50px" TextMode="MultiLine" MaxLength="250"></asp:TextBox>
                      <asp:RequiredFieldValidator runat="server" ID="Required_txtOthers" ControlToValidate="txtOthers" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                    </div>
            </div>
            <div class="divmastersinglecontainer">
                <div class="divmasterleftcontainer">
                    &nbsp;</div>
                <div class="divmasterrightcontainer">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                        onclick="btnSubmit_Click" />&nbsp;<asp:Button ID="btnBack"
                        runat="server" Text="Cancel" onclick="btnBack_Click" CausesValidation="false" />
                </div>
            </div>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
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
            Vendor Details
        </div>
        <div class="viewallinnercontainerpopup">   
                        <div id="divDateAndView">
                <hr style="margin:0 0 0 0;" />
                <div>
                 <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                 <asp:Image ID="imgFromDate" runat="server" ImageUrl="~/Images/calendar.gif" />
        <ajx:CalendarExtender ID="CalendarExtenderFrom" runat="server" TargetControlID="txtFromDate" CssClass="MyCalendarPopup" PopupButtonID="imgFromDate" Format="MM-yyyy" OnClientShown="onCalendarShown">
        
        </ajx:CalendarExtender> &nbsp;&nbsp;<asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
        <asp:Image ID="imgToDate" runat="server" ImageUrl="~/Images/calendar.gif" />
        <ajx:CalendarExtender ID="CalendarExtenderTo" runat="server" TargetControlID="txtToDate" CssClass="MyCalendarPopup" PopupButtonID="imgToDate" Format="MM-yyyy" OnClientShown="onCalendarShown">
        </ajx:CalendarExtender>&nbsp;<asp:Button ID="btnGo" runat="server" Text="Go" CssClass="btnCommonGOstyle" OnClick="BtnGo_Click" CausesValidation="false" />
        <div style="float:right;text-align:right;color:Red;">Select any one date of your month.</div>
                </div>
                <hr style="margin:0 0 0 0;" />
                <div style="height:10px"></div>
                </div>         
            <div>
                <asp:GridView ID="gvVehicleDetails" runat="server" SkinID="PopupViewAllGrid" Width="100%"
                    PagerStyle-Height="30px">
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
                                <asp:Label ID="lblVName" runat="server" Text='<%#Eval("VendorName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contact" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVContact" runat="server" Text='<%#Eval("VendorContact") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVAddress" runat="server" Text='<%#Eval("VendorAddress") %>'></asp:Label>
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
