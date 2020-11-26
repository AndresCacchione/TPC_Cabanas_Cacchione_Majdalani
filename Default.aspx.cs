using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ManagementDB managementDB = new ManagementDB();
            managementDB.CrearTablasDB();
            managementDB.SetTRInsteadOfDELComplejos();
            managementDB.SetTRInsteadOfDELCabañas();
            managementDB.CargaPaises();
            managementDB.CargarNiveles();
<<<<<<< HEAD
            managementDB.CargarUsuarios();
=======

>>>>>>> b1da98a86c83c4a1aff2e8e8b7c362ec8d5f3e4b
        }
	}
}