using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public virtual DbSet<Budgets> Budgets { get; set; }
        public virtual DbSet<Caisses> Caisses { get; set; }
        public virtual DbSet<Comptegenerals> Comptegenerals { get; set; }
        public virtual DbSet<Exercices> Exercices { get; set; }
        public virtual DbSet<Generalites> Generalites { get; set; }
        public virtual DbSet<Groupeutilisateurs> Groupeutilisateurs { get; set; }
        public virtual DbSet<Natureoperations> Natureoperations { get; set; }
        public virtual DbSet<Operations> Operations { get; set; }
        public virtual DbSet<Periodes> Periodes { get; set; }
        public virtual DbSet<Personnels> Personnels { get; set; }
        public virtual DbSet<Utilisateurs> Utilisateurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-RHNF4BL\\SQL17;Initial Catalog=caisses;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Budgets>(entity =>
            {
                entity.HasKey(e => e.Idbudget);

                entity.ToTable("BUDGETS");

                entity.HasIndex(e => e.Idexercice)
                    .HasName("BUDGETS_EXERCICE_FK");

                entity.HasIndex(e => e.Idnatureoperation)
                    .HasName("COUVRIR_FK");

                entity.HasIndex(e => e.Idperiode)
                    .HasName("BUDGETS_PERIODES_FK");

                entity.Property(e => e.Idbudget).HasColumnName("IDBUDGET");

                entity.Property(e => e.Ecart)
                    .HasColumnName("ECART")
                    .HasColumnType("money");

                entity.Property(e => e.Idexercice).HasColumnName("IDEXERCICE");

                entity.Property(e => e.Idnatureoperation).HasColumnName("IDNATUREOPERATION");

                entity.Property(e => e.Idperiode).HasColumnName("IDPERIODE");

                entity.Property(e => e.Montantbudget)
                    .HasColumnName("MONTANTBUDGET")
                    .HasColumnType("money");

                entity.Property(e => e.Pourcentage).HasColumnName("POURCENTAGE");

                entity.Property(e => e.Realisation)
                    .HasColumnName("REALISATION")
                    .HasColumnType("money");

                entity.Property(e => e.Sensbudget)
                    .HasColumnName("SENSBUDGET")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdexerciceNavigation)
                    .WithMany(p => p.Budgets)
                    .HasForeignKey(d => d.Idexercice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BUDGETS_BUDGETS_E_EXERCICE");

                entity.HasOne(d => d.IdnatureoperationNavigation)
                    .WithMany(p => p.Budgets)
                    .HasForeignKey(d => d.Idnatureoperation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BUDGETS_COUVRIR_NATUREOP");

                entity.HasOne(d => d.IdperiodeNavigation)
                    .WithMany(p => p.Budgets)
                    .HasForeignKey(d => d.Idperiode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BUDGETS_BUDGETS_P_PERIODES");
            });

            modelBuilder.Entity<Caisses>(entity =>
            {
                entity.HasKey(e => e.Idcaisse);

                entity.ToTable("CAISSES");

                entity.HasIndex(e => e.Idcompte)
                    .HasName("AVOIR_FK");

                entity.Property(e => e.Idcaisse).HasColumnName("IDCAISSE");

                entity.Property(e => e.Codecaisse)
                    .HasColumnName("CODECAISSE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Descriptioncaisse)
                    .HasColumnName("DESCRIPTIONCAISSE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Idcompte).HasColumnName("IDCOMPTE");

                entity.HasOne(d => d.IdcompteNavigation)
                    .WithMany(p => p.Caisses)
                    .HasForeignKey(d => d.Idcompte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAISSES_AVOIR_COMPTEGE");
            });

            modelBuilder.Entity<Comptegenerals>(entity =>
            {
                entity.HasKey(e => e.Idcompte);

                entity.ToTable("COMPTEGENERALS");

                entity.Property(e => e.Idcompte).HasColumnName("IDCOMPTE");

                entity.Property(e => e.Intitule)
                    .HasColumnName("INTITULE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Numcompte)
                    .HasColumnName("NUMCOMPTE")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Exercices>(entity =>
            {
                entity.HasKey(e => e.Idexercice);

                entity.ToTable("EXERCICES");

                entity.Property(e => e.Idexercice).HasColumnName("IDEXERCICE");

                entity.Property(e => e.Cloture).HasColumnName("CLOTURE");

                entity.Property(e => e.Code)
                    .HasColumnName("CODE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Datedebut)
                    .HasColumnName("DATEDEBUT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datefin)
                    .HasColumnName("DATEFIN")
                    .HasColumnType("datetime");

                entity.Property(e => e.Statut).HasColumnName("STATUT");
            });

            modelBuilder.Entity<Generalites>(entity =>
            {
                entity.HasKey(e => e.Idgeneralite);

                entity.ToTable("GENERALITES");

                entity.Property(e => e.Idgeneralite).HasColumnName("IDGENERALITE");

                entity.Property(e => e.Adresse)
                    .HasColumnName("ADRESSE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Adressemail)
                    .HasColumnName("ADRESSEMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Format)
                    .HasColumnName("FORMAT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Monnaie)
                    .HasColumnName("MONNAIE")
                    .HasColumnType("money");

                entity.Property(e => e.Niu)
                    .HasColumnName("NIU")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasColumnName("NOM")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Pays)
                    .HasColumnName("PAYS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Raisonsocial)
                    .HasColumnName("RAISONSOCIAL")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .HasColumnName("REGION")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Registrecommerce)
                    .HasColumnName("REGISTRECOMMERCE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Siteinternet)
                    .HasColumnName("SITEINTERNET")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasColumnName("TELEPHONE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ville)
                    .HasColumnName("VILLE")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Groupeutilisateurs>(entity =>
            {
                entity.HasKey(e => e.Idgpeutilisateur);

                entity.ToTable("GROUPEUTILISATEURS");

                entity.Property(e => e.Idgpeutilisateur).HasColumnName("IDGPEUTILISATEUR");

                entity.Property(e => e.Nomgroupe)
                    .HasColumnName("NOMGROUPE")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Natureoperations>(entity =>
            {
                entity.HasKey(e => e.Idnatureoperation);

                entity.ToTable("NATUREOPERATIONS");

                entity.HasIndex(e => e.Idcompte)
                    .HasName("AVOIR1_FK");

                entity.Property(e => e.Idnatureoperation).HasColumnName("IDNATUREOPERATION");

                entity.Property(e => e.Codenature)
                    .IsRequired()
                    .HasColumnName("CODENATURE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION_")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Idcompte).HasColumnName("IDCOMPTE");

                entity.Property(e => e.Sensnature).HasColumnName("SENSNATURE");

                entity.Property(e => e.Typenature).HasColumnName("TYPENATURE");

                entity.HasOne(d => d.IdcompteNavigation)
                    .WithMany(p => p.Natureoperations)
                    .HasForeignKey(d => d.Idcompte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NATUREOP_AVOIR1_COMPTEGE");
            });

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

                entity.Property(e => e.Cloturepar).HasColumnName("CLOTUREPAR");

                entity.Property(e => e.Comptabilserpar)
                    .HasColumnName("COMPTABILSERPAR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Controlerpar).HasColumnName("CONTROLERPAR");

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

                entity.HasOne(d => d.ControlerparNavigation)
                    .WithMany(p => p.OperationsControlerparNavigation)
                    .HasForeignKey(d => d.Controlerpar)
                    .HasConstraintName("FK_OPERATIONS_CONTROLER");

                entity.HasOne(d => d.IdcaisseNavigation)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.Idcaisse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OPERATIO_APPARTENI_CAISSES");

                entity.HasOne(d => d.IdexerciceNavigation)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.Idexercice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OPERATIO_ETRE_EXERCICE");

                entity.HasOne(d => d.IdnatureoperationNavigation)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.Idnatureoperation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OPERATIO_CONCERNER_NATUREOP");

                entity.HasOne(d => d.IdperiodeNavigation)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.Idperiode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OPERATIO_ETENDRE_PERIODES");

                entity.HasOne(d => d.IdpersonnelNavigation)
                    .WithMany(p => p.OperationsIdpersonnelNavigation)
                    .HasForeignKey(d => d.Idpersonnel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OPERATIO_EFFECTUER_PERSONNE");
            });

            modelBuilder.Entity<Periodes>(entity =>
            {
                entity.HasKey(e => e.Idperiode);

                entity.ToTable("PERIODES");

                entity.HasIndex(e => e.Idexercice)
                    .HasName("EXERCICES_PERIODES_FK");

                entity.Property(e => e.Idperiode).HasColumnName("IDPERIODE");

                entity.Property(e => e.Codeperiode)
                    .HasColumnName("CODEPERIODE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Datedebut)
                    .HasColumnName("DATEDEBUT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datefin)
                    .HasColumnName("DATEFIN")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idexercice).HasColumnName("IDEXERCICE");

                entity.HasOne(d => d.IdexerciceNavigation)
                    .WithMany(p => p.Periodes)
                    .HasForeignKey(d => d.Idexercice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERIODES_EXERCICES_EXERCICE");
            });

            modelBuilder.Entity<Personnels>(entity =>
            {
                entity.HasKey(e => e.Idpersonnel);

                entity.ToTable("PERSONNELS");

                entity.HasIndex(e => e.Idcaisse)
                    .HasName("GERER_FK");

                entity.Property(e => e.Idpersonnel).HasColumnName("IDPERSONNEL");

                entity.Property(e => e.Codepersonnel)
                    .HasColumnName("CODEPERSONNEL")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Idcaisse).HasColumnName("IDCAISSE");

                entity.Property(e => e.Nom)
                    .HasColumnName("NOM")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasColumnName("PRENOM")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Profil)
                    .HasColumnName("PROFIL")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdcaisseNavigation)
                    .WithMany(p => p.Personnels)
                    .HasForeignKey(d => d.Idcaisse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERSONNE_GERER_CAISSES");
            });

            modelBuilder.Entity<Utilisateurs>(entity =>
            {
                entity.HasKey(e => e.IdUtilisateur);

                entity.ToTable("UTILISATEURS");

                entity.HasIndex(e => e.Idgpeutilisateur)
                    .HasName("APPARTENIR1_FK");

                entity.Property(e => e.IdUtilisateur).HasColumnName("ID_UTILISATEUR_");

                entity.Property(e => e.Idgpeutilisateur).HasColumnName("IDGPEUTILISATEUR");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("LOGIN")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nomutilisateur)
                    .IsRequired()
                    .HasColumnName("NOMUTILISATEUR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Prenomutilisateur)
                    .IsRequired()
                    .HasColumnName("PRENOMUTILISATEUR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdgpeutilisateurNavigation)
                    .WithMany(p => p.Utilisateurs)
                    .HasForeignKey(d => d.Idgpeutilisateur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UTILISAT_APPARTENI_GROUPEUT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
