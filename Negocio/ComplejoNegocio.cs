using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ComplejoNegocio
    {

        public void ModificarComplejo(Complejo Aux)
        {
            AccessDB Acceso = new AccessDB();
            try
            {
                Acceso.SetearQuery("Update Complejos set ImagenPortada=@UrlImagen, Nombre=@Nombre, Telefono=@Tel, Ubicacion=@Ubicacion, email=@Mail, Estado=1, DiferenciaFeriado=@PrecioFeriado where ID=@Id");
                
                Acceso.AgregarParametro("@UrlImagen", Aux.Imagen);
                Acceso.AgregarParametro("@Nombre", Aux.Nombre);
                Acceso.AgregarParametro("@Tel", Aux.Telefono);
                Acceso.AgregarParametro("@Ubicacion", Aux.Ubicacion);
                Acceso.AgregarParametro("@Mail", Aux.Mail);
                Acceso.AgregarParametro("@PrecioFeriado", Aux.PrecioFeriado);
                Acceso.AgregarParametro("@Id", Aux.ID);
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






        public void AgregarComplejo(Complejo Aux)
        {
            AccessDB Acceso = new AccessDB();
            try
            {
            Acceso.SetearQuery("Insert into Complejos (ImagenPortada,Nombre,Telefono,Ubicacion,email,Estado,DiferenciaFeriado) values (@UrlImagen,@Nombre,@Tel,@Ubicacion,@Mail,1,@PrecioFeriado)");
            Acceso.AgregarParametro("@UrlImagen", Aux.Imagen);
            Acceso.AgregarParametro("@Nombre", Aux.Nombre);
            Acceso.AgregarParametro("@Mail", Aux.Mail);
            Acceso.AgregarParametro("@Tel", Aux.Telefono);
            Acceso.AgregarParametro("@Ubicacion", Aux.Ubicacion);
            Acceso.AgregarParametro("@PrecioFeriado", Aux.PrecioFeriado);
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











        public void EliminarComplejoPorId(Int64 IDComplejo)
        {

            AccessDB accessDB = new AccessDB();
            try
            {
                accessDB.SetearQuery("Delete from complejos where id=" + IDComplejo);
                accessDB.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
            
                accessDB.CerrarConexion();
            }
            
        }



        public Complejo BuscarComplejoPorId(Int64 IDComplejo)
        {
            AccessDB accessDB = new AccessDB();
            Complejo aux = new Complejo();

            try
            {
                accessDB.SetearQuery("Select * from complejos where estado = 1 and ID=" + IDComplejo);
                accessDB.EjecutarLector();
                accessDB.Lector.Read();
                aux.ID = (Int64)accessDB.Lector["Id"];
                aux.Imagen = (string)accessDB.Lector["imagenPortada"];
                aux.Telefono = (string)accessDB.Lector["Telefono"];
                aux.Ubicacion = (string)accessDB.Lector["Ubicacion"];
                aux.Mail = (string)accessDB.Lector["Email"];
                aux.EstadoActivo = (bool)accessDB.Lector["Estado"];
                aux.PrecioFeriado = (decimal)accessDB.Lector["DiferenciaFeriado"];
                aux.Nombre = (string)accessDB.Lector["nombre"];
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            finally
            {
               
                accessDB.CerrarConexion();
            }
            return aux;
        }

      public List<Complejo> listarComplejos()
        {
            AccessDB accessDB = new AccessDB();
            List<Complejo> lista = new List<Complejo>();

            try
            {
                accessDB.SetearQuery("Select *from complejos where estado = 1");
                accessDB.EjecutarLector();

                while (accessDB.Lector.Read())
                {
                    Complejo aux = new Complejo();
                    aux.EstadoActivo = (bool)accessDB.Lector["estado"];
                    if (aux.EstadoActivo == true)
                    {
                        aux.ID = (Int64)accessDB.Lector["Id"];
                        aux.Imagen = (string)accessDB.Lector["imagenPortada"];
                        aux.Telefono = (string)accessDB.Lector["Telefono"];
                        aux.Ubicacion = (string)accessDB.Lector["Ubicacion"];
                        aux.Mail = (string)accessDB.Lector["Email"];
                        aux.EstadoActivo = (bool)accessDB.Lector["Estado"];
                        aux.PrecioFeriado = (decimal)accessDB.Lector["DiferenciaFeriado"];
                        aux.Nombre = (string)accessDB.Lector["nombre"];
                        lista.Add(aux);
                    }
                }
            }
            catch (Exception ex)
            {
                accessDB.CerrarConexion();
                throw ex;
            }
            finally{
           
            accessDB.CerrarConexion();
            }
            return lista;
            
        }
    }
}
