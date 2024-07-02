using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegengyBookShelf_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddBooksToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ImageUrl", "Title" },
                values: new object[] { 1, "Sarah MacLean", "A decade ago, the Marquess of Bourne was cast from society with nothing but his title. Now a partner in London’s most exclusive gaming hell, the cold, ruthless Bourne will do whatever it takes to regain his inheritance—including marrying perfect, proper Lady Penelope Marbury.\r\n\r\nA broken engagement and years of disappointing courtships have left Penelope with little interest in a quiet, comfortable marriage, and a longing for something more. How lucky that her new husband has access to such unexplored pleasures.\r\n\r\nBourne may be a prince of London’s underworld, but he vows to keep Penelope untouched by its wickedness—a challenge indeed as the lady discovers her own desires, and her willingness to wager anything for them... even her heart.", "9780062068521", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327928208i/10428803.jpg", "A Rogue by Any Other Name" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 19, 12, 56, 19, 860, DateTimeKind.Local).AddTicks(9644));

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 19, 12, 56, 19, 860, DateTimeKind.Local).AddTicks(9645));
        }
    }
}
