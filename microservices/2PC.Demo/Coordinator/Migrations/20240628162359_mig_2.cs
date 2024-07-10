using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Coordinator.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("37c606d1-1bfa-46ed-9346-86292bac844f"), "Stock.API" },
                    { new Guid("5d825bfd-02e8-4b86-9c37-cad3a3c71033"), "Order.API" },
                    { new Guid("88ee1f9c-5e6b-480b-a73a-eeb299527de0"), "Payment.API" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: new Guid("37c606d1-1bfa-46ed-9346-86292bac844f"));

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: new Guid("5d825bfd-02e8-4b86-9c37-cad3a3c71033"));

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Id",
                keyValue: new Guid("88ee1f9c-5e6b-480b-a73a-eeb299527de0"));
        }
    }
}
