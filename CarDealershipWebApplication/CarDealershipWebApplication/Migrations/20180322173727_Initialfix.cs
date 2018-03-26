using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CarDealershipWebApplication.Migrations
{
    public partial class Initialfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarMarkModel");

            migrationBuilder.DropTable(
                name: "SparePartModel");

            migrationBuilder.CreateTable(
                name: "CarMark",
                columns: table => new
                {
                    CarMarkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MarkName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMark", x => x.CarMarkID);
                });

            migrationBuilder.CreateTable(
                name: "SparePart",
                columns: table => new
                {
                    SparePartID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarMarkID = table.Column<int>(nullable: true),
                    SparePartCode = table.Column<int>(nullable: false),
                    SparePartName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SparePart", x => x.SparePartID);
                    table.ForeignKey(
                        name: "FK_SparePart_CarMark_CarMarkID",
                        column: x => x.CarMarkID,
                        principalTable: "CarMark",
                        principalColumn: "CarMarkID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SparePart_CarMarkID",
                table: "SparePart",
                column: "CarMarkID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SparePart");

            migrationBuilder.DropTable(
                name: "CarMark");

            migrationBuilder.CreateTable(
                name: "SparePartModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SparePartCode = table.Column<int>(nullable: false),
                    SparePartName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SparePartModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarMarkModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MarkName = table.Column<string>(nullable: true),
                    sparePartIDID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMarkModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarMarkModel_SparePartModel_sparePartIDID",
                        column: x => x.sparePartIDID,
                        principalTable: "SparePartModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarMarkModel_sparePartIDID",
                table: "CarMarkModel",
                column: "sparePartIDID");
        }
    }
}
