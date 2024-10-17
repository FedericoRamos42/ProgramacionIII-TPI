using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HarcodeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cardiology" },
                    { 2, "Dermatology" },
                    { 3, "Pediatrics" },
                    { 4, "Orthopedics" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DateOfBirth", "Email", "IsAvailable", "LastName", "MedicalInsurance", "Name", "Password", "PhoneNumber", "UserRole" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", true, "Doe", "HealthInsure", "John", "password123", "1234567890", "Patient" },
                    { 2, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", true, "Smith", "HealthInsure", "Jane", "password123", "0987654321", "Patient" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "PatientId", "PostalCode", "Province", "Street" },
                values: new object[,]
                {
                    { 1, "Springfield", 1, "62701", "IL", "123 Main St" },
                    { 2, "Springfield", 2, "62702", "IL", "456 Elm St" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DateOfBirth", "Email", "IsAvailable", "LastName", "LicenseNumber", "Name", "Password", "PhoneNumber", "SpecialityId", "UserRole" },
                values: new object[,]
                {
                    { 3, new DateTime(1975, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "dr.sarah@example.com", true, "Johnson", 123456, "Dr. Sarah", "password123", "1231231234", 1, "Doctor" },
                    { 4, new DateTime(1985, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "dr.alex@example.com", true, "Williams", 654321, "Dr. Alex", "password123", "3213214321", 2, "Doctor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
