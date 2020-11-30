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
        //InsertarNuevaReserva(servaVieja, reservaNueva); // en modificar reserva sería InsertarNuevaReserva(servaVieja, reservaNueva) esto no cambia

        //ResolverReserva(reserva.id); // Solo a este campo hay que hacer un modificar reserva (para el admin: 1 Pendiente, 2 Confirmada, 3 Rechazada, 4 Cambiada)

        //ListarReservasVigentes();

        //ListarReservasNoVigentes();

        //ListarReservasVigentesPorUsuario(idUsuario); // Listaríamos solo las reservas que, al día de hoy, estén antes de la fecha de egreso.

        //ListarReservasNoVigentesPorUsuario(idUsuario); // Listaríamos solo las reservas que, al día de hoy, estén antes de la fecha de egreso.

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
            access.AgregarParametro("@FechaReserva", reserva.FechaCreacionReserva); // esto no cambia nunca
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

        public List<Reserva> ListarReservasVigentesPorUsuario(long idUsuario)
        {
            List<Reserva> listaVigentesUsuario = new List<Reserva>();
            AccessDB access = new AccessDB();
            try
            {
                access.SetearQuery("select * from reservas where fechaegreso<getdate() and idusuario=" + idUsuario);
                access.EjecutarLector();
                while (access.Lector.Read())
                {
                    Reserva aux = new Reserva
                    {                       
                        Cliente = new Usuario
                        {
                            Id=(long)access.Lector["idUsuario"]
                        },
                        Cabaña = new Cabaña
                        {
                            Id=(long)access.Lector["idCabaña"]
                        },
                        FechaIngreso = (DateTime)access.Lector["fechaIngreso"],
                        FechaEgreso = (DateTime)access.Lector["fechaEgreso"],
                        CantPersonas=(byte)access.Lector["cantidadPersonas"],
                        FechaCreacionReserva = (DateTime)access.Lector["fechaReserva"],
                        Importe = (decimal)access.Lector["importe"],
                        Estado = (byte)access.Lector["estado"],
                        IdReservaOriginal = (long)access.Lector["IDReservaOriginal"]
                    };

                    listaVigentesUsuario.Add(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
            return listaVigentesUsuario;
        }


        public List<Reserva> ListarReservasNoVigentesPorUsuario(long idUsuario)
        {
            List<Reserva> listaNoVigentesUsuario = new List<Reserva>();
            AccessDB access = new AccessDB();
            try
            {
                access.SetearQuery("select * from reservas where fechaegreso>=getdate() and idusuario=" + idUsuario);
                access.EjecutarLector();
                while (access.Lector.Read())
                {
                    Reserva aux = new Reserva
                    {
                        Cliente = new Usuario
                        {
                            Id = (long)access.Lector["idUsuario"]
                        },
                        Cabaña = new Cabaña
                        {
                            Id = (long)access.Lector["idCabaña"]
                        },
                        FechaIngreso = (DateTime)access.Lector["fechaIngreso"],
                        FechaEgreso = (DateTime)access.Lector["fechaEgreso"],
                        CantPersonas = (byte)access.Lector["cantidadPersonas"],
                        FechaCreacionReserva = (DateTime)access.Lector["fechaReserva"],
                        Importe = (decimal)access.Lector["importe"],
                        Estado = (byte)access.Lector["estado"],
                        IdReservaOriginal = (long)access.Lector["IDReservaOriginal"]
                    };

                    listaNoVigentesUsuario.Add(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
            return listaNoVigentesUsuario;
        }

    }
}

//public DateTime FechaCreacionReserva { get; set; }
//public Usuario Cliente { get; set; }
//public Cabaña Cabaña { get; set; }
//public DateTime FechaIngreso { get; set; }
//public DateTime FechaEgreso { get; set; }
//public byte CantPersonas { get; set; }
//public byte Estado { get; set; }
//public long IdReservaOriginal { get; set; }
//public decimal Importe { get; set; }
