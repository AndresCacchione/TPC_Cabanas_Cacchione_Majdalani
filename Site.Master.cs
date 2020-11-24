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
            if(Session["userSession"]!=null)
            {
                UsuarioActual = (Usuario)Session["userSession"];
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}