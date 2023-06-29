using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCaisseAPI.Migrations
{
    public partial class nature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "SENSNATURE",
                table: "NATUREOPERATIONS",
                unicode: false,
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "CODENATURE",
                table: "NATUREOPERATIONS",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SENSNATURE",
                table: "NATUREOPERATIONS",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(short),
                oldUnicode: false,
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "CODENATURE",
                table: "NATUREOPERATIONS",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(short),
                oldUnicode: false,
                oldMaxLength: 20);
        }
    }
}
