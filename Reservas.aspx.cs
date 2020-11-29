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
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio NegocioUsuario = new UsuarioNegocio();
            CabañaNegocio NegocioCabaña = new CabañaNegocio();
            long idCabaña = Convert.ToInt64(Request.QueryString["idCabaña"]);

            long idUsuario = Convert.ToInt64(Request.QueryString["idUsuario"]);

            reserva.Cabaña = (Cabaña)NegocioCabaña.ListarCabañaPorId(idCabaña);
            reserva.Cliente = (Usuario)NegocioUsuario.ListarUsuarioPorId(idUsuario);
        }
        private void CargarReserva()
        {
            /// aca abria que cargar lo del front en la reserva

        }

        private void GuardarReserva()
        {
            /// aca abria que guardar lo del front en la reserva


        }


    }
}