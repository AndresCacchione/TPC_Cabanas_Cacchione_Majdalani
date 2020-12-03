using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_CacchioneMajdalani
{
    public partial class Calendario : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //Get the Selected Date from Calendar
            DateTime startDate = Calendar1.SelectedDate;
            //Add 10 days to the selected date and set it as end date
            //Change the number 10 as per your need
            DateTime endDate = startDate.AddDays(0);
            //Get the difference between both date in days
            TimeSpan dateSpan = endDate.Date - startDate.Date;

            for (int i = 0; i <= dateSpan.Days; i++)
                //set the dates as selected in calendar
                //Here it will set 10 days as selected from currently selected date
                Calendar1.SelectedDates.Add(startDate.AddDays(i));
        }

        protected void BotonBorrarSeleccion_Click(object sender, EventArgs e)
        {
            Calendar1.SelectedDates.Clear();
        }
    }
}