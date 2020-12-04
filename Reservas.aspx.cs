﻿using System;
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
        }

        public Reserva reserva { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            long idCabaña = Convert.ToInt64(Request.QueryString["idCabaña"]);
            
            if((Usuario)Session[Session.SessionID + "userSession"]==null || idCabaña==0)
            {
                Response.Redirect("Login.aspx");
            }
            
            CargarCabaña(idCabaña);
            reserva.Cliente = (Usuario)Session[Session.SessionID + "userSession"];
            PrepararCalendario();
        }

        private void PrepararCalendario()
        {
            CabañaNegocio cabañaNegocio = new CabañaNegocio();
            List<List<DateTime>> Ocupado = cabañaNegocio.ListaOcupadoPorCabaña(reserva.Cabaña.Id);
            
            foreach (List<DateTime>ReservasPrevias in Ocupado)
            {
                DateTime horaIngreso = ReservasPrevias.First();
                DateTime horaEgreso = ReservasPrevias.Last();
                //Código del calendario para que pinte en color rojo las que no se pueden seleccionar.

                //protected void DateRange(object sender, DayRenderEventArgs e)
                //{
                //    DateTime rangeStart = new DateTime(2015, 7, 4);
                //    DateTime rangeEnd = new DateTime(2016, 3, 15);

                //    if (e.Day.Date < rangeStart || e.Day.Date > rangeEnd)
                //    {
                //        e.Day.IsSelectable = false;
                //        e.Cell.ForeColor = System.Drawing.Color.Gray;
                //    }
                //}
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
            reserva.CantPersonas = Convert.ToByte(CantidadPersonas.Value);
            reserva.Estado = 1; //estado 1 = Pendiente, estado 2 = Confirmada, estado 3 = Cancelada
            reserva.FechaCreacionReserva = DateTime.Today;
            reserva.FechaEgreso = Convert.ToDateTime(FechaEgreso.Value);
            reserva.FechaIngreso = Convert.ToDateTime(FechaIngreso.Value);
            TimeSpan dateSpan = reserva.FechaEgreso - reserva.FechaIngreso;
            reserva.Importe = dateSpan.Days * reserva.Cabaña.PrecioDiario;
            reserva.IdReservaOriginal = 0; // 0 sería null en la DB
        }

        private void CargarReserva()
        {
            /// aca habria que guardar lo del front en la reserva


        }

        protected void Reservar_Click(object sender, EventArgs e)
        {
            //RESERVA
            ReservaNegocio NegocioReserva = new ReservaNegocio();
            GuardarReserva();     
            NegocioReserva.InsertarReserva(reserva);
            //ENVIO DE MAIL AL USUARIO QUE RESERVO Y AL ADMINISTRADOR PARA QUE 
            
            ManagementEmail managementEmail = new ManagementEmail();
            
            //DESPUES DE MANAGEMENT EMAIL INSERTAR POP UP
            //Envio mail a los admins
            managementEmail.EnviarEmails(MailDestino2(),"Alta de Reserva (Verficar pago)", CuerpoMail2());
            //Mail de cliente
            List<string> EmailCliente = new List<string>();
            EmailCliente.Add(reserva.Cliente.DatosPersonales.Email);
            /// SETEARLE AL ADMINISTRADOR EL MAIL DEL COMPLEJO QUE ADMINISTRA
            managementEmail.EnviarEmails(EmailCliente,"Enviar comprobante de pago AL MAIL COMPLEJO", CuerpoMail2());
            Response.Redirect("Default.aspx");
        }

        private string CuerpoMail2()
        {
            string CuerpoMail;
            CuerpoMail =$@"Datos de la reserva
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

        protected void Calendar1_Load(object sender, EventArgs e)
        {
            //{
            //    DateTime rangeStart = new DateTime(2020, 7, 4);
            //    DateTime rangeEnd = new DateTime(2020, 3, 15);
            //    if (e.Day.Date < rangeStart || e.Day.Date > rangeEnd)
            //    {
            //        e.Day.IsSelectable = false;
            //        e.Cell.ForeColor = System.Drawing.Color.Gray;
            //    }
            //}
        }
    }
}
