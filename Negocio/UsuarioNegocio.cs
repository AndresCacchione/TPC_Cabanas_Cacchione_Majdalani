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
                access.SetearQuery("Select Id from usuarios where Nombre=@NombreUsuario and Contra=@Contra");
                access.AgregarParametro("@NombreUsuario", usuario.NombreUsuario);
                access.AgregarParametro("@Contra", usuario.Contraseña);

                access.EjecutarLector();
                access.Lector.Read();
                usuario.Id = Convert.ToInt64(access.Lector["Id"]);
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                access.CerrarConexion();
            }

            return usuario;
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

        public long GetIDUltimoUsuario()
        {
            AccessDB access = new AccessDB();
            long aux = new long();
            try
            {
                access.SetearQuery("select top 1 usuarios.id from Usuarios where estado = 1 order by Usuarios.ID desc");
                access.EjecutarLector();
                access.Lector.Read();
                aux = (long)access.Lector["ID"];
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
            return aux;
        }

        public short GetIDPais(string NombrePais)
        {
            AccessDB access = new AccessDB();
            short IdPais = new short();

            try
            {
                access.SetearQuery("select paises.id from Paises where paises.nombre like '" + NombrePais + "'");
                access.EjecutarLector();
                access.Lector.Read();
                IdPais = (short)access.Lector["ID"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
            return IdPais;
        }


        public string ListarPais(int idPais)
        {
            AccessDB access = new AccessDB();
            access.SetearQuery("Select Nombre from paises where id=" + idPais);
            access.EjecutarLector();
            access.Lector.Read();
            string NombrePais = (string)access.Lector["Nombre"];
            return NombrePais;
        }

        public void InsertarDatosPersonales(Usuario NuevoUsuario, short IdPais)
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
            InsertarUsuario(NuevoUsuario);                                      // INSERTAMOS EL USUARIO
            NuevoUsuario.Id = GetIDUltimoUsuario();                             // OBTENER ID DEL USUARIO INSERTADO PARA AGREGAR SUS DATOS PERSONALES
            short IdPais = GetIDPais(NuevoUsuario.DatosPersonales.PaisOrigen);  // ACA AVERIGUAMOS ID PAIS
            InsertarDatosPersonales(NuevoUsuario, IdPais);                      // AGREGAMOS DATOS PERSONALES A LA DB

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
                //access.SetearQuery("update usuarios set nombre=@nombre, contra=@contra," + 
                //    "Estado=@Estado where ID=" + Usuario.Id);

                //access.AgregarParametro("@nombre", Usuario.NombreUsuario);
                //access.AgregarParametro("@contra", Usuario.Contraseña);
                //access.AgregarParametro("@Estado", Usuario.Estado);
                //access.EjecutarAccion();

                access.SetearQuery("update DatosPersonales set domicilio=@Domicilio, email=@Email, telefono=@Telefono,URLimagen=@UrlImagen " +
                    "where ID=" + Usuario.Id);
                access.AgregarParametro("@Domicilio", Usuario.DatosPersonales.Domicilio);
                access.AgregarParametro("@Email", Usuario.DatosPersonales.Email);
                access.AgregarParametro("@Telefono", Usuario.DatosPersonales.Telefono);
                access.AgregarParametro("@UrlImagen", Usuario.DatosPersonales.UrlImagen);
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

        public List<Usuario> ListarUsuarios()
        {
            AccessDB access = new AccessDB();
            List<Usuario> userList = new List<Usuario>();

            try
            {
                access.SetearQuery("Select * from usuarios u, datospersonales dat where u.Estado=1 and dat.idusuario=u.id order by usuarios.ID asc");
                access.EjecutarLector();
                while (access.Lector.Read())
                {
                    Usuario aux = new Usuario
                    {
                        Estado = (bool)access.Lector["Estado"]
                    };
                    if (aux.Estado)
                    {
                        aux.Id = (long)access.Lector["Id"];
                        aux.NombreUsuario = (string)access.Lector["u.nombre"];
                        aux.Contraseña = (string)access.Lector["Contra"];
                        aux.NivelAcceso = (byte)access.Lector["IdNivelAcceso"];
                        aux.DatosPersonales.Nombre = (string)access.Lector["dat.nombre"];
                        aux.DatosPersonales.Apellido = (string)access.Lector["apellido"];
                        aux.DatosPersonales.DNI = (string)access.Lector["dni"];
                        aux.DatosPersonales.Email = (string)access.Lector["email"];
                        aux.DatosPersonales.Telefono = (string)access.Lector["telefono"];
                        aux.DatosPersonales.UrlImagen = (string)access.Lector["URLimagen"];
                        aux.DatosPersonales.PaisOrigen = ListarPais((short)access.Lector["IDPais"]); //con el ID traido de DB, casteado, hago uso del método ListarPais,
                        aux.DatosPersonales.Domicilio = (string)access.Lector["domicilio"];         //que recibe un short y devuelve el País correspondiente en forma de string
                        aux.DatosPersonales.Genero = (char)access.Lector["genero"];
                    }

                    userList.Add(aux);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }

            return userList;

        }

        public Usuario ListarUsuarioPorId(long IdUsuario)
        {
            AccessDB access = new AccessDB();
            Usuario buscado = new Usuario();
            UsuarioNegocio Negocio = new UsuarioNegocio();
            try
            {
                access.SetearQuery("Select * from usuarios u, datospersonales dat where dat.idusuario=u.id and id=" + IdUsuario);
                access.EjecutarLector();
                access.Lector.Read();

                buscado.Id = (long)access.Lector["id"];
                buscado.NombreUsuario = (string)access.Lector["u.Nombre"];
                buscado.Contraseña = (string)access.Lector["Contra"];
                buscado.Estado = (bool)access.Lector["Estado"];
                buscado.DatosPersonales.Apellido = (string)access.Lector["Apellido"];
                buscado.DatosPersonales.Nombre = (string)access.Lector["dat.Nombre"]; //creería que ahí alcanzaría para que no exista ambiguedad en las tablas llamadas Nombre
                buscado.DatosPersonales.DNI = (string)access.Lector["Dni"];
                buscado.DatosPersonales.Domicilio = (string)access.Lector["Domicilio"];
                buscado.DatosPersonales.Email = (string)access.Lector["Email"];
                buscado.DatosPersonales.Genero = (char)access.Lector["Genero"];
                buscado.DatosPersonales.PaisOrigen = Negocio.ListarPais((short)access.Lector["IdPais"]);
                buscado.DatosPersonales.Telefono = (string)access.Lector["Telefono"];
                buscado.DatosPersonales.UrlImagen = (string)access.Lector["URLImagen"];

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                access.CerrarConexion();
            }
            return buscado;
        }

    }
}
