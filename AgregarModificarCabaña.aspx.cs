using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;



namespace TPC_CacchioneMajdalani
{
    public partial class AgregarModificarCabaña : Page
    {
        public Dominio.Cabaña Auxiliar { get; set; }
        public AgregarModificarCabaña()
        {
            Auxiliar = new Dominio.Cabaña()
            {
                complejo = new Dominio.Complejo()
            };
        }

        public void CargarFormulario()
        {
            Imagen.Value = Auxiliar.Imagen;
            PrecioDiario.Value = Auxiliar.PrecioDiario.ToString();
            TiempoEntreReservas.Value = Auxiliar.TiempoEntreReservas.TimeOfDay.ToString();
            Capacidad.Value = Auxiliar.Capacidad.ToString();
            CheckIn.Value = Auxiliar.CheckIn.TimeOfDay.ToString();
            CheckOut.Value = Auxiliar.CheckOut.TimeOfDay.ToString();
            Ambientes.Value = Auxiliar.Ambientes.ToString();
        }

        public void GuardarFormulario()
        {
            Auxiliar.Imagen = Imagen.Value;
            Auxiliar.PrecioDiario = Convert.ToDecimal(PrecioDiario.Value);
            Auxiliar.TiempoEntreReservas = Convert.ToDateTime(TiempoEntreReservas.Value);
            Auxiliar.Capacidad = byte.Parse(Capacidad.Value);
            Auxiliar.CheckIn = DateTime.Parse(CheckIn.Value);
            Auxiliar.CheckOut = DateTime.Parse(CheckOut.Value);
            Auxiliar.Ambientes = byte.Parse(Ambientes.Value);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoadAgregarModificarCab();

        }

        protected void BtnAgregarCabaña_Click(object sender, EventArgs e)
        {
            //Page.Validate();
            //if (Page.IsValid)
            //{
                GuardarFormulario();
                EventoClickbtnAgregarCab();
            //}

        }

        private void EventoClickbtnAgregarCab()
        {

            CabañaNegocio negocio = new CabañaNegocio();

            List<Dominio.Cabaña> listaAux = new List<Dominio.Cabaña>();
            listaAux = (List<Dominio.Cabaña>)Session["listaCabañas"];

            try
            {
                if (Auxiliar.Id == 0)
                {
                    negocio.agregarCabaña(Auxiliar);
                    Auxiliar = negocio.ListarUltimaCabaña();
                    listaAux.Add(Auxiliar);
                    Session["listaCabañas"] = listaAux;
                    Response.Redirect("DetalleCabaña.aspx?idCabaña=" + Auxiliar.Id.ToString());
                }

                else
                {
                    negocio.ModificarCabaña(Auxiliar);

                    listaAux.RemoveAll(item => item.Id == Auxiliar.Id);
                    listaAux.Add(Auxiliar);
                    Session["listaCabañas"] = listaAux;

                    Response.Redirect("Cabañas.aspx?idComplejo =" + Auxiliar.complejo.ID);
                }
            }

            catch (Exception ex)
            {
                // Response.Redirect("Error.aspx");
                throw ex;
            }
        }

        private void PageLoadAgregarModificarCab()
        {
            long ID = Convert.ToInt64(Request.QueryString["IdComplejo"]);
            long IDCabaña = Convert.ToInt64(Request.QueryString["IdCabaña"]);
            Auxiliar.complejo.ID = ID;
            Auxiliar.Id = IDCabaña;

            if (Auxiliar.Id != 0)
            {
                List<Dominio.Cabaña> listaAux = new List<Dominio.Cabaña>();
                listaAux = (List<Dominio.Cabaña>)Session["listaCabañas"];
                Auxiliar = listaAux.Find(i => i.Id == Auxiliar.Id);
                if (!IsPostBack)
                {
                    CargarFormulario();
                    BtnAgregarCabaña.Text = "Modificar Cabaña";
                    BtnAgregarCabaña.BackColor = System.Drawing.Color.FromArgb(228, 192, 50);
                }
            }
        }

        protected void ValidadorTiempoEntre_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.customvalidator.clientvalidationfunction?view=netframework-4.8
            try
            {
                TimeSpan TiempoAValidar = (Convert.ToDateTime(TiempoEntreReservas.Value)).TimeOfDay;
                TimeSpan Tiempominimo = new TimeSpan(0, 0, 0);
                if (TiempoAValidar > Tiempominimo)
                {
                    ValidadorTiempoEntre.IsValid = true;
                }
                else
                {
                    ValidadorTiempoEntre.IsValid = false;
                }
            }
            catch (Exception)
            {
                Response.Redirect(Request.RawUrl);                
            }
        }

    }
}