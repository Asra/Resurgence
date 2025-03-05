using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Library.Migrations
{
    /// <inheritdoc />
    public partial class MapInfoFull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MapInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    MiniMap = table.Column<ushort>(type: "INTEGER", nullable: false),
                    BigMap = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Music = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Light = table.Column<byte>(type: "INTEGER", nullable: false),
                    MapDarkLight = table.Column<byte>(type: "INTEGER", nullable: false),
                    MineIndex = table.Column<byte>(type: "INTEGER", nullable: false),
                    GTIndex = table.Column<byte>(type: "INTEGER", nullable: false),
                    NoTeleport = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoReconnect = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoRandom = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoEscape = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoRecall = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoDrug = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoPosition = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoFight = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoThrowItem = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoDropPlayer = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoDropMonster = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoNames = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoMount = table.Column<bool>(type: "INTEGER", nullable: false),
                    NeedBridle = table.Column<bool>(type: "INTEGER", nullable: false),
                    Fight = table.Column<bool>(type: "INTEGER", nullable: false),
                    NeedHole = table.Column<bool>(type: "INTEGER", nullable: false),
                    Fire = table.Column<bool>(type: "INTEGER", nullable: false),
                    Lightning = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoTownTeleport = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoReincarnation = table.Column<bool>(type: "INTEGER", nullable: false),
                    GT = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoReconnectMap = table.Column<string>(type: "TEXT", nullable: true),
                    FireDamage = table.Column<int>(type: "INTEGER", nullable: false),
                    LightningDamage = table.Column<int>(type: "INTEGER", nullable: false),
                    ActiveCoordsJson = table.Column<string>(type: "TEXT", nullable: true),
                    WeatherParticles = table.Column<ushort>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MineZone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Mine = table.Column<byte>(type: "INTEGER", nullable: false),
                    LocationX = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationY = table.Column<int>(type: "INTEGER", nullable: false),
                    Size = table.Column<ushort>(type: "INTEGER", nullable: false),
                    MapInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MineZone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MineZone_MapInfo_MapInfoId",
                        column: x => x.MapInfoId,
                        principalTable: "MapInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovementInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MapIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    SourceX = table.Column<int>(type: "INTEGER", nullable: false),
                    SourceY = table.Column<int>(type: "INTEGER", nullable: false),
                    DestinationX = table.Column<int>(type: "INTEGER", nullable: false),
                    DestinationY = table.Column<int>(type: "INTEGER", nullable: false),
                    NeedHole = table.Column<bool>(type: "INTEGER", nullable: false),
                    NeedMove = table.Column<bool>(type: "INTEGER", nullable: false),
                    ShowOnBigMap = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConquestIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    Icon = table.Column<int>(type: "INTEGER", nullable: false),
                    MapInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementInfos_MapInfo_MapInfoId",
                        column: x => x.MapInfoId,
                        principalTable: "MapInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NPCInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    MapIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationX = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationY = table.Column<int>(type: "INTEGER", nullable: false),
                    Rate = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Image = table.Column<ushort>(type: "INTEGER", nullable: false),
                    ColourHex = table.Column<string>(type: "TEXT", nullable: true),
                    TimeVisible = table.Column<bool>(type: "INTEGER", nullable: false),
                    HourStart = table.Column<byte>(type: "INTEGER", nullable: false),
                    MinuteStart = table.Column<byte>(type: "INTEGER", nullable: false),
                    HourEnd = table.Column<byte>(type: "INTEGER", nullable: false),
                    MinuteEnd = table.Column<byte>(type: "INTEGER", nullable: false),
                    MinLev = table.Column<short>(type: "INTEGER", nullable: false),
                    MaxLev = table.Column<short>(type: "INTEGER", nullable: false),
                    DayofWeek = table.Column<string>(type: "TEXT", nullable: true),
                    ClassRequired = table.Column<string>(type: "TEXT", nullable: true),
                    Sabuk = table.Column<bool>(type: "INTEGER", nullable: false),
                    FlagNeeded = table.Column<int>(type: "INTEGER", nullable: false),
                    Conquest = table.Column<int>(type: "INTEGER", nullable: false),
                    ShowOnBigMap = table.Column<bool>(type: "INTEGER", nullable: false),
                    BigMapIcon = table.Column<int>(type: "INTEGER", nullable: false),
                    CanTeleportTo = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConquestVisible = table.Column<bool>(type: "INTEGER", nullable: false),
                    CollectQuestIndexesJson = table.Column<string>(type: "TEXT", nullable: true),
                    FinishQuestIndexesJson = table.Column<string>(type: "TEXT", nullable: true),
                    MapInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPCInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NPCInfos_MapInfo_MapInfoId",
                        column: x => x.MapInfoId,
                        principalTable: "MapInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RespawnInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RespawnIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    MonsterIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationX = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationY = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Spread = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Delay = table.Column<ushort>(type: "INTEGER", nullable: false),
                    RandomDelay = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Direction = table.Column<byte>(type: "INTEGER", nullable: false),
                    RoutePath = table.Column<string>(type: "TEXT", nullable: true),
                    SaveRespawnTime = table.Column<bool>(type: "INTEGER", nullable: false),
                    RespawnTicks = table.Column<ushort>(type: "INTEGER", nullable: false),
                    MapInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespawnInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespawnInfo_MapInfo_MapInfoId",
                        column: x => x.MapInfoId,
                        principalTable: "MapInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SafeZoneInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationX = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationY = table.Column<int>(type: "INTEGER", nullable: false),
                    Size = table.Column<ushort>(type: "INTEGER", nullable: false),
                    StartPoint = table.Column<bool>(type: "INTEGER", nullable: false),
                    MapInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafeZoneInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafeZoneInfos_MapInfo_MapInfoId",
                        column: x => x.MapInfoId,
                        principalTable: "MapInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MineZone_MapInfoId",
                table: "MineZone",
                column: "MapInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementInfos_MapInfoId",
                table: "MovementInfos",
                column: "MapInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_NPCInfos_MapInfoId",
                table: "NPCInfos",
                column: "MapInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_RespawnInfo_MapInfoId",
                table: "RespawnInfo",
                column: "MapInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_SafeZoneInfos_MapInfoId",
                table: "SafeZoneInfos",
                column: "MapInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MineZone");

            migrationBuilder.DropTable(
                name: "MovementInfos");

            migrationBuilder.DropTable(
                name: "NPCInfos");

            migrationBuilder.DropTable(
                name: "RespawnInfo");

            migrationBuilder.DropTable(
                name: "SafeZoneInfos");

            migrationBuilder.DropTable(
                name: "MapInfo");
        }
    }
}
