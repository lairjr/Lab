<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="userMenu1.ascx.cs" Inherits="appProfiles.App_Folders.UserUserControl.userMenu1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <ul id="menu-buttons">
            <li><a runat="server" id="lnkHome" class="menu-buttons-first-li"><span class="menu" onmouseover="poeDestaquePai(this, 2)"
                onmouseout="tiraDestaquePai(this, 2)">Home</span></a></li>
            <li><a runat="server" id="lnkContact" href="" class="menu-buttons-rest-a"><span onmouseover="poeDestaquePai(this, 2)"
                onmouseout="tiraDestaquePai(this, 2)">
                <asp:Label ID="lblContact" runat="server" Text="Contact" CssClass="menu"></asp:Label></span></a></li>
            <li><a runat="server" id="lnkResume" href="#" class="menu-buttons-rest-a"><span onmouseover="poeDestaquePai(this, 2)"
                onmouseout="tiraDestaquePai(this, 2)"><asp:Label ID="lblResume" runat="server" Text="Resumé" CssClass="menu"></asp:Label></span></a></li>
            <asp:Repeater ID="pages" runat="server" onitemdatabound="pages_ItemDataBound">
                <ItemTemplate>
                    <li><a id="pageLink" href="#" class="menu-buttons-rest-a" runat="server"><span class="menu" onmouseover="poeDestaquePai(this, 2)"
                        onmouseout="tiraDestaquePai(this, 2)"><%# Eval("name") %></span></a></li>
                    <asp:HiddenField ID="idPage" runat="server" Value='<%# Eval("idpage") %>' />
                </ItemTemplate>
            </asp:Repeater>
            <li runat="server" id="novaCategoria">
                <asp:TextBox ID="txtNewPage" runat="server" onfocus="entraNoCampo(this, 'New Page');"
                    onblur="saiDoCampo(this, 'New Page');" Width="130px"></asp:TextBox>
                <asp:Button ID="btnInsertPage" runat="server" Text="Insert" style=" display: none;" 
                    ClientIDMode="Static" onclick="btnInsertPage_Click" />
            </li>
        </ul>
    </ContentTemplate>
</asp:UpdatePanel>
