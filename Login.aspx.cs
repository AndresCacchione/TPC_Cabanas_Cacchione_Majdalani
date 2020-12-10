using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorLogin.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            IniciarSesion();

        }

        private void IniciarSesion()
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();
            try
            {
                usuario.NombreUsuario = NombreUsuario.Value;
                usuario.Contraseña = Contraseña.Value;

                usuario = usuarioNegocio.Login(usuario);
                if (Convert.ToInt64(usuario.Id) != 0)
                {
                    usuario = usuarioNegocio.ListarUsuarioPorId(usuario.Id);
                    Session.Add(Session.SessionID + "userSession", usuario);
                    Response.Redirect("~/Complejos");
                }
                else
                {
                    lblErrorLogin.Visible = true; 

                }
            }
            catch (Exception ex)
            {
                //Session["Error" + Session.SessionID] = ex.ToString();
                //Response.Redirect("Error.aspx");
                throw ex;
            }
        }

    }
}