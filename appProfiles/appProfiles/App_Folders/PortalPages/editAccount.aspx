<%@ Page Title="" Language="C#" MasterPageFile="~/App_Folders/PortalMasterPages/mPage1.Master" AutoEventWireup="true" CodeBehind="editAccount.aspx.cs" Inherits="appProfiles.App_Folders.PortalPages.editAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtMBirh" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtDBirh" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtYBirh" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSavePersonalInfo" runat="server" Text="Save" 
                    onclick="btnSavePersonalInfo_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
