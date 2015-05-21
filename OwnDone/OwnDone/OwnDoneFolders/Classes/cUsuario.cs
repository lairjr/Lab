using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Web.UI.WebControls;
using System.Data;

namespace OwnDone.OwnDoneFolders.Classes
{
    public class cUsuario
    {
        XmlDocument dados = new XmlDocument();
        XmlDataSource dadosDS = new XmlDataSource();
        cFuncoesDiversas funcoesDiversas = new cFuncoesDiversas();

        int id, id_tema, anoNasc, mesNasc, diaNasc, sexo;
        String pnome, snome, path_xml_dados, path_qr_code, path_categoria, id_own_done, pais, pais_nat, cidade, cidade_nat, estado_civil, interesse;
        String categoria_nome;
        String projeto_nome, projeto_desc;
        String imagem_nome, imagem_file;
        String video_nome, video_file, video_desc;
        String link_link, link_desc;

        public String Link_desc
        {
            get { return link_desc; }
            set { link_desc = value; }
        }

        public String Link_link
        {
            get { return link_link; }
            set { link_link = value; }
        }

        public String Video_desc
        {
            get { return video_desc; }
            set { video_desc = value; }
        }

        public String Video_file
        {
            get { return video_file; }
            set { video_file = value; }
        }

        public String Video_nome
        {
            get { return video_nome; }
            set { video_nome = value; }
        }

        public String Path_categoria
        {
            get { return path_categoria; }
            set { path_categoria = value; }
        } 

        public String Imagem_file
        {
            get { return imagem_file; }
            set { imagem_file = value; }
        }

        public String Imagem_nome
        {
            get { return imagem_nome; }
            set { imagem_nome = value; }
        }

        public String Projeto_desc
        {
            get { return projeto_desc; }
            set { projeto_desc = value; }
        }

        public String Projeto_nome
        {
            get { return projeto_nome; }
            set { projeto_nome = value; }
        }

        public String Categoria_nome
        {
            get { return categoria_nome; }
            set { categoria_nome = value; }
        }

        public String Path_qr_code
        {
            get { return path_qr_code; }
            set { 
                path_qr_code = value;
                path_qr_code = path_qr_code + id + "\\qrcode.bmp";
            }
        }

        public String Interesse
        {
            get { return interesse; }
            set { interesse = value; }
        }

        public String Estado_civil
        {
            get { return estado_civil; }
            set { estado_civil = value; }
        }

        public int Sexo //1 - Feminino, 2 - Masculino
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public String Cidade_nat
        {
            get { return cidade_nat; }
            set { cidade_nat = value; }
        }

        public String Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public String Pais_nat
        {
            get { return pais_nat; }
            set { pais_nat = value; }
        }

        public String Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        public int DiaNasc
        {
            get { return diaNasc; }
            set { diaNasc = value; }
        }

        public int MesNasc
        {
            get { return mesNasc; }
            set { mesNasc = value; }
        }

        public int AnoNasc
        {
            get { return anoNasc; }
            set { anoNasc = value; }
        }

        public int Id_tema
        {
            get { return id_tema; }
            set { id_tema = value; }
        }

