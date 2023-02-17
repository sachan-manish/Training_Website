using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrainingWebService.Models
{
    public partial class TrainingDatabaseContext : DbContext
    {
        public TrainingDatabaseContext()
        {
        }

        public TrainingDatabaseContext(DbContextOptions<TrainingDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Modules> Modules { get; set; }
        public virtual DbSet<SubModules> SubModules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=TrainingDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Modules>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubModules>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.VideoLink)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WikiLink)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.SubModules)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK__SubModule__Modul__398D8EEE");
            });
        }
    }
}
