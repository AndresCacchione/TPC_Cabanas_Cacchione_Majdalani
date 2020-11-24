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

        public Usuario Login(Usuario usuario)
        {
            AccessDB access = new AccessDB();
            try
            {
                access.SetearQuery("Select Id from usuarios where NombreUsuario=@NombreUsuario and Contra=@Contra");
                access.AgregarParametro("@NombreUsuario", usuario.NombreUsuario);
                access.AgregarParametro("@Contra", usuario.Contraseña);

                access.EjecutarLector();
                if (access.Lector.Read())
                {
                    usuario.Id = (int)access.Lector["Id"];
                }

                return usuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsertarUsuario(Usuario NuevoUsuario)
        {
            AccessDB access = new AccessDB();

            try
            {               
                access.SetearQuery("insert into Usuarios (nombre,contra,IdNivelAcceso,estado) values(@nombre,@contra,@IdNivelAcceso,@estado)");
                access.AgregarParametro("@nombre", NuevoUsuario.NombreUsuario);
                access.AgregarParametro("@contra", NuevoUsuario.Contraseña);
                access.AgregarParametro("@estado", NuevoUsuario.Estado);
                access.AgregarParametro("@IdNivelAcceso", NuevoUsuario.NivelAcceso);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }

        }

        public void GetTop1ID(Usuario NuevoUsuario)
        {
            AccessDB access = new AccessDB();

            try
            {
                access.SetearQuery("select top 1 usuarios.id from Usuarios where estado = 1 order by Usuarios.ID desc");
                access.EjecutarLector();
                access.Lector.Read();
                NuevoUsuario.Id = (Int64)access.Lector["ID"];
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
            
        }

        public void GetPaisUsuario(Usuario NuevoUsuario)
        {
            AccessDB access = new AccessDB();

            try
            {
                access.SetearQuery("select paises.id from Paises where paises.nombre like '" + NuevoUsuario.DatosPersonales.PaisOrigen + "'");
                access.EjecutarLector();
                access.Lector.Read();
                Int16 IdPais = new Int16();
                IdPais = (Int16)access.Lector["ID"];
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }

        }

        public void InsertarDatosP(Usuario NuevoUsuario, Int16 IdPais)
        {
            AccessDB access = new AccessDB();

            try
            {
                access.SetearQuery("insert into DatosPersonales (IdUsuario,nombre,apellido,dni,email,telefono,URLimagen,IDpais,domicilio,genero) values(@IdUsuario,@Nombre,@Apellido,@dni,@email,@telefono,@URLimagen,@idPais,@Domicilio,@genero)");
                access.AgregarParametro("@IdUsuario", NuevoUsuario.Id);
                access.AgregarParametro("@Apellido", NuevoUsuario.DatosPersonales.Apellido);
                access.AgregarParametro("@Nombre", NuevoUsuario.DatosPersonales.Nombre);
                access.AgregarParametro("@Domicilio", NuevoUsuario.DatosPersonales.Domicilio);
                access.AgregarParametro("@dni", NuevoUsuario.DatosPersonales.DNI);
                access.AgregarParametro("@email", NuevoUsuario.DatosPersonales.Email);
                access.AgregarParametro("@telefono", NuevoUsuario.DatosPersonales.Telefono);
                access.AgregarParametro("@URLimagen", NuevoUsuario.DatosPersonales.UrlImagen);
                access.AgregarParametro("@genero", NuevoUsuario.DatosPersonales.Genero);
                access.AgregarParametro("@idPais", IdPais);
                access.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
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
            AccessDB access = new AccessDB();
            try
            {
                access.SetearQuery("Delete from usuarios where id=" + IdUsuario);
                access.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
        }

        public void ModificarUsuario(Usuario Usuario)
        {
            AccessDB access = new AccessDB();
            try
            {
                access.SetearQuery("update usuarios set nombre=@nombre, contra=@contra, IdNivelAcceso=@IdNivelAcceso, " +
                    "Estado=@Estado where ID=@ID");
                access.AgregarParametro("@nombre", Usuario.NombreUsuario);
                access.AgregarParametro("@contra", Usuario.Contraseña);
                access.AgregarParametro("@IdNivelAcceso", Usuario.NivelAcceso);
                access.AgregarParametro("Estado", Usuario.Estado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }

        }

        public void ListarUsuarios()
        {


        }

        public void ListarUsuarioPorId(long IdUsuario)
        {
            AccessDB access = new AccessDB();
            try
            {
                access.SetearQuery("Select * from usuarios where id="+IdUsuario);
                access.EjecutarLector();
            }
            catch (Exception ex)
            {

                throw Exception ex;
            }


        }



    }
}
