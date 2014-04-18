<%@ Page Title="Vehicle" Language="C#" MasterPageFile="~/InnerMaster.Master" AutoEventWireup="true" CodeBehind="VehicleGrid.aspx.cs" Inherits="Source.Master.VehicleGrid" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
<script type="text/javascript">
    function isRecordSelected(str) {
        var element = document.getElementById('ctl00_ContentPlaceHolderMain_gvBitExpense').getElementsByTagName('input');
        for (var i = 0; i < element.length; i++)
            if (element[i].type === 'radio')
                if (element[i].checked == true)
                    return true;
        $('div[id$=warningmsg]').css({ 'visibility': 'visible', 'display': 'block' });
        $('div[id$=war]').html('').html('Select a record to ' + str + '.');

        return false;
    }
    function gridsearchvalidation() {
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
       Vehicle
    </div>
    <div class="admingriCenterContainer">
        
                <div class="adminCommonGridContainer">
                      <div class="admingridsearchcontainer" style="height: 25px;">
                        <div class="pro_ddl_search">
                            <asp:DropDownList ID="ddlsearchby" runat="server" Width="157px" Height="20px" TabIndex="1">
                                <asp:ListItem Text="--Select---" value="0"></asp:ListItem>
                                <asp:ListItem Text="Name" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Vehicle Number" Value="2"></asp:ListItem>
                               
                            </asp:DropDownList>
                        </div>
                        <div class="pro_searchtext">
                            <span class="gridsearch_txt">
                                <asp:TextBox ID="txtsearch" runat="server" TabIndex="2" MaxLength="50" Height="16px"
                                    Width="162px"></asp:TextBox>
                            </span><span class="gridsearch_pic">
                                <asp:ImageButton ID="imgSearch" runat="server" Height="20px" Width="23px" TabIndex="3"
                                    OnClientClick="return gridsearchvalidation()" CommandArgument="S" ImageAlign="Top"
                                    ToolTip="Go" ImageUrl="~/Images/searchicongrid.png" OnClick="imgSearch_Click"/>
                            </span>
                        </div>
                       <div class="gridbtncontainer">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Modify" OnClick="btnModify_Click" OnClientClick="return isRecordSelected('modify')" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" OnClientClick="return isRecordSelected('delete')" />
                        </div>
                    </div>
                    <div class="admingridcontainer">
                        <asp:GridView ID="gvVehicle" runat="server" Width="100%" PagerStyle-Height="30px"  OnPageIndexChanging="gvVehicle_SelectedIndexChanged" OnSorting="gvVehicle_Sorting"  >
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblno" SkinID="gridlbl" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Select" HeaderStyle-Width="4%" ItemStyle-Width="4%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <input type="radio" id="optionID" name="optionID" value='<%#Eval("VehicleID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Name|2">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="VehicleNumber" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="VehicleNumber|3">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNUmber" runat="server" Text='<%#Eval("VehicleNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Others" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Others|4">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Others") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
           
    </div>
</asp:Content>
