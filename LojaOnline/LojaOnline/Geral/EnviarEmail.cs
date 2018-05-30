using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

namespace LojaOnline.Geral
{
    public class EnviarEmail
    {

        public void Send(string[] toAddress, string mensagem)
        {
            try
            {
                SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["smtp"].ToString(), 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["usuario"].ToString(), ConfigurationManager.AppSettings["senha"].ToString());
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage m = new MailMessage();
                m.Subject = "Pedido Finalizado";
                m.Body = mensagem;

                foreach (var item in toAddress)
                    m.To.Add(item);

                m.From = new MailAddress(ConfigurationManager.AppSettings["usuario"].ToString());
                m.IsBodyHtml = true;
                smtp.Send(m);
            }
            catch (SmtpException smt)
            {
                throw new Exception(smt.Message);
            }
        }

        public void ConfigurarSmtp(string from, string SMTP, string senha, string usuario)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            config.AppSettings.Settings["smtp"].Value = SMTP;
            config.AppSettings.Settings["from"].Value = from;
            config.AppSettings.Settings["usuario"].Value = usuario;
            config.AppSettings.Settings["senha"].Value = senha;

            config.Save();
        }

    }
}