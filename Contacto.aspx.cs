using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_CacchioneMajdalani
{
    public partial class Contacto : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarInputMailUsuario();
            }
        }

        private void CargarInputMailUsuario()
        {
            if(Session[Session.SessionID + "userSession"]!=null)
            {
                InputMail.Value = ((Usuario)Session[Session.SessionID + "userSession"]).DatosPersonales.Email;
            }
        }

        protected void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            ManagementEmail managementEmail = new ManagementEmail();   
            Resultado.Text = managementEmail.EnviarEmails(MailDestino(), txtBoxAsunto.Text, TextAreaCuerpoMail.InnerText+'\n'+InputMail.Value);
        }

        private List<string> MailDestino()
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            if(Session["listaUsuarios"]==null)
            {
                Session.Add("listaUsuarios", usuarioNegocio.ListarUsuarios());
            }
            List<Usuario> listaUsuarios = (List<Usuario>)Session["listaUsuarios"];

            List<Usuario> listaAdmin = listaUsuarios.FindAll(i => i.NivelAcceso >= 20); //20 es el nivel de acceso del admin
            byte minAcceso = listaAdmin.Min(i => i.NivelAcceso);
            listaAdmin = listaAdmin.FindAll(i => i.NivelAcceso == minAcceso);

            List<string> Emails = listaAdmin.Select(o => o.DatosPersonales.Email).ToList();

            return Emails;
        }
    }
}