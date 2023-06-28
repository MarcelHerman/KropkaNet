using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektTurnieju.Migrations
{
    /// <inheritdoc />
    public partial class maleZmiany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Druzyny_Uzytkownicy_KapitanDruzynyId",
                table: "Druzyny");

            migrationBuilder.DropIndex(
                name: "IX_Druzyny_KapitanDruzynyId",
                table: "Druzyny");

            migrationBuilder.RenameColumn(
                name: "KapitanDruzynyId",
                table: "Druzyny",
                newName: "IdKapitanaDruzyny");

            migrationBuilder.AlterColumn<string>(
                name: "NazwaDruzyny",
                table: "Druzyny",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdKapitanaDruzyny",
                table: "Druzyny",
                newName: "KapitanDruzynyId");

            migrationBuilder.AlterColumn<string>(
                name: "NazwaDruzyny",
                table: "Druzyny",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Druzyny_KapitanDruzynyId",
                table: "Druzyny",
                column: "KapitanDruzynyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Druzyny_Uzytkownicy_KapitanDruzynyId",
                table: "Druzyny",
                column: "KapitanDruzynyId",
                principalTable: "Uzytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
