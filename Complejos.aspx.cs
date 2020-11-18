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
    public partial class Complejo : System.Web.UI.Page
    {
        public List<Dominio.Complejo> ListaComplejosLocal { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ComplejoNegocio negocio = new ComplejoNegocio();

            try
            {
                if (Session["listaBuscados"] == null)
                {
                   //ListaComplejosLocal = (List<Dominio.Complejo>)(base.Session["listaComplejos"]);
                    //if (ListaComplejosLocal == null)
                    //{
                    ListaComplejosLocal = negocio.listarComplejos();
                    Session.Add("listaComplejos", ListaComplejosLocal);
                    ListaComplejosLocal = (List<Dominio.Complejo>)Session["listaComplejos"];
                }
                else
                {
                    ListaComplejosLocal = (List < Dominio.Complejo >) Session["listaBuscados"];
                    Session["listaBuscados"] = null;
                }




                
                //}
            }
        
            catch (Exception ex)
            {
                 Session.Add("Cualquier nombre", ex.ToString());
                 Response.Redirect("Error.aspx");
            }
        }

        protected void BtnBuscarComplejo_Click(object sender, EventArgs e)
        {
            List<Dominio.Complejo> listaAuxBuscar = new List<Dominio.Complejo>();
            if (Session["listaBuscados"] == null)
                Session.Add("listaBuscados", listaAuxBuscar);

            listaAuxBuscar = (List<Dominio.Complejo>)Session["listaComplejos"];
            Session["listaBuscados"] = listaAuxBuscar.FindAll(x => x.Nombre.ToUpper().Contains(TxtBuscarComplejo.Text.ToUpper()) ||
            x.Ubicacion.ToUpper().Contains(TxtBuscarComplejo.Text.ToUpper()) || x.Mail.ToUpper().Contains(TxtBuscarComplejo.Text.ToUpper())
            || x.Telefono.ToUpper().Contains(TxtBuscarComplejo.Text.ToUpper()));

            Session["listaComplejos"] = Session["listaBuscados"];
            Response.Redirect("Complejos.aspx");
        }
    }
}