        public String Id_own_done
        {
            get { return id_own_done; }
            set { id_own_done = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Snome
        {
            get { return snome; }
            set { snome = value; }
        }

        public String Pnome
        {
            get { return pnome; }
            set { pnome = value; }
        }

        public String Path_xml_dados
        {
            get { return path_xml_dados; }
            set
            {
                path_xml_dados = value;
                path_categoria = path_xml_dados + id + "\\Categorias";
                path_xml_dados = path_xml_dados + id + "\\user_dados.xml";
            }
        }

        public Boolean carregaDadosGerais()
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                pnome = dados.SelectSingleNode("dados/dados_gerais/pnome").InnerText;
                snome = dados.SelectSingleNode("dados/dados_gerais/snome").InnerText;
                anoNasc = int.Parse(dados.SelectSingleNode("dados/dados_gerais/anasc").InnerText);
                mesNasc = int.Parse(dados.SelectSingleNode("dados/dados_gerais/mnasc").InnerText);
                diaNasc = int.Parse(dados.SelectSingleNode("dados/dados_gerais/dnasc").InnerText);
                pais = dados.SelectSingleNode("dados/dados_gerais/pais").InnerText;
                pais_nat = dados.SelectSingleNode("dados/dados_gerais/pais_org").InnerText;
                cidade = dados.SelectSingleNode("dados/dados_gerais/cidade").InnerText;
                cidade_nat = dados.SelectSingleNode("dados/dados_gerais/cidade_org").InnerText;
                sexo = int.Parse(dados.SelectSingleNode("dados/dados_gerais/sexo").InnerText);
                estado_civil = dados.SelectSingleNode("dados/dados_gerais/estado_civil").InnerText;
                interesse = dados.SelectSingleNode("dados/dados_gerais/interesse").InnerText;

                id_own_done = dados.SelectSingleNode("dados/dados_gerais/IDLink").InnerText;
                id_tema = int.Parse(dados.SelectSingleNode("dados/config/tema").Attributes["id"].InnerText);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean atualizaDadosGerais()
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                dados.SelectSingleNode("dados/dados_gerais/pnome").InnerText = pnome;
                dados.SelectSingleNode("dados/dados_gerais/snome").InnerText = snome;
                dados.SelectSingleNode("dados/dados_gerais/anasc").InnerText = anoNasc.ToString();
                dados.SelectSingleNode("dados/dados_gerais/mnasc").InnerText = mesNasc.ToString();
                dados.SelectSingleNode("dados/dados_gerais/dnasc").InnerText = diaNasc.ToString();
                dados.SelectSingleNode("dados/dados_gerais/pais").InnerText = pais;
                dados.SelectSingleNode("dados/dados_gerais/pais_org").InnerText = pais_nat;
                dados.SelectSingleNode("dados/dados_gerais/cidade").InnerText = cidade;
                dados.SelectSingleNode("dados/dados_gerais/cidade_org").InnerText = cidade_nat;
                dados.SelectSingleNode("dados/dados_gerais/sexo").InnerText = sexo.ToString();
                dados.SelectSingleNode("dados/dados_gerais/estado_civil").InnerText = estado_civil;
                dados.SelectSingleNode("dados/dados_gerais/interesse").InnerText = interesse;

                id_own_done = dados.SelectSingleNode("dados/dados_gerais/IDLink").InnerText;
                id_tema = int.Parse(dados.SelectSingleNode("dados/config/tema").Attributes["id"].InnerText);

                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean insereEmail(String email, Boolean principal)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                if (principal) // Se tiver principal, ele tira
                {
                    if (dados.SelectSingleNode("dados/dados_gerais/emails").HasChildNodes)
                    {
                        XmlNodeList list = dados.SelectNodes("dados/dados_gerais/emails/email");
                        foreach (XmlNode nodePrincipal in list)
                        {
                            nodePrincipal.Attributes["principal"].InnerText = "";
                        }
                    }
                    else
                        principal = true;
                }

                int id = 0;
                if (dados.SelectSingleNode("dados/dados_gerais/emails").HasChildNodes)
                {
                    id = int.Parse(dados.SelectSingleNode("dados/dados_gerais/emails").LastChild.Attributes["id"].InnerText);
                }
                id++;
                XmlNode node = dados.CreateElement("email");
                XmlAttribute atrrb = dados.CreateAttribute("id");
                atrrb.InnerText = id.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("mail");
                atrrb.InnerText = email;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("principal");
                if (principal)
                    atrrb.InnerText = "1";
                else
                    atrrb.InnerText = "";
                node.Attributes.Append(atrrb);

                dados.SelectSingleNode("dados/dados_gerais/emails").AppendChild(node);

                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean deletaEmail(int id)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                XmlNode node = dados.SelectSingleNode("dados/dados_gerais/emails/email[@id='" + id + "']");
                node.ParentNode.RemoveChild(node);

                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable carregaEmails()
        {
            DataTable emails = null;
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                if (dados.SelectSingleNode("dados/dados_gerais/emails").HasChildNodes)
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(path_xml_dados);
                    emails = ds.Tables["email"];
                    emails.DefaultView.Sort = "principal desc";
                }

                return emails;
            }
            catch (Exception)
            {
                return emails;
            }
        }

