<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="userHeader1.ascx.cs"
    Inherits="appProfiles.App_Folders.UserUserControl.userHeader1" %>
<style type="text/css">
    .style1
    {
        width: 28px;
    }
</style>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div id="header-info">
            <table width="100%" border="0" cellpadding="0" cellspacing="2">
                <tr>
                    <td>
                        <asp:Label ID="lblUserName" runat="server" Text="User Name" CssClass="highlight"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAge" runat="server" Text="Label" CssClass="header-detail"></asp:Label><asp:Label
                            ID="lblYaers" runat="server" Text="Label" CssClass="header-detail"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTitle" runat="server" Text="Title" CssClass="header-description"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div id="header-functions">
            <table>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Like
                    </td>
                </tr>
            </table>
        </div>
        <div id="header-links">
            <table border="0" cellpadding="0" cellspacing="5">
                <tr>
                    <td>
                        <img src="Imagens/facebook.png" width="32" height="32" />
                    </td>
                    <td>
                        <img src="Imagens/linkedin.png" width="32" height="32" />
                    </td>
                    <td>
                        <img src="Imagens/blogspot.png" width="32" height="32" />
                    </td>
                    <td>
                        <img src="Imagens/twitter.png" width="32" height="32" />
                    </td>
                    <td class="style1">
                        <img src="Imagens/wordpress.png" width="32" height="32" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="header-language">
            <div id="menu-language" align="center">
                <ul>
                    <li>
                        <asp:Label ID="lblLanguage" runat="server" Text="Selected Language" CssClass="menu-selected-language"></asp:Label>
                        <ul>
                            <li>
                                <asp:DataList ID="profileLanguages" runat="server" Width="100%" 
                                    DataKeyField="idlanguage" onitemcommand="profileLanguages_ItemCommand" >
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center">
                                                <asp:LinkButton ID="lnkLanguage" runat="server" CssClass="menu-other-language" CommandName="Select"><%# Eval("name") %></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:DataList>
                            </li>
                        </ul>
                    </li>
                </ul>
                <div id="clear">
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
