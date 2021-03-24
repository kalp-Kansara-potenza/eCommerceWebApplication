using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceWebApplication.Migrations
{
    public partial class changespecificationsXcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_specificationsXcategory_SpecificationType_DBspecificationtypespecificationtype_Id",
                table: "specificationsXcategory");

            migrationBuilder.DropIndex(
                name: "IX_specificationsXcategory_DBspecificationtypespecificationtype_Id",
                table: "specificationsXcategory");

            migrationBuilder.DropColumn(
                name: "DBspecificationtypespecificationtype_Id",
                table: "specificationsXcategory");

            migrationBuilder.CreateIndex(
                name: "IX_specificationsXcategory_specificationtype_id",
                table: "specificationsXcategory",
                column: "specificationtype_id");

            migrationBuilder.AddForeignKey(
                name: "FK_specificationsXcategory_SpecificationType_specificationtype_id",
                table: "specificationsXcategory",
                column: "specificationtype_id",
                principalTable: "SpecificationType",
                principalColumn: "specificationtype_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_specificationsXcategory_SpecificationType_specificationtype_id",
                table: "specificationsXcategory");

            migrationBuilder.DropIndex(
                name: "IX_specificationsXcategory_specificationtype_id",
                table: "specificationsXcategory");

            migrationBuilder.AddColumn<int>(
                name: "DBspecificationtypespecificationtype_Id",
                table: "specificationsXcategory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_specificationsXcategory_DBspecificationtypespecificationtype_Id",
                table: "specificationsXcategory",
                column: "DBspecificationtypespecificationtype_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_specificationsXcategory_SpecificationType_DBspecificationtypespecificationtype_Id",
                table: "specificationsXcategory",
                column: "DBspecificationtypespecificationtype_Id",
                principalTable: "SpecificationType",
                principalColumn: "specificationtype_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
