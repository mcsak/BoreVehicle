<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommonFundManagementGrid.aspx.cs" MasterPageFile="~/InnerMaster.Master"    Inherits="Source.General.CommonFundManagementGrid" %>


<asp:Content ID="HeadContent" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script src="../Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function isRecordSelected(str) {
        var element = document.getElementById('ctl00_ContentPlaceHolderMain_gvCommonFund').getElementsByTagName('input');
        for (var i = 0; i < element.length; i++)
            if (element[i].type === 'radio')
                if (element[i].checked == true)
                    return true;
        $('div[id$=warningmsg]').css({ 'visibility': 'visible', 'display': 'block' });
        $('div[id$=war]').html('').html('Select a record to ' + str + '.');
        return false;
    }
    

</script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
 <div class="centertitleheader">
       Common Fund  Management 
    </div>
    <div class="admingriCenterContainer" >
        
                <div class="adminCommonGridContainer">
                     <div class="admingridsearchcontainer" style="height: 25px;">
                        
                        <div class="gridbtncontainer">
                            <asp:Button ID="btnTransfer" runat="server" Text="Transfer" 
                                PostBackUrl="~/General/CommonFundManagement.aspx"  />
                        </div>
                    </div>
                    <div class="admingridcontainer">
                        <asp:GridView ID="gvCommonFund" runat="server" Width="100%" PagerStyle-Height="30px" OnPageIndexChanging="gvCommonFund_SelectedIndexChanged" OnSorting="gvCommonFund_Sorting"> 
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblno" SkinID="gridlbl" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Select" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                      <input type="radio" id="optionID" name="optionID" value='<%#Eval("VehicleID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vehicle Number" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="VehicleNumber|2">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVehicleNumber" runat="server" Text='<%#Eval("VehicleNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vehicle Name" HeaderStyle-Width="6%" ItemStyle-Width="6%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Name|3">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVehicleName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Amount|4">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                             
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
           
    </div>
</asp:Content>