using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class VerReservas : Page
    {
        public VerReservas()
        {
            ListaDeReservas = new List<Reserva>();
        }
        public List<Reserva> ListaDeReservas { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Session.SessionID + "userSession"] != null) //Si no está logueado, que redirija al login
                {
                    CargarReservas();
                }
                else
                {
                    Response.Redirect("~/Login");
                }
            }
        }

        private void CargarReservas()
        {
                        
                DDLReservaEstados.SelectedIndex = Convert.ToInt32(Request.QueryString["IndexEstados"]);
                DDLReservaVigencia.SelectedIndex = Convert.ToInt32(Request.QueryString["IndexVigencia"]);

            
            switch (DDLReservaEstados.SelectedItem.Text)
            {
                case (""):
                    break;
                case ("Pendientes"):
                    {
                            if (DDLReservaVigencia.SelectedItem.Text=="Vigente")
                        {
                            if (((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso == 10)
                            {
                                ListarReservasPorUsuarioVigentes(Convert.ToInt64(((Dominio.Usuario)Session[Session.SessionID + "userSession"]).Id), 1);
                            }
                            else if (((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso >= 20)
                            {
                                ListarReservasVigentes(1);

                            }

                        }
                        if(DDLReservaVigencia.SelectedItem.Text == "Caduca")
                        { 
                            if (((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso == 10)
                            {
                                ListarReservasPorUsuarioCaducas(Convert.ToInt64(((Dominio.Usuario)Session[Session.SessionID + "userSession"]).Id), 1);
                            }
                            else if (((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso >= 20)
                            {
                                ListarReservasCaducas(1);

                            }
                            
                        }
                    }
                    break;
                case ("Confirmadas"):
                    {
                        if (DDLReservaVigencia.SelectedItem.Text == "Vigente")
                        {
                            ListarReservasVigentes(2);
                        }
                        if (DDLReservaVigencia.SelectedItem.Text == "Caduca")
                        {
                            ListarReservasCaducas(2);
                        }
                    }
                    break;
                case ("Canceladas"):
                    {
                        if (DDLReservaVigencia.SelectedItem.Text == "Vigente")
                        {
                            ListarReservasVigentes(3);
                        }
                        if (DDLReservaVigencia.SelectedItem.Text == "Caduca")
                        {
                            ListarReservasCaducas(3);
                        }
                    }
                    break;
                default:
                    { Response.Redirect("Default.aspx"); }
                    break;
            }
        }

        private void ListarReservasPorUsuarioVigentes(long id, byte estado)
        {
            ReservaNegocio NegocioReserva = new ReservaNegocio();
            if (Session["ListaDeReservasPorUsuarioVigente" + estado.ToString()] == null)
            {
                ListaDeReservas = NegocioReserva.ListarReservasVigentesPorUsuario(id);
                Session.Add("ListaDeReservasPorUsuarioVigente" + estado.ToString(), ListaDeReservas);
            }
            else
            {
                ListaDeReservas = (List<Reserva>)Session["ListaDeReservasPorUsuarioVigente" + estado.ToString()];
            }
        }
        private void ListarReservasPorUsuarioCaducas(long id, byte estado)
        {
            ReservaNegocio NegocioReserva = new ReservaNegocio();
            if (Session["ListaDeReservasPorUsuarioCaducas" + estado.ToString()] == null)
            {
                ListaDeReservas = NegocioReserva.ListarReservasCaducasPorUsuario(id,estado);
                Session.Add("ListaDeReservasPorUsuarioCaducas" + estado.ToString(), ListaDeReservas);
            }
            else
            {
                ListaDeReservas = (List<Reserva>)Session["ListaDeReservasPorUsuarioCaducas" + estado.ToString()];
            }
        }


        private void ListarReservasCaducas(byte estado)
        {
            ReservaNegocio NegocioReserva = new ReservaNegocio();
            if (Session["ListaDeReservasCaducas" + estado.ToString()] == null)
            {
                ListaDeReservas = NegocioReserva.ListarReservasCaducasPorEstado(estado);
                Session.Add("ListaDeReservasCaducas" + estado.ToString(), ListaDeReservas);
            }
            else
            {
                ListaDeReservas = (List<Reserva>)Session["ListaDeReservasCaducas" + estado.ToString()];
            }
        }

        private void ListarReservasVigentes(byte estado)
        {
            ReservaNegocio NegocioReserva = new ReservaNegocio();
            if (Session["ListaDeReservasVigentes" + estado.ToString()] == null)
            {
                ListaDeReservas = NegocioReserva.ListarReservasVigentesPorEstado(estado);
                Session.Add("ListaDeReservasVigentes" + estado.ToString(), ListaDeReservas);
            }
            else
            {
                ListaDeReservas = (List<Reserva>)Session["ListaDeReservasVigentes" + estado.ToString()];
            }
        }

        protected void DDLReservaVigencia_TextChanged(object sender, EventArgs e)
        {
            string IndexEstados = Convert.ToString(DDLReservaEstados.SelectedIndex);
            string IndexVigencia = Convert.ToString(DDLReservaVigencia.SelectedIndex);
            Response.Redirect("VerReservas.aspx?IndexEstados=" + IndexEstados + "&?IndexVigencia=" + IndexVigencia);

        }

        protected void DDLReservaEstados_TextChanged(object sender, EventArgs e)
        {
            string IndexEstados = Convert.ToString(DDLReservaEstados.SelectedIndex);
            string IndexVigencia = Convert.ToString( DDLReservaVigencia.SelectedIndex);
            Response.Redirect("VerReservas.aspx?IndexEstados=" + IndexEstados + "&?IndexVigencia=" +IndexVigencia);

        }
    }
}