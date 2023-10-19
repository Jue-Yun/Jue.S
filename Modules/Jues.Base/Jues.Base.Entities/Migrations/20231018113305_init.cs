using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jues.Base.Entities.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bas");

            migrationBuilder.CreateTable(
                name: "file_storage",
                schema: "bas",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    name = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    path = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    mime_type = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    size = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    md5 = table.Column<string>(type: "varchar(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_file_storage", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_info",
                schema: "bas",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    pwd = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    nick = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_info", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "file_storage",
                schema: "bas");

            migrationBuilder.DropTable(
                name: "user_info",
                schema: "bas");
        }
    }
}
