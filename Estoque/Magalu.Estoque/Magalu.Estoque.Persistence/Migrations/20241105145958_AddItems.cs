using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Magalu.Estoque.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("3d7aa781-8a49-4409-a15a-4b9e352c06ef"), "Item 3" },
                    { new Guid("7dd5e92b-40d4-4e8b-a678-137a7ca7e4ed"), "Item 2" },
                    { new Guid("96661d5f-63f3-458e-a1e5-c69afb03970c"), "Item 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("3d7aa781-8a49-4409-a15a-4b9e352c06ef"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7dd5e92b-40d4-4e8b-a678-137a7ca7e4ed"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("96661d5f-63f3-458e-a1e5-c69afb03970c"));
        }
    }
}
