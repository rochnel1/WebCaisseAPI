using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCaisseAPI.Migrations
{
    public partial class changeTpeOfPropertiesExercice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COMPTEGENERALS",
                columns: table => new
                {
                    IDCOMPTE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NUMCOMPTE = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    INTITULE = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPTEGENERALS", x => x.IDCOMPTE);
                });

            migrationBuilder.CreateTable(
                name: "EXERCICES",
                columns: table => new
                {
                    IDEXERCICE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    DATEDEBUT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DATEFIN = table.Column<DateTime>(type: "datetime", nullable: true),
                    STATUT = table.Column<string>(fixedLength: true, maxLength: 1, nullable: true),
                    CLOTURE = table.Column<string>(fixedLength: true, maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXERCICES", x => x.IDEXERCICE);
                });

            migrationBuilder.CreateTable(
                name: "GENERALITES",
                columns: table => new
                {
                    IDGENERALITE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RAISONSOCIAL = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    ADRESSE = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    VILLE = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    REGION = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    PAYS = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    MONNAIE = table.Column<decimal>(type: "money", nullable: true),
                    FORMAT = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    NIU = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    REGISTRECOMMERCE = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    TELEPHONE = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    ADRESSEMAIL = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    SITEINTERNET = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GENERALITES", x => x.IDGENERALITE);
                });

            migrationBuilder.CreateTable(
                name: "GROUPEUTILISATEURS",
                columns: table => new
                {
                    IDGPEUTILISATEUR = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMGROUPE = table.Column<string>(unicode: false, maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUPEUTILISATEURS", x => x.IDGPEUTILISATEUR);
                });

            migrationBuilder.CreateTable(
                name: "CAISSES",
                columns: table => new
                {
                    IDCAISSE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCOMPTE = table.Column<int>(nullable: false),
                    CODECAISSE = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    DESCRIPTIONCAISSE = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAISSES", x => x.IDCAISSE);
                    table.ForeignKey(
                        name: "FK_CAISSES_AVOIR_COMPTEGE",
                        column: x => x.IDCOMPTE,
                        principalTable: "COMPTEGENERALS",
                        principalColumn: "IDCOMPTE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NATUREOPERATIONS",
                columns: table => new
                {
                    IDNATUREOPERATION = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCOMPTE = table.Column<int>(nullable: false),
                    DESCRIPTION_ = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    TYPENATURE = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    CODENATURE = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    SENSNATURE = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NATUREOPERATIONS", x => x.IDNATUREOPERATION);
                    table.ForeignKey(
                        name: "FK_NATUREOP_AVOIR1_COMPTEGE",
                        column: x => x.IDCOMPTE,
                        principalTable: "COMPTEGENERALS",
                        principalColumn: "IDCOMPTE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERIODES",
                columns: table => new
                {
                    IDPERIODE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEXERCICE = table.Column<int>(nullable: false),
                    CODEPERIODE = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    DATEDEBUT = table.Column<DateTime>(type: "datetime", nullable: true),
                    DATEFIN = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERIODES", x => x.IDPERIODE);
                    table.ForeignKey(
                        name: "FK_PERIODES_EXERCICES_EXERCICE",
                        column: x => x.IDEXERCICE,
                        principalTable: "EXERCICES",
                        principalColumn: "IDEXERCICE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UTILISATEURS",
                columns: table => new
                {
                    ID_UTILISATEUR_ = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDGPEUTILISATEUR = table.Column<int>(nullable: false),
                    LOGIN = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    NOMUTILISATEUR = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    PRENOMUTILISATEUR = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UTILISATEURS", x => x.ID_UTILISATEUR_);
                    table.ForeignKey(
                        name: "FK_UTILISAT_APPARTENI_GROUPEUT",
                        column: x => x.IDGPEUTILISATEUR,
                        principalTable: "GROUPEUTILISATEURS",
                        principalColumn: "IDGPEUTILISATEUR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERSONNELS",
                columns: table => new
                {
                    IDPERSONNEL = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCAISSE = table.Column<int>(nullable: false),
                    NOM = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    PRENOM = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    PROFIL = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    CODEPERSONNEL = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONNELS", x => x.IDPERSONNEL);
                    table.ForeignKey(
                        name: "FK_PERSONNE_GERER_CAISSES",
                        column: x => x.IDCAISSE,
                        principalTable: "CAISSES",
                        principalColumn: "IDCAISSE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BUDGETS",
                columns: table => new
                {
                    IDBUDGET = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNATUREOPERATION = table.Column<int>(nullable: false),
                    IDPERIODE = table.Column<int>(nullable: false),
                    IDEXERCICE = table.Column<int>(nullable: false),
                    REALISATION = table.Column<decimal>(type: "money", nullable: true),
                    ECART = table.Column<decimal>(type: "money", nullable: true),
                    POURCENTAGE = table.Column<int>(nullable: true),
                    MONTANTBUDGET = table.Column<decimal>(type: "money", nullable: true),
                    SENSBUDGET = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUDGETS", x => x.IDBUDGET);
                    table.ForeignKey(
                        name: "FK_BUDGETS_BUDGETS_E_EXERCICE",
                        column: x => x.IDEXERCICE,
                        principalTable: "EXERCICES",
                        principalColumn: "IDEXERCICE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BUDGETS_COUVRIR_NATUREOP",
                        column: x => x.IDNATUREOPERATION,
                        principalTable: "NATUREOPERATIONS",
                        principalColumn: "IDNATUREOPERATION",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BUDGETS_BUDGETS_P_PERIODES",
                        column: x => x.IDPERIODE,
                        principalTable: "PERIODES",
                        principalColumn: "IDPERIODE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OPERATIONS",
                columns: table => new
                {
                    IDOPERATION = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCAISSE = table.Column<int>(nullable: false),
                    IDPERSONNEL = table.Column<int>(nullable: false),
                    IDPERIODE = table.Column<int>(nullable: false),
                    IDEXERCICE = table.Column<int>(nullable: false),
                    IDNATUREOPERATION = table.Column<int>(nullable: false),
                    DATEOPERATION = table.Column<DateTime>(type: "datetime", nullable: true),
                    DESCRIPTION_ = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    MONTANT = table.Column<decimal>(type: "money", nullable: true),
                    SENS = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    ETAT = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    NBRECONTROLE = table.Column<int>(nullable: true),
                    CONTROLERPAR = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    COMPTABILSERPAR = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    DATECONTROLE = table.Column<DateTime>(type: "datetime", nullable: true),
                    DATECLOTURE = table.Column<DateTime>(type: "datetime", nullable: true),
                    DATECOMPTABILISATION = table.Column<DateTime>(type: "datetime", nullable: true),
                    CLOTUREPAR = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERATIONS", x => x.IDOPERATION);
                    table.ForeignKey(
                        name: "FK_OPERATIO_APPARTENI_CAISSES",
                        column: x => x.IDCAISSE,
                        principalTable: "CAISSES",
                        principalColumn: "IDCAISSE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPERATIO_ETRE_EXERCICE",
                        column: x => x.IDEXERCICE,
                        principalTable: "EXERCICES",
                        principalColumn: "IDEXERCICE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPERATIO_CONCERNER_NATUREOP",
                        column: x => x.IDNATUREOPERATION,
                        principalTable: "NATUREOPERATIONS",
                        principalColumn: "IDNATUREOPERATION",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPERATIO_ETENDRE_PERIODES",
                        column: x => x.IDPERIODE,
                        principalTable: "PERIODES",
                        principalColumn: "IDPERIODE",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OPERATIO_EFFECTUER_PERSONNE",
                        column: x => x.IDPERSONNEL,
                        principalTable: "PERSONNELS",
                        principalColumn: "IDPERSONNEL",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "BUDGETS_EXERCICE_FK",
                table: "BUDGETS",
                column: "IDEXERCICE");

            migrationBuilder.CreateIndex(
                name: "COUVRIR_FK",
                table: "BUDGETS",
                column: "IDNATUREOPERATION");

            migrationBuilder.CreateIndex(
                name: "BUDGETS_PERIODES_FK",
                table: "BUDGETS",
                column: "IDPERIODE");

            migrationBuilder.CreateIndex(
                name: "AVOIR_FK",
                table: "CAISSES",
                column: "IDCOMPTE");

            migrationBuilder.CreateIndex(
                name: "AVOIR1_FK",
                table: "NATUREOPERATIONS",
                column: "IDCOMPTE");

            migrationBuilder.CreateIndex(
                name: "APPARTENIR_FK",
                table: "OPERATIONS",
                column: "IDCAISSE");

            migrationBuilder.CreateIndex(
                name: "ETRE_FK",
                table: "OPERATIONS",
                column: "IDEXERCICE");

            migrationBuilder.CreateIndex(
                name: "CONCERNER_FK",
                table: "OPERATIONS",
                column: "IDNATUREOPERATION");

            migrationBuilder.CreateIndex(
                name: "ETENDRE_FK",
                table: "OPERATIONS",
                column: "IDPERIODE");

            migrationBuilder.CreateIndex(
                name: "EFFECTUER_FK",
                table: "OPERATIONS",
                column: "IDPERSONNEL");

            migrationBuilder.CreateIndex(
                name: "EXERCICES_PERIODES_FK",
                table: "PERIODES",
                column: "IDEXERCICE");

            migrationBuilder.CreateIndex(
                name: "GERER_FK",
                table: "PERSONNELS",
                column: "IDCAISSE");

            migrationBuilder.CreateIndex(
                name: "APPARTENIR1_FK",
                table: "UTILISATEURS",
                column: "IDGPEUTILISATEUR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BUDGETS");

            migrationBuilder.DropTable(
                name: "GENERALITES");

            migrationBuilder.DropTable(
                name: "OPERATIONS");

            migrationBuilder.DropTable(
                name: "UTILISATEURS");

            migrationBuilder.DropTable(
                name: "NATUREOPERATIONS");

            migrationBuilder.DropTable(
                name: "PERIODES");

            migrationBuilder.DropTable(
                name: "PERSONNELS");

            migrationBuilder.DropTable(
                name: "GROUPEUTILISATEURS");

            migrationBuilder.DropTable(
                name: "EXERCICES");

            migrationBuilder.DropTable(
                name: "CAISSES");

            migrationBuilder.DropTable(
                name: "COMPTEGENERALS");
        }
    }
}
