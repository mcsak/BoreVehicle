<%@ Page Title="Inward Casing" Language="C#" MasterPageFile="~/InnerMaster.Master" AutoEventWireup="true" CodeBehind="InwardCasingGrid.aspx.cs" Inherits="Source.Casing.InwardCasingGrid" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script src="../Scripts/jquery-1.5.1.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function isRecordSelected(str) {
        alert("dsfdsf");
        var element = document.getElementById('ctl00_ContentPlaceHolderMain_gvInwardCasing').getElementsByTagName('input');
        for (var i = 0; i < element.length; i++)
            if (element[i].type === 'radio')
                if (element[i].checked == true)
                    return true;
        $('div[id$=warningmsg]').css({ 'visibility': 'visible', 'display': 'block' });
        $('div[id$=war]').html('').html('Select a record to ' + str + '.');
        alert("kjhkhk");
        return false;
    }
    function gridsearchvalidation() {
        alert("kjkhkhk");
        if (document.getElementById("ctl00_ContentPlaceHolderMain_ddlsearchby").selectedIndex == 0) {
            $('div[id$=warningmsg]').css({ 'visibility': 'visible', 'display': 'block' });
            $('div[id$=war]').html('').html('Select a search by.');
            return false;
        }
        if (document.getElementById("ctl00_ContentPlaceHolderMain_txtsearch").value == "") {
            $('div[id$=warningmsg]').css({ 'visibility': 'visible', 'display': 'block' });
            $('div[id$=war]').html('').html('Enter the search text.');
            document.getElementById("ctl00_ContentPlaceHolderMain_txtsearch").focus();
            return false;
        }
    }

</script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
 <div class="centertitleheader">
       Inward Casing
    </div>
    <div class="admingriCenterContainer">
        
                <div class="adminCommonGridContainer">
                    <div class="admingridsearchcontainer" style="height: 25px;">
                        <div class="pro_ddl_search">
                            <asp:DropDownList ID="ddlsearchby" runat="server" Width="157px" Height="20px" TabIndex="1">
                                <asp:ListItem Text="<--Select-->" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Vendor" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Date" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Billed Amount" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="pro_searchtext">
                            <span class="gridsearch_txt">
                                <asp:TextBox ID="txtsearch" runat="server" TabIndex="2" MaxLength="50" Height="16px"
                                    Width="162px"></asp:TextBox>
                            </span><span class="gridsearch_pic">
                                <asp:ImageButton ID="imgSearch" runat="server" Height="20px" Width="23px" TabIndex="3"
                                    OnClientClick="return gridsearchvalidation()" CommandArgument="S" ImageAlign="Top"
                                    ToolTip="Go" ImageUrl="~/Images/searchicongrid.png" OnClick="imgSearch_Click" />
                            </span>
                        </div>
                        <div class="gridbtncontainer">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Modify" OnClick="btnModify_Click" OnClientClick="return isRecordSelected('modify')" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="return isRecordSelected('delete')" />
                        </div>
                    </div>
                    <div class="admingridcontainer">
                        <asp:GridView ID="gvInwardCasing" runat="server" Width="100%" PagerStyle-Height="30px" OnPageIndexChanging="gvInwardCasing_SelectedIndexChanged" OnSorting="gvInwardCasing_Sorting"> 
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
                                        <asp:RadioButton ID="optionID" runat="server"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="CasingDate|2">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Casingdate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="6%" ItemStyle-Width="6%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="CasingQuantity|3">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("CasingQuantity") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Billed Amount" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="BilledAmount|4">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVehilno" runat="server" Text='<%#Eval("BilledAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vendor" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="VendorName|5">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendor" runat="server" Text='<%#Eval("VendorName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reamarks" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                      <asp:Label ID="lblPerson" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
           
    </div>
</asp:Content>
