using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCaisseAPI.Migrations
{
    public partial class AjoutDuChampJournalComptable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JournalComptable",
                table: "CAISSES",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JournalComptable",
                table: "CAISSES");
        }
    }
}
