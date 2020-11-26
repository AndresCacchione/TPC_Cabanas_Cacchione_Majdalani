using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Security.Cryptography;

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
            usuario.Contraseña = Encrypt.GetSHA256(usuario.Contraseña);
            try
            {
                access.SetearQuery("Select Id from usuarios where NombreUsuario=@NombreUsuario and Contra=@Contra");
                access.AgregarParametro("@NombreUsuario", usuario.NombreUsuario);
                access.AgregarParametro("@Contra", usuario.Contraseña);

                access.EjecutarLector();
                if (access.Lector.Read())
                {
                    usuario.Id = Convert.ToInt64(access.Lector["Id"]);
                }
                else
                {
                    usuario.Id = 0;
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

            return usuario;
        }

        public void InsertarUsuario(Usuario NuevoUsuario)
        {
            AccessDB access = new AccessDB();
            NuevoUsuario.Contraseña = Encrypt.GetSHA256(NuevoUsuario.Contraseña);

            try
            {
                access.SetearQuery("insert into Usuarios (nombreUsuario, contra, IdNivelAcceso, estado) values" +
                    " (@nombre, @contra, @IdNivelAcceso, @estado)");
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
                access.SetearQuery("select top 1 id from Usuarios where estado = 1 order by id desc");
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
                access.SetearQuery("select id from Paises where nombre like '" + NombrePais + "'");
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


        public string ListarPais(short idPais)
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
                access.SetearQuery("insert into DatosPersonales (IdUsuario, nombre, apellido, dni, email, telefono," +
                    " URLimagen, IDpais, domicilio, genero) values (@IdUsuario, @Nombre, @Apellido, @dni, @email, " +
                    "@telefono, @URLimagen, @idPais, @Domicilio, @genero)");
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
                access.SetearQuery("update usuarios set nombreUsuario=@nombre, contra=@contra," +
                "Estado=@Estado, IdNivelAcceso=@IdNivelAcceso where ID=" + Usuario.Id);
                access.AgregarParametro("@nombre", Usuario.NombreUsuario);
                access.AgregarParametro("@contra", Usuario.Contraseña);
                access.AgregarParametro("@IdNivelAcceso", Usuario.NivelAcceso); //Solo visible para nivel acceso mayor a 10. Solo se puede modificar a sus niveles inferiores, y solo con un rango inferior al que poseen (salvo el dueño). Niveles: 0 (visitante) 10 (cliente) 20 (admin) y 30(dueño)
                access.AgregarParametro("@Estado", Usuario.Estado);
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

        public void ModificarDatosPersonales(DatosPersonales Datos, short IDpais, long IDUsuario)
        {
            AccessDB access = new AccessDB();
            try
            {
                access.SetearQuery("update DatosPersonales set nombre=@nombre, apellido=@apellido, dni=@dni, email=@Email, telefono=@Telefono, " +
                "URLimagen=@UrlImagen, IDpais=@IDpais, domicilio=@Domicilio, genero=@genero where ID=" + IDUsuario);
                access.AgregarParametro("@nombre", Datos.Nombre);
                access.AgregarParametro("@apellido", Datos.Apellido);
                access.AgregarParametro("@dni", Datos.DNI);
                access.AgregarParametro("@Email", Datos.Email);
                access.AgregarParametro("@Telefono", Datos.Telefono);
                access.AgregarParametro("@UrlImagen", Datos.UrlImagen);
                access.AgregarParametro("@IDpais", IDpais);
                access.AgregarParametro("@Domicilio", Datos.Domicilio);
                access.AgregarParametro("@genero", Datos.Genero);
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

        public void ActualizarUsuario(Usuario Usuario)
        {
            ModificarUsuario(Usuario);
            short IDPais = GetIDPais(Usuario.DatosPersonales.PaisOrigen);
            ModificarDatosPersonales(Usuario.DatosPersonales, IDPais, Usuario.Id);
        }


        public List<Usuario> ListarUsuarios()
        {
            AccessDB access = new AccessDB();
            List<Usuario> userList = new List<Usuario>();

            try
            {
                access.SetearQuery("Select * from usuarios u, datospersonales dat where dat.idusuario=u.id order by " +
                    "usuarios.ID asc");
                access.EjecutarLector();
                while (access.Lector.Read())
                {
                    Usuario aux = new Usuario
                    {
                        Estado = (bool)access.Lector["Estado"],
                        Id = (long)access.Lector["Id"],
                        NombreUsuario = (string)access.Lector["nombreUsuario"],
                        Contraseña = (string)access.Lector["Contra"],
                        NivelAcceso = (byte)access.Lector["IdNivelAcceso"],
                        DatosPersonales = new DatosPersonales
                        {
                            Nombre = (string)access.Lector["nombre"],
                            Apellido = (string)access.Lector["apellido"],
                            DNI = (string)access.Lector["dni"],
                            Email = (string)access.Lector["email"],
                            Telefono = (string)access.Lector["telefono"],
                            UrlImagen = (string)access.Lector["URLimagen"],
                            PaisOrigen = ListarPais((short)access.Lector["IDPais"]), //con el ID traido de DB, casteado, hago uso del método ListarPais,
                            Domicilio = (string)access.Lector["domicilio"],         //que recibe un short y devuelve el País correspondiente en forma de string
                            Genero = (string)access.Lector["genero"]
                        }
                    };
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
            try
            {
                access.SetearQuery("Select * from usuarios, datospersonales where idusuario=id and id=" + IdUsuario);
                access.EjecutarLector();
                access.Lector.Read();

                buscado.Id = (long)access.Lector["id"];
                buscado.NombreUsuario = (string)access.Lector["NombreUsuario"];
                buscado.Contraseña = (string)access.Lector["Contra"];
                buscado.Estado = (bool)access.Lector["Estado"];
                buscado.DatosPersonales.Apellido = (string)access.Lector["Apellido"];
                buscado.DatosPersonales.Nombre = (string)access.Lector["Nombre"]; //creería que ahí alcanzaría para que no exista ambiguedad en las tablas llamadas Nombre
                buscado.DatosPersonales.DNI = (string)access.Lector["Dni"];
                buscado.DatosPersonales.Domicilio = (string)access.Lector["Domicilio"];
                buscado.DatosPersonales.Email = (string)access.Lector["Email"];
                buscado.DatosPersonales.Genero = (string)access.Lector["genero"];
                buscado.DatosPersonales.PaisOrigen = ListarPais((short)access.Lector["IdPais"]);
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
