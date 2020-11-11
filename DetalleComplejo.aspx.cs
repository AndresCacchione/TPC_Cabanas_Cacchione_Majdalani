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
    public partial class DetalleComplejo : System.Web.UI.Page
    {
        public Dominio.Complejo Aux { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            long idaux = Convert.ToInt64(Request.QueryString["idComplejo"]);

            List<Dominio.Complejo> listaAux = new List<Dominio.Complejo>();
            listaAux = (List<Dominio.Complejo>)base.Session["listaComplejos"];
            Aux = listaAux.Find(i => i.ID == idaux);

        }
    }
}