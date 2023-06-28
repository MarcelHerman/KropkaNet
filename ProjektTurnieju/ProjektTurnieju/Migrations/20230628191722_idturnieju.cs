using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektTurnieju.Migrations
{
    /// <inheritdoc />
    public partial class idturnieju : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TurniejId",
                table: "Druzyny",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Turniej",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turniej", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Druzyny_TurniejId",
                table: "Druzyny",
                column: "TurniejId");

            migrationBuilder.AddForeignKey(
                name: "FK_Druzyny_Turniej_TurniejId",
                table: "Druzyny",
                column: "TurniejId",
                principalTable: "Turniej",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Druzyny_Turniej_TurniejId",
                table: "Druzyny");

            migrationBuilder.DropTable(
                name: "Turniej");

            migrationBuilder.DropIndex(
                name: "IX_Druzyny_TurniejId",
                table: "Druzyny");

            migrationBuilder.DropColumn(
                name: "TurniejId",
                table: "Druzyny");
        }
    }
}
