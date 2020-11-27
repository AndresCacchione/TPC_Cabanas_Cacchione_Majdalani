using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Complejo
    {
        public Complejo()
        {
            this.ListaImagenes = new List<Imagen>();
        }
        public long ID { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Ubicacion { get; set; }
        public string Mail { get; set; }
        public bool EstadoActivo { get; set; }
        public decimal PrecioFeriado { get; set; }
        public List<Imagen> ListaImagenes { get; set; }
    }
}
