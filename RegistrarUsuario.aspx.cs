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
    public partial class RegistrarUsuario : Page
    {
        public ValidacionesNegocio valida { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDDLPaises();
            }
        }

        protected void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            if(Validaciones())
            {
                RegistrarNuevoUsuario();
            }
        }
        private void CargarDDLPaises()
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<string> ListaPaises = usuarioNegocio.ListarPaises();
            Session.Add("listaPaises", ListaPaises);
            DDLPaises.DataSource = ListaPaises;
            DDLPaises.DataBind();
        }

        private bool Validaciones()
        {
            ValidacionesNegocio valida = new ValidacionesNegocio();
            RegularExpressionValidator1.Enabled = valida.ValidarEmail(txtemail.Text);



            return Page.IsValid; 
        }

        private void RegistrarNuevoUsuario()
        {
            Usuario usuario = new Usuario
            {
                Contraseña = Contraseña.Value,
                NombreUsuario = NombreUsuario.Value,
                Estado = true,
                NivelAcceso = 10,
                DatosPersonales = new DatosPersonales
                {
                    Apellido = Apellido.Value,
                    DNI = DNI.Value,
                    Domicilio = Domicilio.Value,
                    Email = email.Value,
                    Genero = Convert.ToString(DDLGenero.SelectedValue),
                    Nombre = Nombre.Value,
                    PaisOrigen = DDLPaises.SelectedValue,
                    Telefono = Telefono.Value,
                    UrlImagen = UrlImagen.Value
                }
            };

            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                if(usuarioNegocio.InsertarUsuario(usuario))
                {
                    //usuario.Id = usuarioNegocio.GetIDUltimoUsuario();
                    usuario = usuarioNegocio.Login(usuario);
                    usuario = usuarioNegocio.ListarUsuarioPorId(usuario.Id);
                    Session.Add(Session.SessionID + "userSession", usuario);

                    Response.Redirect("~/Complejos");
                }
                else
                {
                    //agregar modal o label
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}