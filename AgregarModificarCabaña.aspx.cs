using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class AgregarModificarCabaña : System.Web.UI.Page
    {
        public AgregarModificarCabaña()
        {
            Auxiliar = new Dominio.Cabaña();
            Auxiliar.complejo = new Dominio.Complejo();
        }
        public Dominio.Cabaña Auxiliar { get; set; }
        public void CargarFormulario()
        {
            Imagen.Value = Auxiliar.Imagen;
            PrecioDiario.Value = Auxiliar.PrecioDiario.ToString();
            TiempoEntreReservas.Value = Auxiliar.TiempoEntreReservas.ToString();
            Capacidad.Value = Auxiliar.Capacidad.ToString();
            CheckIn.Value = Auxiliar.CheckIn.ToString();
            CheckOut.Value = Auxiliar.CheckOut.ToString();
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
            Auxiliar.complejo.ID = Convert.ToInt64(Request.QueryString["IdComplejo"]);
            Auxiliar.Id = Convert.ToInt64(Request.QueryString["IdCabaña"]);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            long ID = Convert.ToInt64(Request.QueryString["IdComplejo"]);
            Auxiliar.complejo.ID = ID;

            if (Auxiliar.complejo.ID != 0)
            {
                //long IDcabaña = Convert.ToInt64(Request.QueryString["IdCabaña"]);
                ////modificar, hacer luego
                //List<Dominio.Complejo> listaAux = new List<Dominio.Complejo>();
                //listaAux = (List<Dominio.Complejo>)base.Session["listaComplejos"];
                //Auxiliar = listaAux.Find(i => i.ID == ID);
                //if (!IsPostBack)
                //{
                //    CargarFormulario();
                //    BtnAgregarComplejo.Text = "Modificar Complejo";
                //    BtnAgregarComplejo.BackColor = System.Drawing.Color.FromArgb(228, 192, 50);
                //}
            }

        }

        protected void BtnAgregarCabaña_Click(object sender, EventArgs e)
        {
            GuardarFormulario();
            CabañaNegocio negocio = new CabañaNegocio();

            try
            {
                if (Auxiliar.Id == 0)
                {
                    negocio.agregarCabaña(Auxiliar);
                    //List<Dominio.Complejo> listaAux = new List<Dominio.Complejo>();
                    //listaAux = (List<Dominio.Complejo>)base.Session["listaComplejos"];
                    //listaAux.Add(Auxiliar);
                    //Session["listaComplejos"] = listaAux;
                    //Response.Redirect("Complejos.aspx");
                }
                //else
                //{
                //    negocio.ModificarComplejo(Auxiliar);
                //    List<Dominio.Complejo> listaAux = new List<Dominio.Complejo>();
                //    listaAux = (List<Dominio.Complejo>)base.Session["listaComplejos"];
                //    listaAux.RemoveAll(item => item.ID == Auxiliar.ID);
                //    listaAux.Add(Auxiliar);
                //    Session["listaComplejos"] = negocio.listarComplejos();
                //    Response.Redirect("DetalleComplejo.aspx?idComplejo=" + Auxiliar.ID);
                //}
            }

            catch (Exception ex)
            {

                // Response.Redirect("Error.aspx");
                throw ex;
            }
        }
    }
}