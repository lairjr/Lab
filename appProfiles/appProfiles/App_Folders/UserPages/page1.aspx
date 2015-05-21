<%@ Page Title="" Language="C#" MasterPageFile="~/App_Folders/UserMasterPages/mPage1.Master" AutoEventWireup="true" CodeBehind="page1.aspx.cs" Inherits="appProfiles.App_Folders.UserPages.page1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="2" border="0" width="99%">
                <tr>
                    <td align="left">
                        <asp:ImageButton ID="btnDeletePage" runat="server" style="float: right;" 
                            Height="22px" ImageUrl="~/App_Folders/PortalImageButtons/trashCan.png" 
                            onclick="btnDeletePage_Click" Width="22px"/>
                        <asp:Button ID="btnNewContent" runat="server" Text="New Content" 
                            style="float: right;" CssClass="btnDestaque" 
                            onclick="btnNewContent_Click"  />
                        <asp:Label ID="lblPageName" runat="server" Text="Page Name" CssClass="page-name"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">   
                        <asp:TextBox ID="txtPageName" runat="server"></asp:TextBox>
                        <asp:Button ID="btnSavePage" runat="server" ClientIDMode="Static" 
                            onclick="btnSavePage_Click" style="display: none;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <asp:DataList ID="contents" runat="server" 
                    onitemdatabound="contents_ItemDataBound">
                    <ItemTemplate>
                    <tr>
                        <td align="left">
                            <a id="contentLink" href="#" runat="server"><span class="menu"><%# Eval("title") %></span></a>
                            <asp:HiddenField ID="idContent" runat="server" Value='<%# Eval("idcontent") %>' />
                            <asp:HiddenField ID="idPage" runat="server" Value='<%# Eval("idpage") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("title") %>'></asp:Label>
                        </td>
                    </tr>
                    </ItemTemplate>
                </asp:DataList>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
