using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebCaisseAPI.Models
{
    public partial class CaissesContext : DbContext
    {
        public CaissesContext()
        {
        }

        public CaissesContext(DbContextOptions<CaissesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Operations> Operations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RHNF4BL\\SQL17; Database=Caisses; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operations>(entity =>
            {
                entity.HasKey(e => e.Idoperation);

                entity.ToTable("OPERATIONS");

                entity.HasIndex(e => e.Idcaisse)
                    .HasName("APPARTENIR_FK");

                entity.HasIndex(e => e.Idexercice)
                    .HasName("ETRE_FK");

                entity.HasIndex(e => e.Idnatureoperation)
                    .HasName("CONCERNER_FK");

                entity.HasIndex(e => e.Idperiode)
                    .HasName("ETENDRE_FK");

                entity.HasIndex(e => e.Idpersonnel)
                    .HasName("EFFECTUER_FK");

                entity.Property(e => e.Idoperation).HasColumnName("IDOPERATION");

                entity.Property(e => e.Cloturepar)
                    .HasColumnName("CLOTUREPAR")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Comptabilserpar)
                    .HasColumnName("COMPTABILSERPAR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Controlerpar)
                    .HasColumnName("CONTROLERPAR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Datecloture)
                    .HasColumnName("DATECLOTURE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datecomptabilisation)
                    .HasColumnName("DATECOMPTABILISATION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datecontrole)
                    .HasColumnName("DATECONTROLE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dateoperation)
                    .HasColumnName("DATEOPERATION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION_")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Etat)
                    .HasColumnName("ETAT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Idcaisse).HasColumnName("IDCAISSE");

                entity.Property(e => e.Idexercice).HasColumnName("IDEXERCICE");

                entity.Property(e => e.Idnatureoperation).HasColumnName("IDNATUREOPERATION");

                entity.Property(e => e.Idperiode).HasColumnName("IDPERIODE");

                entity.Property(e => e.Idpersonnel).HasColumnName("IDPERSONNEL");

                entity.Property(e => e.Montant)
                    .HasColumnName("MONTANT")
                    .HasColumnType("money");

                entity.Property(e => e.Nbrecontrole).HasColumnName("NBRECONTROLE");

                entity.Property(e => e.Regularise).HasColumnName("REGULARISE");

                entity.Property(e => e.Sens)
                    .HasColumnName("SENS")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
