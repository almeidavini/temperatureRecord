using SistemaMedicao.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaMedicao
{
    public class MedicaoDbContext : DbContext
    {
        DbSet<Pessoa> Pessoas { get; set; }
        DbSet<Setor> Setores { get; set; }
        DbSet<Medicao> Medicoes { get; set; }

        // Questionar o Udson
        public MedicaoDbContext(DbContextOptions options) : base(options)
        {
        }

        // Questionar o Udson
        public MedicaoDbContext()
        {
            
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(entity => {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Nome).HasMaxLength(100);
                entity.Property(o => o.Sobrenome).HasMaxLength(200);
                entity.Property(o => o.Email);
            });

            modelBuilder.Entity<Setor>(entity => {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Nome).HasMaxLength(100);
            });

            modelBuilder.Entity<Medicao>(entity => {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Temperatura);
            });
        }
    }
}