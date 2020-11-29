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
    public partial class ListadoDeUsuarios : Page
    {
        public List<Usuario> UsuariosLista { get; set; }
        public Dictionary<byte, string> DicNivelesAcceso { get; set; }
        public Dictionary<bool, string> DicEstados { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDiccionarioNivelesAcceso();
            CargarDiccionarioEstados();
            UsuarioNegocio Negocio = new UsuarioNegocio();

            if (Session["listaUsuarios"] == null)
            {
                UsuariosLista = Negocio.ListarUsuarios();
                Session.Add("listaUsuarios", UsuariosLista);
            }
            else
            {
                UsuariosLista = (List<Usuario>)Session["listaUsuarios"];
            }
        }
        private void CargarDiccionarioEstados()
        {
            if (Session["DicEstados"] == null)
            {
                DicEstados = new Dictionary<bool, string>()
                {
                    { false, "Bloqueado" },{true, "Activo" }
                };
                Session.Add("DicEstados", DicEstados);
            }
            else
            {
                DicEstados = (Dictionary<bool, string>)Session["DicEstados"];
            }
        }

        private void CargarDiccionarioNivelesAcceso()
        {
            if (Session["DicNivelesAcceso"] == null)
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                DicNivelesAcceso = usuarioNegocio.ListarNivelesAcceso();
                Session.Add("DicNivelesAcceso", DicNivelesAcceso);
            }
            else
            {
                DicNivelesAcceso = (Dictionary<byte, string>)Session["DicNivelesAcceso"];
            }
        }
    }
}