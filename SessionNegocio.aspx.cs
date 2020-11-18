using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_CacchioneMajdalani
{
    public partial class SessionNegocio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

         public void setComplejo(Int64 IDcomplejo)
        {
            if(Session["IDcomplejo"]==null)
            {
                Session.Add("IDcomplejo", IDcomplejo);
            }
            
            else
            {
                Session["IDcomplejo"] = IDcomplejo;
            }
        }

        //public void setComplejo(Int64 IDcomplejo)
        //{

        //}






    }
}