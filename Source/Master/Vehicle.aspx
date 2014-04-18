<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vehicle.aspx.cs" Inherits="Source.Master.Vehicle"
    MasterPageFile="~/InnerMaster.Master" %>

<asp:Content ID="VehicleHeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
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
<asp:Content ID="VehicleBodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
<asp:UpdatePanel ID="updpnlMainContentVehicle" runat="server" UpdateMode="Conditional">
<ContentTemplate>
 <asp:UpdateProgress ID="UpdateProgress_updpnlMainContentVehicle" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="updpnlMainContentVehicle">
<ProgressTemplate> 
<div class="ProgressPageOverlay">
<asp:Image ID="imgloaderupdpnlMainContentVehicle" CssClass="ProgressImage" runat="server" ImageUrl="~/Images/loader.gif" />
</div>
</ProgressTemplate>
</asp:UpdateProgress>
    <div class="centermaincontaineryle">
        <div class="centertitleheader" runat="server" id="HeaderTitle">
            Vehicle - Add
        </div>
         <div  class="divViewAllList"  runat="server" id="ViewAllDetails">
            <asp:Button ID="btnViewAll" runat="server" Text="View All"  
                  onclick="btnViewAll_Click" CausesValidation="false"
                 />
        </div>
        <div class="mastercentercontainer">
            <div class="divmastersinglecontainer">
                <div class="divmasterleftcontainer">
                    Vehicle No.</div>
                <div class="divmasterrightcontainer">
                    <asp:TextBox ID="txtVehicle" runat="server" Width="180px" MaxLength="25"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="Required_txtVehicle" ControlToValidate="txtVehicle" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                    </div>
            </div>
             <div class="divmastersinglecontainer">
                <div class="divmasterleftcontainer">
                   Name</div>
                <div class="divmasterrightcontainer">
                    <asp:TextBox ID="txtName" runat="server" Width="180px"  MaxLength="25"></asp:TextBox>
                     <asp:RequiredFieldValidator runat="server" ID="Required_txtName" ControlToValidate="txtName" ErrorMessage="*" 
                                    ></asp:RequiredFieldValidator>
                    
                    </div>
            </div>
             <div class="divmastersinglecontainer">
                <div class="divmasterleftcontainer">
                    Others</div>
                <div class="divmasterrightcontainer">
                    <asp:TextBox ID="txtOthers" runat="server" Width="240px" Height="50px" TextMode="MultiLine"  MaxLength="250"></asp:TextBox>
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
                        runat="server" Text="Cancel" onclick="btnBack_Click" CausesValidation="false"/>
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
            Vehicle Details
        </div>
        <div class="viewallinnercontainerpopup">  
                                <div id="divDateAndView"  >
                <hr style="margin:0 0 0 0;" />
                <div>
                 <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                 <asp:Image ID="imgFromDate" runat="server" ImageUrl="~/Images/calendar.gif" />
        <ajx:CalendarExtender ID="CalendarExtenderFrom" runat="server" TargetControlID="txtFromDate" CssClass="MyCalendarPopup" PopupButtonID="imgFromDate" Format="MM-yyyy" OnClientShown="onCalendarShown">
        
        </ajx:CalendarExtender> &nbsp;&nbsp;<asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
        <asp:Image ID="imgToDate" runat="server" ImageUrl="~/Images/calendar.gif" />
        <ajx:CalendarExtender ID="CalendarExtenderTo" runat="server" TargetControlID="txtToDate" CssClass="MyCalendarPopup" PopupButtonID="imgToDate" Format="MM-yyyy" OnClientShown="onCalendarShown">
        </ajx:CalendarExtender>&nbsp;<asp:Button ID="btnGo" runat="server" Text="Go" CssClass="btnCommonGOstyle" OnClick="BtnGo_Click" />
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
                        <asp:TemplateField HeaderText="Vehicle ID" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVName" runat="server" Text='<%#Eval("VehicleNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vehicle Name" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVContact" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Others" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVAddress" runat="server" Text='<%#Eval("Others") %>'></asp:Label>
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
