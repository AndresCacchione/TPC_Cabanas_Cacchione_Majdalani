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
    public partial class Reservas : Page
    {
        public Reserva reserva { get; set; }

        public Reservas()
        {
            reserva = new Reserva();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            long idCabaña = Convert.ToInt64(Request.QueryString["idCabaña"]);
            long idUsuario = Convert.ToInt64(Request.QueryString["idUsuario"]);

            if (idUsuario != 0 && idCabaña != 0)
            {
                CargarCabaña(idCabaña);
                reserva.Cliente = (Usuario)Session[Session.SessionID + "userSession"];
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        private void CargarCabaña(long idCabaña)
        {
            if (Session["listaCabañas"] != null)
            {
                reserva.Cabaña = ((List<Cabaña>)Session["listaCabañas"]).Find(i => i.Id == idCabaña);
            }
            else
            {
                CabañaNegocio NegocioCabaña = new CabañaNegocio();
                List<Cabaña> aux = new List<Cabaña>();
                aux = NegocioCabaña.listarCabañas();
                Session.Add("listaCabañas", aux);
                reserva.Cabaña = aux.Find(i => i.Id == idCabaña);
            }
        }


        private void GuardarReserva()
        {
            reserva.CantPersonas = Convert.ToByte(CantidadPersonas.Value);
            reserva.Estado = 1; //estado 1 = Pendiente, estado 2 = Confirmada, estado 3 = Cancelada
            reserva.FechaCreacionReserva = DateTime.Today;
            reserva.FechaEgreso = Convert.ToDateTime(FechaEgreso.Value);
            reserva.FechaIngreso = Convert.ToDateTime(FechaIngreso.Value);
            TimeSpan dateSpan = reserva.FechaEgreso - reserva.FechaIngreso;
            reserva.Importe = dateSpan.Days * reserva.Cabaña.PrecioDiario;
            reserva.IdReservaOriginal = 0; // 0 sería null en la DB
        }

        private void CargarReserva()
        {
            /// aca abria que guardar lo del front en la reserva


        }

        protected void Reservar_Click(object sender, EventArgs e)
        {
            ReservaNegocio NegocioReserva = new ReservaNegocio();
            GuardarReserva();
            NegocioReserva.InsertarReserva(reserva);
        }
    }
}