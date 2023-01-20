using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class voorstellingtweede : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetrokkenPersoonVoorstelling");

            migrationBuilder.AddColumn<string>(
                name: "Beschrijving",
                table: "Voorstellingen",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BetrokkenPersoonPersoonId",
                table: "Voorstellingen",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZaalID",
                table: "Voorstellingen",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Voorstellingen_BetrokkenPersoonPersoonId",
                table: "Voorstellingen",
                column: "BetrokkenPersoonPersoonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voorstellingen_Crews_BetrokkenPersoonPersoonId",
                table: "Voorstellingen",
                column: "BetrokkenPersoonPersoonId",
                principalTable: "Crews",
                principalColumn: "PersoonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voorstellingen_Crews_BetrokkenPersoonPersoonId",
                table: "Voorstellingen");

            migrationBuilder.DropIndex(
                name: "IX_Voorstellingen_BetrokkenPersoonPersoonId",
                table: "Voorstellingen");

            migrationBuilder.DropColumn(
                name: "Beschrijving",
                table: "Voorstellingen");

            migrationBuilder.DropColumn(
                name: "BetrokkenPersoonPersoonId",
                table: "Voorstellingen");

            migrationBuilder.DropColumn(
                name: "ZaalID",
                table: "Voorstellingen");

            migrationBuilder.CreateTable(
                name: "BetrokkenPersoonVoorstelling",
                columns: table => new
                {
                    CrewPersoonId = table.Column<int>(type: "INTEGER", nullable: false),
                    VoorstellingenVoorstellingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetrokkenPersoonVoorstelling", x => new { x.CrewPersoonId, x.VoorstellingenVoorstellingId });
                    table.ForeignKey(
                        name: "FK_BetrokkenPersoonVoorstelling_Crews_CrewPersoonId",
                        column: x => x.CrewPersoonId,
                        principalTable: "Crews",
                        principalColumn: "PersoonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BetrokkenPersoonVoorstelling_Voorstellingen_VoorstellingenVoorstellingId",
                        column: x => x.VoorstellingenVoorstellingId,
                        principalTable: "Voorstellingen",
                        principalColumn: "VoorstellingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BetrokkenPersoonVoorstelling_VoorstellingenVoorstellingId",
                table: "BetrokkenPersoonVoorstelling",
                column: "VoorstellingenVoorstellingId");
        }
    }
}
