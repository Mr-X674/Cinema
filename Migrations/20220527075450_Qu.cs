using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Migrations
{
    public partial class Qu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "halls",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hall = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_halls", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genreid = table.Column<int>(type: "int", nullable: false),
                    hallid = table.Column<int>(type: "int", nullable: false),
                    sessionid = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Years = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.id);
                    table.ForeignKey(
                        name: "FK_Films_Genres_Genreid",
                        column: x => x.Genreid,
                        principalTable: "Genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Films_halls_hallid",
                        column: x => x.hallid,
                        principalTable: "halls",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sessions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filmid = table.Column<int>(type: "int", nullable: false),
                    hallid = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessions", x => x.id);
                    table.ForeignKey(
                        name: "FK_sessions_Films_filmid",
                        column: x => x.filmid,
                        principalTable: "Films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sessions_halls_hallid",
                        column: x => x.hallid,
                        principalTable: "halls",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filmid = table.Column<int>(type: "int", nullable: false),
                    hallid = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    number_rows = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    number_place = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tickets_Films_filmid",
                        column: x => x.filmid,
                        principalTable: "Films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_halls_hallid",
                        column: x => x.hallid,
                        principalTable: "halls",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_Genreid",
                table: "Films",
                column: "Genreid");

            migrationBuilder.CreateIndex(
                name: "IX_Films_hallid",
                table: "Films",
                column: "hallid");

            migrationBuilder.CreateIndex(
                name: "IX_Films_sessionid",
                table: "Films",
                column: "sessionid");

            migrationBuilder.CreateIndex(
                name: "IX_sessions_filmid",
                table: "sessions",
                column: "filmid");

            migrationBuilder.CreateIndex(
                name: "IX_sessions_hallid",
                table: "sessions",
                column: "hallid");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_filmid",
                table: "Tickets",
                column: "filmid");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_hallid",
                table: "Tickets",
                column: "hallid");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_sessions_sessionid",
                table: "Films",
                column: "sessionid",
                principalTable: "sessions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Genres_Genreid",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_halls_hallid",
                table: "Films");

            migrationBuilder.DropForeignKey(
                name: "FK_sessions_halls_hallid",
                table: "sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Films_sessions_sessionid",
                table: "Films");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "halls");

            migrationBuilder.DropTable(
                name: "sessions");

            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
