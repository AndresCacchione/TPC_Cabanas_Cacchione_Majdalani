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

        public void InsertarReserva(Reserva reserva)
        {
            AccessDB access = new AccessDB();
            try
            {
                access.SetearQuery("insert into reservas values(@IdCabaña,@IdUsuario,@FechaIngreso,@FechaEgreso,@CantPersonas,@FechaReserva,@Importe,@Estado,@IdReservaOriginal)");
                access.AgregarParametro("@IdCabaña", reserva.Cabaña.Id);
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
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                CabañaNegocio cabañaNegocio = new CabañaNegocio();

                access.SetearQuery("select * from reservas r, usuarios u, cabañas c where fechaegreso<getdate() and " +
                    "r.idcabaña=c.id and idusuario=" + idUsuario);
                access.EjecutarLector();
                while (access.Lector.Read())
                {
                    Reserva aux = new Reserva
                    {

                        Cliente = usuarioNegocio.ListarUsuarioPorId(((long)access.Lector["idUsuario"])),
                        Cabaña = cabañaNegocio.ListarCabañaPorId((long)access.Lector["idCabaña"]),
                        FechaIngreso = (DateTime)access.Lector["fechaIngreso"],
                        FechaEgreso = (DateTime)access.Lector["fechaEgreso"],
                        CantPersonas = (byte)access.Lector["cantidadPersonas"],
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
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                CabañaNegocio cabañaNegocio = new CabañaNegocio();

                access.SetearQuery("select * from reservas r, usuarios u, cabañas c where fechaegreso>=getdate() " +
                    "and r.idcabaña=c.id and r.idusuario=" + idUsuario);
                access.EjecutarLector();
                while (access.Lector.Read())
                {
                    Reserva aux = new Reserva
                    {
                        Cliente = usuarioNegocio.ListarUsuarioPorId(((long)access.Lector["idUsuario"])),
                        Cabaña = cabañaNegocio.ListarCabañaPorId((long)access.Lector["idCabaña"]),
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

        public List<Reserva> ListarReservasVigentes()
        {
            List<Reserva> listaReservasVigentes = new List<Reserva>();
            AccessDB access = new AccessDB();
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                CabañaNegocio cabañaNegocio = new CabañaNegocio();

                access.SetearQuery("select * from reservas where fechaegreso<getdate()");
                access.EjecutarLector();
                while (access.Lector.Read())
                {
                    Reserva aux = new Reserva
                    {
                        Cliente = usuarioNegocio.ListarUsuarioPorId(((long)access.Lector["idUsuario"])),
                        Cabaña = cabañaNegocio.ListarCabañaPorId((long)access.Lector["idCabaña"]),
                        FechaIngreso = (DateTime)access.Lector["fechaIngreso"],
                        FechaEgreso = (DateTime)access.Lector["fechaEgreso"],
                        CantPersonas = (byte)access.Lector["cantidadPersonas"],
                        FechaCreacionReserva = (DateTime)access.Lector["fechaReserva"],
                        Importe = (decimal)access.Lector["importe"],
                        Estado = (byte)access.Lector["estado"],
                        IdReservaOriginal = (long)access.Lector["IDReservaOriginal"]
                    };
                    listaReservasVigentes.Add(aux);
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
            return listaReservasVigentes;
        }

        public List<Reserva> ListarReservasNoVigentes()
        {
            List<Reserva> listaReservasNoVigentes = new List<Reserva>();
            AccessDB access = new AccessDB();
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                CabañaNegocio cabañaNegocio = new CabañaNegocio();

                access.SetearQuery("select * from reservas where fechaegreso>=getdate()");
                access.EjecutarLector();
                while (access.Lector.Read())
                {
                    Reserva aux = new Reserva
                    {
                        Cliente = usuarioNegocio.ListarUsuarioPorId(((long)access.Lector["idUsuario"])),
                        Cabaña = cabañaNegocio.ListarCabañaPorId((long)access.Lector["idCabaña"]),
                        FechaIngreso = (DateTime)access.Lector["fechaIngreso"],
                        FechaEgreso = (DateTime)access.Lector["fechaEgreso"],
                        CantPersonas = (byte)access.Lector["cantidadPersonas"],
                        FechaCreacionReserva = (DateTime)access.Lector["fechaReserva"],
                        Importe = (decimal)access.Lector["importe"],
                        Estado = (byte)access.Lector["estado"],
                        IdReservaOriginal = (long)access.Lector["IDReservaOriginal"]
                    };
                    listaReservasNoVigentes.Add(aux);
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
            return listaReservasNoVigentes;
        }

        public void ResolverReserva(long idReserva)
        {

            Reserva buscada = ListarReservaPorId(idReserva);
            AccessDB access = new AccessDB();
            try
            {
                access.SetearQuery("update reservas set estado=@estado where id=" + idReserva);
                access.AgregarParametro("@estado", buscada.Estado);
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

        public Reserva ListarReservaPorId(long idReserva)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            CabañaNegocio cabañaNegocio = new CabañaNegocio();
            AccessDB access = new AccessDB();
            Reserva reserva = new Reserva();
            try
            {
                access.SetearQuery("select * from reservas where Id="+idReserva);
                access.EjecutarLector();
                access.Lector.Read();
                
                reserva.Cliente = usuarioNegocio.ListarUsuarioPorId((long)access.Lector["idUsuario"]); //Capaz convenga agregar el atributo Id a la clase Reserva
                reserva.Cabaña = cabañaNegocio.ListarCabañaPorId((long)access.Lector["idCabaña"]);
                reserva.FechaIngreso = (DateTime)access.Lector["fechaIngreso"];
                reserva.FechaEgreso = (DateTime)access.Lector["fechaEgreso"];
                reserva.CantPersonas = (byte)access.Lector["cantidadPersonas"];
                reserva.FechaCreacionReserva = (DateTime)access.Lector["fechaReserva"];
                reserva.Importe = (decimal)access.Lector["importe"];
                reserva.Estado = (byte)access.Lector["estado"];
                reserva.IdReservaOriginal = (long)access.Lector["IDReservaOriginal"];
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                access.CerrarConexion();
            }
            return reserva;

        }

    }
}


