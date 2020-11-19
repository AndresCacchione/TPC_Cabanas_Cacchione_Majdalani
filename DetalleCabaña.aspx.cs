using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_CacchioneMajdalani
{
    public partial class DetalleCabaña : System.Web.UI.Page
    {
        public Dominio.Cabaña Cab { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            long idaux = Convert.ToInt64(Request.QueryString["idCabaña"]);

            List<Dominio.Cabaña> listaAux = new List<Dominio.Cabaña>();
            listaAux = (List<Dominio.Cabaña>)base.Session["listaCabañas"];
            Cab = listaAux.Find(i => i.Id == idaux);
        }
    }
}