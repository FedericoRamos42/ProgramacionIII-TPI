using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNavigationToAddressCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Usuarios_UserId1",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserId1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Usuarios_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Usuarios_UserId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Addresses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId1",
                table: "Addresses",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Usuarios_UserId1",
                table: "Addresses",
                column: "UserId1",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
