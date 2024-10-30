using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pablo_Yanez_Examen1.Models;

namespace Pablo_Yanez_Examen1.Data
{
    public class Pablo_Yanez_Examen1Context : DbContext
    {
        public Pablo_Yanez_Examen1Context (DbContextOptions<Pablo_Yanez_Examen1Context> options)
            : base(options)
        {
        }

        public DbSet<Pablo_Yanez_Examen1.Models.PYanez> PYanez { get; set; } = default!;
        public DbSet<Pablo_Yanez_Examen1.Models.Celular> Celular { get; set; } = default!;
    }
}
