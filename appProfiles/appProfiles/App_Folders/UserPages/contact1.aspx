<%@ Page Title="" Language="C#" MasterPageFile="~/App_Folders/UserMasterPages/mPage1.Master"
    AutoEventWireup="true" CodeBehind="contact1.aspx.cs" Inherits="appProfiles.App_Folders.UserPages.contact1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="contact" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left">
                        <asp:Label ID="lblContactMe" runat="server" Text="Contact Me" CssClass="page-name"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td width="420px">
                                    <table cellspacing="3">
                                        <tr>
                                            <td align="left" valign="middle">
                                                <asp:Label ID="lblName" runat="server" Text="Name" CssClass="page-highlight"></asp:Label>
                                            </td>
                                            <td align="left" colspan="1" rowspan="1">
                                                <asp:TextBox ID="txtName" runat="server" Width="350px" CssClass="input-text"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="middle">
                                                <asp:Label ID="lblEmail" runat="server" Text="E-Mail" CssClass="page-highlight"></asp:Label>
                                            </td>
                                            <td align="left" colspan="1" rowspan="1">
                                                <asp:TextBox ID="txtEmail" runat="server" Width="350px" CssClass="input-text"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="middle">
                                                <asp:Label ID="lblSubject" runat="server" Text="Subject" CssClass="page-highlight"></asp:Label>
                                            </td>
                                            <td align="left" colspan="1" rowspan="1">
                                                <asp:TextBox ID="txtSubject" runat="server" Width="350px" CssClass="input-text"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <asp:Label ID="lblMessage" runat="server" Text="Message" CssClass="page-highlight" style="margin-top: 3px"></asp:Label>
                                            </td>
                                            <td align="left" colspan="1" rowspan="1">
                                                <asp:TextBox ID="txtMessage" runat="server" Height="100px" TextMode="MultiLine" Width="350px"
                                                    CssClass="input-text"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left" valign="middle">
                                                <asp:Button ID="btnSendMsg" runat="server" Text="Send" 
                                                    onclick="btnSendMsg_Click" CssClass="btnNormal" />
                                                <asp:Label ID="lblResult" runat="server" style="margin-bottom: 3px;" 
                                                    CssClass="page-normal"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="left" valign="top">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
