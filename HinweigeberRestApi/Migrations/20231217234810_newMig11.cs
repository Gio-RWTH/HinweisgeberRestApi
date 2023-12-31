﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HinweigeberRestApi.Migrations
{
    public partial class newMig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Massnahmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschreibung = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Massnahmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meldungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beschreibung = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isFinished = table.Column<bool>(type: "bit", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meldungs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeitereInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Beschreibung = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MassnahmeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeitereInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeitereInfo_Massnahmes_MassnahmeId",
                        column: x => x.MassnahmeId,
                        principalTable: "Massnahmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MassnahmeMeldung",
                columns: table => new
                {
                    MassnahmenId = table.Column<int>(type: "int", nullable: false),
                    MeldungenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MassnahmeMeldung", x => new { x.MassnahmenId, x.MeldungenId });
                    table.ForeignKey(
                        name: "FK_MassnahmeMeldung_Massnahmes_MassnahmenId",
                        column: x => x.MassnahmenId,
                        principalTable: "Massnahmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MassnahmeMeldung_Meldungs_MeldungenId",
                        column: x => x.MeldungenId,
                        principalTable: "Meldungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MassnahmeMeldung_MeldungenId",
                table: "MassnahmeMeldung",
                column: "MeldungenId");

            migrationBuilder.CreateIndex(
                name: "IX_WeitereInfo_MassnahmeId",
                table: "WeitereInfo",
                column: "MassnahmeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MassnahmeMeldung");

            migrationBuilder.DropTable(
                name: "WeitereInfo");

            migrationBuilder.DropTable(
                name: "Meldungs");

            migrationBuilder.DropTable(
                name: "Massnahmes");
        }
    }
}
