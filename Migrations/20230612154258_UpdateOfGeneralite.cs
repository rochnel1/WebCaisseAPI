using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCaisseAPI.Migrations
{
    public partial class UpdateOfGeneralite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "TYPENATURE",
                table: "NATUREOPERATIONS",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CODENATURE",
                table: "NATUREOPERATIONS",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldUnicode: false,
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TYPENATURE",
                table: "NATUREOPERATIONS",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(short),
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<short>(
                name: "CODENATURE",
                table: "NATUREOPERATIONS",
                type: "smallint",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
