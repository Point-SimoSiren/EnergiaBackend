using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EnergiaBackend.Models
{
    public partial class EnergiaDBContext : DbContext
    {
        public EnergiaDBContext()
        {
        }

        public EnergiaDBContext(DbContextOptions<EnergiaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kaukolampo> Kaukolampos { get; set; } = null!;
        public virtual DbSet<Sahko> Sahkos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=xxxdatabase.windows.net;Database=EnergiaDB;User ID=aaa;Password=bbb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Kaukolampo>(entity =>
            {
                entity.ToTable("Kaukolampo");

                entity.Property(e => e.KaukolampoId).HasColumnName("kaukolampoID");

                entity.Property(e => e.Kwh)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("kwh");

                entity.Property(e => e.Pvm)
                    .HasMaxLength(20)
                    .HasColumnName("pvm");

                entity.Property(e => e.Summa)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("summa");
            });

            modelBuilder.Entity<Sahko>(entity =>
            {
                entity.ToTable("Sahko");

                entity.Property(e => e.SahkoId).HasColumnName("sahkoID");

                entity.Property(e => e.Kwh)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("kwh");

                entity.Property(e => e.Pvm)
                    .HasMaxLength(20)
                    .HasColumnName("pvm");

                entity.Property(e => e.Summa)
                    .HasColumnType("decimal(7, 2)")
                    .HasColumnName("summa");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
