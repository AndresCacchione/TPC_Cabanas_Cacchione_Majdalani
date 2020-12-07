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
    public partial class AdministradoresDeComplejos : Page
    {
        public List<Administrador> ListaAdministradores { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarAdministradores();
        }


        private void CargarAdministradores()
        {
            if (Session["listaAdministradores"] == null)
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                ListaAdministradores = usuarioNegocio.ListarAdministradores(((Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso);
                Session.Add("listaAdministradores", ListaAdministradores);
            }
            else
            {
                ListaAdministradores = (List<Administrador>)Session["listaAdministradores"];
            }
        }
    }
}