using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public Usuario()
        {
            DatosPersonales = new DatosPersonales();
        }
        public long Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public byte NivelAcceso { get; set; }
        public bool Estado { get; set; }
        public DatosPersonales DatosPersonales { get; set; }
    }
}
