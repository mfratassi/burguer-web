using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesWeb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SnackCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnackCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Snacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ShorDescription = table.Column<string>(maxLength: 100, nullable: true),
                    LongDescription = table.Column<string>(maxLength: 255, nullable: true),
                    MainImage = table.Column<string>(maxLength: 255, nullable: true),
                    MainThumbnail = table.Column<string>(maxLength: 255, nullable: true),
                    IsStarred = table.Column<bool>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    SnackCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Snacks_SnackCategories_SnackCategoryId",
                        column: x => x.SnackCategoryId,
                        principalTable: "SnackCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Snacks_SnackCategoryId",
                table: "Snacks",
                column: "SnackCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Snacks");

            migrationBuilder.DropTable(
                name: "SnackCategories");
        }
    }
}
