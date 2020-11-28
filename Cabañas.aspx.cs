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
    public partial class Cabañas : Page
    {
        public List<Cabaña> ListaCabañasLocal { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ComplejoActual();
            CargarListaCabañasLocal();
            AgregarComplejo();
        }

        private void ComplejoActual()
        {
            long complejoPorURL = Convert.ToInt64(Request.QueryString["idComplejo"]);
            if (complejoPorURL != 0)
            {
                Session.Add("ComplejoActual", complejoPorURL);
            }
            else
            {
                Session["ComplejoActual"] = null;
            }
        }

        private void CargarListaCabañasLocal()
        {
            CabañaNegocio negocio = new CabañaNegocio();
            ListaCabañasLocal = (List<Cabaña>)(Session["listaCabañas"]);
            if (ListaCabañasLocal == null)
            {
                ListaCabañasLocal = negocio.listarCabañas();
                Session.Add("listaCabañas", ListaCabañasLocal);
            }
        }

        private void AgregarComplejo()
        {
            long idaux = Convert.ToInt64(Request.QueryString["idComplejo"]);
            if (idaux != 0)
            {
                List<Cabaña> listaAux = new List<Cabaña>();
                foreach (Dominio.Cabaña item in ListaCabañasLocal)
                {
                    if (item.complejo.ID == idaux)
                    {
                        listaAux.Add(item);
                    }
                }
                ListaCabañasLocal = listaAux;
            }
        }
    }
}