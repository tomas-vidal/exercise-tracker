using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class ExerciseContext : DbContext
    {
        public DbSet<ExerciseItem> Exercises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(LocalDB)\\LocalDB;Database=ExerciseDB;Trusted_Connection=True;");
        }
    }
}
