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
        public Usuario UsuarioActual { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDDLPaises();
            }
        }

        protected void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                RegistrarNuevoUsuario();
            }
            else
            {
                exampleModalLabel.InnerText = "Error al ingresar los datos";
                modalbody.InnerText = "Datos Incorrectos. Verifique sus ingresos";
                btnAgregar.Text = "Reintentar";
                btnCancelar.Text = "Cancelar Alta";
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
            //= valida.ValidarEmail(txtemail.Text);


            return Page.IsValid;
        }

        private void RegistrarNuevoUsuario()
        {
            UsuarioActual = new Usuario
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

            exampleModalLabel.InnerText = "Confirmación de alta de Usuario";
            modalbody.InnerText = CargarConfirmacionModal();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                if (usuarioNegocio.InsertarUsuario(UsuarioActual))
                {
                    UsuarioActual = usuarioNegocio.Login(UsuarioActual);
                    UsuarioActual = usuarioNegocio.ListarUsuarioPorId(UsuarioActual.Id);
                    Session.Add(Session.SessionID + "userSession", UsuarioActual);

                    Response.Redirect("~/Complejos");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string CargarConfirmacionModal()
        {
            string retorno = @"Datos ingresados: " + '\n' +
                              "Nombre Usuario: " + NombreUsuario.Value + '\n' +
                              "Nombre: " + Nombre.Value + '\n' +
                              "Apellido: " + Apellido.Value + '\n' +
                              "DNI: " + DNI.Value + '\n' +
                              "Correo Electrónico: " + email.Value + '\n' +
                              "Teléfono: " + Telefono.Value + '\n' +
                              "Género: " + DDLGenero.SelectedValue + '\n' +
                              "Imagen de perfil: " + UrlImagen.Value + '\n' +
                              "Domicilio: " + Domicilio.Value + '\n' +
                              "Pais de origen: " + DDLPaises.SelectedValue;
            return retorno;
        }
    }
}