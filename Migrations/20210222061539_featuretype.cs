using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceWebApplication.Migrations
{
    public partial class featuretype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "featuretype_id",
            //    table: "FeatureType",
            //    newName: "featuretype_Id");
            migrationBuilder.CreateTable(
                name: "FeatureType",
                columns: table => new
                {
                    featuretype_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    featuretype_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureType", x => x.featuretype_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "featuretype_Id",
            //    table: "FeatureType",
            //    newName: "featuretype_id");
            migrationBuilder.DropTable(
                name: "FeatureType");
        }
    }
}
