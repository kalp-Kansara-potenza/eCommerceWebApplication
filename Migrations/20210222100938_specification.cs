using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceWebApplication.Migrations
{
    public partial class specification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specification",
                columns: table => new
                {
                    specification_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    specificationtype_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    featuretype_id = table.Column<int>(nullable: false),
                    DBfeaturetypefeaturetype_id = table.Column<int>(nullable: true),
                    specification_description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specification", x => x.specification_id);
                    table.ForeignKey(
                        name: "FK_Specification_FeatureType_DBfeaturetypefeaturetype_id",
                        column: x => x.DBfeaturetypefeaturetype_id,
                        principalTable: "FeatureType",
                        principalColumn: "featuretype_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specification_Product_product_id",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Specification_SpecificationType_specificationtype_id",
                        column: x => x.specificationtype_id,
                        principalTable: "SpecificationType",
                        principalColumn: "specificationtype_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specification_DBfeaturetypefeaturetype_id",
                table: "Specification",
                column: "DBfeaturetypefeaturetype_id");

            migrationBuilder.CreateIndex(
                name: "IX_Specification_product_id",
                table: "Specification",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Specification_specificationtype_id",
                table: "Specification",
                column: "specificationtype_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specification");
        }
    }
}
