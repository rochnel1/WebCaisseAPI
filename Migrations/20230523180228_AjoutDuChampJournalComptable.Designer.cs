﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebCaisseAPI.Models;

namespace WebCaisseAPI.Migrations
{
    [DbContext(typeof(CaissesContext))]
    [Migration("20230523180228_AjoutDuChampJournalComptable")]
    partial class AjoutDuChampJournalComptable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebCaisseAPI.Models.Budgets", b =>
                {
                    b.Property<int>("Idbudget")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDBUDGET")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Ecart")
                        .HasColumnName("ECART")
                        .HasColumnType("money");

                    b.Property<int>("Idexercice")
                        .HasColumnName("IDEXERCICE")
                        .HasColumnType("int");

                    b.Property<int>("Idnatureoperation")
                        .HasColumnName("IDNATUREOPERATION")
                        .HasColumnType("int");

                    b.Property<int>("Idperiode")
                        .HasColumnName("IDPERIODE")
                        .HasColumnType("int");

                    b.Property<decimal?>("Montantbudget")
                        .HasColumnName("MONTANTBUDGET")
                        .HasColumnType("money");

                    b.Property<int?>("Pourcentage")
                        .HasColumnName("POURCENTAGE")
                        .HasColumnType("int");

                    b.Property<decimal?>("Realisation")
                        .HasColumnName("REALISATION")
                        .HasColumnType("money");

                    b.Property<string>("Sensbudget")
                        .HasColumnName("SENSBUDGET")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("Idbudget");

                    b.HasIndex("Idexercice")
                        .HasName("BUDGETS_EXERCICE_FK");

                    b.HasIndex("Idnatureoperation")
                        .HasName("COUVRIR_FK");

                    b.HasIndex("Idperiode")
                        .HasName("BUDGETS_PERIODES_FK");

                    b.ToTable("BUDGETS");
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Caisses", b =>
                {
                    b.Property<int>("Idcaisse")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDCAISSE")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codecaisse")
                        .HasColumnName("CODECAISSE")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Descriptioncaisse")
                        .HasColumnName("DESCRIPTIONCAISSE")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<int>("Idcompte")
                        .HasColumnName("IDCOMPTE")
                        .HasColumnType("int");

                    b.Property<string>("JournalComptable")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Idcaisse");

                    b.HasIndex("Idcompte")
                        .HasName("AVOIR_FK");

                    b.ToTable("CAISSES");
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Comptegenerals", b =>
                {
                    b.Property<int>("Idcompte")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDCOMPTE")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Intitule")
                        .HasColumnName("INTITULE")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Numcompte")
                        .HasColumnName("NUMCOMPTE")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("Idcompte");

                    b.ToTable("COMPTEGENERALS");
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Exercices", b =>
                {
                    b.Property<int>("Idexercice")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDEXERCICE")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cloture")
                        .HasColumnName("CLOTURE")
                        .HasColumnType("nchar(3)")
                        .IsFixedLength(true)
                        .HasMaxLength(3);

                    b.Property<string>("Code")
                        .HasColumnName("CODE")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Datedebut")
                        .HasColumnName("DATEDEBUT")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("Datefin")
                        .HasColumnName("DATEFIN")
                        .HasColumnType("datetime");

                    b.Property<string>("Statut")
                        .HasColumnName("STATUT")
                        .HasColumnType("nchar(1)")
                        .IsFixedLength(true)
                        .HasMaxLength(1);

                    b.HasKey("Idexercice");

                    b.ToTable("EXERCICES");
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Generalites", b =>
                {
                    b.Property<int>("Idgeneralite")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDGENERALITE")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .HasColumnName("ADRESSE")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Adressemail")
                        .HasColumnName("ADRESSEMAIL")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Format")
                        .HasColumnName("FORMAT")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<decimal?>("Monnaie")
                        .HasColumnName("MONNAIE")
                        .HasColumnType("money");

                    b.Property<string>("Niu")
                        .HasColumnName("NIU")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Pays")
                        .HasColumnName("PAYS")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Raisonsocial")
                        .HasColumnName("RAISONSOCIAL")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Region")
                        .HasColumnName("REGION")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Registrecommerce")
                        .HasColumnName("REGISTRECOMMERCE")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Siteinternet")
                        .HasColumnName("SITEINTERNET")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Telephone")
                        .HasColumnName("TELEPHONE")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Ville")
                        .HasColumnName("VILLE")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("Idgeneralite");

