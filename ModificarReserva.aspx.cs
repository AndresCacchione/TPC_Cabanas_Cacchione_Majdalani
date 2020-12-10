using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_CacchioneMajdalani
{
    public partial class ModificarReserva : Page
    {
        public Dominio.Reserva Auxiliar { get; set; }

        public ModificarReserva()
        {
            Auxiliar = new Dominio.Reserva()
            {
                Cliente = new Dominio.Usuario(),
                Cabaña = new Dominio.Cabaña()
            };
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void btnModificarDatos_Click(object sender, EventArgs e)
        //{

        //}
    }
}