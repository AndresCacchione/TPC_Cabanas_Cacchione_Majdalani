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

        protected void BtnAgregarCabaña_Click(object sender, EventArgs e)
        {
            GuardarFormulario();
            CabañaNegocio negocio = new CabañaNegocio();
                    
            List<Dominio.Cabaña> listaAux = new List<Dominio.Cabaña>();
            listaAux = (List<Dominio.Cabaña>)Session["listaCabañas"];
            
            try
            {
                if (Auxiliar.Id == 0)
                {
                    negocio.agregarCabaña(Auxiliar);

                    List<Dominio.Complejo> listaAuxComplejos = new List<Dominio.Complejo>();
                    listaAuxComplejos = (List<Dominio.Complejo>)Session["listaComplejos"];
                    Auxiliar.complejo = listaAuxComplejos.Find(i => i.ID == Auxiliar.complejo.ID);
                    
                    listaAux.Add(Auxiliar);
                    Session["listaCabañas"] = listaAux;
                    Response.Redirect("Cabañas.aspx?idComplejo ="+Auxiliar.complejo.ID);
                }
                
                else
                {
                    negocio.ModificarCabaña(Auxiliar);
                    listaAux.RemoveAll(item => item.Id == Auxiliar.Id);
                    listaAux.Add(Auxiliar);
                    Session["listaCabañas"] = listaAux;
                    Response.Redirect("Cabañas.aspx?idComplejo ="+Auxiliar.complejo.ID);
                }
            }

            catch (Exception ex)
            {

                // Response.Redirect("Error.aspx");
                throw ex;
            }
        }
    }
}