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
    public partial class Reservas : Page
    {
        public Reservas()
        {
            reserva = new Reserva();
            Fechas = new Dictionary<string, DateTime>();
        }

        public Reserva reserva { get; set; }
        public Dictionary<string, DateTime> Fechas { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            CargarDiccionarioFechas();
            long idCabaña = Convert.ToInt64(Request.QueryString["idCabaña"]);

            if ((Usuario)Session[Session.SessionID + "userSession"] == null || idCabaña == 0)
            {
                Response.Redirect("Login.aspx");
            }
            CargarCabaña(idCabaña);
            reserva.Cliente = (Usuario)Session[Session.SessionID + "userSession"];

        }

        private void CargarTextBoxsFechas()
        {
            if (Fechas.Keys.Contains("fechaIngreso"))
            {
                HoraIngreso.Text = reserva.Cabaña.CheckIn.TimeOfDay.ToString();
                FechaDeIngreso.Text = Fechas["fechaIngreso"].ToShortDateString();
            }
            if (Fechas.Keys.Contains("fechaEgreso"))
            {
                HoraEgreso.Text = reserva.Cabaña.CheckOut.TimeOfDay.ToString();
                FechaDeEgreso.Text = Fechas["fechaEgreso"].ToShortDateString();
            }
        }

        private void CargarDiccionarioFechas()
        {
            if (Session["fechasDelCalendario"] == null)
            {
                Session.Add("fechasDelCalendario", Fechas);
            }
            else
            {
                Fechas = (Dictionary<string, DateTime>)Session["fechasDelCalendario"];
            }
        }

        private void CargarCabaña(long idCabaña)
        {
            if (Session["listaCabañas"] != null)
            {
                reserva.Cabaña = ((List<Cabaña>)Session["listaCabañas"]).Find(i => i.Id == idCabaña);
            }
            else
            {
                CabañaNegocio NegocioCabaña = new CabañaNegocio();
                List<Cabaña> aux = new List<Cabaña>();
                aux = NegocioCabaña.listarCabañas();
                Session.Add("listaCabañas", aux);
                reserva.Cabaña = aux.Find(i => i.Id == idCabaña);
            }
        }


        private void GuardarReserva()
        {

            reserva.Estado = 1; //estado 1 = Pendiente, estado 2 = Confirmada, estado 3 = Cancelada
            reserva.FechaCreacionReserva = DateTime.Today;
            reserva.FechaEgreso = Convert.ToDateTime(FechaDeEgreso.Text);
            reserva.FechaIngreso = Convert.ToDateTime(FechaDeIngreso.Text);
            TimeSpan dateSpan = reserva.FechaEgreso - reserva.FechaIngreso;
            reserva.Importe = dateSpan.Days * reserva.Cabaña.PrecioDiario;
            reserva.IdReservaOriginal = 0; // 0 sería null en la DB  
        }

        private void CargarReserva()
        {
            /// aca habria que guardar lo del front en la reserva cuando se modifique una reserva


        }

        protected void Reservar_Click(object sender, EventArgs e)
        {
            //RESERVA
            ReservaNegocio NegocioReserva = new ReservaNegocio();
            GuardarReserva();
            reserva.CantPersonas = Convert.ToByte(CantidadDePersonas.Text);
            if (reserva.CantPersonas <= reserva.Cabaña.Capacidad && reserva.CantPersonas > 0)
            {
                bool inserto = NegocioReserva.InsertarReserva(reserva);
                //ENVIO DE MAIL AL USUARIO QUE RESERVO Y AL ADMINISTRADOR PARA QUE 
                if (inserto)
                {
                    ManagementEmail managementEmail = new ManagementEmail();

                    //DESPUES DE MANAGEMENT EMAIL INSERTAR POP UP
                    //Envio mail a los admins
                    managementEmail.EnviarEmails(MailDestino2(), "Alta de Reserva (Verficar pago)", CuerpoMail2());
                    //Mail de cliente
                    List<string> EmailCliente = new List<string>();
                    EmailCliente.Add(reserva.Cliente.DatosPersonales.Email);
                    /// SETEARLE AL ADMINISTRADOR EL MAIL DEL COMPLEJO QUE ADMINISTRA
                    managementEmail.EnviarEmails(EmailCliente, "Enviar comprobante de pago AL MAIL COMPLEJO", CuerpoMail2());
                    EliminarSesionDeReservas();
                    Response.Redirect("VerReservas.aspx");
                }
                else
                {
                    LblCalendario.Text = "Verifique los datos ingresados ";
                }
            }
            else
            {

                LblCalendario.Text = "Verifique la cantidad de personas ";

            }

        }
        public void EliminarSesionDeReservas()
        {
            Session.Remove("ListaDeReservasPorUsuarioVigente1");
            Session.Remove("ListaDeReservasPorUsuarioVigente2");
            Session.Remove("ListaDeReservasPorUsuarioVigente3");
            Session.Remove("ListaDeReservasPorUsuarioCaducas1");
            Session.Remove("ListaDeReservasPorUsuarioCaducas2");
            Session.Remove("ListaDeReservasPorUsuarioCaducas3");
            Session.Remove("ListaDeReservasCaducas1");
            Session.Remove("ListaDeReservasCaducas2");
            Session.Remove("ListaDeReservasCaducas3");
            Session.Remove("ListaDeReservasVigentes1");
            Session.Remove("ListaDeReservasVigentes2");
            Session.Remove("ListaDeReservasVigentes3"); 

        }
        private string CuerpoMail2()
        {
            string CuerpoMail;
            CuerpoMail = $@"Datos de la reserva
Fecha de la Creacion de la reserva : {reserva.FechaCreacionReserva} 
Fecha de inicio de la reserva      : dia {reserva.FechaIngreso} - hora checkin {reserva.Cabaña.CheckIn}
Fecha de fin de la reserva         : dia {reserva.FechaEgreso} - hora checkout {reserva.Cabaña.CheckOut}

Complejo: {reserva.Cabaña.complejo.Nombre}
Direccion del complejo:{reserva.Cabaña.complejo.Ubicacion}
Telefono: {reserva.Cabaña.complejo.Telefono} Mail: {reserva.Cabaña.complejo.Mail}
foto del complejo: {reserva.Cabaña.complejo.Imagen}
foto de la cabaña: {reserva.Cabaña.Imagen}
  
Cantidad de huespedes: {reserva.CantPersonas}
Importe de la reserva: {reserva.Importe}
          
Datos del cliente
Nombre            : {reserva.Cliente.DatosPersonales.Nombre}
Apellido          : {reserva.Cliente.DatosPersonales.Apellido}
Dni               : {reserva.Cliente.DatosPersonales.DNI}
Telefono          : {reserva.Cliente.DatosPersonales.Telefono}
Mail              : {reserva.Cliente.DatosPersonales.Email}
";


            return CuerpoMail;

        }

        private List<string> MailDestino2()
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            if (Session["listaUsuarios"] == null)
            {
                Session.Add("listaUsuarios", usuarioNegocio.ListarUsuarios());
            }
            List<Usuario> listaUsuarios = (List<Usuario>)Session["listaUsuarios"];

            List<Usuario> listaAdmin = listaUsuarios.FindAll(i => i.NivelAcceso >= 20); //20 es el nivel de acceso del admin
            byte minAcceso = listaAdmin.Min(i => i.NivelAcceso);
            listaAdmin = listaAdmin.FindAll(i => i.NivelAcceso == minAcceso);

            List<string> Emails = listaAdmin.Select(o => o.DatosPersonales.Email).ToList();

            return Emails;
        }

        protected void BotonBorrarSeleccion_Click(object sender, EventArgs e)
        {
            Calendar1.SelectedDates.Clear();
            Session.Remove("fechasDelCalendario");
            FechaDeIngreso.Text = null;
            FechaDeEgreso.Text = null;
            HoraEgreso.Text = null;
            HoraIngreso.Text = null;
            CantidadDePersonas.Text = null;
            importes.Text = null;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            if (!Fechas.ContainsKey("fechaIngreso"))
            {
                Fechas.Add("fechaIngreso", Calendar1.SelectedDate);
                Fechas.Add("fechaEgreso", Fechas["fechaIngreso"].Date.AddDays(1));
            }
            else if (Calendar1.SelectedDate < Fechas["fechaIngreso"])
            {
                Fechas["fechaIngreso"] = Calendar1.SelectedDate;
            }
            else if (Calendar1.SelectedDate > Fechas["fechaEgreso"])
            {
                Fechas["fechaEgreso"] = Calendar1.SelectedDate;
            }

            if (Fechas.Keys.Count() == 2)
            {
                Calendar1.SelectedDates.SelectRange(Fechas["fechaIngreso"], Fechas["fechaEgreso"]);
            }

            Session.Add("fechasDelCalendario", Fechas);

            CargarTextBoxsFechas();

            GuardarReserva();
            importes.Text = reserva.Importe.ToString();
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            CabañaNegocio cabañaNegocio = new CabañaNegocio();
            List<List<DateTime>> Ocupado = cabañaNegocio.ListaOcupadoPorCabaña(reserva.Cabaña.Id);

            foreach (List<DateTime> ReservasPrevias in Ocupado)
            {
                DateTime fechaIngreso = ReservasPrevias.First();
                DateTime fechaEgreso = ReservasPrevias.Last();

                if (e.Day.Date < DateTime.Now)
                {
                    e.Day.IsSelectable = false;
                    e.Cell.BackColor = System.Drawing.Color.LightGray;
                    e.Cell.ForeColor = System.Drawing.Color.Gray;
                }
                else if (e.Day.Date < fechaEgreso && e.Day.Date >= fechaIngreso)
                {
                    e.Day.IsSelectable = false;
                    e.Cell.ForeColor = System.Drawing.Color.Red;
                    e.Cell.Text = e.Cell.Text + "Reservado";
                    if (e.Day.IsToday)
                    {
                        e.Cell.BackColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        e.Cell.BackColor = System.Drawing.Color.LightGray;
                    }
                }
                else if (e.Day.IsToday)
                {
                    e.Cell.BackColor = System.Drawing.Color.LightSkyBlue;
                }
            }
        }
    }
}
