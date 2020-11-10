using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccessDB
    {
        public SqlDataReader Lector { get; set; }
        public SqlConnection Conexion { get; set; }
        public SqlCommand Comando { get; set; }

        public AccessDB()
        {
            Conexion = new SqlConnection("data source=.\\SQLEXPRESS01; initial catalog=Cacchione_Majdalani_DB; integrated security=sspi");
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }

        public void SetearQuery(String Consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = Consulta;
        }

        public void SetearSp(string sp)
        {
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.CommandText = sp;
        }

        public void AgregarParametro(string nombre, object Valor)
        {
            Comando.Parameters.AddWithValue(nombre, Valor);
        }

        public void EjecutarLector()
        {
            try
            {
                Conexion.Open();
                Lector = Comando.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CerrarConexion()
        {
            if (Lector != null)
                Lector.Close();
            if (Conexion != null)
                Conexion.Close();
        }

        internal void EjecutarAccion()
        {
            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Lector != null)
                    Lector.Close();
                if (Conexion != null)
                    Conexion.Close();
            }
        }
    }
 }



        
