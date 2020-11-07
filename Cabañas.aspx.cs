using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;
using Dominio;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class Cabañas : System.Web.UI.Page
    {
        public List<Cabaña> ListaCabañasLocal { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CabañaNegocio negocio = new CabañaNegocio();
            ListaCabañasLocal = negocio.listarCabañas();
            Session.Add("listaCabañas", ListaCabañasLocal);
        }
    }
}