using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceWebApplication.Migrations
{
    public partial class specificationtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecificationType",
                columns: table => new
                {
                    specificationtype_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    specificationtype_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationType", x => x.specificationtype_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecificationType");
        }
    }
}
