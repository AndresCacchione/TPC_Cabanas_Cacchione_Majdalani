using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cabaña
    {
         public Int64 Id { get; set; }
         public Complejo complejo { get; set; }
         public decimal PrecioDiario  { get; set; }
         public int Capacidad { get; set; }
         public int Ambientes { get; set; }
         public int TiempoEntreReservas { get; set; }
         public int CheckIn { get; set; }
         public int CheckOut { get; set; }
         public int EstadoActivo { get; set; }
}
}
