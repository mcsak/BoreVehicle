<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Balance.aspx.cs" Inherits="Source.Report.Balance"
    MasterPageFile="~/InnerMaster.Master" %>

<asp:Content ID="InwardHeadContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">
    <link href="../CSS/Report.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../Scripts/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" language="javascript">
        function showdetail() {
            $('.divPopupBackground').css({ 'height': (document.documentElement.scrollHeight | document.body.scrollHeight) + 150 + 'px', 'display': 'block' });
            $('.showBalanceDetailpopup').css({
                'top': (document.documentElement.scrollTop | document.body.scrollTop) + 80,
                'left': 330,
                'z-Index': 999,
                'display': 'block'
            });
            return false;
        }

        function closepopup() {
            $('.showBalanceDetailpopup').css({ 'display': 'none' });
            $('.divPopupBackground').css({ 'display': 'none' });
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="InwardBodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">

    <div class="centertitleheader">
        Balance
    </div>
    <div class="BalanceCenterContainer">
        <asp:UpdatePanel ID="updpnl" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="adminpagegridcontainer">
                    <div class="admingridsearchcontainer" style="height: 25px;">
                        <div class="pro_ddl_search">
                            <asp:DropDownList ID="ddlsearchby" runat="server" Width="153px" Height="20px" TabIndex="1">
                                <asp:ListItem Text="--Select---"></asp:ListItem>
                                <asp:ListItem Text="Party Name"></asp:ListItem>
                                <asp:ListItem Text="Phone Number"></asp:ListItem>
                                <asp:ListItem Text="Billed Amount"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="pro_searchtext">
                            <span class="gridsearch_txt">
                                <asp:TextBox ID="txtsearch" runat="server" TabIndex="2" MaxLength="50" Height="16px"
                                    Width="160px"></asp:TextBox>
                            </span><span class="gridsearch_pic">
                                <asp:ImageButton ID="imgSearch" runat="server" Height="20px" Width="23px" TabIndex="3"
                                    OnClientClick="return gridsearchvalidation()" CommandArgument="S" ImageAlign="Top"
                                    ToolTip="Go" ImageUrl="~/Images/searchicongrid.png" 
                                onclick="imgSearch_Click" />
                                
                            </span>
                            
                        </div>
                        <%--<div class="gridbtncontainer">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Modify" OnClientClick="return isRecordSelected('modify')" />
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClientClick="return isRecordSelected('delete')" />
                        </div>--%>
                        <div style="text-align:right;padding-right:280px; padding-top:2px;">
                        <asp:LinkButton ID="lnkViewAll" runat="server" Text="View All" CausesValidation="false" 
                                onclick="lnkViewAll_Click" ></asp:LinkButton>
                        </div>
                    </div>
                    <div class="admingridcontainer">
                        <asp:GridView ID="gvBalance" runat="server" Width="100%" PagerStyle-Height="30px" AutoGenerateColumns="false" 
                        OnRowCommand="gvBalance_OnRowCommand" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging_gvBalance">
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
                                        <asp:Label ID="lblPartyName" runat="server" Text='<%#Eval("PartyName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone Number" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPhNumber" runat="server" Text='<%#Eval("PhoneNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Amount" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalName" runat="server" Text='<%#Eval("BilledAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Paid" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaid" runat="server" Text='<%#Eval("PaidAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remaining" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemaining" runat="server" Text='<%#Eval("BalanceAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Details" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkView" runat="server" Text="View" CommandName="ViewParticularLeads" 
                                        CommandArgument='<% #Eval("LeadID") %>' ></asp:LinkButton>
                                        
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="showBalanceDetailpopup">
        <div class="reportclose">
            <img class="divClose" id="Img1" runat="server" src="~/Images/CloseIcon16.png" alt=""
                onclick="return closepopup()" />
        </div>
        <asp:UpdatePanel ID="updpnlpopup" runat="server" UpdateMode="Conditional">
        <ContentTemplate>       
        
        <div class="balancepopupheaderheader">
            Balance Detail
        </div>
        <div class="balanceinnercontainerpopup">
            <div class="balancedetailpopcontent">
                <div class="balancepopsingle">
                    Point No: <asp:Label ID="lblPointNumbetrVal" runat="server" ></asp:Label>
                </div>
                <div class="balancepopsingle">
                    Total Amount: <asp:Label ID="lblAmountTotalVal" runat="server" ></asp:Label>
                </div>
                <div class="balancepopsingle">
                    Paid Amount: <asp:Label ID="lblAmountPaidVal" runat="server" ></asp:Label>
                </div>
                <div class="balancepopsingle">
                    Remainig Amount: <asp:Label ID="lblAmountRemainingVal" runat="server" ></asp:Label>
                </div>
            </div>
            <div>
            <asp:GridView ID="gvBalanceDetails" runat="server" Width="100%"
                    PagerStyle-Height="30px">
                    <Columns>
                        <asp:TemplateField HeaderText="#" HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblno" SkinID="gridlbl" runat="server" Text="<%# Container.DataItemIndex+1 %>"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblDate" runat="server" Text='<%#Eval("PaidDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Paid" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblPaid" runat="server" Text='<%#Eval("PaidAmount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remaining" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblRemaining" runat="server" Text='<%#Eval("BalanceAmount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        
        </ContentTemplate>
        <Triggers></Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
