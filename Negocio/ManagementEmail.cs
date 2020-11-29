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
        public string EnviarEmails(List<string> emailsDestinatarios, string asunto, string cuerpo, string emailEmisor = "response.redirect@hotmail.com", string contraseñaEmisor = "Paomajcac")
        {
            List<string> resultados = new List<string>();
            foreach (string EmailDestino in emailsDestinatarios)
            {
                SmtpClient smtpClient = new SmtpClient()
                {
                    Credentials = new NetworkCredential(emailEmisor, contraseñaEmisor),
                };

                MailMessage mail = new MailMessage(emailEmisor, EmailDestino)
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
                resultados.Add(Resultado);
            }

            string retorno;
            if (resultados.TrueForAll(i => i != "Email enviado"))
            {
                retorno = resultados.First();
            }
            else
            {
                retorno = "Email enviado";
            }
            return retorno;
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
