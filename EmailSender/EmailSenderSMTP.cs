using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using EASendMail;

namespace EmailSender
{
    class EmailSenderSMTP
    {
        public void SendEmail(string message, string email, string subject)
        {
            string mensaje = "Error al enviar correo.";

            try
            {
                SmtpMail emailObject = new SmtpMail("TryIt");

                emailObject.From = "";
                emailObject.To = email;
                emailObject.Subject = subject;
                emailObject.TextBody = message;

                SmtpServer serverObject = new SmtpServer("smtp.gmail.com");

                serverObject.User = "bastagameservice@gmail.com";
                serverObject.Password = "30dpr4319n";
                serverObject.Port = 587;
                serverObject.ConnectType = SmtpConnectType.ConnectSSLAuto;

                SmtpClient clientObject = new SmtpClient();
                clientObject.SendMail(serverObject, emailObject);
                mensaje = "Correo Enviado Correctamente.";


            }
            catch (Exception ex)
            {
                mensaje = "Error al enviar correo." + ex.Message;
            }
        }
    }
}
