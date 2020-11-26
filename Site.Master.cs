using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPC_CacchioneMajdalani
{
    public partial class SiteMaster : MasterPage
    {
        public SiteMaster()
        {
            UsuarioActual = new Usuario();
        }
        public Usuario UsuarioActual { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            SetearUsuarioActual();




        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Default");
        }

        protected void btnModificarDatos_Click(object sender, EventArgs e)
        {
            Usuario Usuario = new Usuario();
            Usuario = (Usuario)Session[Session.SessionID + "userSession"];
            Response.Redirect("~/ModificarUsuario?idUsuario=" + Usuario.Id.ToString());
        }

        private void SetearUsuarioActual()
        {
            if (Session[Session.SessionID + "userSession"] != null)
            {
                UsuarioActual = (Usuario)Session[Session.SessionID + "userSession"];
                lblNombreUsuario.Text = "Usuario: " + UsuarioActual.NombreUsuario;
            }
            else
            {
                UsuarioActual = null;
            }
        }

        protected void btnAFavoritas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CabañasFavoritas");
        }
    }
}