                    b.ToTable("GENERALITES");
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Groupeutilisateurs", b =>
                {
                    b.Property<int>("Idgpeutilisateur")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDGPEUTILISATEUR")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nomgroupe")
                        .HasColumnName("NOMGROUPE")
                        .HasColumnType("varchar(40)")
                        .HasMaxLength(40)
                        .IsUnicode(false);

                    b.HasKey("Idgpeutilisateur");

                    b.ToTable("GROUPEUTILISATEURS");
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Natureoperations", b =>
                {
                    b.Property<int>("Idnatureoperation")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDNATUREOPERATION")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codenature")
                        .HasColumnName("CODENATURE")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION_")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("Idcompte")
                        .HasColumnName("IDCOMPTE")
                        .HasColumnType("int");

                    b.Property<string>("Sensnature")
                        .HasColumnName("SENSNATURE")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Typenature")
                        .HasColumnName("TYPENATURE")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("Idnatureoperation");

                    b.HasIndex("Idcompte")
                        .HasName("AVOIR1_FK");

                    b.ToTable("NATUREOPERATIONS");
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Operations", b =>
                {
                    b.Property<int>("Idoperation")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDOPERATION")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cloturepar")
                        .HasColumnName("CLOTUREPAR")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Comptabilserpar")
                        .HasColumnName("COMPTABILSERPAR")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Controlerpar")
                        .HasColumnName("CONTROLERPAR")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Datecloture")
                        .HasColumnName("DATECLOTURE")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("Datecomptabilisation")
                        .HasColumnName("DATECOMPTABILISATION")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("Datecontrole")
                        .HasColumnName("DATECONTROLE")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("Dateoperation")
                        .HasColumnName("DATEOPERATION")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnName("DESCRIPTION_")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Etat")
                        .HasColumnName("ETAT")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int>("Idcaisse")
                        .HasColumnName("IDCAISSE")
                        .HasColumnType("int");

                    b.Property<int>("Idexercice")
                        .HasColumnName("IDEXERCICE")
                        .HasColumnType("int");

                    b.Property<int>("Idnatureoperation")
                        .HasColumnName("IDNATUREOPERATION")
                        .HasColumnType("int");

                    b.Property<int>("Idperiode")
                        .HasColumnName("IDPERIODE")
                        .HasColumnType("int");

                    b.Property<int>("Idpersonnel")
                        .HasColumnName("IDPERSONNEL")
                        .HasColumnType("int");

                    b.Property<decimal?>("Montant")
                        .HasColumnName("MONTANT")
                        .HasColumnType("money");

                    b.Property<int?>("Nbrecontrole")
                        .HasColumnName("NBRECONTROLE")
                        .HasColumnType("int");

                    b.Property<string>("Sens")
                        .HasColumnName("SENS")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("Idoperation");

                    b.HasIndex("Idcaisse")
                        .HasName("APPARTENIR_FK");

                    b.HasIndex("Idexercice")
                        .HasName("ETRE_FK");

                    b.HasIndex("Idnatureoperation")
                        .HasName("CONCERNER_FK");

                    b.HasIndex("Idperiode")
                        .HasName("ETENDRE_FK");

                    b.HasIndex("Idpersonnel")
                        .HasName("EFFECTUER_FK");

                    b.ToTable("OPERATIONS");
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Periodes", b =>
                {
                    b.Property<int>("Idperiode")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDPERIODE")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codeperiode")
                        .HasColumnName("CODEPERIODE")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Datedebut")
                        .HasColumnName("DATEDEBUT")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("Datefin")
                        .HasColumnName("DATEFIN")
                        .HasColumnType("datetime");

                    b.Property<int>("Idexercice")
                        .HasColumnName("IDEXERCICE")
                        .HasColumnType("int");

                    b.HasKey("Idperiode");

                    b.HasIndex("Idexercice")
                        .HasName("EXERCICES_PERIODES_FK");

                    b.ToTable("PERIODES");
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Personnels", b =>
                {
                    b.Property<int>("Idpersonnel")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDPERSONNEL")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codepersonnel")
                        .HasColumnName("CODEPERSONNEL")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int>("Idcaisse")
                        .HasColumnName("IDCAISSE")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnName("NOM")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Prenom")
                        .HasColumnName("PRENOM")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Profil")
                        .HasColumnName("PROFIL")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("Idpersonnel");

                    b.HasIndex("Idcaisse")
                        .HasName("GERER_FK");

