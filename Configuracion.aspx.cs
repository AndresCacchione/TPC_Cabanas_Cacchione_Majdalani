using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class Configuracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            //levantar un popup y volver a confirmar de borrar todo. Podríamos poner alguna contraseña del Dueño para confirmar
            ManagementDB managementDB = new ManagementDB();
            managementDB.BorrarTablas();
            managementDB.CrearTablasDB();
            managementDB.SetTRInsteadOfDELComplejos();
            managementDB.SetTRInsteadOfDELCabañas();
            managementDB.CargaPaises();
            managementDB.CargarNiveles();
            managementDB.CargarUsuarios();
            Response.Redirect("~/Default"); //una vez borradas todas las tablas, en el mismo load de default se ejecuta todo (creación de tablas, SP, TR, inserts, etc)
        }
    }
}