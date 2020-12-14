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
    public partial class ResolverReservas : Page
    {
        public ResolverReservas()
        {

            Reserva = new Reserva()
            {
                Cliente = new Usuario(),
                Cabaña = new Cabaña()
            };
            Administrador = new Administrador();
            Seguimiento = new Seguimiento();
            //{
            //    IDTablaNuevo = null,
            //    IDAdmin = null,
            //    IDCliente = null
            //};
        }
        public Administrador Administrador { get; set; }
        public Seguimiento Seguimiento { get; set; }
        public Reserva Reserva { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Session.SessionID + "userSession"] != null) //Si no está logueado, que redirija al login
            {

                if (Request.QueryString["idReserva"] != null)
                {
                    long IdReserva = Convert.ToInt64(Request.QueryString["idReserva"]);
                    // byte estado = Convert.ToByte(Request.QueryString["Estado"]);
                    ReservaNegocio NegocioReserva = new ReservaNegocio();
                    Reserva = NegocioReserva.ListarReservaPorId(IdReserva);
                    Administrador.usuario = (Usuario)Session[Session.SessionID + "userSession"];

                }
                else
                {
                    Response.Redirect("~/Default");
                }
            }
            else
            {
                Response.Redirect("~/Login");
            }
        }

        protected void btnConfirmada_Click(object sender, EventArgs e)
        {
            ReservaNegocio NegocioReserva = new ReservaNegocio();
            txtMotivo.Text = "Confirmación alta.";
            GuardarFormularioSeguimiento(2);
            NegocioReserva.ResolverReserva(Reserva.ID, 2);
            EliminarSesionDeReservas();
            Response.Redirect("~/VerReservas");
        }

        public void EliminarSesionDeReservas()
        {
            Session.Remove("ListaDeReservasPorUsuarioVigente1");
            Session.Remove("ListaDeReservasPorUsuarioVigente2");
            Session.Remove("ListaDeReservasPorUsuarioVigente3");
            Session.Remove("ListaDeReservasPorUsuarioCaducas1");
            Session.Remove("ListaDeReservasPorUsuarioCaducas2");
            Session.Remove("ListaDeReservasPorUsuarioCaducas3");
            Session.Remove("ListaDeReservasCaducas1");
            Session.Remove("ListaDeReservasCaducas2");
            Session.Remove("ListaDeReservasCaducas3");
            Session.Remove("ListaDeReservasVigentes1");
            Session.Remove("ListaDeReservasVigentes2");
            Session.Remove("ListaDeReservasVigentes3");
        }

        public void GuardarFormularioSeguimiento(byte nuevoEstado)
        {
            SeguimientoNegocio seguimientoNegocio = new SeguimientoNegocio();
            Seguimiento.IDAdmin = ((Usuario)Session[Session.SessionID + "userSession"]).Id;
            Seguimiento.IDCliente = Reserva.Cliente.Id;
            Seguimiento.IDTabla = seguimientoNegocio.GetIDTabla("Reservas");
            Seguimiento.IDTablaAnterior = Reserva.ID;
            Seguimiento.Motivo = "Motivo: "+ txtMotivo.Text + "Cambio en Reserva." + "Estado anterior: "+ Reserva.Estado +
                "Estado actualizado: "+nuevoEstado.ToString() + " .- Administrador:" + Administrador.usuario.NombreUsuario +
                ", Cliente:" + Reserva.Cliente.NombreUsuario + ", " + " ID Tabla Anterior:" + Seguimiento.IDTablaAnterior;
            seguimientoNegocio.GuardarSeguimiento(Seguimiento);
        }

        protected void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            ReservaNegocio NegocioReserva = new ReservaNegocio();
            GuardarFormularioSeguimiento(3);
            NegocioReserva.ResolverReserva(Reserva.ID, 3);
            EliminarSesionDeReservas();
            Response.Redirect("~/VerReservas");
        }
    }
}