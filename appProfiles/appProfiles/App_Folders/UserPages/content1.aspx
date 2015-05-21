<%@ Page Title="" Language="C#" MasterPageFile="~/App_Folders/UserMasterPages/mPage1.Master"
    AutoEventWireup="true" CodeBehind="content1.aspx.cs" Inherits="appProfiles.App_Folders.UserPages.content1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="99%">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="2" border="0" width="99%">
                            <tr>
                                <td align="left">
                                    <asp:ImageButton ID="btnDeleteContent" runat="server" Style="float: right;" Height="22px"
                                        ImageUrl="~/App_Folders/PortalImageButtons/trashCan.png" Width="22px" />
                                    <div id="menu-add-section" align="center">
                                        <ul>
                                            <li>
                                                <asp:Label ID="lblAdd" runat="server" Text="Add" CssClass="menu-selected-language"></asp:Label>
                                                <ul>
                                                    <li>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="lnkAddText" runat="server" onclick="lnkAddText_Click">Text</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="lnkAddSubTitle" runat="server" 
                                                                        onclick="lnkAddSubTitle_Click">Subtitle</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="lnkAddPhoto" runat="server">Photo</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </li>
                                                </ul>
                                            </li>
                                        </ul>
                                        <div id="clear">
                                        </div>
                                    </div>
                                    <asp:Label ID="lblContentName" runat="server" Text="Content Name" CssClass="page-name"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:TextBox ID="txtContentName" runat="server"></asp:TextBox>
                                    <asp:Button ID="btnSaveContent" runat="server" ClientIDMode="Static" OnClick="btnSaveContent_Click"
                                        Style="display: none;" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Repeater ID="sections" runat="server" OnItemDataBound="sections_ItemDataBound">
                            <ItemTemplate>
                                <div runat="server" id="holder">
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div id="clear"></div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="add_section_div" runat="server">
                        </div>
                        <div id="clear"></div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
