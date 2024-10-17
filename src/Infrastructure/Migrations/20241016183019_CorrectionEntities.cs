using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Addresses_AddressId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_AddressId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Doctor_IsAvailable",
                table: "Usuarios",
                newName: "SpecialityId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Addresses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SpecialityId",
                table: "Usuarios",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PatientId",
                table: "Addresses",
                column: "PatientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Usuarios_PatientId",
                table: "Addresses",
                column: "PatientId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Specialities_SpecialityId",
                table: "Usuarios",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Usuarios_PatientId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Specialities_SpecialityId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_SpecialityId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_PatientId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "SpecialityId",
                table: "Usuarios",
                newName: "Doctor_IsAvailable");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Usuarios",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "Usuarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_AddressId",
                table: "Usuarios",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Addresses_AddressId",
                table: "Usuarios",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
