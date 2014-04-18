<%@ Page Title="Stock Management" Language="C#" MasterPageFile="~/InnerMaster.Master" AutoEventWireup="true" 
CodeBehind="StockManagement.aspx.cs" Inherits="Source.Reports.StockManagement" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">

</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
 <div class="centertitleheader" id="divTitle" runat="server">
       Stock Details
    </div>
    <div class="admingriCenterContainer">
        
                <div class="adminpagegridcontainer">
                    <div class="admingridsearchcontainer" style="height: 25px; visibility:hidden;">
                        <div class="pro_ddl_search">
                            <asp:DropDownList ID="ddlsearchby" runat="server" Width="157px" Height="20px" TabIndex="1">
                                <asp:ListItem Text="--Select---"></asp:ListItem>
                                <asp:ListItem Text="Bill Status" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Date" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Point No" Value="1"></asp:ListItem>
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
                            
                        </div>
                    </div>
                    <div class="admingridcontainer">
                        <asp:GridView ID="gvStockManagement" runat="server" Width="100%" PagerStyle-Height="30px" AutoGenerateColumns="false" > 
                            <Columns>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblno" SkinID="gridlbl" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Size" HeaderText="Size" />
                                <asp:BoundField DataField="AvailableQty" HeaderText="Available Qty." />
                                <asp:BoundField DataField="VehicleNumber" HeaderText="Vehicle Number" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
           
    </div>
</asp:Content>
