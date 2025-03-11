using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialEFMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Awakes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<byte>(type: "INTEGER", nullable: false),
                    listAwake = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awakes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpireInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpireInfos", x => x.Id);
                });

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
                name: "Items",
                columns: table => new
                {
                    Index = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<byte>(type: "INTEGER", nullable: false),
                    Grade = table.Column<byte>(type: "INTEGER", nullable: false),
                    RequiredType = table.Column<byte>(type: "INTEGER", nullable: false),
                    RequiredClass = table.Column<byte>(type: "INTEGER", nullable: false),
                    RequiredGender = table.Column<byte>(type: "INTEGER", nullable: false),
                    Set = table.Column<byte>(type: "INTEGER", nullable: false),
                    Shape = table.Column<short>(type: "INTEGER", nullable: false),
                    Weight = table.Column<byte>(type: "INTEGER", nullable: false),
                    Light = table.Column<byte>(type: "INTEGER", nullable: false),
                    RequiredAmount = table.Column<byte>(type: "INTEGER", nullable: false),
                    Image = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Durability = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Price = table.Column<uint>(type: "INTEGER", nullable: false),
                    StackSize = table.Column<ushort>(type: "INTEGER", nullable: false),
                    StartItem = table.Column<bool>(type: "INTEGER", nullable: false),
                    Effect = table.Column<byte>(type: "INTEGER", nullable: false),
                    NeedIdentify = table.Column<bool>(type: "INTEGER", nullable: false),
                    ShowGroupPickup = table.Column<bool>(type: "INTEGER", nullable: false),
                    GlobalDropNotify = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClassBased = table.Column<bool>(type: "INTEGER", nullable: false),
                    LevelBased = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanMine = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanFastRun = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanAwakening = table.Column<bool>(type: "INTEGER", nullable: false),
                    Bind = table.Column<short>(type: "INTEGER", nullable: false),
                    Unique = table.Column<short>(type: "INTEGER", nullable: false),
                    RandomStatsId = table.Column<byte>(type: "INTEGER", nullable: false),
                    ToolTip = table.Column<string>(type: "TEXT", nullable: true),
                    Slots = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Index);
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
                name: "RentalInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SealedInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SealedInfos", x => x.Id);
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
                    Unknown = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemInfoIndex = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Items_ItemInfoIndex",
                        column: x => x.ItemInfoIndex,
                        principalTable: "Items",
                        principalColumn: "Index");
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
                name: "UserItems",
                columns: table => new
                {
                    UniqueID = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentDura = table.Column<ushort>(type: "INTEGER", nullable: false),
                    MaxDura = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Count = table.Column<ushort>(type: "INTEGER", nullable: false),
                    GemCount = table.Column<ushort>(type: "INTEGER", nullable: false),
                    RefinedValue = table.Column<byte>(type: "INTEGER", nullable: false),
                    RefineAdded = table.Column<byte>(type: "INTEGER", nullable: false),
                    RefineSuccessChance = table.Column<int>(type: "INTEGER", nullable: false),
                    DuraChanged = table.Column<bool>(type: "INTEGER", nullable: false),
                    SoulBoundId = table.Column<int>(type: "INTEGER", nullable: false),
                    Identified = table.Column<bool>(type: "INTEGER", nullable: false),
                    Cursed = table.Column<bool>(type: "INTEGER", nullable: false),
                    WeddingRing = table.Column<int>(type: "INTEGER", nullable: false),
                    SlotsJson = table.Column<string>(type: "TEXT", nullable: true),
                    BuybackExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpireInfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    RentalInformationId = table.Column<int>(type: "INTEGER", nullable: true),
                    SealedInfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsShopItem = table.Column<bool>(type: "INTEGER", nullable: false),
                    GMMade = table.Column<bool>(type: "INTEGER", nullable: false),
                    AwakeId = table.Column<int>(type: "INTEGER", nullable: true),
                    AddedStatsId = table.Column<int>(type: "INTEGER", nullable: true),
                    ParentItemID = table.Column<ulong>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItems", x => x.UniqueID);
                    table.ForeignKey(
                        name: "FK_UserItems_Awakes_AwakeId",
                        column: x => x.AwakeId,
                        principalTable: "Awakes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserItems_ExpireInfos_ExpireInfoId",
                        column: x => x.ExpireInfoId,
                        principalTable: "ExpireInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserItems_Items_ItemIndex",
                        column: x => x.ItemIndex,
                        principalTable: "Items",
                        principalColumn: "Index",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserItems_RentalInformations_RentalInformationId",
                        column: x => x.RentalInformationId,
                        principalTable: "RentalInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserItems_SealedInfos_SealedInfoId",
                        column: x => x.SealedInfoId,
                        principalTable: "SealedInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserItems_Stats_AddedStatsId",
                        column: x => x.AddedStatsId,
                        principalTable: "Stats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserItems_UserItems_ParentItemID",
                        column: x => x.ParentItemID,
                        principalTable: "UserItems",
                        principalColumn: "UniqueID");
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

            migrationBuilder.CreateIndex(
                name: "IX_Stats_ItemInfoIndex",
                table: "Stats",
                column: "ItemInfoIndex",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_AddedStatsId",
                table: "UserItems",
                column: "AddedStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_AwakeId",
                table: "UserItems",
                column: "AwakeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_ExpireInfoId",
                table: "UserItems",
                column: "ExpireInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_ItemIndex",
                table: "UserItems",
                column: "ItemIndex");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_ParentItemID",
                table: "UserItems",
                column: "ParentItemID");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_RentalInformationId",
                table: "UserItems",
                column: "RentalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_SealedInfoId",
                table: "UserItems",
                column: "SealedInfoId");
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
                name: "UserItems");

            migrationBuilder.DropTable(
                name: "GuildBuffInfo");

            migrationBuilder.DropTable(
                name: "GuildInfos");

            migrationBuilder.DropTable(
                name: "MapInfo");

            migrationBuilder.DropTable(
                name: "Awakes");

            migrationBuilder.DropTable(
                name: "ExpireInfos");

            migrationBuilder.DropTable(
                name: "RentalInformations");

            migrationBuilder.DropTable(
                name: "SealedInfos");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
