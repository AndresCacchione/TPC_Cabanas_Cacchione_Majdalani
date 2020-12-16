using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPC_CacchioneMajdalani
{
    public partial class VerSeguimientos : Page
    {
        public List<Seguimiento> ListaSeguimientos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Session.SessionID + "userSession"] != null) 
                {
                    
                }
                else
                {
                    Response.Redirect("~/Login");
                }
            }
        }
    }
}