using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Administrador> ListarAdministradores(byte NivelAccesoSolicitante)
        {
            AccessDB acceso = new AccessDB();
            List<Administrador> ListaAdministradores = new List<Administrador>();
            try
            {
                acceso.SetearQuery("select * from VW_AdministradoresPorComplejo");
                acceso.EjecutarLector();
                while (acceso.Lector.Read())
                {

                    Administrador aux = new Administrador
                    {
                        usuario = ListarUsuarioPorId((long)acceso.Lector["IDUsuario"])
                    };
                    if (!acceso.Lector.IsDBNull(1))
                    {
                        aux.IDComplejo = (long)acceso.Lector["IDComplejo"];
                    }
                    ListaAdministradores.Add(aux);
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
            return ListaAdministradores;
        }

        public Dictionary<byte, string> ListarNivelesAcceso()
        {
            Dictionary<byte, string> aux = new Dictionary<byte, string>();
            DataSet dataSet = ListarNivelesAccesoDDL();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                aux.Add(Convert.ToByte(row["NivelAcceso"]), row["nombre"].ToString());
            }
            return aux;
        }

        public DataSet ListarNivelesAccesoDDL()
        {
            AccessDB acceso = new AccessDB();
            DataSet dataSet = acceso.ConsultaDDL("select * from NivelesAcceso");

            return dataSet;
        }

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
                access.Lector.Read();

                if (access.Lector.HasRows)
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

        public bool InsertarUsuario(Usuario NuevoUsuario)
        {
            AccessDB access = new AccessDB();
            string AuxContraseña = Encrypt.GetSHA256(NuevoUsuario.Contraseña);
            short IdPais = GetIDPais(NuevoUsuario.DatosPersonales.PaisOrigen);

            bool retorno = true;
            try
            {
                access.AgregarParametroSP("@nombreusuario", NuevoUsuario.NombreUsuario, SqlDbType.VarChar);
                access.AgregarParametroSP("@contra", AuxContraseña, SqlDbType.VarChar);
                access.AgregarParametroSP("@IdNivelAcceso", NuevoUsuario.NivelAcceso, SqlDbType.TinyInt);
                access.AgregarParametroSP("@Nombre", NuevoUsuario.DatosPersonales.Nombre, SqlDbType.VarChar);
                access.AgregarParametroSP("@Apellido", NuevoUsuario.DatosPersonales.Apellido, SqlDbType.VarChar);
                access.AgregarParametroSP("@dni", NuevoUsuario.DatosPersonales.DNI, SqlDbType.VarChar);
                access.AgregarParametroSP("@email", NuevoUsuario.DatosPersonales.Email, SqlDbType.VarChar);
                access.AgregarParametroSP("@telefono", NuevoUsuario.DatosPersonales.Telefono, SqlDbType.VarChar);
                access.AgregarParametroSP("@URLimagen", NuevoUsuario.DatosPersonales.UrlImagen, SqlDbType.VarChar);
                access.AgregarParametroSP("@idPais", IdPais, SqlDbType.SmallInt);
                access.AgregarParametroSP("@Domicilio", NuevoUsuario.DatosPersonales.Domicilio, SqlDbType.VarChar);
                access.AgregarParametroSP("@genero", NuevoUsuario.DatosPersonales.Genero, SqlDbType.Char);

                if (access.EjecutarStoredProcedureIntReturn("spAgregarUsuario") == 0)
                {
                    retorno = false;
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
            return retorno;
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

        private void ModificarUsuario(Usuario Usuario)
        {
            AccessDB access = new AccessDB();
            try
            {
                access.SetearQuery("update usuarios set nombreUsuario=@nombre, contra=@contra,Estado=@Estado, IdNivelAcceso=@IdNivelAcceso where ID=" + Usuario.Id);
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

        private void ModificarDatosPersonales(DatosPersonales Datos, short IDpais, long IDUsuario)
        {
            AccessDB access = new AccessDB();
            try
            {
                access.SetearQuery("update DatosPersonales set nombre=@nombre, apellido=@apellido, dni=@dni, email=@Email, telefono=@Telefono,URLimagen=@UrlImagen, IDpais=@IDpais, domicilio=@Domicilio, genero=@genero where IDUsuario=" + IDUsuario);
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
            Usuario.Contraseña = Encrypt.GetSHA256(Usuario.Contraseña);
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
                    "u.ID asc");
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
                            PaisOrigen = ListarPais((short)access.Lector["IDPais"]),
                            Domicilio = (string)access.Lector["domicilio"],
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
                buscado.NivelAcceso = (byte)access.Lector["IdNivelAcceso"];
                buscado.DatosPersonales.Apellido = (string)access.Lector["Apellido"];
                buscado.DatosPersonales.Nombre = (string)access.Lector["Nombre"];
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
