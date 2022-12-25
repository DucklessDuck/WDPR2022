using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Gebruikersnaam = table.Column<string>(type: "TEXT", nullable: false),
                    Wachtwoord = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    PersoonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Zaalnaam = table.Column<string>(type: "TEXT", nullable: false),
                    Functie = table.Column<string>(type: "TEXT", nullable: false),
                    Geboortedatum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Foto = table.Column<string>(type: "TEXT", nullable: false),
                    CrewLidPersoonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.PersoonId);
                    table.ForeignKey(
                        name: "FK_Crews_Crews_CrewLidPersoonId",
                        column: x => x.CrewLidPersoonId,
                        principalTable: "Crews",
                        principalColumn: "PersoonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voorstellingen",
                columns: table => new
                {
                    VoorstellingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NaamVoorstelling = table.Column<string>(type: "TEXT", nullable: false),
                    VoorstellingsDatum = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voorstellingen", x => x.VoorstellingId);
                });

            migrationBuilder.CreateTable(
                name: "Zalen",
                columns: table => new
                {
                    Zaalnaam = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zalen", x => x.Zaalnaam);
                });

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

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    KaartId = table.Column<string>(type: "TEXT", nullable: false),
                    BezoekerAccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    Geboortedatum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Prijs = table.Column<double>(type: "REAL", nullable: false),
                    VoorstellingId = table.Column<int>(type: "INTEGER", nullable: false),
                    StoelNummer = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.KaartId);
                    table.ForeignKey(
                        name: "FK_Tickets_Accounts_BezoekerAccountId",
                        column: x => x.BezoekerAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Voorstellingen_VoorstellingId",
                        column: x => x.VoorstellingId,
                        principalTable: "Voorstellingen",
                        principalColumn: "VoorstellingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stoelen",
                columns: table => new
                {
                    StoelID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StoelRanking = table.Column<int>(type: "INTEGER", nullable: false),
                    Zaalnaam = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoelen", x => x.StoelID);
                    table.ForeignKey(
                        name: "FK_Stoelen_Zalen_Zaalnaam",
                        column: x => x.Zaalnaam,
                        principalTable: "Zalen",
                        principalColumn: "Zaalnaam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BetrokkenPersoonVoorstelling_VoorstellingenVoorstellingId",
                table: "BetrokkenPersoonVoorstelling",
                column: "VoorstellingenVoorstellingId");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_CrewLidPersoonId",
                table: "Crews",
                column: "CrewLidPersoonId");

            migrationBuilder.CreateIndex(
                name: "IX_Stoelen_Zaalnaam",
                table: "Stoelen",
                column: "Zaalnaam");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BezoekerAccountId",
                table: "Tickets",
                column: "BezoekerAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_VoorstellingId",
                table: "Tickets",
                column: "VoorstellingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetrokkenPersoonVoorstelling");

            migrationBuilder.DropTable(
                name: "Stoelen");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.DropTable(
                name: "Zalen");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Voorstellingen");
        }
    }
}
