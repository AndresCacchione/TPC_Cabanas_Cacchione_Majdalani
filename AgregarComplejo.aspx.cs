using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Microsoft.Ajax.Utilities;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class AgregarComplejo : System.Web.UI.Page
    {
        public Complejo Auxiliar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void BtnAgregarComplejo_Click(object sender, EventArgs e)
        {
            Auxiliar.PrecioFeriado=TxtTelefonoAgregarComplejo.c


        }
    }
}