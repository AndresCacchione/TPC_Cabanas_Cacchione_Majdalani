using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ReservaNegocio
    {
        public void InsertarReserva(Reserva reserva)
        {
            AccessDB access = new AccessDB();
            try
            {
            access.SetearQuery("insert into reservas values(@IdCabaña,@IdUsuario,@FechaIngreso,@FechaEgreso,@CantPersonas,@FechaReserva,@Importe,@Estado,@IdReservaOriginal)");
            access.AgregarParametro("@IdCabaña",reserva.Cabaña.Id);
            access.AgregarParametro("@IdUsuario", reserva.Cliente.Id);
            access.AgregarParametro("@CantPersonas", reserva.CantPersonas);
            access.AgregarParametro("@Estado", reserva.Estado);
            access.AgregarParametro("@FechaReserva", reserva.FechaCreacionReserva);
            access.AgregarParametro("@FechaEgreso", reserva.FechaEgreso);
            access.AgregarParametro("@Importe", reserva.Importe);
            access.AgregarParametro("@FechaIngreso", reserva.FechaIngreso);
            access.AgregarParametro("@IdReservaOriginal", reserva.IdReservaOriginal);
            access.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
        

        }

    }
}
