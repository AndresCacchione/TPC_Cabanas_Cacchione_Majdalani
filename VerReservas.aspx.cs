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
            ListarReservasCaducas();

        }
        private void ListarReservasCaducas()
        {
            ReservaNegocio NegocioReserva = new ReservaNegocio();
            if (Session["ListaDeReservasCaducas"] == null)
            {
                ListaDeReservas = NegocioReserva.ListarReservasCaducas();
                Session.Add("ListaDeReservasCaducas", ListaDeReservas);
            }
            else
            {
                ListaDeReservas = (List<Reserva>)Session["ListaDeReservasCaducas"];
            }
        }
    }
}