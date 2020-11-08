using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cabaña
    {
        public Cabaña()
         {
            Imagenes = new List<string>();
         }
         public Int64 Id { get; set; }
         public decimal PrecioDiario { get; set; }
         public Byte Capacidad { get; set; }
         public List<string> Imagenes { get; set; }
         public Byte Ambientes { get; set; }
         public Int16 TiempoEntreReservas { get; set; }
         public DateTime CheckIn { get; set; }
         public DateTime CheckOut { get; set; }
         public bool EstadoActivo { get; set; }
         public Complejo complejo { get; set; }
    }
}
