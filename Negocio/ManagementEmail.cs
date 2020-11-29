using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Negocio
{
    public class ManagementEmail
    {
        public string EnviarEmail(string emailDestinatario, string asunto, string cuerpo, string emailEmisor = "response.redirect@hotmail.com", string contraseñaEmisor = "Paomajcac")
        {
            SmtpClient smtpClient = new SmtpClient()
            {
                Credentials = new NetworkCredential(emailEmisor, contraseñaEmisor), //Acá iría el email y password usados para enviar los mails
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            MailMessage mail = new MailMessage(emailEmisor, emailDestinatario)
            {
                Subject = asunto,
                Body = cuerpo
            };

            string Resultado;
            try
            {
                smtpClient.Send(mail); //si se usa Google Chrome, ir a https://myaccount.google.com/lesssecureapps 
                Resultado = "Email enviado"; //y permitir acceso de apps menos seguras, ya que de otra manera, el email no se va a enviar
            }
            catch (Exception ex)
            {
                Resultado = ex.ToString();
            }
            return Resultado;

            // ESTO VA EN EL WEB CONFIG: 
            //< system.net >
            //    < mailSettings >
            //        < smtp from = "response.redirect@hotmail.com" >
            //             < network host = "smtp.live.com"
            //             port = "25"
            //             userName = "response.redirect@hotmail.com"
            //             password = "Paomajcac"
            //             enableSsl = "true" />
            //        </ smtp >
            //    </ mailSettings >
            //</ system.net >
        }
    }
}