        public Boolean insereTelefone(String telefone, Boolean principal)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                if (principal) // Se tiver principal, ele tira
                {
                    if (dados.SelectSingleNode("dados/dados_gerais/telefones").HasChildNodes)
                    {
                        XmlNodeList list = dados.SelectNodes("dados/dados_gerais/telefones/telefone");
                        foreach (XmlNode nodePrincipal in list)
                        {
                            nodePrincipal.Attributes["principal"].InnerText = "";
                        }
                    }
                    else
                        principal = true;
                }

                int id = 0;
                if (dados.SelectSingleNode("dados/dados_gerais/telefones").HasChildNodes)
                {
                    id = int.Parse(dados.SelectSingleNode("dados/dados_gerais/telefones").LastChild.Attributes["id"].InnerText);
                }
                id++;
                XmlNode node = dados.CreateElement("telefone");
                XmlAttribute atrrb = dados.CreateAttribute("id");
                atrrb.InnerText = id.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("fone");
                atrrb.InnerText = telefone;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("principal");
                if (principal)
                    atrrb.InnerText = "1";
                else
                    atrrb.InnerText = "";
                node.Attributes.Append(atrrb);

                dados.SelectSingleNode("dados/dados_gerais/telefones").AppendChild(node);

                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean deletaTelefone(int id)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                XmlNode node = dados.SelectSingleNode("dados/dados_gerais/telefones/telefone[@id='" + id + "']");
                node.ParentNode.RemoveChild(node);

                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable carregaTelefones()
        {
            DataTable telefones = null;
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                if (dados.SelectSingleNode("dados/dados_gerais/telefones").HasChildNodes)
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(path_xml_dados);
                    telefones = ds.Tables["telefone"];
                    telefones.DefaultView.Sort = "principal desc";
                }