                    b.ToTable("PERSONNELS");
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Utilisateurs", b =>
                {
                    b.Property<int>("IdUtilisateur")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_UTILISATEUR_")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Idgpeutilisateur")
                        .HasColumnName("IDGPEUTILISATEUR")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnName("LOGIN")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Nomutilisateur")
                        .HasColumnName("NOMUTILISATEUR")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Prenomutilisateur")
                        .HasColumnName("PRENOMUTILISATEUR")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("IdUtilisateur");

                    b.HasIndex("Idgpeutilisateur")
                        .HasName("APPARTENIR1_FK");

                    b.ToTable("UTILISATEURS");
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Budgets", b =>
                {
                    b.HasOne("WebCaisseAPI.Models.Exercices", "IdexerciceNavigation")
                        .WithMany("Budgets")
                        .HasForeignKey("Idexercice")
                        .HasConstraintName("FK_BUDGETS_BUDGETS_E_EXERCICE")
                        .IsRequired();

                    b.HasOne("WebCaisseAPI.Models.Natureoperations", "IdnatureoperationNavigation")
                        .WithMany("Budgets")
                        .HasForeignKey("Idnatureoperation")
                        .HasConstraintName("FK_BUDGETS_COUVRIR_NATUREOP")
                        .IsRequired();

                    b.HasOne("WebCaisseAPI.Models.Periodes", "IdperiodeNavigation")
                        .WithMany("Budgets")
                        .HasForeignKey("Idperiode")
                        .HasConstraintName("FK_BUDGETS_BUDGETS_P_PERIODES")
                        .IsRequired();
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Caisses", b =>
                {
                    b.HasOne("WebCaisseAPI.Models.Comptegenerals", "IdcompteNavigation")
                        .WithMany("Caisses")
                        .HasForeignKey("Idcompte")
                        .HasConstraintName("FK_CAISSES_AVOIR_COMPTEGE")
                        .IsRequired();
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Natureoperations", b =>
                {
                    b.HasOne("WebCaisseAPI.Models.Comptegenerals", "IdcompteNavigation")
                        .WithMany("Natureoperations")
                        .HasForeignKey("Idcompte")
                        .HasConstraintName("FK_NATUREOP_AVOIR1_COMPTEGE")
                        .IsRequired();
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Operations", b =>
                {
                    b.HasOne("WebCaisseAPI.Models.Caisses", "IdcaisseNavigation")
                        .WithMany("Operations")
                        .HasForeignKey("Idcaisse")
                        .HasConstraintName("FK_OPERATIO_APPARTENI_CAISSES")
                        .IsRequired();

                    b.HasOne("WebCaisseAPI.Models.Exercices", "IdexerciceNavigation")
                        .WithMany("Operations")
                        .HasForeignKey("Idexercice")
                        .HasConstraintName("FK_OPERATIO_ETRE_EXERCICE")
                        .IsRequired();

                    b.HasOne("WebCaisseAPI.Models.Natureoperations", "IdnatureoperationNavigation")
                        .WithMany("Operations")
                        .HasForeignKey("Idnatureoperation")
                        .HasConstraintName("FK_OPERATIO_CONCERNER_NATUREOP")
                        .IsRequired();

                    b.HasOne("WebCaisseAPI.Models.Periodes", "IdperiodeNavigation")
                        .WithMany("Operations")
                        .HasForeignKey("Idperiode")
                        .HasConstraintName("FK_OPERATIO_ETENDRE_PERIODES")
                        .IsRequired();

                    b.HasOne("WebCaisseAPI.Models.Personnels", "IdpersonnelNavigation")
                        .WithMany("Operations")
                        .HasForeignKey("Idpersonnel")
                        .HasConstraintName("FK_OPERATIO_EFFECTUER_PERSONNE")
                        .IsRequired();
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Periodes", b =>
                {
                    b.HasOne("WebCaisseAPI.Models.Exercices", "IdexerciceNavigation")
                        .WithMany("Periodes")
                        .HasForeignKey("Idexercice")
                        .HasConstraintName("FK_PERIODES_EXERCICES_EXERCICE")
                        .IsRequired();
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Personnels", b =>
                {
                    b.HasOne("WebCaisseAPI.Models.Caisses", "IdcaisseNavigation")
                        .WithMany("Personnels")
                        .HasForeignKey("Idcaisse")
                        .HasConstraintName("FK_PERSONNE_GERER_CAISSES")
                        .IsRequired();
                });

            modelBuilder.Entity("WebCaisseAPI.Models.Utilisateurs", b =>
                {
                    b.HasOne("WebCaisseAPI.Models.Groupeutilisateurs", "IdgpeutilisateurNavigation")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("Idgpeutilisateur")
                        .HasConstraintName("FK_UTILISAT_APPARTENI_GROUPEUT")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
