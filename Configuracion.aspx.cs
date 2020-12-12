using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class Configuracion : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            RestaurarValoresFabrica();
        }

        private void RestaurarValoresFabrica()
        {
            //levantar un popup y volver a confirmar de borrar todo. Podríamos poner alguna contraseña del Dueño para confirmar
            ManagementDB managementDB = new ManagementDB(); //https://getbootstrap.com/docs/4.2/components/modal/ similar al pop-up, maxi nos dijo de usar este si mal no recuerdo
            AccessDB access = new AccessDB();
            managementDB.BorrarTablas();
            managementDB.CrearTablasDB();
            managementDB.CrearSPIngresarUsuario();
            managementDB.SetTRInsteadOfDELComplejos();
            managementDB.SetTRInsteadOfDELCabañas();
            managementDB.CargaPaises();
            managementDB.CargarNiveles();
            managementDB.CargarUsuarios();
            managementDB.CrearVistaAdministradoresPorComplejo();
            managementDB.CrearSpAgregarReserva();
            managementDB.CrearSPCargarTablaDeTablas();
            access.EjecutarStoredProcedure("CargarTablas");
            Session.Clear();
            Response.Redirect("~/Default"); //una vez borradas todas las tablas, en el mismo load de default se ejecuta todo (creación de tablas, SP, TR, inserts, etc)
        }
    }
}