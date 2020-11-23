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
        public void AgregarUsuario(Usuario NuevoUsuario)
        {
            AccessDB accessDB = new AccessDB();
             //Aca se inserta un usuario
            accessDB.SetearQuery("insert into Usuarios (nombre,contra,IdNivelAcceso,estado) values(@nombre,@contra,@IdNivelAcceso,@estado)");
            accessDB.AgregarParametro("@nombre", NuevoUsuario.NombreUsuario);
            accessDB.AgregarParametro("@contra", NuevoUsuario.Contraseña);
            accessDB.AgregarParametro("@estado", NuevoUsuario.Estado);
            accessDB.AgregarParametro("@IdNivelAcceso", NuevoUsuario.NivelAcceso);
            accessDB.EjecutarAccion();
            //
            //Aca buscaMOS el usuario recien insertado y sacarle el id
            accessDB.SetearQuery("select top 1 usuarios.id from Usuarios where estado = 1 order by Usuarios.ID desc");
            accessDB.EjecutarLector();
            accessDB.Lector.Read();
            NuevoUsuario.Id = (Int64)accessDB.Lector["ID"];
            // ACA AVERIGUAMOS ID PAIS
            accessDB.SetearQuery("select paises.id from Paises where paises.nombre like '" + NuevoUsuario.DatosPersonales.PaisOrigen  + "'");
            accessDB.EjecutarLector();
            accessDB.Lector.Read();

            Int16 IdPais = new Int16(); 
            IdPais=(Int16)accessDB.Lector["ID"];

            //Aca se insertan los datos personales 
            accessDB.SetearQuery("insert into DatosPersonales (IdUsuario,nombre,apellido,dni,email,telefono,URLimagen,IDpais,domicilio,genero) values(@IdUsuario,@Nombre,@Apellido,@dni,@email,@telefono,@URLimagen,@idPais,@Domicilio,@genero)");
            accessDB.AgregarParametro("@IdUsuario", NuevoUsuario.Id);
            accessDB.AgregarParametro("@Apellido", NuevoUsuario.DatosPersonales.Apellido);
            accessDB.AgregarParametro("@Nombre", NuevoUsuario.DatosPersonales.Nombre);
            accessDB.AgregarParametro("@Domicilio", NuevoUsuario.DatosPersonales.Domicilio);
            accessDB.AgregarParametro("@dni", NuevoUsuario.DatosPersonales.DNI);
            accessDB.AgregarParametro("@email", NuevoUsuario.DatosPersonales.Email);
            accessDB.AgregarParametro("@telefono", NuevoUsuario.DatosPersonales.Telefono);
            accessDB.AgregarParametro("@URLimagen", NuevoUsuario.DatosPersonales.UrlImagen);
            accessDB.AgregarParametro("@genero", NuevoUsuario.DatosPersonales.Genero);
            accessDB.AgregarParametro("@idPais", IdPais);
            accessDB.EjecutarAccion();
            
            




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
