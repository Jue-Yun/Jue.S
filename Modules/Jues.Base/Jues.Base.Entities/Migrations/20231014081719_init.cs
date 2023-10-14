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
                name: "user_info",
                schema: "bas",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    pwd = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true),
                    nick = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_info", x => x.id);
                    //table.UniqueConstraint("PK_user_info_name", d => d.name);
                });

            migrationBuilder.CreateIndex("IX_user_info_name", "bas.user_info", "name", unique: true);
            migrationBuilder.CreateIndex("IX_user_info_nick", "bas.user_info", "nick");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_info",
                schema: "bas");
        }
    }
}
