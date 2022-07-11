using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniCore.Models;

namespace MiniCore.Data
{
    public class MiniCoreContext : DbContext
    {
        public MiniCoreContext (DbContextOptions<MiniCoreContext> options)
            : base(options)
        {
        }

        public DbSet<MiniCore.Models.Persona>? Personas { get; set; }

        public DbSet<MiniCore.Models.PersonasPase>? PersonasPases { get; set; }

        public DbSet<MiniCore.Models.TipoPase>? TipoPases { get; set; }
    }
}
