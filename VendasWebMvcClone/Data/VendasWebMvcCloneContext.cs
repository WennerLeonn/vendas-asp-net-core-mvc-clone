using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMvcClone.Models
{
    public class VendasWebMvcCloneContext : DbContext
    {
        public VendasWebMvcCloneContext (DbContextOptions<VendasWebMvcCloneContext> options)
            : base(options)
        {
        }

        public DbSet<VendasWebMvcClone.Models.Departamento> Departamento { get; set; }
    }
}
