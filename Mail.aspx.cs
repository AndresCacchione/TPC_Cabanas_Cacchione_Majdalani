using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace TPC_CacchioneMajdalani
{
    public partial class Mail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviarMail_Click(object sender, EventArgs e)
        {
            SmtpClient smtpClient = new SmtpClient("domain.a2hosted.com", 25)//Replace domain.a2hosted.com with your own domain name. Acá habla de un dominio, tendríamos que ver la manera de saber el nuestro
            {
                Credentials = new NetworkCredential("usuario@ejemplo.com", "contraseña"), //Acá iría el email y password usados para enviar los mails
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            MailMessage mail = new MailMessage(txtEmisor.Text, txtDestinatario.Text)
            {
                Subject = txtAsunto.Text,
                Body = txtBody.Text
            };

            try
            {
                smtpClient.Send(mail); //si se usa Google Chrome, ir a https://myaccount.google.com/lesssecureapps 
                Resultado.Text = "Email enviado"; //y permitir acceso de apps menos seguras, ya que de otra manera, el email no se va a enviar
            }
            catch (Exception ex)
            {
                Resultado.Text = ex.ToString();
            }
        }
    }
}