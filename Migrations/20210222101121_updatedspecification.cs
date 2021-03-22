using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Migrations
{
    public partial class updatedspecification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specification_FeatureType_DBfeaturetypefeaturetype_id",
                table: "Specification");

            migrationBuilder.DropIndex(
                name: "IX_Specification_DBfeaturetypefeaturetype_id",
                table: "Specification");

            migrationBuilder.DropColumn(
                name: "DBfeaturetypefeaturetype_id",
                table: "Specification");

            migrationBuilder.CreateIndex(
                name: "IX_Specification_featuretype_id",
                table: "Specification",
                column: "featuretype_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Specification_FeatureType_featuretype_id",
                table: "Specification",
                column: "featuretype_id",
                principalTable: "FeatureType",
                principalColumn: "featuretype_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specification_FeatureType_featuretype_id",
                table: "Specification");

            migrationBuilder.DropIndex(
                name: "IX_Specification_featuretype_id",
                table: "Specification");

            migrationBuilder.AddColumn<int>(
                name: "DBfeaturetypefeaturetype_id",
                table: "Specification",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specification_DBfeaturetypefeaturetype_id",
                table: "Specification",
                column: "DBfeaturetypefeaturetype_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Specification_FeatureType_DBfeaturetypefeaturetype_id",
                table: "Specification",
                column: "DBfeaturetypefeaturetype_id",
                principalTable: "FeatureType",
                principalColumn: "featuretype_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
