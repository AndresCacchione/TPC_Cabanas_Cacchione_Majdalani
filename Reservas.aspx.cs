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
    public partial class Reservas : System.Web.UI.Page
    {
        public Reserva reserva { get; set; }

        public Reservas()
        {
            reserva = new Reserva();
        }
         
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio NegocioUsuario = new UsuarioNegocio();
            CabañaNegocio NegocioCabaña = new CabañaNegocio();
          

            long idCabaña = Convert.ToInt64(Request.QueryString["idCabaña"]);
            long idUsuario = Convert.ToInt64(Request.QueryString["idUsuario"]);

            if (Request.QueryString["idUsuario"] != null && Request.QueryString["idCabaña"] != null) {
                reserva.Cabaña = NegocioCabaña.ListarCabañaPorId(idCabaña);
                reserva.Cliente = NegocioUsuario.ListarUsuarioPorId(idUsuario);
               
            } 
        }
        private void GuardarReserva()
        {
            reserva.CantPersonas=Convert.ToByte(CantidadPersonas.Value);
            reserva.Estado=1;
            reserva.FechaCreacionReserva=DateTime.Today;
            reserva.FechaEgreso=Convert.ToDateTime(FechaEgreso.Value);
            reserva.FechaIngreso = Convert.ToDateTime(FechaIngreso.Value);
            TimeSpan dateSpan = reserva.FechaEgreso - reserva.FechaIngreso;
            reserva.Importe =dateSpan.Days * reserva.Cabaña.PrecioDiario;
            reserva.IdReservaOriginal=0;
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