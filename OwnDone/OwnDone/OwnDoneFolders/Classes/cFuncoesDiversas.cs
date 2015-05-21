using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Data;
using System.IO;
using ThoughtWorks.QRCode.Codec;
using System.Diagnostics;

namespace OwnDone.OwnDoneFolders.Classes
{
    public class cFuncoesDiversas
    {
        public int calculaIdade(DateTime dataNascimento)
        {
            int idade = 0;
            int ano = dataNascimento.Year;
            int mes = dataNascimento.Month;
            int dia = dataNascimento.Day;
            int anoAtual = DateTime.Now.Year;
            int mesAtual = DateTime.Now.Month;
            int diaAtual = DateTime.Now.Day;
            idade = anoAtual - ano;
            if (mesAtual < mes)
                idade--;
            if (mesAtual == mes)
            {
                if (diaAtual < dia)
                    idade--;
            }
            return idade;
        }

        public Boolean enviaMensagemUsuario(String para, String nome, String assunto, String mensagem)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("lairjr.mail@gmail.com");
            msg.To.Add(new MailAddress(para));
            msg.Subject = assunto;
            msg.Body = "<html><body><table><tr><td>Nome:</td><td>" + nome + "</td></tr>";
            msg.Body = msg.Body + "<tr><td>Mensagem:</td><td>" + mensagem + "</td></tr></body></html>";
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;

            SmtpClient smpt = new SmtpClient("smtp.gmail.com", 587);
            smpt.EnableSsl = true;
            smpt.Credentials = new System.Net.NetworkCredential("lairjr.mail@gmail.com", "sis12345");
            try
            {
                smpt.Send(msg);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable geraTableAnos(Boolean previsao)
        {
            DataTable anos = new DataTable("anos");
            anos.Columns.Add("ano");
            int ano = 1900;
            if (previsao)
            {
                while (ano <= DateTime.Now.Year + 10)
                {
                    DataRow rano = anos.NewRow();
                    rano[0] = ano;
                    anos.Rows.Add(rano);
                    ano++;
                }
            }
            else {
                while (ano <= DateTime.Now.Year)
                {
                    DataRow rano = anos.NewRow();
                    rano[0] = ano;
                    anos.Rows.Add(rano);
                    ano++;
                }
            }
            return anos;
        }

        public Boolean geraQRCode(String texto, String localDestino)
        {
            try
            {
                if (File.Exists(localDestino))
                    File.Delete(localDestino);
                QRCodeEncoder qrcode = new QRCodeEncoder();
                System.Drawing.Bitmap imageQRCode = qrcode.Encode(texto);
                imageQRCode.Save(localDestino);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int obterCategoria(String url)
        {
            int idcategoria = -1;
            int iIdcategoria = url.IndexOf("Category/", StringComparison.Ordinal) + 9;
            if (iIdcategoria > 9)
            {
                String depoisCategoria = url.Substring(iIdcategoria);
                if (depoisCategoria.Contains("/")) 
                {
                    int iBarra = depoisCategoria.IndexOf("/");
                    idcategoria = int.Parse(depoisCategoria.Substring(0, iBarra));
                }
                else
                    idcategoria = int.Parse(url.Substring(iIdcategoria));
                
            }
            return idcategoria;
        }

        public int obterProjeto(String url)
        {
            int idprojeto = -1;
            int iIdprojeto = url.IndexOf("EditProject/", StringComparison.Ordinal) + 12;
            if (iIdprojeto > 12)
            {
                String depoisEditProject = url.Substring(iIdprojeto);
                if (depoisEditProject.Contains("/"))
                {
                    int iBarra = depoisEditProject.IndexOf("/");
                    idprojeto = int.Parse(depoisEditProject.Substring(0, iBarra));
                }
                else
                    idprojeto = int.Parse(url.Substring(iIdprojeto));

            }
            else 
            {
                iIdprojeto = url.IndexOf("Project/", StringComparison.Ordinal) + 8;
                if (iIdprojeto > 8)
                {
                    String depoisProject = url.Substring(iIdprojeto);
                    if (depoisProject.Contains("/"))
                    {
                        int iBarra = depoisProject.IndexOf("/");
                        idprojeto = int.Parse(depoisProject.Substring(0, iBarra));
                    }
                    else
                        idprojeto = int.Parse(url.Substring(iIdprojeto));
                }
            }
            return idprojeto;
        }

        public Boolean converteVideo(String ffmpegPath, String origemVideoPath, String destinoVideoPath)
        {
            try
            {
                Process ffmpeg = new Process();
                //ffmpeg.StartInfo = " -i " + origemVideoPath + " -s 480*360 -deinterlace -ab 32 -r 15 -ar 22050 -ac 1 ";
                ffmpeg.StartInfo.Arguments = " -i " + origemVideoPath + " -ar 22050 -ab 32 -f flv -s 480×360 " + destinoVideoPath;
                ffmpeg.StartInfo.FileName = ffmpegPath + "\\ffmpeg.exe";
                ffmpeg.Start();
                ffmpeg.WaitForExit();
                ffmpeg.Close();

                destinoVideoPath = Path.ChangeExtension(destinoVideoPath, ".jpg");
                ffmpeg.StartInfo.Arguments = " -i " + origemVideoPath + " -s 480*360  -vframes 1 -f image2 -vcodec mjpeg " + destinoVideoPath;
                ffmpeg.StartInfo.FileName = ffmpegPath + "\\ffmpeg.exe";
                ffmpeg.Start();
                ffmpeg.WaitForExit();
                ffmpeg.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}