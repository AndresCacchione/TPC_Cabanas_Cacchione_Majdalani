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
        public int MyProperty { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio Negocio = new UsuarioNegocio();
            UsuariosLista = Negocio.ListarUsuarios();
            Session.Add("listaUsuarios", UsuariosLista);
        }
    }
}