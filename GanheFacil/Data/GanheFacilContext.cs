using GanheFacil.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace GanheFacil.Data
{
    public class GanheFacilContext : DbContext
    {
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<Sorteio> Sorteios { get; set; }
        public DbSet<NumeroSorteado> NumeroSorteados { get; set; }

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
            modelBuilder.Entity<Sorteio>().ToTable("Sorteios");
            modelBuilder.Entity<Sorteio>().Property(r => r.Numero).IsRequired();
            modelBuilder.Entity<Sorteio>().Property(r => r.NumerosSorteados).IsRequired();
            modelBuilder.Entity<Sorteio>().Property(r => r.DataSorteio).IsRequired();
            modelBuilder.Entity<Sorteio>().Property(s => s.TipoJogo).IsRequired();
            modelBuilder.Entity<NumeroSorteado>().ToTable("NumeroSorteados");
            modelBuilder.Entity<NumeroSorteado>().Property(r => r.Numero).IsRequired();
        }
    }
}


