<%@ Page Title="" Language="C#" MasterPageFile="~/OwnDoneFolders/MasterPages/user.Master"
    AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="OwnDone.OwnDoneFolders.UserPages.edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            height: 16px;
        }
        .grid tr, .grid td, .grid th
        {
            border: 0px;    
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnEnviaNovaFoto" />
            <asp:PostBackTrigger ControlID="btnGerarCartao" />
        </Triggers>
        <ContentTemplate>
            <strong>Edição de Perfil</strong>
            <br />
            <br />
            <div id="menu-tab">
                <ul>
                    <li>
                        <asp:LinkButton ID="lnkDados" runat="server" onclick="lnkDados_Click">Dados</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lnkContato" runat="server" OnClick="lnkContato_Click">Contato</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lnkFoto" runat="server" onclick="lnkFoto_Click">Foto</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lnkCartoes" runat="server" onclick="lnkCartoes_Click">Cartão</asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="lnkBio" runat="server">Sobre Mim</asp:LinkButton>
                    </li>
                </ul>
            </div>
            <asp:Panel ID="dados" runat="server" Width="100%">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="50%">
                            Primeiro Nome:
                        </td>
                        <td width="50%">
                            Sobrenome:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPNome" runat="server" Width="200px" 
                                CssClass="input-text-normal"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSNome" runat="server" Width="200px" 
                                CssClass="input-text-normal"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Data de Nascimento:
                        </td>
                        <td>
                            Nacionalidade:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="cmbNascMes" runat="server">
                                <asp:ListItem>Mês</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                            ,
                            <asp:DropDownList ID="cmbNascDia" runat="server">
                                <asp:ListItem>Dia</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>13</asp:ListItem>
                                <asp:ListItem>14</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>16</asp:ListItem>
                                <asp:ListItem>17</asp:ListItem>
                                <asp:ListItem>18</asp:ListItem>
                                <asp:ListItem>19</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>21</asp:ListItem>
                                <asp:ListItem>22</asp:ListItem>
                                <asp:ListItem>23</asp:ListItem>
                                <asp:ListItem>24</asp:ListItem>
                                <asp:ListItem>25</asp:ListItem>
                                <asp:ListItem>26</asp:ListItem>
                                <asp:ListItem>27</asp:ListItem>
                                <asp:ListItem>28</asp:ListItem>
                                <asp:ListItem>29</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>31</asp:ListItem>
                            </asp:DropDownList>
                            de
                            <asp:DropDownList ID="cmbNascAno" runat="server">
                                <asp:ListItem>Ano</asp:ListItem>
                                <asp:ListItem>1987</asp:ListItem>
                                <asp:ListItem>1988</asp:ListItem>
                                <asp:ListItem>1989</asp:ListItem>
                                <asp:ListItem>1990</asp:ListItem>
                                <asp:ListItem>1991</asp:ListItem>
                                <asp:ListItem>1992</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNascPais" runat="server" Width="200px" 
                                CssClass="input-text-normal"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            Naturalidade:
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNascCid" runat="server" Width="200px" 
                                CssClass="input-text-normal"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Sexo:
                        </td>
                        <td>
                            Estado Civil:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="cmbSexo" runat="server">
                                <asp:ListItem>Indefinido</asp:ListItem>
                                <asp:ListItem>Fem</asp:ListItem>
                                <asp:ListItem>Masc</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="cmbEstadoCivil" runat="server">
                                <asp:ListItem>Solteiro</asp:ListItem>
                                <asp:ListItem>Casado</asp:ListItem>
                                <asp:ListItem>Divorciado</asp:ListItem>
                                <asp:ListItem>Viúvo</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            País Atual:
                        </td>
                        <td>
                            Cidade Atual:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPaisAtual" runat="server" Width="200px" 
                                CssClass="input-text-normal"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCidadeAtual" runat="server" Width="200px" 
                                CssClass="input-text-normal"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Interesse:
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtInteresse" runat="server" Width="200px" 
                                CssClass="input-text-normal"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btnDestaque" OnClick="btnSalvar_Click" />
                            <asp:Label ID="lblValidacao" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="contatos" runat="server" Width="100%">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="50%" class="style1" valign="top">
                            E-mails:
                        </td>
                        <td width="50%" class="style1">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="220px" align="left">
                                        <asp:TextBox ID="txtEmailNovo" runat="server" Width="200px" 
                                            CssClass="input-text-normal"></asp:TextBox>
                                    </td>
                                    <td width="110px">
                                        <asp:DropDownList ID="cmbEmail" runat="server">
                                            <asp:ListItem>Principal</asp:ListItem>
                                            <asp:ListItem>Secundário</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnNovoEmail" runat="server" ImageUrl="~/OwnDoneFolders/BotoesImagens/add.png"
                                            BorderStyle="None" OnClick="btnNovoEmail_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:GridView ID="gridEmails" runat="server" OnRowCreated="gridEmails_RowCreated"
                                ShowHeader="False" 
                                OnSelectedIndexChanged="gridEmails_SelectedIndexChanged" BorderStyle="None" 
                                BorderWidth="0px" CellPadding="0" CssClass="grid">
                                <Columns>
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/OwnDoneFolders/BotoesImagens/delete.png"
                                        SelectText="" ShowSelectButton="True" >
                                    <ControlStyle BorderStyle="None" BorderWidth="0px" />
                                    <ItemStyle BorderStyle="None" BorderWidth="0px" />
                                    </asp:CommandField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" valign="top">
                            Telefones:
                        </td>
                        <td class="style1">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="220px" align="left">
                                        <asp:TextBox ID="txtTelefoneNovo" runat="server" Width="200px" 
                                            CssClass="input-text-normal"></asp:TextBox>
                                    </td>
                                    <td width="110px">
                                        <asp:DropDownList ID="cmbTelefone" runat="server">
                                            <asp:ListItem>Principal</asp:ListItem>
                                            <asp:ListItem>Secundário</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnNovoTelefone" runat="server" ImageUrl="~/OwnDoneFolders/BotoesImagens/add.png"
                                            BorderStyle="None" OnClick="btnNovoTelefone_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:GridView ID="gridTelefones" runat="server" OnRowCreated="gridTelefones_RowCreated"
                                ShowHeader="False" 
                                onselectedindexchanged="gridTelefones_SelectedIndexChanged" 
                                BorderStyle="None" BorderWidth="0px" CellPadding="0" CssClass="grid">
                                <Columns>
                                    <asp:CommandField ButtonType="Image" 
                                        SelectImageUrl="~/OwnDoneFolders/BotoesImagens/delete.png" SelectText="" 
                                        ShowSelectButton="True" >
                                    <ControlStyle BorderStyle="None" BorderWidth="0px" />
                                    <ItemStyle BorderStyle="None" BorderWidth="0px" />
                                    </asp:CommandField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1" valign="top">
                            Mensageiros Instatâneos:
                        </td>
                        <td class="style1">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="220px" align="left">
                                        <asp:TextBox ID="txtMensageiroNovo" runat="server" Width="200px" 
                                            CssClass="input-text-normal"></asp:TextBox>
                                    </td>
                                    <td width="110px">
                                        <asp:DropDownList ID="cmbMensageiro" runat="server">
                                            <asp:ListItem>MSN</asp:ListItem>
                                            <asp:ListItem>Skype</asp:ListItem>
                                            <asp:ListItem>Google Talk</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnNovoMenssageiro" runat="server" ImageUrl="~/OwnDoneFolders/BotoesImagens/add.png"
                                            BorderStyle="None" onclick="btnNovoMenssageiro_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:GridView ID="gridMensageiros" runat="server" 
                                OnRowCreated="gridMensageiros_RowCreated" 
                                onselectedindexchanged="gridMensageiros_SelectedIndexChanged" 
                                ShowHeader="False" BorderStyle="None" BorderWidth="0px" CellPadding="0" 
                                CssClass="grid">
                                <Columns>
                                    <asp:CommandField ButtonType="Image" 
                                        SelectImageUrl="~/OwnDoneFolders/BotoesImagens/delete.png" SelectText="" 
                                        ShowSelectButton="True" >
                                    <ControlStyle BorderStyle="None" BorderWidth="0px" />
                                    <ItemStyle BorderStyle="None" BorderWidth="0px" />
                                    </asp:CommandField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Redes Sociais:
                        </td>
                        <td>

                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="220px" align="left">
                                        <asp:TextBox ID="txtRedesNovo" runat="server" Width="200px" 
                                            CssClass="input-text-normal"></asp:TextBox>
                                    </td>
                                    <td width="110px">
                                        <asp:DropDownList ID="cmbRedes" runat="server">
                                            <asp:ListItem>Facebook</asp:ListItem>
                                            <asp:ListItem>Orkut</asp:ListItem>
                                            <asp:ListItem>Linkedin</asp:ListItem>
                                            <asp:ListItem>Twitter</asp:ListItem>
                                            <asp:ListItem>Google+</asp:ListItem>
                                            <asp:ListItem>Blogspot</asp:ListItem>
                                            <asp:ListItem>My Space</asp:ListItem>
                                            <asp:ListItem>Wordpress</asp:ListItem>
                                            <asp:ListItem>About.Me</asp:ListItem>
                                            <asp:ListItem>Youtube</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnNovoRede" runat="server" ImageUrl="~/OwnDoneFolders/BotoesImagens/add.png"
                                            BorderStyle="None" onclick="btnNovoRede_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:GridView ID="gridRedes" runat="server" 
                                OnRowCreated="gridRedes_RowCreated" 
                                onselectedindexchanged="gridRedes_SelectedIndexChanged" 
                                ShowHeader="False" BorderStyle="None" BorderWidth="0px" CellPadding="0" 
                                CssClass="grid">
                                <Columns>
                                    <asp:CommandField ButtonType="Image" 
                                        SelectImageUrl="~/OwnDoneFolders/BotoesImagens/delete.png" SelectText="" 
                                        ShowSelectButton="True" >
                                    <ControlStyle BorderStyle="None" BorderWidth="0px" />
                                    <ItemStyle BorderStyle="None" BorderWidth="0px" />
                                    </asp:CommandField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Idiomas:
                        </td>
                        <td>

                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="220px" align="left">
                                        <asp:TextBox ID="txtIdiomaNovo" runat="server" Width="200px" 
                                            CssClass="input-text-normal"></asp:TextBox>
                                    </td>
                                    <td width="110px">
                                        <asp:DropDownList ID="cmbIdioma" runat="server">
                                            <asp:ListItem>Fluente</asp:ListItem>
                                            <asp:ListItem>Avançado</asp:ListItem>
                                            <asp:ListItem>Intermediário</asp:ListItem>
                                            <asp:ListItem>Básico</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnNovoIdioma" runat="server" ImageUrl="~/OwnDoneFolders/BotoesImagens/add.png"
                                            BorderStyle="None" onclick="btnNovoIdioma_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:GridView ID="gridIdiomas" runat="server" 
                                OnRowCreated="gridIdiomas_RowCreated" 
                                onselectedindexchanged="gridIdiomas_SelectedIndexChanged" 
                                ShowHeader="False" BorderStyle="None" BorderWidth="0px" CellPadding="0" 
                                CssClass="grid">
                                <Columns>
                                    <asp:CommandField ButtonType="Image" 
                                        SelectImageUrl="~/OwnDoneFolders/BotoesImagens/delete.png" SelectText="" 
                                        ShowSelectButton="True" >
                                    <ControlStyle BorderStyle="None" BorderWidth="0px" />
                                    <ItemStyle BorderStyle="None" BorderWidth="0px" />
                                    </asp:CommandField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="foto" runat="server" Width="100%">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="50%" valign="middle" align="center">
                            <asp:FileUpload ID="fUploadUserPhoto" runat="server" ClientIDMode="Static" 
                                CssClass="input-text-normal" Width="250px" />
                            <br />
                            <br />
                            <asp:Button ID="btnEnviaNovaFoto" runat="server" Text="Enviar nova Foto" 
                                CssClass="btnNormal" onclick="btnEnviaNovaFoto_Click" 
                                ClientIDMode="Static"  />
                        </td>
                        <td width="50%" valign="middle" align="center">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                                <tr>
                                    <td>
                                    <asp:Image ID="editImgFoto" runat="server" 
                                            ImageUrl="~/OwnDoneFolders/Imagens/usuarioSemFoto.png" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="lnkTirarFoto" runat="server" onclick="lnkTirarFoto_Click">Remover Foto</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="cartao" runat="server" Width="100%">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            Opções
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnGerarCartao" runat="server" Text="Gerar Cartão" 
                                CssClass="btnNormal" onclick="btnGerarCartao_Click" 
                                ClientIDMode="Static" />
                            <asp:Button ID="btnGerarQRCode" runat="server" Text="QR Code" 
                                onclick="btnGerarQRCode_Click" CssClass="btnNormal" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
