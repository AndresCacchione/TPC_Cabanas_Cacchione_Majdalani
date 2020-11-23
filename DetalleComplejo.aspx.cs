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
            if(idaux==0)
            {
                Response.Redirect("Complejos.aspx");
            }

            List<Dominio.Complejo> listaAux = new List<Dominio.Complejo>();
            listaAux = (List<Dominio.Complejo>)base.Session["listaComplejos"];
            Aux = listaAux.Find(i => i.ID == idaux);

           ComplejoNegocio negocio = new ComplejoNegocio();
            if (Request.QueryString["idImagen"] != null)
                negocio.EliminarImagen(Int64.Parse(Request.QueryString["idImagen"]));
            Aux.ListaImagenes = negocio.ListarImagenesPorID(Aux.ID);

            ////Cargo el string del Boton Volver
            //if (Convert.ToInt64(Session["ComplejoActual"]) != 0)
            //{
            //    StringBotonVolver = "Cabañas.aspx?idComplejo=" + Convert.ToString(Session["ComplejoActual"]);
            //}
            //else
            //{
            //    StringBotonVolver = "Cabañas.aspx";
            //}
        }

        protected void AgregarImagen(object sender, EventArgs e)
        {
            long idaux = Convert.ToInt64(Request.QueryString["idComplejo"]);
            if (URLImagen.Value !="")
            {
                ComplejoNegocio negocio = new ComplejoNegocio();
                negocio.AgregarImagen(URLImagen.Value,idaux);
            }
            Response.Redirect("DetalleComplejo.aspx?idComplejo=" + Aux.ID);
        }
    }
    }