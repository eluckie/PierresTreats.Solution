using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Treats.Migrations
{
    public partial class AddTreatFlavorProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlavorId",
                table: "TreatFlavors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TreatId",
                table: "TreatFlavors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TreatFlavors_FlavorId",
                table: "TreatFlavors",
                column: "FlavorId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatFlavors_TreatId",
                table: "TreatFlavors",
                column: "TreatId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatFlavors_Flavors_FlavorId",
                table: "TreatFlavors",
                column: "FlavorId",
                principalTable: "Flavors",
                principalColumn: "FlavorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreatFlavors_Treats_TreatId",
                table: "TreatFlavors",
                column: "TreatId",
                principalTable: "Treats",
                principalColumn: "TreatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatFlavors_Flavors_FlavorId",
                table: "TreatFlavors");

            migrationBuilder.DropForeignKey(
                name: "FK_TreatFlavors_Treats_TreatId",
                table: "TreatFlavors");

            migrationBuilder.DropIndex(
                name: "IX_TreatFlavors_FlavorId",
                table: "TreatFlavors");

            migrationBuilder.DropIndex(
                name: "IX_TreatFlavors_TreatId",
                table: "TreatFlavors");

            migrationBuilder.DropColumn(
                name: "FlavorId",
                table: "TreatFlavors");

            migrationBuilder.DropColumn(
                name: "TreatId",
                table: "TreatFlavors");
        }
    }
}
