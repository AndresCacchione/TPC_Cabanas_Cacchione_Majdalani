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
    public partial class VerReservas : System.Web.UI.Page
    {
        public VerReservas()
        {
            ListaDeReservas = new List<Reserva>();
        }
        public List<Reserva> ListaDeReservas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Session.SessionID + "userSession"] != null) //Si no está logueado, que redirija al login
                CargarReservas();
            else
                Response.Redirect("~/Login");

        }

        private void CargarReservas()
        {
            switch (DDLReservaEstados.SelectedItem.Text)
            {
                case ("Pendientes"):
                    {
                        if (DDLReservaVigencia.SelectedItem.Text == "Vigente")
                        {
                            ListarReservasVigentes(1);
                        }
                        else
                        {
                            ListarReservasCaducas(1);
                        }
                    }
                    break;
                case ("Confirmadas"):
                    {
                        if (DDLReservaVigencia.SelectedItem.Text == "Vigente")
                        {
                            ListarReservasVigentes(2);
                        }
                        else
                        {
                            ListarReservasCaducas(2);
                        }
                    }
                    break;
                case ("Canceladas"):
                    {
                        if (DDLReservaVigencia.SelectedItem.Text == "Vigente")
                        {
                            ListarReservasVigentes(3);
                        }
                        else
                        {
                            ListarReservasCaducas(3);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void ListarReservasCaducas(byte estado)
        {
            ReservaNegocio NegocioReserva = new ReservaNegocio();
            if (Session["ListaDeReservasCaducas" + estado.ToString()] == null)
            {
                ListaDeReservas = NegocioReserva.ListarReservasCaducasPorEstado(estado);
                Session.Add("ListaDeReservasCaducas" + estado.ToString(), ListaDeReservas);
            }
            else
            {
                ListaDeReservas = (List<Reserva>)Session["ListaDeReservasCaducas" + estado.ToString()];
            }
        }

        private void ListarReservasVigentes(byte estado)
        {
            ReservaNegocio NegocioReserva = new ReservaNegocio();
            if (Session["ListaDeReservasVigentes" + estado.ToString()] == null)
            {
                ListaDeReservas = NegocioReserva.ListarReservasVigentesPorEstado(estado);
                Session.Add("ListaDeReservasVigentes" + estado.ToString(), ListaDeReservas);
            }
            else
            {
                ListaDeReservas = (List<Reserva>)Session["ListaDeReservasVigentes" + estado.ToString()];
            }
        }



        protected void DDLReservaEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReservas();
        }

        protected void DDLReservaVigencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReservas();
        }
    }
}