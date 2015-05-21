<%@ Page Title="" Language="C#" MasterPageFile="~/OwnDoneFolders/MasterPages/user.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="OwnDone.OwnDoneFolders.UserPages.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .lista_contatos
        {
            float:left;
            position: relative;
        }
        .grid tr, .grid td, .grid th
        {
            border: 0px;    
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
		    <strong>Contato</strong> <br /><br />
            <asp:Panel ID="usuario_logado" runat="server">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="usuario_nao_logado" runat="server">
                <table border="0" cellpadding="0" cellspacing="2" width="100%">
                    <tr>
                        <td width="80px">
                            Nome:
                        </td>
                        <td>
                            <asp:TextBox ID="txtNome" runat="server" Width="300px" 
                                CssClass="input-text-normal"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Contato:
                        </td>
                        <td>
                            <asp:TextBox ID="txtContato" runat="server" Width="300px" 
                                CssClass="input-text-normal"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            Ou use sua conta fazendo o login
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <table width="100%" border="0" cellpadding="0" cellspacing="2">
                <tr>
                    <td width="80px" valign="top">
                        Assunto:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAssunto" runat="server" Width="300px" 
                            CssClass="input-text-normal"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        Mensagem:
                    </td>
                    <td>
                        <asp:TextBox ID="txtMensagem" runat="server" Height="100px" 
                            TextMode="MultiLine" Width="300px" CssClass="input-text-normal"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" 
                            CssClass="btnDestaque" onclick="btnEnviar_Click" />
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Panel ID="emails" runat="server" Width="242px" CssClass="lista_contatos">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <strong>Emails</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gridEmail" runat="server" onrowcreated="gridEmail_RowCreated" 
                                ShowHeader="False" BorderStyle="None" BorderWidth="0px" CellPadding="0" 
                                CssClass="grid">
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="mensagerios" runat="server" Width="242px" 
                CssClass="lista_contatos">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <strong>Mensageiros</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DataList ID="gridMensageiros" runat="server" CssClass="grid">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblTipo" runat="server" Text='<%# Eval("tipo") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblValor" runat="server" Text='<%# Eval("valor") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="telefones" runat="server" Width="242px" 
                CssClass="lista_contatos">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <strong>Telefones</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gridTelefones" runat="server"  
                                ShowHeader="False" onrowcreated="gridTelefones_RowCreated" 
                                BorderStyle="None" BorderWidth="0px" CellPadding="0" CssClass="grid">
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
