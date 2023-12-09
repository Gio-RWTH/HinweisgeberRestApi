using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HinweigeberRestApi.Migrations
{
    public partial class newmig33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weitereinfo_Meldungs_MeldungId",
                table: "Weitereinfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weitereinfo",
                table: "Weitereinfo");

            migrationBuilder.DropIndex(
                name: "IX_Weitereinfo_MeldungId",
                table: "Weitereinfo");

            migrationBuilder.RenameTable(
                name: "Weitereinfo",
                newName: "WeitereInfo");

            migrationBuilder.RenameColumn(
                name: "MeldungId",
                table: "WeitereInfo",
                newName: "MassnahmeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeitereInfo",
                table: "WeitereInfo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WeitereInfo_MassnahmeId",
                table: "WeitereInfo",
                column: "MassnahmeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeitereInfo_Massnahmes_MassnahmeId",
                table: "WeitereInfo",
                column: "MassnahmeId",
                principalTable: "Massnahmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeitereInfo_Massnahmes_MassnahmeId",
                table: "WeitereInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeitereInfo",
                table: "WeitereInfo");

            migrationBuilder.DropIndex(
                name: "IX_WeitereInfo_MassnahmeId",
                table: "WeitereInfo");

            migrationBuilder.RenameTable(
                name: "WeitereInfo",
                newName: "Weitereinfo");

            migrationBuilder.RenameColumn(
                name: "MassnahmeId",
                table: "Weitereinfo",
                newName: "MeldungId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weitereinfo",
                table: "Weitereinfo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Weitereinfo_MeldungId",
                table: "Weitereinfo",
                column: "MeldungId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weitereinfo_Meldungs_MeldungId",
                table: "Weitereinfo",
                column: "MeldungId",
                principalTable: "Meldungs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
