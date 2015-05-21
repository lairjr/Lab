<%@ Page Title="" Language="C#" MasterPageFile="~/App_Folders/UserMasterPages/mPage1.Master"
    AutoEventWireup="true" CodeBehind="subject1.aspx.cs" Inherits="appProfiles.App_Folders.UserPages.subject1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="2" border="0" width="99%">
                <tr>
                    <td align="left">
                        <asp:ImageButton ID="btnDeleteSection" runat="server" Style="float: right;" Height="22px"
                            ImageUrl="~/App_Folders/PortalImageButtons/trashCan.png" Width="22px" OnClick="btnDeleteSection_Click" />
                        <asp:Label ID="lblSectionName" runat="server" Text="Section Name" CssClass="page-name"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Repeater ID="Repeater1" runat="server">
                        </asp:Repeater>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
