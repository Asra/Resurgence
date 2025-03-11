using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Library.Migrations
{
    /// <inheritdoc />
    public partial class DragonInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DragonInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    MapFileName = table.Column<string>(type: "TEXT", nullable: true),
                    MonsterName = table.Column<string>(type: "TEXT", nullable: true),
                    BodyName = table.Column<string>(type: "TEXT", nullable: true),
                    LocationX = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationY = table.Column<int>(type: "INTEGER", nullable: false),
                    DropAreaTopX = table.Column<int>(type: "INTEGER", nullable: false),
                    DropAreaTopY = table.Column<int>(type: "INTEGER", nullable: false),
                    DropAreaBottomX = table.Column<int>(type: "INTEGER", nullable: false),
                    DropAreaBottomY = table.Column<int>(type: "INTEGER", nullable: false),
                    Exps = table.Column<string>(type: "TEXT", nullable: true),
                    Level = table.Column<byte>(type: "INTEGER", nullable: false),
                    Experience = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DragonInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GTMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Key = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Owner = table.Column<string>(type: "TEXT", nullable: true),
                    Leader = table.Column<string>(type: "TEXT", nullable: true),
                    Leader2 = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Days = table.Column<int>(type: "INTEGER", nullable: false),
                    Begin = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GTMaps", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DragonInfo");

            migrationBuilder.DropTable(
                name: "GTMaps");
        }
    }
}
