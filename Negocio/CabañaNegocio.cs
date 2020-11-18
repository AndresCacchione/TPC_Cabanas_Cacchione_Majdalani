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
                    aux.TiempoEntreReservas = (Int16)acceso.Lector["tiempoEntreReservas"];
                    aux.CheckIn = (DateTime)acceso.Lector["horaCheckIn"];
                    aux.CheckOut = (DateTime)acceso.Lector["horaCheckOut"];
                    aux.Imagen=(string)acceso.Lector["imagenPortada"];
                    aux.complejo = negocio.BuscarComplejoPorId((Int64)acceso.Lector["Idcomplejo"]);
                    lista.Add(aux);
                    }
                }
                // listar complejo por I
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
            AccessDB Acceso = new AccessDB();

            try
            {
                Acceso.SetearQuery("insert into cabañas (ImagenPortada, IDComplejo, precioDiario, capacidad, cantidadAmbientes, tiempoEntreReservas, horacheckin, horacheckout, estado) values (@Imagen,@IDcomplejo,@precioDiario,@capacidad,@cantidadAmbientes,@tiempoEntreReservas,@horaCheckIn,@horaCheckOut,1)");
                Acceso.AgregarParametro("@Imagen", CabañaAgregada.Imagen);
                Acceso.AgregarParametro("@IDcomplejo", CabañaAgregada.complejo.ID);
                Acceso.AgregarParametro("@precioDiario", CabañaAgregada.PrecioDiario);
                Acceso.AgregarParametro("@capacidad", CabañaAgregada.Capacidad);
                Acceso.AgregarParametro("@cantidadAmbientes", CabañaAgregada.Ambientes);
                Acceso.AgregarParametro("@tiempoEntreReservas", CabañaAgregada.TiempoEntreReservas);
                Acceso.AgregarParametro("@horaCheckIn", CabañaAgregada.CheckIn);
                Acceso.AgregarParametro("@horaCheckOut", CabañaAgregada.CheckOut);
                Acceso.EjecutarAccion();
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Acceso.CerrarConexion();
            }

        }

    }
}
