using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class harcodeDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Cardiology focuses on the diagnosis and treatment of heart conditions and disorders of the cardiovascular system.");

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Dermatology deals with the study, diagnosis, and treatment of skin, hair, and nail disorders.");

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Pediatrics involves the medical care of infants, children, and adolescents up to the age of 18.");

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Orthopedics specializes in the diagnosis, correction, prevention, and treatment of skeletal deformities, including bones, joints, muscles, and ligaments.");

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 5, "Dentistry is the branch of medicine that involves the study, diagnosis, prevention, and treatment of diseases and conditions of the oral cavity.", "Dentist" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "");
        }
    }
}
