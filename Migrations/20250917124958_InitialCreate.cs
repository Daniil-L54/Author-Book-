using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthorBookApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sachs",
                columns: table => new
                {
                    SachId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TieuDe = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sachs", x => x.SachId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TacGias",
                columns: table => new
                {
                    TacGiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ten = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacGias", x => x.TacGiaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TacGiaSachs",
                columns: table => new
                {
                    TacGiaId = table.Column<int>(type: "int", nullable: false),
                    SachId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacGiaSachs", x => new { x.TacGiaId, x.SachId });
                    table.ForeignKey(
                        name: "FK_TacGiaSachs_Sachs_SachId",
                        column: x => x.SachId,
                        principalTable: "Sachs",
                        principalColumn: "SachId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TacGiaSachs_TacGias_TacGiaId",
                        column: x => x.TacGiaId,
                        principalTable: "TacGias",
                        principalColumn: "TacGiaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TacGiaSachs_SachId",
                table: "TacGiaSachs",
                column: "SachId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TacGiaSachs");

            migrationBuilder.DropTable(
                name: "Sachs");

            migrationBuilder.DropTable(
                name: "TacGias");
        }
    }
}
