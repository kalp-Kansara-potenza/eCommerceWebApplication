using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Migrations
{
    public partial class addforeignkeyoffeaturetypeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "featuretype_Id",
                table: "FeatureType",
                newName: "featuretype_id");

            migrationBuilder.AddColumn<int>(
                name: "featuretype_id",
                table: "SpecificationType",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationType_featuretype_id",
                table: "SpecificationType",
                column: "featuretype_id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecificationType_FeatureType_featuretype_id",
                table: "SpecificationType",
                column: "featuretype_id",
                principalTable: "FeatureType",
                principalColumn: "featuretype_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecificationType_FeatureType_featuretype_id",
                table: "SpecificationType");

            migrationBuilder.DropIndex(
                name: "IX_SpecificationType_featuretype_id",
                table: "SpecificationType");

            migrationBuilder.DropColumn(
                name: "featuretype_id",
                table: "SpecificationType");

            migrationBuilder.RenameColumn(
                name: "featuretype_id",
                table: "FeatureType",
                newName: "featuretype_Id");
        }
    }
}
