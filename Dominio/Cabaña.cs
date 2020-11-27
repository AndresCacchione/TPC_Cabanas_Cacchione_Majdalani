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
            this.ListaImagenes = new List<Imagen>();
        }
        public long Id { get; set; }
        public decimal PrecioDiario { get; set; }
        public byte Capacidad { get; set; }
        public string Imagen { get; set; }
        public byte Ambientes { get; set; }
        public DateTime TiempoEntreReservas { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool EstadoActivo { get; set; }
        public Complejo complejo { get; set; }
        public List<Imagen> ListaImagenes { get; set; }
    }
}
