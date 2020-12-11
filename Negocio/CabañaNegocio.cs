using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CabañaNegocio
    {
        public List<List<DateTime>> ListaOcupadoPorCabaña(long idCabaña)
        {
            AccessDB acceso = new AccessDB();
            List<List<DateTime>> aux = new List<List<DateTime>>();

            try
            {
                acceso.SetearQuery("select fechaIngreso, fechaEgreso from reservas where fechaEgreso>getdate() and estado < 3 and IDCabaña =" + idCabaña);
                acceso.EjecutarLector();

                while (acceso.Lector.Read())
                {
                    List<DateTime> rango = new List<DateTime>();
                    rango.Add((DateTime)acceso.Lector["fechaIngreso"]);
                    rango.Add((DateTime)acceso.Lector["fechaEgreso"]);
                    aux.Add(rango);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }

            return aux;
        }

        public List<Imagen> ListarImagenesPorID(long IDCabaña)
        {
            AccessDB acceso = new AccessDB();
            List<Imagen> ListaAux = new List<Imagen>();

            try
            {
                acceso.SetearQuery("select ID, URLImagen from ImagenesCabañas where IDCabaña=" + IDCabaña.ToString());
                acceso.EjecutarLector();
                while (acceso.Lector.Read())
                {
                    Imagen aux = new Imagen
                    {
                        ID = (long)acceso.Lector["ID"],
                        URLImagen = (string)acceso.Lector["URLImagen"]
                    };

                    ListaAux.Add(aux);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }

            return ListaAux;
        }

        public void EliminarImagen(long IDImagen)
        {
            AccessDB acceso = new AccessDB();
            try
            {
                acceso.SetearQuery("Delete from ImagenesCabañas where id=" + IDImagen);
                acceso.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }
        }

        public void AgregarImagen(string URLImagen, long IDCabaña)
        {
            AccessDB acceso = new AccessDB();

            try
            {
                acceso.SetearQuery("insert into ImagenesCabañas (IDCabaña, URLImagen) values (@IDCabaña, @URLImagen)");
                acceso.AgregarParametro("@IDCabaña", IDCabaña);
                acceso.AgregarParametro("@URLImagen", URLImagen);
                acceso.EjecutarAccion();
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }
        }

        public void ModificarCabaña(Cabaña cabaña)
        {
            AccessDB acceso = new AccessDB();
            try
            {
                acceso.SetearQuery("Update Cabañas set ImagenPortada=@Imagen, IDComplejo=@IDcomplejo, precioDiario=@precioDiario, capacidad=@capacidad, cantidadAmbientes=@cantidadAmbientes, tiempoEntreReservas=@tiempoEntreReservas, horacheckin=@horaCheckIn, horacheckout=@horaCheckOut, estado=1 where ID=@Id");

                acceso.AgregarParametro("@Imagen", cabaña.Imagen);
                acceso.AgregarParametro("@IDcomplejo", cabaña.complejo.ID);
                acceso.AgregarParametro("@precioDiario", cabaña.PrecioDiario);
                acceso.AgregarParametro("@capacidad", cabaña.Capacidad);
                acceso.AgregarParametro("@cantidadAmbientes", cabaña.Ambientes);
                acceso.AgregarParametro("@tiempoEntreReservas", cabaña.TiempoEntreReservas);
                acceso.AgregarParametro("@horaCheckIn", cabaña.CheckIn);
                acceso.AgregarParametro("@horaCheckOut", cabaña.CheckOut);
                acceso.AgregarParametro("@ID", cabaña.Id);
                acceso.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }
        }
        public void EliminarCabañaPorId(long IDCabaña)
        {

            AccessDB acceso = new AccessDB();
            try
            {
                acceso.SetearQuery("Delete from cabañas where id=" + IDCabaña);
                acceso.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                acceso.CerrarConexion();
            }

        }
        public List<Cabaña> listarCabañas()
        {
            AccessDB acceso = new AccessDB();
            List<Cabaña> lista = new List<Cabaña>();


            try
            {
                acceso.SetearQuery("select * from Cabañas where estado = 1");
                acceso.EjecutarLector();
                while (acceso.Lector.Read())
                {
                    ComplejoNegocio negocio = new ComplejoNegocio();
                    Cabaña aux = new Cabaña
                    {
                        EstadoActivo = (bool)acceso.Lector["estado"]
                    };
                    if (aux.EstadoActivo)
                    {
                        aux.Id = (long)acceso.Lector["ID"];
                        aux.PrecioDiario = (decimal)acceso.Lector["precioDiario"];
                        aux.Capacidad = (byte)acceso.Lector["capacidad"];
                        aux.Ambientes = (byte)acceso.Lector["cantidadAmbientes"];
                        aux.TiempoEntreReservas = (DateTime)acceso.Lector["tiempoEntreReservas"];
                        aux.CheckIn = (DateTime)acceso.Lector["horaCheckIn"];
                        aux.CheckOut = (DateTime)acceso.Lector["horaCheckOut"];
                        aux.Imagen = (string)acceso.Lector["imagenPortada"];
                        aux.complejo = negocio.BuscarComplejoPorId((long)acceso.Lector["Idcomplejo"]);
                        lista.Add(aux);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }
            return lista;
        }

        public void agregarCabaña(Cabaña CabañaAgregada)
        {
            AccessDB acceso = new AccessDB();

            try
            {
                acceso.SetearQuery("insert into cabañas (ImagenPortada, IDComplejo, precioDiario, capacidad, cantidadAmbientes, tiempoEntreReservas, horacheckin, horacheckout, estado) values (@Imagen,@IDcomplejo,@precioDiario,@capacidad,@cantidadAmbientes,@tiempoEntreReservas,@horaCheckIn,@horaCheckOut,1)");
                acceso.AgregarParametro("@Imagen", CabañaAgregada.Imagen);
                acceso.AgregarParametro("@IDcomplejo", CabañaAgregada.complejo.ID);
                acceso.AgregarParametro("@precioDiario", CabañaAgregada.PrecioDiario);
                acceso.AgregarParametro("@capacidad", CabañaAgregada.Capacidad);
                acceso.AgregarParametro("@cantidadAmbientes", CabañaAgregada.Ambientes);
                acceso.AgregarParametro("@tiempoEntreReservas", CabañaAgregada.TiempoEntreReservas);
                acceso.AgregarParametro("@horaCheckIn", CabañaAgregada.CheckIn);
                acceso.AgregarParametro("@horaCheckOut", CabañaAgregada.CheckOut);
                acceso.EjecutarAccion();
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }
        }
        public Cabaña ListarUltimaCabaña()
        {
            AccessDB acceso = new AccessDB();
            Cabaña ultima = new Cabaña();
            try
            {
                ComplejoNegocio negocio = new ComplejoNegocio();

                acceso.SetearQuery("select top 1 * from Cabañas where estado = 1 order by Cabañas.ID desc");
                acceso.EjecutarLector();
                acceso.Lector.Read();

                ultima.EstadoActivo = (bool)acceso.Lector["estado"];
                ultima.Id = (long)acceso.Lector["ID"];
                ultima.PrecioDiario = (decimal)acceso.Lector["precioDiario"];
                ultima.Capacidad = (byte)acceso.Lector["capacidad"];
                ultima.Ambientes = (byte)acceso.Lector["cantidadAmbientes"];
                ultima.TiempoEntreReservas = (DateTime)acceso.Lector["tiempoEntreReservas"];
                ultima.CheckIn = (DateTime)acceso.Lector["horaCheckIn"];
                ultima.CheckOut = (DateTime)acceso.Lector["horaCheckOut"];
                ultima.Imagen = (string)acceso.Lector["imagenPortada"];
                ultima.complejo = negocio.BuscarComplejoPorId((long)acceso.Lector["Idcomplejo"]);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }
            return ultima;
        }
        public Cabaña ListarCabañaPorId(long idDeCabaña)
        {
            AccessDB acceso = new AccessDB();
            Cabaña cabaña = new Cabaña();
            try
            {
                ComplejoNegocio negocio = new ComplejoNegocio();

                acceso.SetearQuery("select* from Cabañas where estado = 1 and Cabañas.ID =" + idDeCabaña);
                acceso.EjecutarLector();
                acceso.Lector.Read();

                cabaña.EstadoActivo = (bool)acceso.Lector["estado"];
                cabaña.Id = (long)acceso.Lector["ID"];
                cabaña.PrecioDiario = (decimal)acceso.Lector["precioDiario"];
                cabaña.Capacidad = (byte)acceso.Lector["capacidad"];
                cabaña.Ambientes = (byte)acceso.Lector["cantidadAmbientes"];
                cabaña.TiempoEntreReservas = (DateTime)acceso.Lector["tiempoEntreReservas"];
                cabaña.CheckIn = (DateTime)acceso.Lector["horaCheckIn"];
                cabaña.CheckOut = (DateTime)acceso.Lector["horaCheckOut"];
                cabaña.Imagen = (string)acceso.Lector["imagenPortada"];
                cabaña.complejo = negocio.BuscarComplejoPorId((long)acceso.Lector["Idcomplejo"]);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.CerrarConexion();
            }
            return cabaña;
        }



    }
}
