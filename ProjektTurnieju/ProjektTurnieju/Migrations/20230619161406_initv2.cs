using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektTurnieju.Migrations
{
    /// <inheritdoc />
    public partial class initv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Druzyny_Zawodnik_KapitanDruzynyId",
                table: "Druzyny");

            migrationBuilder.DropTable(
                name: "Zawodnik");

            migrationBuilder.AddColumn<int>(
                name: "DruzynaId",
                table: "Uzytkownicy",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_DruzynaId",
                table: "Uzytkownicy",
                column: "DruzynaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Druzyny_Uzytkownicy_KapitanDruzynyId",
                table: "Druzyny",
                column: "KapitanDruzynyId",
                principalTable: "Uzytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Druzyny_DruzynaId",
                table: "Uzytkownicy",
                column: "DruzynaId",
                principalTable: "Druzyny",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Druzyny_Uzytkownicy_KapitanDruzynyId",
                table: "Druzyny");

            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Druzyny_DruzynaId",
                table: "Uzytkownicy");

            migrationBuilder.DropIndex(
                name: "IX_Uzytkownicy_DruzynaId",
                table: "Uzytkownicy");

            migrationBuilder.DropColumn(
                name: "DruzynaId",
                table: "Uzytkownicy");

            migrationBuilder.CreateTable(
                name: "Zawodnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DruzynaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zawodnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zawodnik_Druzyny_DruzynaId",
                        column: x => x.DruzynaId,
                        principalTable: "Druzyny",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zawodnik_DruzynaId",
                table: "Zawodnik",
                column: "DruzynaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Druzyny_Zawodnik_KapitanDruzynyId",
                table: "Druzyny",
                column: "KapitanDruzynyId",
                principalTable: "Zawodnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
