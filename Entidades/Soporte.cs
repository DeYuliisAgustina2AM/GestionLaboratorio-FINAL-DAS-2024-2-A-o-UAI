using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Soporte
    {
        public int SoporteId { get; set; }
        public string NombreyApellido { get; set; }
        public long Dni { get; set; }
        public int Legajo { get; set; }

        public int cantidadTicket { get; set; }
        public int TicketResueltos { get; set; }
        public int TicketNoResueltos { get; set; }
        public int TicketEnProceso { get; set; }
        public int TicketEnEspera { get; set; }
        public int TicketCerrados { get; set; }
        public int TicketAbiertos { get; set; }
        public int TicketTotal { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    }
}
