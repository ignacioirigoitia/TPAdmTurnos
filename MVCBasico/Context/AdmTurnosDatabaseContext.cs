using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using MVCBasico.Models;


namespace MVCBasico.Context
{
    public class AdmTurnosDatabaseContext : DbContext
    {
        public AdmTurnosDatabaseContext(DbContextOptions<AdmTurnosDatabaseContext> options)
       : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Turnera> Turneras { get; set; }
        public DbSet<Turno> Turnos{ get; set; }

    }

}
