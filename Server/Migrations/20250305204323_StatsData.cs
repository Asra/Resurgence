using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Library.Migrations
{
    /// <inheritdoc />
    public partial class StatsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuildInfos",
                columns: table => new
                {
                    GuildIndex = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Level = table.Column<byte>(type: "INTEGER", nullable: false),
                    SparePoints = table.Column<byte>(type: "INTEGER", nullable: false),
                    Experience = table.Column<long>(type: "INTEGER", nullable: false),
                    Gold = table.Column<uint>(type: "INTEGER", nullable: false),
                    Votes = table.Column<int>(type: "INTEGER", nullable: false),
                    LastVoteAttempt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Voting = table.Column<bool>(type: "INTEGER", nullable: false),
                    Membercount = table.Column<int>(type: "INTEGER", nullable: false),
                    Notice = table.Column<string>(type: "TEXT", nullable: true),
                    MemberCap = table.Column<int>(type: "INTEGER", nullable: false),
                    FlagImage = table.Column<ushort>(type: "INTEGER", nullable: false),
                    FlagColourArgb = table.Column<int>(type: "INTEGER", nullable: false),
                    GTRent = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GTBegin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GTIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    GTKey = table.Column<int>(type: "INTEGER", nullable: false),
                    GTPrice = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildInfos", x => x.GuildIndex);
                });

            migrationBuilder.CreateTable(
                name: "HeroInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AutoPot = table.Column<bool>(type: "INTEGER", nullable: false),
                    Grade = table.Column<byte>(type: "INTEGER", nullable: false),
                    HPItemIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    MPItemIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    AutoHPPercent = table.Column<byte>(type: "INTEGER", nullable: false),
                    AutoMPPercent = table.Column<byte>(type: "INTEGER", nullable: false),
                    SealCount = table.Column<ushort>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MagicInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Spell = table.Column<byte>(type: "INTEGER", nullable: false),
                    BaseCost = table.Column<byte>(type: "INTEGER", nullable: false),
                    LevelCost = table.Column<byte>(type: "INTEGER", nullable: false),
                    Icon = table.Column<byte>(type: "INTEGER", nullable: false),
                    Level1 = table.Column<byte>(type: "INTEGER", nullable: false),
                    Level2 = table.Column<byte>(type: "INTEGER", nullable: false),
                    Level3 = table.Column<byte>(type: "INTEGER", nullable: false),
                    Need1 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Need2 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Need3 = table.Column<ushort>(type: "INTEGER", nullable: false),
                    DelayBase = table.Column<uint>(type: "INTEGER", nullable: false),
                    DelayReduction = table.Column<uint>(type: "INTEGER", nullable: false),
                    PowerBase = table.Column<ushort>(type: "INTEGER", nullable: false),
                    PowerBonus = table.Column<ushort>(type: "INTEGER", nullable: false),
                    MPowerBase = table.Column<ushort>(type: "INTEGER", nullable: false),
                    MPowerBonus = table.Column<ushort>(type: "INTEGER", nullable: false),
                    MultiplierBase = table.Column<float>(type: "REAL", nullable: false),
                    MultiplierBonus = table.Column<float>(type: "REAL", nullable: false),
                    Range = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MinAC = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxAC = table.Column<int>(type: "INTEGER", nullable: false),
                    MinMAC = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxMAC = table.Column<int>(type: "INTEGER", nullable: false),
                    MinDC = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxDC = table.Column<int>(type: "INTEGER", nullable: false),
                    MinMC = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxMC = table.Column<int>(type: "INTEGER", nullable: false),
                    MinSC = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxSC = table.Column<int>(type: "INTEGER", nullable: false),
                    Accuracy = table.Column<int>(type: "INTEGER", nullable: false),
                    Agility = table.Column<int>(type: "INTEGER", nullable: false),
                    HP = table.Column<int>(type: "INTEGER", nullable: false),
                    MP = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    Luck = table.Column<int>(type: "INTEGER", nullable: false),
                    BagWeight = table.Column<int>(type: "INTEGER", nullable: false),
                    HandWeight = table.Column<int>(type: "INTEGER", nullable: false),
                    WearWeight = table.Column<int>(type: "INTEGER", nullable: false),
                    Reflect = table.Column<int>(type: "INTEGER", nullable: false),
                    Strong = table.Column<int>(type: "INTEGER", nullable: false),
                    Holy = table.Column<int>(type: "INTEGER", nullable: false),
                    Freezing = table.Column<int>(type: "INTEGER", nullable: false),
                    PoisonAttack = table.Column<int>(type: "INTEGER", nullable: false),
                    MagicResist = table.Column<int>(type: "INTEGER", nullable: false),
                    PoisonResist = table.Column<int>(type: "INTEGER", nullable: false),
                    HealthRecovery = table.Column<int>(type: "INTEGER", nullable: false),
                    SpellRecovery = table.Column<int>(type: "INTEGER", nullable: false),
                    PoisonRecovery = table.Column<int>(type: "INTEGER", nullable: false),
                    CriticalRate = table.Column<int>(type: "INTEGER", nullable: false),
                    CriticalDamage = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxACRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxMACRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxDCRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxMCRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxSCRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackSpeedRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    HPRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    MPRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    HPDrainRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    ExpRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemDropRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    GoldDropRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    MineRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    GemRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    FishRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    CraftRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillGainMultiplier = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackBonus = table.Column<int>(type: "INTEGER", nullable: false),
                    LoverExpRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    MentorDamageRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    MentorExpRatePercent = table.Column<int>(type: "INTEGER", nullable: false),
                    DamageReductionPercent = table.Column<int>(type: "INTEGER", nullable: false),
                    EnergyShieldPercent = table.Column<int>(type: "INTEGER", nullable: false),
                    EnergyShieldHPGain = table.Column<int>(type: "INTEGER", nullable: false),
                    ManaPenaltyPercent = table.Column<int>(type: "INTEGER", nullable: false),
                    TeleportManaPenaltyPercent = table.Column<int>(type: "INTEGER", nullable: false),
                    Hero = table.Column<int>(type: "INTEGER", nullable: false),
                    Unknown = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuildRank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuildInfoGuildIndex = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildRank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuildRank_GuildInfos_GuildInfoGuildIndex",
                        column: x => x.GuildInfoGuildIndex,
                        principalTable: "GuildInfos",
                        principalColumn: "GuildIndex");
                });

            migrationBuilder.CreateTable(
                name: "GuildBuffInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Icon = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    LevelRequirement = table.Column<byte>(type: "INTEGER", nullable: false),
                    PointsRequirement = table.Column<byte>(type: "INTEGER", nullable: false),
                    TimeLimit = table.Column<int>(type: "INTEGER", nullable: false),
                    ActivationCost = table.Column<int>(type: "INTEGER", nullable: false),
                    StatsId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildBuffInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuildBuffInfo_Stats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "Stats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GuildBuff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InfoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    ActiveTimeRemaining = table.Column<int>(type: "INTEGER", nullable: false),
                    GuildInfoGuildIndex = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildBuff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuildBuff_GuildBuffInfo_InfoId",
                        column: x => x.InfoId,
                        principalTable: "GuildBuffInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuildBuff_GuildInfos_GuildInfoGuildIndex",
                        column: x => x.GuildInfoGuildIndex,
                        principalTable: "GuildInfos",
                        principalColumn: "GuildIndex");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuildBuff_GuildInfoGuildIndex",
                table: "GuildBuff",
                column: "GuildInfoGuildIndex");

            migrationBuilder.CreateIndex(
                name: "IX_GuildBuff_InfoId",
                table: "GuildBuff",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_GuildBuffInfo_StatsId",
                table: "GuildBuffInfo",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_GuildRank_GuildInfoGuildIndex",
                table: "GuildRank",
                column: "GuildInfoGuildIndex");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuildBuff");

            migrationBuilder.DropTable(
                name: "GuildRank");

            migrationBuilder.DropTable(
                name: "HeroInfos");

            migrationBuilder.DropTable(
                name: "MagicInfo");

            migrationBuilder.DropTable(
                name: "GuildBuffInfo");

            migrationBuilder.DropTable(
                name: "GuildInfos");

            migrationBuilder.DropTable(
                name: "Stats");
        }
    }
}
