using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            ManagementEmail managementEmail = new ManagementEmail();
          //Resultado.Text = managementEmail.EnviarEmail(mailDestino, txtAsunto.Text, txtBody.Text);
          // Nos falta crear un txtbox y un label del asunto del mail en el front.
          // También falta un método de usuarioNegocio para seleccionar el mail del admin de mayor nivel de permisos al método de la línea 22.
        }
    }
}