<%@ Page Title="" Language="C#" MasterPageFile="~/OwnDoneFolders/MasterPages/user.Master"
    AutoEventWireup="true" CodeBehind="editproject.aspx.cs" Inherits="OwnDone.OwnDoneFolders.UserPages.editproject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../../OwnDoneFolders/Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../../../OwnDoneFolders/Scripts/jquery.MultiFile.js" type="text/javascript"></script>
    <script type="text/javascript">
        function showDiv() {
            document.getElementById('upload-hide-div').style.display = "";
            setTimeout('document.images["upload-loader"].src = "../../../OwnDoneFolders/Gifs/imagem-loader.gif"', 200);
        }
        function BrowseImagem() {
            var fileUpload = document.getElementById("<%= fuImagems.ClientID %>");
            fileUpload.click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnEnviarImagens" />
            <asp:PostBackTrigger ControlID="btnEnviarVideo" />
        </Triggers>
        <ContentTemplate>
            <table id="cabecalho_manutencao">
                <tr>
                    <td>
                        <asp:Button ID="btnExcluirProjeto" runat="server" Text="Excluir Projeto" CssClass="btnNormal"
                            OnClick="btnExcluirProjeto_Click" />
                    </td>
                </tr>
            </table>
            <strong>Edição Projeto</strong>
            <br />
            <br />
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="50%">
                                    <strong>Nome: </strong>
                                </td>
                                <td width="50%">
                                    <strong>Categoria:</strong>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="50%" valign="top">
                                    <asp:TextBox ID="txtNome" runat="server" CssClass="input-text-normal" Width="95%"></asp:TextBox>
                                </td>
                                <td width="50%" valign="top">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="80%" valign="top">
                                                            <asp:DropDownList ID="cmbCategoria" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="20%" align="right">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Descrição:</strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtDescricao" runat="server" Width="97%" CssClass="input-text-normal"
                            Height="80px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSalvarCategoria" runat="server" Text="Salvar" CssClass="btnDestaque"
                            OnClick="btnSalvarCategoria_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Imagens:</strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellpadding="0" border="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="120px" valign="top">
                                                Adicionar Imagens:
                                                <!--<input id="btnAdicImagems" type="button" value="Adicionar Imagens" onclick="BrowseImagem();" class="btnNormal"/> -->
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="fuImagems" runat="server" class="multi" ClientIDMode="Static" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td valign="middle">
                                                <asp:Button ID="btnEnviarImagens" runat="server" Text="Enviar" ClientIDMode="Static"
                                                    CssClass="btnNormal" OnClick="btnEnviarImagens_Click" OnClientClick="return showDiv();" />
                                                <asp:Label ID="lblEnviaImagens" runat="server"></asp:Label>
                                                <span id="upload-hide-div" style="display: none;">
                                                    <img src="../../../OwnDoneFolders/Gifs/imagem-loader.gif" id="upload-loader" alt="" />
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:DataList ID="imagens" runat="server" RepeatDirection="Horizontal" Width="100%"
                                        RepeatColumns="4" OnItemDataBound="imagens_ItemDataBound" HorizontalAlign="Center"
                                        CellSpacing="4" DataKeyField="id" OnDeleteCommand="imagens_DeleteCommand" ItemStyle-Width="140px"
                                        ItemStyle-Height="100px">
                                        <ItemStyle Height="100px" HorizontalAlign="Center" VerticalAlign="Middle" Width="170px" />
                                        <ItemTemplate>
                                            <table id="cabecalho_manutencao" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="lnkImagemDelete" runat="server" EnableTheming="True" CommandName="delete">
                                                            <img src="../../../OwnDoneFolders/BotoesImagens/delete.png" alt="" width="13" height="13" style="border: 0;" onmouseover="poeDestaquePai(this, 6)" onmouseout="tiraDestaquePai(this, 6)" />
                                                        </asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td align="center">
                                                        <asp:HiddenField ID="fileName" runat="server" Value='<%# Eval("filename") %>' />
                                                        <asp:Image ID="imagem" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Vídeos:</strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="120px" valign="top">
                                                Adicionar Vídeo:
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="fuVideo" runat="server" ClientIDMode="Static" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Título:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtVideoTitulo" runat="server" CssClass="input-text-normal" Width="400px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Descrição:
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtVideoDesc" runat="server" CssClass="input-text-normal" Height="160px"
                                                    TextMode="MultiLine" Width="400px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnEnviarVideo" runat="server" Text="Enviar" ClientIDMode="Static"
                                                    CssClass="btnNormal" OnClick="Button1_Click" />
                                                <asp:Label ID="lblEnviaVideo" runat="server"></asp:Label>
                                                <span id="Span1" style="display: none;">
                                                    <img src="../../../OwnDoneFolders/Gifs/imagem-loader.gif" id="Img1" alt="" />
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Audio:</strong>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Arquivos:</strong>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Links:</strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="120px" valign="midle">
                                    Link:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLink" runat="server" CssClass="input-text-normal" 
                                        Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="120px" valign="midle">
                                    Descrição:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLinkDesc" runat="server" CssClass="input-text-normal" 
                                        Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>    
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnSalvarLink" runat="server" Text="Incluir" 
                                        CssClass="btnNormal" onclick="btnSalvarLink_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:DataList ID="links" runat="server" Width="97%" DataKeyField="id" 
                                        ondeletecommand="links_DeleteCommand">
                                        <ItemTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td width="98%">
                                                        <asp:Label ID="lblLink" runat="server" Text='<%# Eval("descricao") %>'></asp:Label>
                                                    </td>
                                                    <td width="2%">
                                                        <asp:LinkButton ID="lnkLinkDelete" runat="server" EnableTheming="True" CommandName="delete">
                                                            <img src="../../../OwnDoneFolders/BotoesImagens/delete.png" alt="" width="13" height="13" style="border: 0;" onmouseover="poeDestaquePai(this, 6)" onmouseout="tiraDestaquePai(this, 6)" />
                                                        </asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
