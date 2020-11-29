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
    public partial class Mail : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviarMail_Click(object sender, EventArgs e)
        {
            SmtpClient smtpClient = new SmtpClient()
            {
                Credentials = new NetworkCredential("response.redirect@hotmail.com", "Paomajcac"), //Acá iría el email y password usados para enviar los mails
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            txtEmisor.Text = "response.redirect@hotmail.com";
            txtDestinatario.Text = "cristianpaolini3@gmail.com";
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