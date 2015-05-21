<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="signForm.ascx.cs" Inherits="appProfiles.App_Folders.PortalUserControl.signForm" %>
<table>
    <tr>
        <td>
            First Name:
        </td>
        <td>
            <asp:TextBox ID="txtFName" runat="server" meta:resourcekey="txtFNameResource1"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Second Name:
        </td>
        <td>
            <asp:TextBox ID="txtLName" runat="server" meta:resourcekey="txtLNameResource1"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            E-mail:
        </td>
        <td>
            <asp:TextBox ID="txtEMail" runat="server" meta:resourcekey="txtEMailResource1"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Account Name:</td>
        <td>
            <asp:TextBox ID="txtAccountName" runat="server" 
                meta:resourcekey="txtEMailResource1"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Password:
        </td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" 
                meta:resourcekey="txtPasswordResource1"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Password Confirmation:
        </td>
        <td>
            <asp:TextBox ID="txtPasswordConfirmation" runat="server" 
                meta:resourcekey="txtPasswordConfirmationResource1"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            
        </td>
        <td>
            <asp:Button ID="btnSendData" runat="server" Text="Send" 
                meta:resourcekey="btnSendDataResource1" onclick="btnSendData_Click" />
        </td>
    </tr>
</table>