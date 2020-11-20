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
        public List<Imagen> ListarImagenesPorID(Int64 IDCabaña)
        {
            AccessDB acceso = new AccessDB();
            acceso.SetearQuery("select ID, URLImagen from ImagenesCabañas where IDCabaña="+IDCabaña.ToString());
            acceso.EjecutarLector();

            List<Imagen> ListaAux = new List<Imagen>();
            
            while (acceso.Lector.Read())
            {
                Imagen aux = new Imagen();
                aux.ID = (Int64)acceso.Lector["ID"];
                aux.URLImagen = (string)acceso.Lector["URLImagen"];
                ListaAux.Add(aux);
            }
            return ListaAux;
        }

        public void EliminarImagen(Int64 IDImagen)
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

        public void AgregarImagen(string URLImagen, Int64 IDCabaña)
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
                acceso.AgregarParametro("@ID",cabaña.Id);
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
        public void EliminarCabañaPorId(Int64 IDCabaña)
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
                while(acceso.Lector.Read())
                {
                    ComplejoNegocio negocio = new ComplejoNegocio();
                    Cabaña aux = new Cabaña();
                    aux.EstadoActivo = (bool)acceso.Lector["estado"];
                    if (aux.EstadoActivo==true)
                    { 
                    aux.Id = (Int64)acceso.Lector["ID"];
                    aux.PrecioDiario = (decimal)acceso.Lector["precioDiario"];
                    aux.Capacidad = (Byte)acceso.Lector["capacidad"];
                    aux.Ambientes = (Byte)acceso.Lector["cantidadAmbientes"];
                    aux.TiempoEntreReservas = (DateTime)acceso.Lector["tiempoEntreReservas"];
                    aux.CheckIn = (DateTime)acceso.Lector["horaCheckIn"];
                    aux.CheckOut = (DateTime)acceso.Lector["horaCheckOut"];
                    aux.Imagen=(string)acceso.Lector["imagenPortada"];
                    aux.complejo = negocio.BuscarComplejoPorId((Int64)acceso.Lector["Idcomplejo"]);
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

    }
}
