<%@ Page Title="" Language="C#" MasterPageFile="~/OwnDoneFolders/MasterPages/user.Master"
    AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="OwnDone.OwnDoneFolders.UserPages.category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="categoria" runat="server" Width="100%">
                <table id="cabecalho_manutencao" border="0" cellpadding="0" cellspacing="2">
                    <tr>
                        <td>
                            <asp:Button ID="btnDeletaCategoria" runat="server" Text="Excluir" 
                                CssClass="btnNormal" onclick="btnDeletaCategoria_Click"  />
                        </td>
                        <td>
                            <asp:Button ID="btnNovoProjeto" runat="server" Text="Novo Projeto" 
                                CssClass="btnDestaque" onclick="btnNovoProjeto_Click" />
                        </td>
                    </tr>
                </table>
                <strong><asp:Label ID="lblCategoriaNome" runat="server" Text=""></asp:Label></strong>
                <br />
                <br />
                <asp:DataList ID="projetos" runat="server" Width="100%" 
                    onitemdatabound="projetos_ItemDataBound">
                    <ItemTemplate>
                        <asp:HiddenField ID="idProjeto" runat="server" Value='<%# Eval("id") %>'/>
                        <table id="cabecalho_manutencao" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <a href="" runat="server" id="editarProjetoLink">Editar</a>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <a href="" runat="server" id="projetoLink">
                                    <strong>    
                                        <asp:Label ID="lblDoneTitulo" runat="server" Text='<%# Eval("nome") %>'></asp:Label></strong></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblProjetoDescricao" runat="server" Text='<%# Eval("descricao") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
