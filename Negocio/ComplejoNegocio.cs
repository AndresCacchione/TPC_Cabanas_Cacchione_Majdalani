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
      public List<Complejo> listarComplejos()
        {
            AccessDB accessDB = new AccessDB();
            List<Complejo> lista = new List<Complejo>();

            try
            {
                accessDB.SetearQuery("Select *from complejos");
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
            accessDB.CerrarConexion();
            return lista;
        }
    }
}
