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
            //EN CASO DE QUE NO SE PUEDA ACCEDER A LA BASE DESCOMENTAR PARA HACER LOGIN CON
            //USUARIO: Admin CONTRASEÑA: Admin
            ManagementDB managementDB = new ManagementDB();
            managementDB.CrearSpAgregarReserva();
            managementDB.CrearTablasDB();
            managementDB.SetTRInsteadOfDELComplejos();
            managementDB.SetTRInsteadOfDELCabañas();
            managementDB.CargaPaises();
            managementDB.CargarNiveles();
            managementDB.CargarUsuarios();
            //Response.Redirect("~/Default");
        }
    }
}