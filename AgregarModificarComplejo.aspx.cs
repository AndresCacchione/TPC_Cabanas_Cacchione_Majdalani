using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Antlr.Runtime;
using Dominio;
using Microsoft.Ajax.Utilities;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class AgregarModificarComplejo : Page
    {
        public Dominio.Complejo Auxiliar { get; set; }

        public void CargarFormulario()
        {
            Imagen.Value = Auxiliar.Imagen;
            Nombre.Value = Auxiliar.Nombre;
            Email.Value = Auxiliar.Mail;
            AumentoFeriado.Value = Auxiliar.PrecioFeriado.ToString();
            Telefono.Value = Auxiliar.Telefono;
            Direccion.Value = Auxiliar.Ubicacion;
        }

        public void GuardarFormulario()
        {
            Auxiliar.Imagen = Imagen.Value;
            Auxiliar.Nombre = Nombre.Value;
            Auxiliar.Mail = Email.Value;
            Auxiliar.PrecioFeriado = decimal.Parse(AumentoFeriado.Value);
            Auxiliar.EstadoActivo = true;
            Auxiliar.Telefono = Telefono.Value;
            Auxiliar.Ubicacion = Direccion.Value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idComplejo"] != null)
            {
                PageLoadAgregarModificarComp();
            }
            else
            {
                Response.Redirect("~/Default");
            }
            
        }

        protected void BtnAgregarComplejo_Click(object sender, EventArgs e)
        {
            GuardarFormulario();
            EventoClickbtnAgregarComp();
        }

        private void EventoClickbtnAgregarComp()
        {
            ComplejoNegocio negocio = new ComplejoNegocio();
            List<Dominio.Complejo> listaAux = new List<Dominio.Complejo>();
            listaAux = (List<Dominio.Complejo>)base.Session["listaComplejos"];

            try
            {
                if (Auxiliar.ID == 0)
                {
                    negocio.AgregarComplejo(Auxiliar);
                    Auxiliar = negocio.ListarUltimoComplejo();
                    listaAux.Add(Auxiliar);
                    Session["listaComplejos"] = listaAux;
                    Response.Redirect("DetalleComplejo.aspx?IdComplejo=" + Auxiliar.ID.ToString());
                }
                else
                {
                    negocio.ModificarComplejo(Auxiliar);

                    listaAux.RemoveAll(item => item.ID == Auxiliar.ID);
                    listaAux.Add(Auxiliar);
                    Session["listaComplejos"] = negocio.listarComplejos();

                    Response.Redirect("DetalleComplejo.aspx?idComplejo=" + Auxiliar.ID.ToString());
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void PageLoadAgregarModificarComp()
        {
            long ID = Convert.ToInt64(Request.QueryString["IdComplejo"]);
            Auxiliar = new Dominio.Complejo
            {
                ID = ID
            };

            if (Auxiliar.ID != 0)
            {
                List<Dominio.Complejo> listaAux = new List<Dominio.Complejo>();
                listaAux = (List<Dominio.Complejo>)base.Session["listaComplejos"];
                Auxiliar = listaAux.Find(i => i.ID == ID);
                if (!IsPostBack)
                {
                    CargarFormulario();
                    BtnAgregarComplejo.Text = "Modificar Complejo";
                    BtnAgregarComplejo.BackColor = System.Drawing.Color.FromArgb(228, 192, 50);
                }
            }
        }
    }
}