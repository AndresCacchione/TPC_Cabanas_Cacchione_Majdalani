using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
   public class UsuarioNegocio
    {
        public List<string> ListarPaises()
        {
            AccessDB acceso = new AccessDB();
            List<string> ListaPaises = new List<string>();
            try
            {
                acceso.SetearQuery("select Nombre from Paises");
                acceso.EjecutarLector();
                while (acceso.Lector.Read())
                {
                    string aux = (string)acceso.Lector["Nombre"];
                    ListaPaises.Add(aux);
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
            return ListaPaises;

        }
        public void AgregarUsuario(Usuario NuevoUsuario)
        {
            AccessDB accessDB1 = new AccessDB();
            AccessDB accessDB2 = new AccessDB();
            AccessDB accessDB3 = new AccessDB();
            AccessDB accessDB4 = new AccessDB();

            try
            {
                //Aca se inserta un usuario
                accessDB1.SetearQuery("insert into Usuarios (nombre,contra,IdNivelAcceso,estado) values(@nombre,@contra,@IdNivelAcceso,@estado)");
                accessDB1.AgregarParametro("@nombre", NuevoUsuario.NombreUsuario);
                accessDB1.AgregarParametro("@contra", NuevoUsuario.Contraseña);
                accessDB1.AgregarParametro("@estado", NuevoUsuario.Estado);
                accessDB1.AgregarParametro("@IdNivelAcceso", NuevoUsuario.NivelAcceso);
                accessDB1.EjecutarAccion();

                //
                //Aca buscaMOS el usuario recien insertado y sacarle el id
                accessDB2.SetearQuery("select top 1 usuarios.id from Usuarios where estado = 1 order by Usuarios.ID desc");
                accessDB2.EjecutarLector();
                accessDB2.Lector.Read();
                NuevoUsuario.Id = (Int64)accessDB2.Lector["ID"];


                // ACA AVERIGUAMOS ID PAIS
                accessDB3.SetearQuery("select paises.id from Paises where paises.nombre like '" + NuevoUsuario.DatosPersonales.PaisOrigen + "'");
                accessDB3.EjecutarLector();
                accessDB3.Lector.Read();
                Int16 IdPais = new Int16();
                IdPais = (Int16)accessDB3.Lector["ID"];

                //Aca se insertan los datos personales 
                accessDB4.SetearQuery("insert into DatosPersonales (IdUsuario,nombre,apellido,dni,email,telefono,URLimagen,IDpais,domicilio,genero) values(@IdUsuario,@Nombre,@Apellido,@dni,@email,@telefono,@URLimagen,@idPais,@Domicilio,@genero)");
                accessDB4.AgregarParametro("@IdUsuario", NuevoUsuario.Id);
                accessDB4.AgregarParametro("@Apellido", NuevoUsuario.DatosPersonales.Apellido);
                accessDB4.AgregarParametro("@Nombre", NuevoUsuario.DatosPersonales.Nombre);
                accessDB4.AgregarParametro("@Domicilio", NuevoUsuario.DatosPersonales.Domicilio);
                accessDB4.AgregarParametro("@dni", NuevoUsuario.DatosPersonales.DNI);
                accessDB4.AgregarParametro("@email", NuevoUsuario.DatosPersonales.Email);
                accessDB4.AgregarParametro("@telefono", NuevoUsuario.DatosPersonales.Telefono);
                accessDB4.AgregarParametro("@URLimagen", NuevoUsuario.DatosPersonales.UrlImagen);
                accessDB4.AgregarParametro("@genero", NuevoUsuario.DatosPersonales.Genero);
                accessDB4.AgregarParametro("@idPais", IdPais);
                accessDB4.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accessDB1.CerrarConexion();
                accessDB2.CerrarConexion();
                accessDB3.CerrarConexion();
                accessDB4.CerrarConexion();
            }
        }

        public void EliminarUsuario(long IdUsuario)
        {

        }

        public void ModificarUsuario(Usuario Usuario)
        {


        }

        public void ListarUsuaruios()
        {


        }

        public void ListarUsuarioPorId(long IdUsuario)
        {


        }



    }
}
