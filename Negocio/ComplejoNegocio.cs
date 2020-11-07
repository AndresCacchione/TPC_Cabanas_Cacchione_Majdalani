using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class ComplejoNegocio
    {
      public List<Complejo> ListarComplejos()
        {
            List<Complejo> listaComplejos = new List<Complejo>();
            AccessDB accessDB = new AccessDB();
            accessDB.SetearQuery("Select *from complejos");

            try
            {
                accessDB.EjecutarLector();
                
                while (accessDB.Lector.Read())
                {
                    Complejo aux = new Complejo(); 
                    aux.ID = (Int64)accessDB.Lector["Id"];
                    aux.Imagen= (string)accessDB.Lector["Imagen"];
                    aux.Nombre = (string)accessDB.Lector["Nombre"];
                    aux.Telefono = (string)accessDB.Lector["Telefono"];
                    aux.Ubicacion = (string)accessDB.Lector["Ubicacion"];
                    aux.Mail = (string)accessDB.Lector["Mail"];
                    aux.EstadoActivo = (bool)accessDB.Lector["EstadoActivo"];
                    aux.PrecioFeriado= (decimal)accessDB.Lector["DiferenciaFeriado"];
                    listaComplejos.Add(aux);
                }
                accessDB.CerrarConexion();
                return listaComplejos;
            }

            catch (Exception ex)
            {
                accessDB.CerrarConexion();
                throw ex;
            }
        }
    }
}
