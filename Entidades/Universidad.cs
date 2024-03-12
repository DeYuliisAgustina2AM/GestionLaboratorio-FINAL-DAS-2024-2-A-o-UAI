using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Universidad
    {
        public int UniversidadId { get; set; }
        public string NombreUniversidad { get; set; }

        public ICollection<Sede> Sedes { get; set; } = new List<Sede>();
    }
}
