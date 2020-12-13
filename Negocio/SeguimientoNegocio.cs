using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dominio;

namespace Negocio
{
    public class SeguimientoNegocio
    {
        public void GuardarSeguimiento(Seguimiento seguimiento)
        {
            AccessDB access = new AccessDB();
            try
            {
                access.EjecutarStoredProcedure("spCargarSeguimiento");
                access.AgregarParametroSP("@IDAdmin", seguimiento.IDAdmin, SqlDbType.BigInt);
                access.AgregarParametroSP("@IDCliente", seguimiento.IDCliente, SqlDbType.BigInt);
                //access.AgregarParametroSP("@Fecha", seguimiento.Fecha, SqlDbType.Date);
                access.AgregarParametroSP("@IDTabla", seguimiento.IDTabla, SqlDbType.BigInt);
                access.AgregarParametroSP("@IDTablaAnterior", seguimiento.IDTablaAnterior, SqlDbType.BigInt);
                access.AgregarParametroSP("@IDTablaNuevo", seguimiento.IDTablaNuevo, SqlDbType.BigInt);
                access.AgregarParametroSP("@Motivo", seguimiento.Motivo, SqlDbType.VarChar);
                access.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
