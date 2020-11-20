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

        public Cabaña CabañaAuxiliar { get; set;}

        protected void Page_Load(object sender, EventArgs e)
        {
            long idaux = Convert.ToInt64(Request.QueryString["idCabaña"]);

            List<Cabaña> listaAux = new List<Cabaña>();
            listaAux = (List<Cabaña>)Session["listaCabañas"];
            CabañaAuxiliar = listaAux.Find(i => i.Id == idaux);

            CabañaNegocio negocio = new CabañaNegocio();
            CabañaAuxiliar.ListaImagenes = negocio.ListarImagenesPorID(CabañaAuxiliar.Id);
        }

        protected void EliminarImagen(object sender, EventArgs e)
        {
            CabañaNegocio negocio = new CabañaNegocio();
            //negocio.EliminarImagen(); // necesito el ID de imagen a eliminar, esta en el item que contiene el boton que accionó el evento
        }

        protected void AgregarImagen(object sender, EventArgs e)
        {
            if(URLImagen.Value!=null)
            { 
                CabañaNegocio negocio = new CabañaNegocio();
                negocio.AgregarImagen(URLImagen.Value,CabañaAuxiliar.Id);
            }
            Response.Redirect("DetalleCabaña.aspx?idCabaña="+CabañaAuxiliar.Id);
        }
    }
}