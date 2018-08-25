using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 150, nullable: false),
                    LastName = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 2500, nullable: true),
                    AuthorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("7e024344-2e8f-4221-9dd4-30a1a1583e19"), "George", "RR Martin" },
                    { new Guid("80a69425-841f-4a41-bb76-066edbcc27ca"), "Stephen", "Fry" },
                    { new Guid("4801a767-7686-42d8-bc5d-21be5e77f09a"), "Douglas", "Adams" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("c1db50b3-d8f3-46f9-b206-7670642f59f9"), new Guid("3cd38d75-3902-412c-9505-a5cd94655224"), "The book that seems impossible to write.", "The Winds of Winter" },
                    { new Guid("085f56b1-22a2-4e7e-ad87-95f53fbbb4a5"), new Guid("b4bf6403-d0f1-44a1-aa91-d9495b7b6e2d"), "The Greek myths are amongst the best stories ever told.", "Mythos" },
                    { new Guid("a82f3d1b-b73a-4c9b-baa2-dde17ace455a"), new Guid("0d7550d9-fdeb-4251-9ba7-5d54d28639b6"), "American Tabloid is a 1995 novel by James Ellroy.", "American Tabloid" },
                    { new Guid("ccf51053-355c-4761-a316-6a6524b6a32d"), new Guid("5f677fd5-ed28-4b7c-a4bb-0bf8470c6865"), "In the Hitchhiker's Guide to the Galaxy.", "The Hitchhiker's Guide to the Galaxy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
