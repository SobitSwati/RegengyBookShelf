using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegengyBookShelf_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddNewDataToDbTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeriesId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "SeriesId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ImageUrl", "SeriesId", "Title" },
                values: new object[] { 2, "Sarah MacLean", "Since being named on of London’s “Lords to Land” by a popular ladies’ magazine, Nicholas St. John has been relentlessly pursued by every matrimony-minded female in the ton.", "9780061852060", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1322231419i/7781699.jpg", 1, "Ten Ways to Be Adored When Landing a Lord" });

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 21, 13, 1, 7, 909, DateTimeKind.Local).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 21, 13, 1, 7, 909, DateTimeKind.Local).AddTicks(8110));

            migrationBuilder.CreateIndex(
                name: "IX_Books_SeriesId",
                table: "Books",
                column: "SeriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Series_SeriesId",
                table: "Books",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Series_SeriesId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_SeriesId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "SeriesId",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 2, 18, 18, 24, 730, DateTimeKind.Local).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 2, 18, 18, 24, 730, DateTimeKind.Local).AddTicks(2296));
        }
    }
}
