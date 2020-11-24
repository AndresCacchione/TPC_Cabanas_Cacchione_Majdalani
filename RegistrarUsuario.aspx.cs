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
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        public Usuario Usuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                List<string> ListaPaises = usuarioNegocio.ListarPaises();
                Session.Add("listaPaises", ListaPaises);
                DDLPaises.DataSource = ListaPaises;
                DDLPaises.DataBind();
            }
        }

        protected void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                Contraseña = Contraseña.Value,
                NombreUsuario = NombreUsuario.Value,
                Estado = true,
                NivelAcceso = 1,
                DatosPersonales = new DatosPersonales
                {
                    Apellido = Apellido.Value,
                    DNI = DNI.Value,
                    Domicilio = Domicilio.Value,
                    Email = email.Value,
                    Genero = Convert.ToChar(DDLGenero.SelectedValue),
                    Nombre = Nombre.Value,
                    PaisOrigen = DDLPaises.SelectedValue,
                    Telefono = Telefono.Value,
                    UrlImagen = UrlImagen.Value
                }
            };

            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                usuarioNegocio.AgregarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Response.Redirect("login.aspx");
            }
        }
    }
}