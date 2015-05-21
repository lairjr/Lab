<%@ Page Title="" Language="C#" MasterPageFile="~/OwnDoneFolders/MasterPages/user.Master"
    AutoEventWireup="true" CodeBehind="resume.aspx.cs" Inherits="OwnDone.OwnDoneFolders.UserPages.resume" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <strong>Resume</strong><br />
    <br />
    <asp:LinkButton ID="lnkImprimir" runat="server" onclick="lnkImprimir_Click">Imprimir</asp:LinkButton>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td>
                        <table id="cabecalho_manutencao" cellpadding="0" cellspacing="0" >
                            <tr>
                                <td>
                                    <asp:Button ID="btnSalvaProfObj" runat="server" Text="Salvar" CssClass="btnDestaque"
                                        Visible="false" OnClick="btnSalvaProfObj_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnEditProfObj" runat="server" Text="Editar" CssClass="btnNormal"
                                        OnClick="btnEditProfObj_Click" />
                                </td>
                            </tr>
                        </table>
                        <span class="conteudo_titulo">Objetivo Profissional</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="edit_professional_goals" runat="server" Width="100%" Visible="False">
                            <asp:TextBox ID="txtEditProfGoals" runat="server" Height="78px" TextMode="MultiLine"
                                Width="718px" onfocus="entraNoCampo(this, 'Objetivo Profissional...');" 
                                onblur="saiDoCampo(this, 'Objetivo Profissional...');" 
                                CssClass="input-text-normal"></asp:TextBox>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p class="conteudo_normal">
                            <asp:Label ID="lblProfGoals" runat="server" Text="Professional Goals"></asp:Label>
                        </p>
                        <p class="conteudo_normal">
                            &nbsp;
                        </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="cabecalho_manutencao" cellpadding="0" cellspacing="2">
                            <tr>
                                <td width="200px" align="right">
                                    <asp:Label ID="lblExpProfValida" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="btnSalvaExpProf" runat="server" CssClass="btnDestaque" OnClick="btnSalvaExpProf_Click"
                                        Text="Salvar" Visible="False" />
                                </td>
                                <td>
                                    <asp:Button ID="btnNovoExpProf" runat="server" CssClass="btnNormal" OnClick="btnNovoExpProf_Click"
                                        Text="Novo" />
                                </td>
                                <td>
                                    <asp:Button ID="btnFecharExpProf" runat="server" Text="Fechar" CssClass="btnNormal"
                                        Visible="False" OnClick="btnFecharExpProf_Click" />
                                </td>
                            </tr>
                        </table>
                        <span class="conteudo_titulo">Experiências de Trabalho</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="edit_exp_profs" runat="server" Visible="False">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td width="50%" valign="top">
                                        <table cellpadding="0" cellspacing="2" border="0" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtExpProfProfissao" runat="server" Width="350px" onfocus="entraNoCampo(this, 'Profissão...');"
                                                        onblur="saiDoCampo(this, 'Profissão...');" Font-Italic="True" 
                                                        Font-Size="12px" ForeColor="#CCCCCC" CssClass="input-text-normal">Profissão...</asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtExpProfEmpresa" runat="server" Width="350px" onfocus="entraNoCampo(this, 'Empresa...');"
                                                        onblur="saiDoCampo(this, 'Empresa...');" Font-Italic="True" 
                                                        Font-Size="12px" ForeColor="#CCCCCC" CssClass="input-text-normal">Empresa...</asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="cmbExpProfMesIni" runat="server">
                                                        <asp:ListItem>Mês</asp:ListItem>
                                                        <asp:ListItem>01</asp:ListItem>
                                                        <asp:ListItem>02</asp:ListItem>
                                                        <asp:ListItem>03</asp:ListItem>
                                                        <asp:ListItem>04</asp:ListItem>
                                                        <asp:ListItem>05</asp:ListItem>
                                                        <asp:ListItem>06</asp:ListItem>
                                                        <asp:ListItem>07</asp:ListItem>
                                                        <asp:ListItem>08</asp:ListItem>
                                                        <asp:ListItem>09</asp:ListItem>
                                                        <asp:ListItem>10</asp:ListItem>
                                                        <asp:ListItem>11</asp:ListItem>
                                                        <asp:ListItem>12</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <span class="conteudo_normal">/</span>
                                                    <asp:DropDownList ID="cmbExpProfAnoIni" runat="server">
                                                        <asp:ListItem>1900</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <span class="conteudo_normal">até </span>
                                                    <asp:DropDownList ID="cmbExpProfMesFim" runat="server">
                                                        <asp:ListItem>Mês</asp:ListItem>
                                                        <asp:ListItem>01</asp:ListItem>
                                                        <asp:ListItem>02</asp:ListItem>
                                                        <asp:ListItem>03</asp:ListItem>
                                                        <asp:ListItem>04</asp:ListItem>
                                                        <asp:ListItem>05</asp:ListItem>
                                                        <asp:ListItem>06</asp:ListItem>
                                                        <asp:ListItem>07</asp:ListItem>
                                                        <asp:ListItem>08</asp:ListItem>
                                                        <asp:ListItem>09</asp:ListItem>
                                                        <asp:ListItem>10</asp:ListItem>
                                                        <asp:ListItem>11</asp:ListItem>
                                                        <asp:ListItem>12</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <span class="conteudo_normal">/</span>
                                                    <asp:DropDownList ID="cmbExpProfAnoFim" runat="server">
                                                        <asp:ListItem>1900</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CheckBox ID="chkExpProfSemDataFim" runat="server" Text="Atualidade" 
                                                        BorderWidth="0px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="50%" valign="top">
                                        <asp:TextBox ID="txtExpProfAtividades" runat="server" Height="67px" onblur="saiDoCampo(this, 'Atividades...');"
                                            onfocus="entraNoCampo(this, 'Atividades...');" TextMode="MultiLine" 
                                            Width="350px" Font-Italic="True" Font-Size="12px" ForeColor="#CCCCCC" 
                                            CssClass="input-text-normal">Atividades...</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DataList ID="exp_profs" runat="server" BorderStyle="None" CellPadding="0" Width="100%"
                            DataKeyField="id" OnDeleteCommand="exp_profs_DeleteCommand" 
                            onitemdatabound="exp_profs_ItemDataBound">
                            <ItemTemplate>
                                <table id="cabecalho_manutencao" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lnkEduDelete" runat="server" EnableTheming="True" CommandName="delete">
                                                <img src="../OwnDoneFolders/BotoesImagens/delete.png" alt="" width="13" height="13" style="border: 0;" onmouseover="poeDestaquePai(this, 7)" onmouseout="tiraDestaquePai(this, 7)" />
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="200" valign="top">
                                            <asp:Label ID="lblProfissao" runat="server" Text='<%# Eval("profissao") %>' CssClass="conteudo_destaque"></asp:Label><br />
                                            <asp:Label ID="lblEmpresa" runat="server" Text='<%# Eval("empresa") %>' CssClass="conteudo_normal"></asp:Label><br />
                                            <asp:Label ID="lblMesIni" runat="server" Text='<%# Eval("mesini") %>' CssClass="conteudo_normal"></asp:Label><span
                                                class="conteudo_normal">/</span><asp:Label ID="lblAnoIni" runat="server" Text='<%# Eval("anoini") %>' CssClass="conteudo_normal"></asp:Label>
                                            <asp:Label ID="lblMesFim" runat="server" Text='<%#Eval("mesFim")%>' CssClass="conteudo_normal"></asp:Label><asp:Label
                                                ID="lblAnoFim" runat="server" Text='<%#Eval("anoFim")%>' CssClass="conteudo_normal"></asp:Label>
                                        </td>
                                        <td valign="top">
                                            <asp:HiddenField ID="hideAtividades" runat="server" Value='<%# Eval("atividades") %>' />
                                            <asp:Label ID="lblAtividades" runat="server" Text="" CssClass="conteudo_normal"></asp:Label><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                </tr>
                <tr>
                    <td>
                        <table id="cabecalho_manutencao" cellpadding="0" cellspacing="2" >
                            <tr>
                                <td width="200px" align="right">
                                    <asp:Label ID="lblEduValida" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="btnSalvaEdu" runat="server" CssClass="btnDestaque" OnClick="btnSalvaEdu_Click"
                                        Text="Salvar" Visible="False" />
                                </td>
                                <td>
                                    <asp:Button ID="btnNovoEdu" runat="server" CssClass="btnNormal" OnClick="btnNovoEdu_Click"
                                        Text="Novo" />
                                </td>
                                <td>
                                    <asp:Button ID="btnEduFechar" runat="server" Text="Fechar" CssClass="btnNormal" OnClick="btnEduFechar_Click"
                                        Visible="False" />
                                </td>
                            </tr>
                        </table>
                        <span class="conteudo_titulo">Educação</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="edit_education" runat="server" Width="100%" Visible="false">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td valign="top" width="150">
                                        <asp:DropDownList ID="cmbEduNivel" runat="server">
                                            <asp:ListItem>Ensino Fundamental</asp:ListItem>
                                            <asp:ListItem>Ensino Médio</asp:ListItem>
                                            <asp:ListItem>Graduação</asp:ListItem>
                                            <asp:ListItem>MBA</asp:ListItem>
                                            <asp:ListItem>Pós-Graduação</asp:ListItem>
                                            <asp:ListItem>Mestrado</asp:ListItem>
                                            <asp:ListItem>Doutorado</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                            <tr>
                                                <td align="left" valign="middle">
                                                    <asp:TextBox ID="txtEduInstituicao" runat="server" Width="300px" onfocus="entraNoCampo(this, 'Instituição...');"
                                                        onblur="saiDoCampo(this, 'Instituição...');" 
                                                        onchange="saiDoCampo(this, 'Instituição...');" CssClass="input-text-normal" >Instituição...</asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle">
                                                    <asp:TextBox ID="txtEduCidade" runat="server" Width="300px" onfocus="entraNoCampo(this, 'Cidade...');"
                                                        onblur="saiDoCampo(this, 'Cidade...');" Font-Italic="False" 
                                                        CssClass="input-text-normal">Cidade...</asp:TextBox>
                                                    /
                                                    <asp:TextBox ID="txtEduPais" runat="server" Width="200px" onfocus="entraNoCampo(this, 'País...');"
                                                        onblur="saiDoCampo(this, 'País...');" Font-Italic="False" 
                                                        CssClass="input-text-normal">País...</asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle">
                                                    <asp:TextBox ID="txtEduCurso" runat="server" Width="300px" onfocus="entraNoCampo(this, 'Curso...');"
                                                        onblur="saiDoCampo(this, 'Curso...');" Font-Italic="False" 
                                                        CssClass="input-text-normal">Curso...</asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="middle">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td width="50%">
                                                                <asp:DropDownList ID="cmbEduMesIni" runat="server">
                                                                    <asp:ListItem>Mês</asp:ListItem>
                                                                    <asp:ListItem>01</asp:ListItem>
                                                                    <asp:ListItem>02</asp:ListItem>
                                                                    <asp:ListItem>03</asp:ListItem>
                                                                    <asp:ListItem>04</asp:ListItem>
                                                                    <asp:ListItem>05</asp:ListItem>
                                                                    <asp:ListItem>06</asp:ListItem>
                                                                    <asp:ListItem>07</asp:ListItem>
                                                                    <asp:ListItem>08</asp:ListItem>
                                                                    <asp:ListItem>09</asp:ListItem>
                                                                    <asp:ListItem>10</asp:ListItem>
                                                                    <asp:ListItem>11</asp:ListItem>
                                                                    <asp:ListItem>12</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <span class="conteudo_normal">/</span>
                                                                <asp:DropDownList ID="cmbEduAnoIni" runat="server">
                                                                    <asp:ListItem>1900</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <span class="conteudo_normal">até </span>
                                                                <asp:DropDownList ID="cmbEduMesFim" runat="server">
                                                                    <asp:ListItem>Mês</asp:ListItem>
                                                                    <asp:ListItem>01</asp:ListItem>
                                                                    <asp:ListItem>02</asp:ListItem>
                                                                    <asp:ListItem>03</asp:ListItem>
                                                                    <asp:ListItem>04</asp:ListItem>
                                                                    <asp:ListItem>05</asp:ListItem>
                                                                    <asp:ListItem>06</asp:ListItem>
                                                                    <asp:ListItem>07</asp:ListItem>
                                                                    <asp:ListItem>08</asp:ListItem>
                                                                    <asp:ListItem>09</asp:ListItem>
                                                                    <asp:ListItem>10</asp:ListItem>
                                                                    <asp:ListItem>11</asp:ListItem>
                                                                    <asp:ListItem>12</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <span class="conteudo_normal">/</span>
                                                                <asp:DropDownList ID="cmbEduAnoFim" runat="server">
                                                                    <asp:ListItem>1900</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkEduSemDataFim" runat="server" 
                                                                    Text="Sem previsão de conclusão" BorderWidth="0px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DataList ID="academicos" runat="server" BorderStyle="None" CellPadding="0" Width="100%"
                            DataKeyField="id" OnDeleteCommand="academicos_DeleteCommand" OnItemDataBound="academicos_ItemDataBound">
                            <ItemTemplate>
                                <table id="cabecalho_manutencao" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lnkEduDelete" runat="server" EnableTheming="True" CommandName="delete">
                                                <img src="../OwnDoneFolders/BotoesImagens/delete.png" alt="" width="13" height="13" style="border: 0;" onmouseover="poeDestaquePai(this, 7)" onmouseout="tiraDestaquePai(this, 7)"/>
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="200" valign="top">
                                            <asp:Label ID="lblGrau" runat="server" Text='<%# Eval("grau") %>' CssClass="conteudo_destaque"></asp:Label>
                                        </td>
                                        <td valign="top">
                                            <asp:Label ID="lblInstituicao" runat="server" Text='<%# Eval("instituicao") %>' CssClass="conteudo_normal"></asp:Label><br />
                                            <asp:Label ID="lblCidade" runat="server" Text='<%# Eval("cidade") %>' CssClass="conteudo_normal"></asp:Label><span
                                                class="conteudo_normal"> - </span>
                                            <asp:Label ID="lblPais" runat="server" Text='<%# Eval("pais") %>' CssClass="conteudo_normal"></asp:Label><br />
                                            <asp:Label ID="lblCurso" runat="server" Text='<%# Eval("curso") %>' CssClass="conteudo_normal"></asp:Label><br />
                                            <asp:Label ID="lblMesIni" runat="server" Text='<%#Eval("mesini")%>' CssClass="conteudo_normal"></asp:Label><span
                                                class="conteudo_normal">/</span><asp:Label ID="lblAnoIni" runat="server" Text='<%#Eval("anoini")%>'
                                                    CssClass="conteudo_normal"></asp:Label>
                                            <asp:Label ID="lblMesFim" runat="server" Text='<%#Eval("mesFim")%>' CssClass="conteudo_normal"></asp:Label><asp:Label
                                                ID="lblAnoFim" runat="server" Text='<%#Eval("anoFim")%>' CssClass="conteudo_normal"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="cabecalho_manutencao" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <asp:Button ID="btnSalvaHabilidades" runat="server" Text="Salvar" CssClass="btnDestaque"
                                        Visible="false" OnClick="btnSalvaHabilidades_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnEditaHabilidades" runat="server" Text="Editar" CssClass="btnNormal"
                                        OnClick="btnEditaHabilidades_Click" />
                                </td>
                            </tr>
                        </table>
                        <span class="conteudo_titulo">Habilidades</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="edit_skills" runat="server" Width="100%" Visible="False">
                            <asp:TextBox ID="txtEditSkills" runat="server" Height="78px" TextMode="MultiLine"
                                Width="718px" onfocus="entraNoCampo(this, 'Habilidades...');" 
                                onblur="saiDoCampo(this, 'Habilidades...');" CssClass="input-text-normal"></asp:TextBox>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p class="conteudo_normal">
                            <asp:Label ID="lblSkills" runat="server" Text="Skills"></asp:Label>
                        </p>
                        <p class="conteudo_normal">
                            &nbsp;
                        </p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="cabecalho_manutencao" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Button ID="btnSalvaInfAdic" runat="server" Text="Salvar" CssClass="btnDestaque"
                                        Visible="false" OnClick="btnSalvaInfAdic_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnEditarInfAdic" runat="server" Text="Editar" CssClass="btnNormal"
                                        OnClick="btnEditarInfAdic_Click" />
                                </td>
                            </tr>
                        </table>
                        <span class="conteudo_titulo">Informações Adicionais</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="edit_aditional_informations" runat="server" Width="100%" Visible="False">
                            <asp:TextBox ID="txtEditInfAdic" runat="server" Height="78px" TextMode="MultiLine"
                                Width="718px" onfocus="entraNoCampo(this, 'Informações Adicionais...');" 
                                onblur="saiDoCampo(this, 'Informações Adicionais...');" 
                                CssClass="input-text-normal"></asp:TextBox>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p class="conteudo_normal">
                            <asp:Label ID="lblInfAdic" runat="server" Text="Aditional Informations"></asp:Label>
                        </p>
                        <p class="conteudo_normal">
                            &nbsp;
                        </p>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
