using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPC_CacchioneMajdalani
{
    public partial class CabañasFavoritas : System.Web.UI.Page
    {
        public List<Cabaña> ListaFavoritas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[Session.SessionID + "listaFavoritas"] == null)
                {
                    ListaFavoritas = new List<Cabaña>();
                    Session.Add(Session.SessionID + "listaFavoritas", ListaFavoritas);
                }
                else
                    ListaFavoritas = (List<Cabaña>)Session[Session.SessionID + "listaFavoritas"];

                if (Request.QueryString["idCabaña"] != null)
                {
                    foreach (Cabaña item in ListaFavoritas)
                    {
                        if (item.Id == Convert.ToInt64(Request.QueryString["idCabaña"]))
                        {
                            Response.Redirect("~/CabañasFavoritas");
                        }
                        List<Cabaña> ListaOriginal = (List<Cabaña>)Session["listaCabañas"];
                        ListaFavoritas.Add(ListaOriginal.Find(i => i.Id == long.Parse(Request.QueryString["idCabaña"])));
                        Session[Session.SessionID + "listaFavoritas"] = ListaFavoritas;
                    }
                }

                if (Request.QueryString["idQuitar"] != null)
                {
                    ListaFavoritas.Remove(ListaFavoritas.Find(i => i.Id == long.Parse(Request.QueryString["idCabaña"])));
                    Session[Session.SessionID + "listaFavoritas"] = ListaFavoritas;
                    Response.Redirect("~/CabañasFavoritas");
                }

                lblCantidad.Text = ((List<Cabaña>)Session[Session.SessionID + "listaFavoritas"]).Count().ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}