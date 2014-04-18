<%@ Page Title="Bit Expenses" Language="C#" MasterPageFile="~/InnerMaster.Master" AutoEventWireup="true" CodeBehind="BitExpensesGrid.aspx.cs" Inherits="Source.Expenses.BitExpensesGrid" %>
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
        Bit Expenses
    </div>
    <div class="admingriCenterContainer">
        
                <div class="adminpagegridcontainer">
                    <div class="admingridsearchcontainer" style="height: 25px;">
                        <div class="pro_ddl_search">
                            <asp:DropDownList ID="ddlsearchby" runat="server" Width="157px" Height="20px" TabIndex="1">
                                <asp:ListItem Text="<--Select-->" Value="0"></asp:ListItem>
                                 <asp:ListItem Text="Vendo rName" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Date" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Payment Status" Value="3"></asp:ListItem>
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
                        <asp:GridView ID="gvBitExpense" runat="server" Width="100%" PagerStyle-Height="30px" OnPageIndexChanging="gvBitExpense_SelectedIndexChanged" OnSorting="gvBitExpense_Sorting" >
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
                                       <input type="radio" value='<%#Eval("BitExpensesID") %>' id="optionID" name="optionID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="ExpenseDate|2">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("ExpenseDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Replaceable" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Replaceable|3">
                                    <ItemTemplate>
                                        <asp:Label ID="lblReplaceable" runat="server" Text='<%#Eval("Replaceable") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty.Bitsize 6" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="BitSize6Quantity|4">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBit6" runat="server" Text='<%#Eval("BitSize6Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty.Bitsize 6.5" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="BitSize6p5Quantity|5">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBit6p" runat="server" Text='<%#Eval("BitSize6p5Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty.Bitsize 7" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="BitSize7Quantity|6">
                                    <ItemTemplate>
                                         <asp:Label ID="lblBit7" runat="server" Text='<%#Eval("BitSize7Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Qty.Bitsize 7.5" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="BitSize7p5Quantity|7">
                                    <ItemTemplate>
                                         <asp:Label ID="lblBit7p" runat="server" Text='<%#Eval("BitSize7p5Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Qty.Bitsize 8" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="BitSize8Quantity|8">
                                    <ItemTemplate>
                                         <asp:Label ID="lblBit8" runat="server" Text='<%#Eval("BitSize8Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Payment Status" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="PaymentStatus|3">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaymnetstatus" runat="server" Text='<%#Eval("PaymentStatus") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="VendorName" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="VendorName|9">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendor" runat="server" Text='<%#Eval("VendorName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
           
    </div>
</asp:Content>
