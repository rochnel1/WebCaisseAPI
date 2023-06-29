using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCaisseAPI.Migrations
{
    public partial class exercice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "STATUT",
                table: "EXERCICES",
                fixedLength: true,
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(1)",
                oldFixedLength: true,
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CLOTURE",
                table: "EXERCICES",
                fixedLength: true,
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(3)",
                oldFixedLength: true,
                oldMaxLength: 3,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "STATUT",
                table: "EXERCICES",
                type: "nchar(1)",
                fixedLength: true,
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(bool),
                oldFixedLength: true,
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "CLOTURE",
                table: "EXERCICES",
                type: "nchar(3)",
                fixedLength: true,
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(bool),
                oldFixedLength: true,
                oldMaxLength: 3);
        }
    }
}
