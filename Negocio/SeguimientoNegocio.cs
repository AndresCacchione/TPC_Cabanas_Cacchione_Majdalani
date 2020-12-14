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
                access.AgregarParametroSP("@IDAdmin", seguimiento.IDAdmin, SqlDbType.BigInt);
                access.AgregarParametroSP("@IDCliente", seguimiento.IDCliente, SqlDbType.BigInt);
                access.AgregarParametroSP("@IDTabla", seguimiento.IDTabla, SqlDbType.BigInt);
                access.AgregarParametroSP("@IDTablaAnterior", seguimiento.IDTablaAnterior, SqlDbType.BigInt);
                access.AgregarParametroSP("@IDTablaNuevo", seguimiento.IDTablaNuevo, SqlDbType.BigInt);
                access.AgregarParametroSP("@Motivo", seguimiento.Motivo, SqlDbType.VarChar);
                access.EjecutarStoredProcedure("spCargarSeguimiento");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long GetIDTabla(string nombreTabla)
        {
            AccessDB accessDB = new AccessDB();
            long retorno = new long();
            try
            {
                accessDB.SetearQuery("select IDTabla from tablas where nombre = @nombre");
                accessDB.AgregarParametro("@nombre",nombreTabla);
                accessDB.EjecutarLector();
                accessDB.Lector.Read();
                
                if(!accessDB.Lector.IsDBNull(0))
                    retorno = (long)accessDB.Lector["IDTabla"]; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }
    }
}
