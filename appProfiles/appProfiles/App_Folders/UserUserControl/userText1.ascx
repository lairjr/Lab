<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="userText1.ascx.cs" Inherits="appProfiles.App_Folders.UserUserControl.userText1" %>
<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:Label ID="lblText" runat="server" Text="Text" CssClass="section-text"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtText" runat="server" Height="89px" TextMode="MultiLine" 
                Width="368px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnSaveText" runat="server" onclick="btnSaveText_Click" 
                Text="Save Text" />
        </td>
    </tr>
</table>