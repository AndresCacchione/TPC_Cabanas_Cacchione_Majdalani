using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Reserva
    {
        public DateTime FechaCreacionReserva { get; set; }
        public Usuario Cliente { get; set; }
        public Cabaña Cabaña { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEgreso { get; set; }
        public byte CantPersonas { get; set; }
        public byte Estado { get; set; }
        public long IdReservaOriginal { get; set; }

    }
}
