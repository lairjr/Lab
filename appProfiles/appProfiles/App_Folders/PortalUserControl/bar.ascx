<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bar.ascx.cs" Inherits="appProfiles.App_Folders.PortalUserControl.bar" %>
<div id="bar">
    <table cellpadding="0" border="0" cellspacing="0" width="100%">
        <tr>
            <td align="center">
                <table width="900px" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td width="80px">
                            appProfiles
                        </td>
                        <td width="740px">
                        </td>
                        <td width="80px" valign="middle">
                            <asp:Panel ID="notLogged" runat="server">
                                <div id="login-bar" align="center">
                                    <ul>
                                        <li>Login
                                            <ul>
                                                <li id="invisible-id">&nbsp; </li>
                                                <li>
                                                    <table border="0px" cellpadding="5px" cellspacing="5px" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table border="0px" cellpadding="0px" cellspacing="0px" width="100%">
                                                                    <tr>
                                                                        <td align="center" width="50%">
                                                                            <asp:Button ID="btnLogar" runat="server" Text="Login" CssClass="btnDestaque" OnClick="btnLogar_Click" />
                                                                        </td>
                                                                        <td align="center" width="50%">
                                                                            <asp:Label ID="lblSignUp" runat="server" Text="Sign Up"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </li>
                                            </ul>
                                        </li>
                                    </ul>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="logged" runat="server">
                                <div id="login-bar" align="center">
                                    <ul>
                                        <li>Account
                                            <ul>
                                                <li id="invisible-id">&nbsp; </li>
                                                <li>
                                                    <table border="0px" cellpadding="5px" cellspacing="5px" width="100%">
                                                        <tr>
                                                            <td>
                                                                <a id="lnkMyProfile" href="" runat="server">
                                                                    <asp:Label ID="lblMyProfile" runat="server" Text="My Profile"></asp:Label></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Configurações
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="lnkLogOut" runat="server" onclick="lnkLogOut_Click">Log Out</asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </li>
                                            </ul>
                                        </li>
                                    </ul>
                                </div>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
