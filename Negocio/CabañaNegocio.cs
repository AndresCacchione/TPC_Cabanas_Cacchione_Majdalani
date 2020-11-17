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
        public void AgregarCabaña(Cabaña Caba)
        {
            AccessDB Acceso = new AccessDB();
            try
            {
                
                Acceso.SetearQuery("Insert into Cabañas (ImagenPortada,IdComplejo,PrecioDiario,Capacidad,CantidadAmbientes,TiempoEntreReservas,HoraCheckIn,HoraCheckout,Estado) values (@Imagen,@IdComplejo,@PrecioDiario,@Capacidad,@Ambientes,@Tiempo,@In,@Out,1)");
                Acceso.AgregarParametro("@Imagen", Caba.Imagen);
                Acceso.AgregarParametro("@IdComplejo", Caba.complejo.ID);
                Acceso.AgregarParametro("@PrecioDiario", Caba.PrecioDiario);
                Acceso.AgregarParametro("@Capacidad", Caba.Capacidad);
                Acceso.AgregarParametro("@Ambientes", Caba.Ambientes);
                Acceso.AgregarParametro("@Tiempo", Caba.TiempoEntreReservas);
                Acceso.AgregarParametro("@In", Caba.CheckIn);
                Acceso.AgregarParametro("@Out", Caba.CheckOut);
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
