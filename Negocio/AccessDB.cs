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
            Comando = new SqlCommand
            {
                Connection = Conexion
            };
        }

        public void SetearQuery(string Consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = Consulta;
        }

        public void SetearTrigger(string trig)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = trig;
            Conexion.Open();
            Comando.ExecuteNonQuery();
        }

        public void EjecutarStoredProcedure(string sp)
        {
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.CommandText = sp;
        }

        public int EjecutarStoredProcedureIntReturn(string sp)
        {
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.CommandText = sp;

            var returnParametro = Comando.Parameters.Add("@ReturnValue", System.Data.SqlDbType.Int);
            returnParametro.Direction = System.Data.ParameterDirection.ReturnValue;
            Conexion.Open();
            Comando.ExecuteNonQuery();
            return (int)returnParametro.Value;
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

        public void EjecutarAccion()
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




