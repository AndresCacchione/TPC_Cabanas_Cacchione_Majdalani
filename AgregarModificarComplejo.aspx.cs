using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Antlr.Runtime;
using Dominio;
using Microsoft.Ajax.Utilities;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class AgregarModificarComplejo : System.Web.UI.Page
    {
        public Dominio.Complejo Auxiliar { get; set; }
        
        public void CargarFormulario()
        {
            Imagen.Value = Auxiliar.Imagen;
            Nombre.Value = Auxiliar.Nombre;
            Email.Value = Auxiliar.Mail;
            AumentoFeriado.Value = Auxiliar.PrecioFeriado.ToString();
            Telefono.Value =Auxiliar.Telefono;
            Direccion.Value = Auxiliar.Ubicacion;
        }

        public void GuardarFormulario()
        {
            Auxiliar.Imagen = Imagen.Value;
            Auxiliar.Nombre = Nombre.Value;
            Auxiliar.Mail = Email.Value;
            Auxiliar.PrecioFeriado = decimal.Parse(AumentoFeriado.Value);
            Auxiliar.EstadoActivo = true;
            Auxiliar.Telefono = Telefono.Value;
            Auxiliar.Ubicacion = Direccion.Value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            long ID = Convert.ToInt64(Request.QueryString["IdComplejo"]);
            Auxiliar = new Dominio.Complejo();
            Auxiliar.ID = ID;

            if (Auxiliar.ID != 0)
            {
                List<Dominio.Complejo> listaAux = new List<Dominio.Complejo>();
                listaAux = (List<Dominio.Complejo>)base.Session["listaComplejos"];
                Auxiliar = listaAux.Find(i => i.ID == ID);
                if (!IsPostBack)
                {
                    CargarFormulario();
                    BtnAgregarComplejo.Text = "Modificar Complejo";
                    BtnAgregarComplejo.BackColor = System.Drawing.Color.FromArgb(228, 192, 50);
                }
            }
        }

        protected void BtnAgregarComplejo_Click(object sender, EventArgs e)
        {
            GuardarFormulario();
            ComplejoNegocio negocio = new ComplejoNegocio();

            try
            {
                if (Auxiliar.ID == 0)
                {
                    negocio.AgregarComplejo(Auxiliar);
                    List<Dominio.Complejo> listaAux = new List<Dominio.Complejo>();
                    listaAux = (List<Dominio.Complejo>)base.Session["listaComplejos"];
                    listaAux.Add(Auxiliar);
                    Session["listaComplejos"] = listaAux;
                }
                else
                {
                    negocio.ModificarComplejo(Auxiliar);
                    List<Dominio.Complejo> listaAux = new List<Dominio.Complejo>();
                    listaAux = (List<Dominio.Complejo>)base.Session["listaComplejos"];
                    listaAux.RemoveAll(item => item.ID == Auxiliar.ID);
                    listaAux.Add(Auxiliar);
                    Session["listaComplejos"] = negocio.listarComplejos();
                }
                Response.Redirect("Complejos.aspx");
            }

            catch (Exception ex)
            {

               // Response.Redirect("Error.aspx");
                throw ex;             
            }
        }
    }
}