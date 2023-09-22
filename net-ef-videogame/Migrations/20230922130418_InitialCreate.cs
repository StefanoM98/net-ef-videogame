using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Software_houses",
                columns: table => new
                {
                    SoftwarehouseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software_houses", x => x.SoftwarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "Videogiochi",
                columns: table => new
                {
                    VideogameId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Release_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Software_houseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videogiochi", x => x.VideogameId);
                    table.ForeignKey(
                        name: "FK_Videogiochi_Software_houses_Software_houseId",
                        column: x => x.Software_houseId,
                        principalTable: "Software_houses",
                        principalColumn: "SoftwarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videogiochi_Software_houseId",
                table: "Videogiochi",
                column: "Software_houseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videogiochi");

            migrationBuilder.DropTable(
                name: "Software_houses");
        }
    }
}
