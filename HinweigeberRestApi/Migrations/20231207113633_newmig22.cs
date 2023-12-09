using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HinweigeberRestApi.Migrations
{
    public partial class newmig22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFinished",
                table: "Meldungs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Weitereinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Beschreibung = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MeldungId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weitereinfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weitereinfo_Meldungs_MeldungId",
                        column: x => x.MeldungId,
                        principalTable: "Meldungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weitereinfo_MeldungId",
                table: "Weitereinfo",
                column: "MeldungId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weitereinfo");

            migrationBuilder.DropColumn(
                name: "isFinished",
                table: "Meldungs");
        }
    }
}
