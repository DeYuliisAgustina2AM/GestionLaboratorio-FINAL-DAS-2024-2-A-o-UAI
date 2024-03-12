using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Context : DbContext
    {
        public DbSet<Universidad> Universidades { get; set; }
        public DbSet<Sede> Sedes { get; set; }
        public DbSet<Computadora> Computadoras { get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SistemaGestion;Trusted_Connection=True;");
        }
    }
}
