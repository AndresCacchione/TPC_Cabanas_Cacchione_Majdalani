using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using System.Data;

namespace TPC_CacchioneMajdalani
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        public ModificarUsuario()
        {
            dictNivelesAcceso = new Dictionary<string, int>();
            dictGeneros = new Dictionary<string, int>
            {
                { "F", 0}, { "M", 1 }, { "O", 2 }
            };
        }

        public Usuario usuario { get; set; }
        public Dictionary<string, int> dictNivelesAcceso { get; set; }
        public Dictionary<string, int> dictGeneros { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDDLPaises();
            CargarDDLNivelAcceso();

            usuario = new Usuario();
            if (!IsPostBack)
            {
                long id = Convert.ToInt64(Request.QueryString["idUsuario"]);
                if (id != 0)
                {
                    usuario = (Usuario)Session[Session.SessionID + "userSession"];
                    CargarInputsUsuarios();
                }
            }
        }

        private void CargarDDLPaises()
        {
            if (!IsPostBack)
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                List<string> ListaPaises = usuarioNegocio.ListarPaises();
                if (Session["listaPaises"] == null)
                {
                    Session.Add("listaPaises", ListaPaises);
                }
                else
                {
                    ListaPaises = (List<string>)Session["listaPaises"];
                }
                DDLPaises.DataSource = ListaPaises;
                DDLPaises.DataBind();
            }
        }

        private void CargarDDLNivelAcceso()
        {
            if (!IsPostBack)
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                DataSet aux = new DataSet();
                if (Session["listaNivelesDDL"] == null)
                {
                    aux = usuarioNegocio.ListarNivelesAccesoDDL();
                    DDLNivelAcceso.DataSource = aux;
                    Session.Add("listaNivelesDDL", DDLNivelAcceso.DataSource);
                }
                else
                {
                    aux = (DataSet)Session["listaNivelesDDL"];
                    DDLNivelAcceso.DataSource = aux;
                }
                DDLNivelAcceso.DataTextField = "nombre";
                DDLNivelAcceso.DataValueField = "ID";
                DDLNivelAcceso.DataBind();

                int i = 0;
                foreach (DataRow row in aux.Tables[0].Rows)
                {
                    dictNivelesAcceso.Add(row["id"].ToString(), i);
                    i++;
                }
            }
        }

        private void CargarInputsUsuarios()
        {
            NombreUsuario.Value = usuario.NombreUsuario;
            Contraseña.Value = usuario.Contraseña;
            DDLEstado.SelectedIndex = usuario.Estado ? 1 : 0;
            DDLNivelAcceso.SelectedIndex = dictNivelesAcceso[usuario.NivelAcceso.ToString()];
            Nombre.Value = usuario.DatosPersonales.Nombre;
            Apellido.Value = usuario.DatosPersonales.Apellido;
            Telefono.Value = usuario.DatosPersonales.Telefono;
            Domicilio.Value = usuario.DatosPersonales.Domicilio;
            DNI.Value = usuario.DatosPersonales.DNI;
            Email.Value = usuario.DatosPersonales.Email;
            DDLGenero.SelectedIndex = dictGeneros[usuario.DatosPersonales.Genero.ToUpper()];
            UrlImagen.Value = usuario.DatosPersonales.UrlImagen;
            DDLPaises.SelectedValue = usuario.DatosPersonales.PaisOrigen;
        }

        private void GuardarInputsUsuarios()
        {
            usuario.NombreUsuario = NombreUsuario.Value;
            usuario.Contraseña = Contraseña.Value;
            usuario.Estado = (DDLEstado.SelectedValue == "1") ? true : false;
            usuario.NivelAcceso = Convert.ToByte(DDLNivelAcceso.SelectedValue);
            usuario.DatosPersonales.Nombre = Nombre.Value;
            usuario.DatosPersonales.Apellido = Apellido.Value;
            usuario.DatosPersonales.Telefono = Telefono.Value;
            usuario.DatosPersonales.Domicilio = Domicilio.Value;
            usuario.DatosPersonales.DNI = DNI.Value;
            usuario.DatosPersonales.Email = Email.Value;
            usuario.DatosPersonales.Genero = DDLGenero.SelectedValue;
            usuario.DatosPersonales.UrlImagen = UrlImagen.Value;
            usuario.DatosPersonales.PaisOrigen = DDLPaises.SelectedValue;
        }
        protected void btnModificarDatos_Click(object sender, EventArgs e)
        {
            UsuarioNegocio Negocio = new UsuarioNegocio();
            GuardarInputsUsuarios();
            Negocio.ActualizarUsuario(usuario);
            Response.Redirect("Default.aspx");
        }
    }
}