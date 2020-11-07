using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Complejo
    {
        public Int64 ID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Ubicacion { get; set; }
        public string Mail { get; set; }
        public bool EstadoActivo { get; set; }
        public decimal PrecioFeriado { get; set; }
    }
}
