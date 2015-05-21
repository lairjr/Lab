<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usermenu.ascx.cs" Inherits="OwnDone.OwnDoneFolders.UserPages.usermenu" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <ul id="menu-botoes">
            <li><a href="../idlink" id="homeLink" runat="server">Home</a></li>
            <li><a href="../idlink/Contact" id="contactLink" runat="server">Contato</a></li>
            <li><a href="../idlink/Resume" id="resumeLink" runat="server">Currículo</a></li>
            <asp:Repeater ID="categorias" runat="server" OnItemDataBound="categorias_ItemDataBound">
                <ItemTemplate>
                    <li><a href="../idlink/Contact" id="categoryLink" runat="server">
                        <%# Eval("nome") %></a> </li>
                    <asp:HiddenField ID="idCategoria" runat="server" Value='<%# Eval("id") %>' />
                </ItemTemplate>
            </asp:Repeater>
            <li runat="server" id="novaCategoria">
                <asp:TextBox ID="txtNovaCategoria" runat="server" CssClass="input-text-normal" onfocus="entraNoCampo(this, 'Nova Categoria');"
                    onblur="saiDoCampo(this, 'Nova Categoria');" Width="130px"></asp:TextBox>
                <asp:Button ID="btnInsereCategoria" runat="server" Text="Inserir" style=" display: none;"
                    onclick="btnInsereCategoria_Click" ClientIDMode="Static" />
            </li>
        </ul>
    </ContentTemplate>
</asp:UpdatePanel>
