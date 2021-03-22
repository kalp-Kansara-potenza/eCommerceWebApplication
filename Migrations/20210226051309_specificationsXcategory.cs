using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Migrations
{
    public partial class specificationsXcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "specificationsXcategory",
                columns: table => new
                {
                    specificationsXcategory_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(nullable: false),
                    featuretype_id = table.Column<int>(nullable: false),
                    specificationtype_id = table.Column<int>(nullable: false),
                    DBspecificationtypespecificationtype_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specificationsXcategory", x => x.specificationsXcategory_id);
                    table.ForeignKey(
                        name: "FK_specificationsXcategory_SpecificationType_DBspecificationtypespecificationtype_Id",
                        column: x => x.DBspecificationtypespecificationtype_Id,
                        principalTable: "SpecificationType",
                        principalColumn: "specificationtype_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_specificationsXcategory_Category_category_id",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_specificationsXcategory_FeatureType_featuretype_id",
                        column: x => x.featuretype_id,
                        principalTable: "FeatureType",
                        principalColumn: "featuretype_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_specificationsXcategory_DBspecificationtypespecificationtype_Id",
                table: "specificationsXcategory",
                column: "DBspecificationtypespecificationtype_Id");

            migrationBuilder.CreateIndex(
                name: "IX_specificationsXcategory_category_id",
                table: "specificationsXcategory",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_specificationsXcategory_featuretype_id",
                table: "specificationsXcategory",
                column: "featuretype_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "specificationsXcategory");
        }
    }
}
