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
    public partial class DetalleCabaña : System.Web.UI.Page
    {
        public DetalleCabaña()
        {
            CabañaAuxiliar = new Cabaña();
        }

        public string StringBotonVolver { get; set; }

        public Cabaña CabañaAuxiliar { get; set;}

        protected void Page_Load(object sender, EventArgs e)
        {
            long idaux = Convert.ToInt64(Request.QueryString["idCabaña"]);
            if(idaux==0)
            {
                Response.Redirect("Cabañas.aspx?idComplejo=" + Convert.ToString(Session["ComplejoActual"]));
            }

            List<Cabaña> listaAux = new List<Cabaña>();
            listaAux = (List<Cabaña>)Session["listaCabañas"];
            CabañaAuxiliar = listaAux.Find(i => i.Id == idaux);

            CabañaNegocio negocio = new CabañaNegocio();
            if(Request.QueryString["idImagen"]!=null)
                negocio.EliminarImagen(Int64.Parse(Request.QueryString["idImagen"]));
            CabañaAuxiliar.ListaImagenes = negocio.ListarImagenesPorID(CabañaAuxiliar.Id);

            //Cargo el string del Boton Volver
            if(Convert.ToInt64(Session["ComplejoActual"])!=0)
            {
                StringBotonVolver = "Cabañas.aspx?idComplejo="+ Convert.ToString(Session["ComplejoActual"]);
            }
            else
            {
                StringBotonVolver = "Cabañas.aspx";
            }
        }

        protected void AgregarImagen(object sender, EventArgs e)
        {
            if(URLImagen.Value!="")
            { 
                CabañaNegocio negocio = new CabañaNegocio();
                negocio.AgregarImagen(URLImagen.Value,CabañaAuxiliar.Id);
            }
            Response.Redirect("DetalleCabaña.aspx?idCabaña="+CabañaAuxiliar.Id);
        }
    }
}