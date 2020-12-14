using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Seguimiento
    {
        public long ID { get; set; }
        public long? IDAdmin { get; set; }
        public long? IDCliente { get; set; }
        public DateTime Fecha { get; set; }
        public long IDTabla { get; set; }
        public long IDTablaAnterior { get; set; }
        public long? IDTablaNuevo { get; set; }
        public string Motivo { get; set; }
    }
}
