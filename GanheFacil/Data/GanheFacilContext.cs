using GanheFacil.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace GanheFacil.Data
{
    public class GanheFacilContext : DbContext
    {
        public DbSet<Resultado> Resultados { get; set; }

        public GanheFacilContext(DbContextOptions<GanheFacilContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Resultado>().ToTable("Resultados");
            modelBuilder.Entity<Resultado>().Ignore(r => r.NumerosSorteados).HasNoKey();
            modelBuilder.Entity<Resultado>().Property(r => r.DataSorteio).IsRequired();
            modelBuilder.Entity<Resultado>().Property(r => r.ValorPremio).HasColumnType("decimal(18, 2)");
        }
    }
}


