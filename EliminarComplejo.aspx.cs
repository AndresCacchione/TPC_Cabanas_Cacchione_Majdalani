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
    public partial class EliminarComplejo : Page
    {
        public Dominio.Complejo Aux { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ObtenerIDyComplejoSiExiste();

        }

        private void ObtenerIDyComplejoSiExiste()
        {
            if (Request.QueryString["idComplejo"] != null)
            {
                ComplejoNegocio negocio = new ComplejoNegocio();

                long idaux = Convert.ToInt64(Request.QueryString["idComplejo"]);

                List<Dominio.Complejo> listaAux = new List<Dominio.Complejo>();
                listaAux = (List<Dominio.Complejo>)base.Session["listaComplejos"];
                Aux = listaAux.Find(i => i.ID == idaux);
            }
            else
            {
                Response.Redirect("Complejos.aspx");
            }
        }

        private void EliminarComplejoyCabañasVinculadas()
        {
            if (check_eliminar.Checked)
            {
                try
                {
                    ComplejoNegocio auxNeg = new ComplejoNegocio();
                    auxNeg.EliminarComplejoPorId(Aux.ID);

                    List<Dominio.Complejo> listaAuxComplejos = new List<Dominio.Complejo>();
                    listaAuxComplejos = (List<Dominio.Complejo>)Session["listaComplejos"];
                    listaAuxComplejos.RemoveAll(i => i.ID == Aux.ID);
                    Session["listaComplejos"] = listaAuxComplejos;
                }

                catch (Exception ex)
                {
                    throw ex;
                }

                List<Cabaña> listaAuxCabañas = new List<Cabaña>();
                listaAuxCabañas = (List<Cabaña>)Session["listaCabañas"];

                if (listaAuxCabañas != null)
                {
                    listaAuxCabañas.RemoveAll(i => i.complejo.ID == Aux.ID);
                    Session["listaCabañas"] = listaAuxCabañas;
                }
                Response.Redirect("~/Complejos");
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

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            EliminarComplejoyCabañasVinculadas();
        }
    }
}