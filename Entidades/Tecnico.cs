﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tecnico
    {
        public int TecnicoId { get; set; }
        public string NombreyApellido { get; set; }
        public long Dni { get; set; }
        public int Legajo { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>(); //un soporte puede tener muchos tickets
    }
}
