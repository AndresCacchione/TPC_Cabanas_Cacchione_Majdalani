using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class EliminarComplejo : System.Web.UI.Page
    {

        public Complejo aux { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ComplejoNegocio negocio= new ComplejoNegocio();

            long idaux = Convert.ToInt64(Request.QueryString["idComplejo"]);

            Session["listaComplejos"].f

        }


    }
}