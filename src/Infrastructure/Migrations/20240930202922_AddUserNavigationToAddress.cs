using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNavigationToAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Adress_AdressId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adress",
                table: "Adress");

            migrationBuilder.RenameTable(
                name: "Adress",
                newName: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Addresses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Addresses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Addresses_AdressId",
                table: "Usuarios",
                column: "AdressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Usuarios_UserId1",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Addresses_AdressId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserId1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Adress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adress",
                table: "Adress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Adress_AdressId",
                table: "Usuarios",
                column: "AdressId",
                principalTable: "Adress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
