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
        public Complejo Auxiliar { get; set; }
        
        private void CargarFormulario()
        {
            Imagen.Value = this.Auxiliar.Imagen;
            Nombre.Value = this.Auxiliar.Nombre;
            Email.Value = this.Auxiliar.Mail;
            AumentoFeriado.Value = this.Auxiliar.PrecioFeriado.ToString();
            Telefono.Value = this.Auxiliar.Telefono;
            Direccion.Value = this.Auxiliar.Ubicacion;
        }

        private void GuardarFormulario()
        {
            this.Auxiliar.Imagen = Imagen.Value;
            this.Auxiliar.Nombre = Nombre.Value;
            this.Auxiliar.Mail = Email.Value;
            this.Auxiliar.PrecioFeriado = decimal.Parse(AumentoFeriado.Value);
            this.Auxiliar.EstadoActivo = true;
            this.Auxiliar.Telefono = Telefono.Value;
            this.Auxiliar.Ubicacion = Direccion.Value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Auxiliar = new Complejo
            {
                ID = Convert.ToInt64(Request.QueryString["IdComplejo"])
            };
            if (Auxiliar.ID!=0)
            {
                List<Complejo> listaAux = new List<Complejo>();
                listaAux = (List<Complejo>)Session["listaComplejos"];
                Auxiliar = listaAux.Find(i => i.ID == Auxiliar.ID);

                CargarFormulario();
                BtnAgregarComplejo.Text = "Modificar Complejo";
                BtnAgregarComplejo.BackColor = System.Drawing.Color.FromArgb(228, 192, 50);
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
                    //negocio.agregar();
                }

                else
                {
                    //negocio.modificar();
                }

                //Response.Redirect("Complejos.aspx");
            }

            catch (Exception ex)
            {
                throw ex;
                //Response.Redirect("Error.aspx");
            }
        }
    }
}