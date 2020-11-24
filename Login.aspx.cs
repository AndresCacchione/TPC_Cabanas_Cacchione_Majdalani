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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();
            try
            {
                usuario.NombreUsuario = NombreUsuario.Value;
                usuario.Contraseña = Contraseña.Value;
                usuario = usuarioNegocio.Login(usuario);
                if (usuario.Id != 0)
                {
                    Session.Add("userSession", usuario);
                    //Response.Redirect() A donde querramos que vaya
                }
                else
                {
                    Session["Error" + Session.SessionID] = "Usuario o contraseña incorrectos.";
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception ex) //Despues vemos de hacerlo con Session y que redirija a Error.aspx
            {
                //Session["Error" + Session.SessionID] = ex.ToString();
                //Response.Redirect("Error.aspx");
                throw ex;
            }
        }
    }
}