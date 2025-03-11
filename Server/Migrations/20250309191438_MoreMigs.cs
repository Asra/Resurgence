using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Library.Migrations
{
    /// <inheritdoc />
    public partial class MoreMigs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HeroInfos",
                newName: "Index");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "SealedInfos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NextSealDate",
                table: "SealedInfos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<short>(
                name: "BindingFlags",
                table: "RentalInformations",
                type: "INTEGER",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "RentalInformations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "RentalInformations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RentalLocked",
                table: "RentalInformations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "GuildRank",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GuildRank",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Options",
                table: "GuildRank",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "ExpireInfos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "GuildMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    LastLogin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HasVoted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Online = table.Column<bool>(type: "INTEGER", nullable: false),
                    GuildRankId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuildMember_GuildRank_GuildRankId",
                        column: x => x.GuildRankId,
                        principalTable: "GuildRank",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuildMember_GuildRankId",
                table: "GuildMember",
                column: "GuildRankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuildMember");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "SealedInfos");

            migrationBuilder.DropColumn(
                name: "NextSealDate",
                table: "SealedInfos");

            migrationBuilder.DropColumn(
                name: "BindingFlags",
                table: "RentalInformations");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "RentalInformations");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "RentalInformations");

            migrationBuilder.DropColumn(
                name: "RentalLocked",
                table: "RentalInformations");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "GuildRank");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "GuildRank");

            migrationBuilder.DropColumn(
                name: "Options",
                table: "GuildRank");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "ExpireInfos");

            migrationBuilder.RenameColumn(
                name: "Index",
                table: "HeroInfos",
                newName: "Id");
        }
    }
}
