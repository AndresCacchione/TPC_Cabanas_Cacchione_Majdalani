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
            try
            {
                CargarListaBuscadosyComplejos();
            }

            catch (Exception ex)
            {
                Session.Add("Cualquier nombre", ex.ToString());
                //Response.Redirect("Error.aspx");
            }
        }

        protected void BtnBuscarComplejo_Click(object sender, EventArgs e)
        {
            BuscarComplejo();
        }

        private void BuscarComplejo()
        {
            if (TxtBuscarComplejo.Text.Length != 0)
            {
                List<Dominio.Complejo> listaAuxBuscar = new List<Dominio.Complejo>();
                if (Session["listaBuscados"] == null)
                    Session.Add("listaBuscados", listaAuxBuscar);

                listaAuxBuscar = (List<Dominio.Complejo>)Session["listaComplejos"];
                Session["listaBuscados"] = listaAuxBuscar.FindAll(x => x.Nombre.ToUpper().Contains(TxtBuscarComplejo.Text.ToUpper()) ||
                x.Ubicacion.ToUpper().Contains(TxtBuscarComplejo.Text.ToUpper()) || x.Mail.ToUpper().Contains(TxtBuscarComplejo.Text.ToUpper())
                || x.Telefono.ToUpper().Contains(TxtBuscarComplejo.Text.ToUpper()));
            }
            else
            {
                ComplejoNegocio negocio = new ComplejoNegocio();
                Session["listaBuscados"] = null;
            }

            Response.Redirect("Complejos.aspx");
        }

        private void CargarListaBuscadosyComplejos()
        {
            ComplejoNegocio negocio = new ComplejoNegocio();
            if (Session["listaBuscados"] == null)
            {
                if ((List<Dominio.Complejo>)Session["listaComplejos"] == null)
                {
                    ListaComplejosLocal = negocio.listarComplejos();
                    Session.Add("listaComplejos", ListaComplejosLocal);
                }
                else
                {
                    ListaComplejosLocal = (List<Dominio.Complejo>)Session["listaComplejos"];
                }
            }
            else
            {
                ListaComplejosLocal = (List<Dominio.Complejo>)Session["listaBuscados"];
                Session["listaBuscados"] = null;
            }
        }
    }
}
