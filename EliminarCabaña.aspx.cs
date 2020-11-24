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
    public partial class EliminarCabaña : System.Web.UI.Page
    {
        public Cabaña Aux { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            CabañaNegocio Negocio = new CabañaNegocio();

            long idaux = Convert.ToInt64(Request.QueryString["IdCabaña"]);

            List<Dominio.Cabaña> listaAux = new List<Dominio.Cabaña>();
            listaAux = (List<Dominio.Cabaña>)base.Session["listaCabañas"];
            Aux = listaAux.Find(i => i.Id == idaux);
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

            if (check_eliminar.Checked)
            {
                CabañaNegocio auxNeg = new CabañaNegocio();
                auxNeg.EliminarCabañaPorId(Aux.Id);

                List<Dominio.Cabaña> listaAuxCabañas = new List<Dominio.Cabaña>();
                listaAuxCabañas = (List<Dominio.Cabaña>)base.Session["listaCabañas"];
                listaAuxCabañas.RemoveAll(i => i.Id == Aux.Id);
                Session["listaCabañas"] = listaAuxCabañas;
                Response.Redirect("Cabañas.Aspx");
            }
            else
            {
                if (check_eliminar.ForeColor == System.Drawing.Color.Red)
                {
                    check_eliminar.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    check_eliminar.ForeColor = System.Drawing.Color.Red;
                }
            }

        }
    }
}