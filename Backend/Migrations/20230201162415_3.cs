using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "donatieCounter",
                table: "AspNetUsers",
                newName: "DonatieCounter");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "AspNetRoles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetRoles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_AccountId",
                table: "AspNetRoles",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_RoleId",
                table: "AspNetRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetRoles_RoleId",
                table: "AspNetRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_AccountId",
                table: "AspNetRoles",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetRoles_RoleId",
                table: "AspNetRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_AccountId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_AccountId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_RoleId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetRoles");

            migrationBuilder.RenameColumn(
                name: "DonatieCounter",
                table: "AspNetUsers",
                newName: "donatieCounter");
        }
    }
}