                return telefones;
            }
            catch (Exception)
            {
                return telefones;
            }
        }

        public Boolean insereMensageiro(String valor, String tipo)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                int id = 0;
                if (dados.SelectSingleNode("dados/dados_gerais/mensageiros").HasChildNodes)
                {
                    id = int.Parse(dados.SelectSingleNode("dados/dados_gerais/mensageiros").LastChild.Attributes["id"].InnerText);
                }
                id++;
                XmlNode node = dados.CreateElement("mensageiro");
                XmlAttribute atrrb = dados.CreateAttribute("id");
                atrrb.InnerText = id.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("tipo");
                atrrb.InnerText = tipo;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("valor");
                atrrb.InnerText = valor;
                node.Attributes.Append(atrrb);

                dados.SelectSingleNode("dados/dados_gerais/mensageiros").AppendChild(node);

                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean deletaMensageiro(int id)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                XmlNode node = dados.SelectSingleNode("dados/dados_gerais/mensageiros/mensageiro[@id='" + id + "']");
                node.ParentNode.RemoveChild(node);

                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable carregaMensageiros()
        {
            DataTable mensageiros = null;
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                if (dados.SelectSingleNode("dados/dados_gerais/mensageiros").HasChildNodes)
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(path_xml_dados);
                    mensageiros = ds.Tables["mensageiro"];
                    mensageiros.DefaultView.Sort = "id";
                }

                return mensageiros;
            }
            catch (Exception)
            {
                return mensageiros;
            }
        }

        public Boolean insereRede(String valor, String rede)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                if (!valor.StartsWith("http://"))
                    valor = "http://" + valor;

                int id = 0;
                if (dados.SelectSingleNode("dados/dados_gerais/redes_sociais").HasChildNodes)
                {
                    id = int.Parse(dados.SelectSingleNode("dados/dados_gerais/redes_sociais").LastChild.Attributes["id"].InnerText);
                }
                id++;
                XmlNode node = dados.CreateElement("rede_social");
                XmlAttribute atrrb = dados.CreateAttribute("id");
                atrrb.InnerText = id.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("rede");
                atrrb.InnerText = rede;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("valor");
                atrrb.InnerText = valor;
                node.Attributes.Append(atrrb);

                dados.SelectSingleNode("dados/dados_gerais/redes_sociais").AppendChild(node);

                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean deletaRede(int id)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                XmlNode node = dados.SelectSingleNode("dados/dados_gerais/redes_sociais/rede_social[@id='" + id + "']");
                node.ParentNode.RemoveChild(node);

                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable carregaRedes()
        {
            DataTable redes = null;
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                if (dados.SelectSingleNode("dados/dados_gerais/redes_sociais").HasChildNodes)
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(path_xml_dados);
                    redes = ds.Tables["rede_social"];
                    redes.DefaultView.Sort = "id";
                }
                return redes;
            }
            catch (Exception)
            {
                return redes;
            }
        }

        public Boolean insereIdioma(String idioma, String nivel)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                int id = 0;
                if (dados.SelectSingleNode("dados/dados_gerais/idiomas").HasChildNodes)
                {
                    id = int.Parse(dados.SelectSingleNode("dados/dados_gerais/idiomas").LastChild.Attributes["id"].InnerText);
                }
                id++;
                XmlNode node = dados.CreateElement("idioma");
                XmlAttribute atrrb = dados.CreateAttribute("id");
                atrrb.InnerText = id.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("lingua");
                atrrb.InnerText = idioma;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("nivel");
                atrrb.InnerText = nivel;
                node.Attributes.Append(atrrb);

                dados.SelectSingleNode("dados/dados_gerais/idiomas").AppendChild(node);

                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean deletaIdioma(int id)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                XmlNode node = dados.SelectSingleNode("dados/dados_gerais/idiomas/idioma[@id='" + id + "']");
                node.ParentNode.RemoveChild(node);

                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable carregaIdiomas()
        {
            DataTable idiomas = null;
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                if (dados.SelectSingleNode("dados/dados_gerais/idiomas").HasChildNodes)
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(path_xml_dados);
                    idiomas = ds.Tables["idioma"];
                    idiomas.DefaultView.Sort = "id";
                }
                return idiomas;
            }
            catch (Exception)
            {
                return idiomas;
            }
        }

        public int calculaIdade()
        {
            int idade = 0; 
            int mesNasc = int.Parse(dados.SelectSingleNode("dados/dados_gerais/mnasc").InnerText);
            int diaNasc = int.Parse(dados.SelectSingleNode("dados/dados_gerais/dnasc").InnerText);
            int anoNasc = int.Parse(dados.SelectSingleNode("dados/dados_gerais/anasc").InnerText);
            DateTime dataNasc = new DateTime(anoNasc, mesNasc, diaNasc);
            idade = funcoesDiversas.calculaIdade(dataNasc);
            return idade;
        }

        public String emailPrincipal()
        {
            dados.Load(path_xml_dados);
            dadosDS.EnableCaching = false;

            String email = dados.SelectSingleNode("dados/dados_gerais/emails/email[@principal='1']").Attributes["mail"].InnerText;
            return email;
        }

        public String ObjetivoProfissional
        {
            get 
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                String objetivoProfissional = dados.SelectSingleNode("dados/curriculo/obj_prof").InnerText;
                return objetivoProfissional; 
            }
            set
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                dados.SelectSingleNode("dados/curriculo/obj_prof").InnerText = value;
                dados.Save(path_xml_dados);
            }
        }

        public String Habilidades
        {
            get
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                String habilidades = dados.SelectSingleNode("dados/curriculo/habilidades").InnerText;
                return habilidades;
            }
            set
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                dados.SelectSingleNode("dados/curriculo/habilidades").InnerText = value;
                dados.Save(path_xml_dados);
            }
        }

        public String InfoAdic
        {
            get
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                String infoAdic = dados.SelectSingleNode("dados/curriculo/inf_adc").InnerText;
                return infoAdic;
            }
            set
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                dados.SelectSingleNode("dados/curriculo/inf_adc").InnerText = value;
                dados.Save(path_xml_dados);
            }
        }

        public DataTable carregaEscolaridade()
        {
            DataTable escolaridade = null;
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                if (dados.SelectSingleNode("dados/curriculo/academicos").HasChildNodes)
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(path_xml_dados);
                    escolaridade = ds.Tables["academico"];
                    escolaridade.DefaultView.Sort = "anofim desc";
                }
                return escolaridade;
            }
            catch (Exception)
            {
                return escolaridade;
            }
        }

        public Boolean insereEscolaridade(String nivel, String instituicao, String curso, String pais, String cidade, int mesIni, int anoIni, int mesFim, int anoFim)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                int id = 0;
                if (dados.SelectSingleNode("dados/curriculo/academicos").HasChildNodes)
                {
                    id = int.Parse(dados.SelectSingleNode("dados/curriculo/academicos").LastChild.Attributes["id"].InnerText);
                }
                id++;
                XmlNode node = dados.CreateElement("academico");
                XmlAttribute atrrb = dados.CreateAttribute("id");
                atrrb.InnerText = id.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("grau");
                atrrb.InnerText = nivel;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("instituicao");
                atrrb.InnerText = instituicao;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("curso");
                atrrb.InnerText = curso;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("mesini");
                atrrb.InnerText = mesIni.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("anoini");
                atrrb.InnerText = anoIni.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("anofim");
                atrrb.InnerText = anoFim.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("mesfim");
                atrrb.InnerText = mesFim.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("cidade");
                atrrb.InnerText = cidade;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("pais");
                atrrb.InnerText = pais;
                node.Attributes.Append(atrrb);

                dados.SelectSingleNode("dados/curriculo/academicos").AppendChild(node);
                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean deletaEscolaridade(int id)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                XmlNode node = null;

                node = dados.SelectSingleNode("dados/curriculo/academicos/academico[@id='" + id + "']");

                node.ParentNode.RemoveChild(node);
                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable carregaExpProfissionais()
        {
            DataTable expProfissionais = null;
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                if (dados.SelectSingleNode("dados/curriculo/exp_profs").HasChildNodes)
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(path_xml_dados);
                    expProfissionais = ds.Tables["exp_prof"];
                    expProfissionais.DefaultView.Sort = "anofim desc";
                }
                return expProfissionais;
            }
            catch (Exception)
            {
                return expProfissionais;
            }
        }

        public Boolean insereExpProfissional(String profissao, String empresa, String atividades, int mesIni, int anoIni, int mesFim, int anoFim)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                int id = 0;
                if (dados.SelectSingleNode("dados/curriculo/exp_profs").HasChildNodes)
                {
                    id = int.Parse(dados.SelectSingleNode("dados/curriculo/exp_profs").LastChild.Attributes["id"].InnerText);
                }
                id++;
                XmlNode node = dados.CreateElement("exp_prof");
                XmlAttribute atrrb = dados.CreateAttribute("id");
                atrrb.InnerText = id.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("profissao");
                atrrb.InnerText = profissao;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("empresa");
                atrrb.InnerText = empresa;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("mesini");
                atrrb.InnerText = mesIni.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("anoini");
                atrrb.InnerText = anoIni.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("anofim");
                atrrb.InnerText = anoFim.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("mesfim");
                atrrb.InnerText = mesFim.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("atividades");
                atrrb.InnerText = atividades;
                node.Attributes.Append(atrrb);

                dados.SelectSingleNode("dados/curriculo/exp_profs").AppendChild(node);
                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public Boolean deletaExpProfissional(int id)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                XmlNode node = null;

                node = dados.SelectSingleNode("dados/curriculo/exp_profs/exp_prof[@id='" + id + "']");

                node.ParentNode.RemoveChild(node);
                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable carregaCategorias()
        {
            DataTable categorias = null;
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false; 
                
                if (dados.SelectSingleNode("dados/categorias").HasChildNodes)
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(path_xml_dados);
                    categorias = ds.Tables["categoria"];
                    categorias.DefaultView.Sort = "nome";
                }

                return categorias;
            }
            catch (Exception)
            {
                return categorias;
            }
        }

        public Boolean insereCategoria()
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false; 

                int id = 0;
                if (dados.SelectSingleNode("dados/categorias") == null) 
                {
                    XmlNode nodee = dados.CreateElement("categorias");
                    dados.SelectSingleNode("dados").AppendChild(nodee);
                }
                if (dados.SelectSingleNode("dados/categorias").HasChildNodes)
                {
                    id = int.Parse(dados.SelectSingleNode("dados/categorias").LastChild.Attributes["id"].InnerText);
                }
                id++;
                XmlNode node = dados.CreateElement("categoria");
                XmlAttribute atrrb = dados.CreateAttribute("id");
                atrrb.InnerText = id.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("nome");
                atrrb.InnerText = categoria_nome;
                node.Attributes.Append(atrrb);

                dados.SelectSingleNode("dados/categorias").AppendChild(node);
                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean deletaCategoria(int id)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false; 
                
                XmlNode node = null;

                node = dados.SelectSingleNode("dados/categorias/categoria[@id='" + id + "']");

                node.ParentNode.RemoveChild(node);
                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }

        public Boolean carregaUmaCategoria(int idcategoria)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                categoria_nome = dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']").Attributes["nome"].InnerText;
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public DataTable carregaProjetos(int idcategoria)
        {
            DataTable projetos = null;
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                if (dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']").HasChildNodes)
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(new XmlNodeReader(dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']")));
                    projetos = ds.Tables["projeto"];
                    projetos.DefaultView.Sort = "id";
                }

                return projetos;
            }
            catch (Exception)
            {
                return projetos;
            }
        }

        public int insereProjeto(int idcategoria)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                int id = 0;
                if (dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']").HasChildNodes)
                {
                    id = int.Parse(dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']").LastChild.Attributes["id"].InnerText);
                }
                id++;
                XmlNode node = dados.CreateElement("projeto");
                XmlAttribute atrrb = dados.CreateAttribute("id");
                atrrb.InnerText = id.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("nome");
                atrrb.InnerText = projeto_nome;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("fotofilename");
                atrrb.InnerText = "";
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("gostou");
                atrrb.InnerText = "0";
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("acesso");
                atrrb.InnerText = "0";
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("descricao");
                atrrb.InnerText = projeto_desc;
                node.Attributes.Append(atrrb);

                dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']").AppendChild(node);
                dados.Save(path_xml_dados);
                return id;
            }
            catch (Exception)
            {
                return id;
            }
        }

        public Boolean atualizaProjeto(int idcategoria, int idprojeto)
        {
            try {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']").Attributes["nome"].InnerText = projeto_nome;
                dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']").Attributes["descricao"].InnerText = projeto_desc;

                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }

        public Boolean carregaUmProjeto(int idcategoria, int idprojeto)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                Projeto_nome = dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']").Attributes["nome"].InnerText;
                Projeto_desc = dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']").Attributes["descricao"].InnerText;
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public Boolean deletaProjeto(int idcategoria, int idprojeto)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                XmlNode node = null;

                node = dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']");

                node.ParentNode.RemoveChild(node);
                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int insereImagem(int idcategoria, int idprojeto)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                int id = 0;
                if (dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/imagens") == null)
                {
                    XmlNode nodee = dados.CreateElement("imagens");
                    dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']").AppendChild(nodee);
                }
                if (dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/imagens").HasChildNodes)
                {
                    id = int.Parse(dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/imagens").LastChild.Attributes["id"].InnerText);
                }
                id++;
                XmlNode node = dados.CreateElement("imagem");
                XmlAttribute atrrb = dados.CreateAttribute("id");
                atrrb.InnerText = id.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("filename");
                atrrb.InnerText = id.ToString() + Imagem_file;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("descricao");
                atrrb.InnerText = imagem_nome;
                node.Attributes.Append(atrrb);

                dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/imagens").AppendChild(node);
                dados.Save(path_xml_dados);
                return id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public DataTable carregaImagensProjeto(int idcategoria, int idprojeto)
        {
            DataTable imagens = null;
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                if (dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/imagens").HasChildNodes)
                {
                    DataSet ds = new DataSet();
                    //ds.ReadXml(path_xml_dados);
                    ds.ReadXml(new XmlNodeReader(dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/imagens")));
                    imagens = ds.Tables["imagem"];
                    imagens.DefaultView.Sort = "id";
                }

                return imagens;
            }
            catch (Exception)
            {
                return imagens;
            }
        }

        public Boolean carregaImagemProjeto(int idcategoria, int idprojeto, int idimagem)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                Imagem_nome = dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/imagens/imagem[@id='" + idimagem + "']").Attributes["descricao"].InnerText;
                Imagem_file = dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/imagens/imagem[@id='" + idimagem + "']").Attributes["filename"].InnerText;

                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public Boolean deletaImagemProjeto(int idcategoria, int idprojeto, int idimagem)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                XmlNode node = null;

                node = dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/imagens/imagem[@id='" + idimagem + "']");

                node.ParentNode.RemoveChild(node);
                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        public int insereVideo(int idcategoria, int idprojeto)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                int id = 0;
                if (dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/videos") == null)
                {
                    XmlNode nodee = dados.CreateElement("videos");
                    dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']").AppendChild(nodee);
                }
                if (dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/videos").HasChildNodes)
                {
                    id = int.Parse(dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/videos").LastChild.Attributes["id"].InnerText);
                }
                id++;
                XmlNode node = dados.CreateElement("video");
                XmlAttribute atrrb = dados.CreateAttribute("id");
                atrrb.InnerText = id.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("filename");
                atrrb.InnerText = id.ToString() + video_file;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("nome");
                atrrb.InnerText = video_nome;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("descricao");
                atrrb.InnerText = video_desc;
                node.Attributes.Append(atrrb);

                dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/videos").AppendChild(node);
                dados.Save(path_xml_dados);
                return id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public Boolean insereLink(int idcategoria, int idprojeto)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                int id = 0;
                if (dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/links") == null)
                {
                    XmlNode nodee = dados.CreateElement("links");
                    dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']").AppendChild(nodee);
                }
                if (dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/links").HasChildNodes)
                {
                    id = int.Parse(dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/links").LastChild.Attributes["id"].InnerText);
                }
                id++;
                XmlNode node = dados.CreateElement("link");
                XmlAttribute atrrb = dados.CreateAttribute("id");
                atrrb.InnerText = id.ToString();
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("link");
                atrrb.InnerText = link_link;
                node.Attributes.Append(atrrb);
                atrrb = dados.CreateAttribute("descricao");
                atrrb.InnerText = link_desc;
                node.Attributes.Append(atrrb);

                dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/links").AppendChild(node);
                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable carregaLinksProjeto(int idcategoria, int idprojeto)
        {
            DataTable links = null;
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                if (dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/links").HasChildNodes)
                {
                    DataSet ds = new DataSet();
                    //ds.ReadXml(path_xml_dados);
                    ds.ReadXml(new XmlNodeReader(dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/links")));
                    links = ds.Tables["link"];
                    links.DefaultView.Sort = "id";
                }

                return links;
            }
            catch (Exception)
            {
                return links;
            }
        }

        public Boolean deletaLinkProjeto(int idcategoria, int idprojeto, int idlink)
        {
            try
            {
                dados.Load(path_xml_dados);
                dadosDS.EnableCaching = false;

                XmlNode node = null;

                node = dados.SelectSingleNode("dados/categorias/categoria[@id='" + idcategoria + "']/projeto[@id='" + idprojeto + "']/links/link[@id='" + idlink + "']");

                node.ParentNode.RemoveChild(node);
                dados.Save(path_xml_dados);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean geraQRCode(String link, String localDestino)
        {
            if (funcoesDiversas.geraQRCode(link, localDestino))
                return true;
            else
                return false;
        }
    }
}