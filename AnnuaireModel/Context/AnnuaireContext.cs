using Microsoft.EntityFrameworkCore;
using AnnuaireModel.Entities;

namespace AnnuaireModel.Context
{
    public class AnnuaireContext : DbContext
    {
        public DbSet<Site> Sites { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Employe> Employes { get; set; }

        public AnnuaireContext(DbContextOptions<AnnuaireContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=AnnuaireEntreprise.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Site>(entity =>
            {
                entity.ToTable("Sites");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Ville)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Services");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Employe>(entity =>
            {
                entity.ToTable("Employes");
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(100);
                
                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(100);
                
                entity.Property(e => e.TelephoneFixe)
                    .HasMaxLength(20);
                
                entity.Property(e => e.TelephonePortable)
                    .HasMaxLength(20);
                
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(e => e.Service)
                    .WithMany(s => s.Employes)
                    .HasForeignKey(e => e.ServiceId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Site)
                    .WithMany(s => s.Employes)
                    .HasForeignKey(e => e.SiteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
