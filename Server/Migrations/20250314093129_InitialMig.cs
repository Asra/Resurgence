using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Library.Migrations
{
    /// <inheritdoc />
    public partial class InitialMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountID = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Salt = table.Column<byte[]>(type: "BLOB", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SecretQuestion = table.Column<string>(type: "TEXT", nullable: true),
                    SecretAnswer = table.Column<string>(type: "TEXT", nullable: true),
                    EMailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    CreationIP = table.Column<string>(type: "TEXT", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Banned = table.Column<bool>(type: "INTEGER", nullable: false),
                    RequirePasswordChange = table.Column<bool>(type: "INTEGER", nullable: false),
                    BanReason = table.Column<string>(type: "TEXT", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WrongPasswordCount = table.Column<int>(type: "INTEGER", nullable: false),
                    LastIP = table.Column<string>(type: "TEXT", nullable: true),
                    LastDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HasExpandedStorage = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExpandedStorageExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gold = table.Column<uint>(type: "INTEGER", nullable: false),
                    Credit = table.Column<uint>(type: "INTEGER", nullable: false),
                    AdminAccount = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInfo", x => x.Id);
                });

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
                name: "BuffInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<byte>(type: "INTEGER", nullable: false),
                    StackType = table.Column<byte>(type: "INTEGER", nullable: false),
                    Properties = table.Column<byte>(type: "INTEGER", nullable: false),
                    Icon = table.Column<int>(type: "INTEGER", nullable: false),
                    Visible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuffInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConquestGuildInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Owner = table.Column<int>(type: "INTEGER", nullable: false),
                    GoldStorage = table.Column<uint>(type: "INTEGER", nullable: false),
                    AttackerID = table.Column<int>(type: "INTEGER", nullable: false),
                    NPCRate = table.Column<byte>(type: "INTEGER", nullable: false),
                    NeedSave = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquestGuildInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConquestInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    FullMap = table.Column<bool>(type: "INTEGER", nullable: false),
                    LocationX = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationY = table.Column<int>(type: "INTEGER", nullable: false),
                    Size = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    MapIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    PalaceIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    ExtraMaps = table.Column<string>(type: "TEXT", nullable: true),
                    GuardIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    GateIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    WallIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    SiegeIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    FlagIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    StartHour = table.Column<byte>(type: "INTEGER", nullable: false),
                    WarLength = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<byte>(type: "INTEGER", nullable: false),
                    Game = table.Column<byte>(type: "INTEGER", nullable: false),
                    Monday = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tuesday = table.Column<bool>(type: "INTEGER", nullable: false),
                    Wednesday = table.Column<bool>(type: "INTEGER", nullable: false),
                    Thursday = table.Column<bool>(type: "INTEGER", nullable: false),
                    Friday = table.Column<bool>(type: "INTEGER", nullable: false),
                    Saturday = table.Column<bool>(type: "INTEGER", nullable: false),
                    Sunday = table.Column<bool>(type: "INTEGER", nullable: false),
                    KingLocationX = table.Column<int>(type: "INTEGER", nullable: false),
                    KingLocationY = table.Column<int>(type: "INTEGER", nullable: false),
                    KingSize = table.Column<ushort>(type: "INTEGER", nullable: false),
                    ControlPointIndex = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquestInfo", x => x.Id);
                });

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
                name: "ExpireInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpireInfos", x => x.Id);
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
                name: "IntelligentCreatureInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PetType = table.Column<byte>(type: "INTEGER", nullable: false),
                    Icon = table.Column<int>(type: "INTEGER", nullable: false),
                    MinimalFullness = table.Column<int>(type: "INTEGER", nullable: false),
                    MousePickupEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    MousePickupRange = table.Column<int>(type: "INTEGER", nullable: false),
                    AutoPickupEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AutoPickupRange = table.Column<int>(type: "INTEGER", nullable: false),
                    SemiAutoPickupEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    SemiAutoPickupRange = table.Column<int>(type: "INTEGER", nullable: false),
                    CanProduceBlackStone = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntelligentCreatureInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntelligentCreatureItemFilter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PetPickupAll = table.Column<bool>(type: "INTEGER", nullable: false),
                    PetPickupGold = table.Column<bool>(type: "INTEGER", nullable: false),
                    PetPickupWeapons = table.Column<bool>(type: "INTEGER", nullable: false),
                    PetPickupArmours = table.Column<bool>(type: "INTEGER", nullable: false),
                    PetPickupHelmets = table.Column<bool>(type: "INTEGER", nullable: false),
                    PetPickupBoots = table.Column<bool>(type: "INTEGER", nullable: false),
                    PetPickupBelts = table.Column<bool>(type: "INTEGER", nullable: false),
                    PetPickupAccessories = table.Column<bool>(type: "INTEGER", nullable: false),
                    PetPickupOthers = table.Column<bool>(type: "INTEGER", nullable: false),
                    PickupGrade = table.Column<byte>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntelligentCreatureItemFilter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemInfos",
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
                    table.PrimaryKey("PK_ItemInfos", x => x.Index);
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
                name: "MountInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MountType = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestFlagTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestFlagTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestInfo",
                columns: table => new
                {
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Group = table.Column<string>(type: "TEXT", nullable: true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    GotoMessage = table.Column<string>(type: "TEXT", nullable: true),
                    KillMessage = table.Column<string>(type: "TEXT", nullable: true),
                    ItemMessage = table.Column<string>(type: "TEXT", nullable: true),
                    FlagMessage = table.Column<string>(type: "TEXT", nullable: true),
                    RequiredMinLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    RequiredMaxLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    RequiredQuest = table.Column<int>(type: "INTEGER", nullable: false),
                    RequiredClass = table.Column<byte>(type: "INTEGER", nullable: false),
                    Type = table.Column<byte>(type: "INTEGER", nullable: false),
                    TimeLimitInSeconds = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestInfo", x => x.Index);
                });

            migrationBuilder.CreateTable(
                name: "RentalInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerName = table.Column<string>(type: "TEXT", nullable: true),
                    BindingFlags = table.Column<short>(type: "INTEGER", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RentalLocked = table.Column<bool>(type: "INTEGER", nullable: false)
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
                        .Annotation("Sqlite:Autoincrement", true),
                    ExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NextSealDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SealedInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConquestGuildArcherInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Alive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConquestGuildInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquestGuildArcherInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConquestGuildArcherInfo_ConquestGuildInfo_ConquestGuildInfoId",
                        column: x => x.ConquestGuildInfoId,
                        principalTable: "ConquestGuildInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConquestGuildGateInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    ConquestGuildInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquestGuildGateInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConquestGuildGateInfo_ConquestGuildInfo_ConquestGuildInfoId",
                        column: x => x.ConquestGuildInfoId,
                        principalTable: "ConquestGuildInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConquestGuildSiegeInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    ConquestGuildInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquestGuildSiegeInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConquestGuildSiegeInfo_ConquestGuildInfo_ConquestGuildInfoId",
                        column: x => x.ConquestGuildInfoId,
                        principalTable: "ConquestGuildInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConquestGuildWallInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    ConquestGuildInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquestGuildWallInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConquestGuildWallInfo_ConquestGuildInfo_ConquestGuildInfoId",
                        column: x => x.ConquestGuildInfoId,
                        principalTable: "ConquestGuildInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConquestArcherInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationX = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationY = table.Column<int>(type: "INTEGER", nullable: false),
                    MobIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RepairCost = table.Column<uint>(type: "INTEGER", nullable: false),
                    ConquestInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquestArcherInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConquestArcherInfo_ConquestInfo_ConquestInfoId",
                        column: x => x.ConquestInfoId,
                        principalTable: "ConquestInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConquestFlagInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationX = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationY = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    ConquestInfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    ConquestInfoId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquestFlagInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConquestFlagInfo_ConquestInfo_ConquestInfoId",
                        column: x => x.ConquestInfoId,
                        principalTable: "ConquestInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConquestFlagInfo_ConquestInfo_ConquestInfoId1",
                        column: x => x.ConquestInfoId1,
                        principalTable: "ConquestInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConquestGateInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationX = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationY = table.Column<int>(type: "INTEGER", nullable: false),
                    MobIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RepairCost = table.Column<int>(type: "INTEGER", nullable: false),
                    ConquestInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquestGateInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConquestGateInfo_ConquestInfo_ConquestInfoId",
                        column: x => x.ConquestInfoId,
                        principalTable: "ConquestInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConquestSiegeInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationX = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationY = table.Column<int>(type: "INTEGER", nullable: false),
                    MobIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RepairCost = table.Column<int>(type: "INTEGER", nullable: false),
                    ConquestInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquestSiegeInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConquestSiegeInfo_ConquestInfo_ConquestInfoId",
                        column: x => x.ConquestInfoId,
                        principalTable: "ConquestInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConquestWallInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationX = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationY = table.Column<int>(type: "INTEGER", nullable: false),
                    MobIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RepairCost = table.Column<int>(type: "INTEGER", nullable: false),
                    ConquestInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquestWallInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConquestWallInfo_ConquestInfo_ConquestInfoId",
                        column: x => x.ConquestInfoId,
                        principalTable: "ConquestInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GuildRanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Options = table.Column<byte>(type: "INTEGER", nullable: false),
                    GuildInfoGuildIndex = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildRanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuildRanks_GuildInfos_GuildInfoGuildIndex",
                        column: x => x.GuildInfoGuildIndex,
                        principalTable: "GuildInfos",
                        principalColumn: "GuildIndex");
                });

            migrationBuilder.CreateTable(
                name: "GameShopItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    GIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    GoldPrice = table.Column<uint>(type: "INTEGER", nullable: false),
                    CreditPrice = table.Column<uint>(type: "INTEGER", nullable: false),
                    Count = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Class = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    iStock = table.Column<bool>(type: "INTEGER", nullable: false),
                    Deal = table.Column<bool>(type: "INTEGER", nullable: false),
                    TopItem = table.Column<bool>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CanBuyGold = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanBuyCredit = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameShopItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameShopItems_ItemInfos_ItemIndex",
                        column: x => x.ItemIndex,
                        principalTable: "ItemInfos",
                        principalColumn: "Index",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestItemTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemIndex = table.Column<int>(type: "INTEGER", nullable: true),
                    Count = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestItemTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestItemTask_ItemInfos_ItemIndex",
                        column: x => x.ItemIndex,
                        principalTable: "ItemInfos",
                        principalColumn: "Index");
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
                        name: "FK_Stats_ItemInfos_ItemInfoIndex",
                        column: x => x.ItemInfoIndex,
                        principalTable: "ItemInfos",
                        principalColumn: "Index");
                });

            migrationBuilder.CreateTable(
                name: "MineZones",
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
                    table.PrimaryKey("PK_MineZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MineZones_MapInfo_MapInfoId",
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
                name: "NPCInfo",
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
                    table.PrimaryKey("PK_NPCInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NPCInfo_MapInfo_MapInfoId",
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
                name: "GuildMembers",
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
                    table.PrimaryKey("PK_GuildMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuildMembers_GuildRanks_GuildRankId",
                        column: x => x.GuildRankId,
                        principalTable: "GuildRanks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GuildBuffInfos",
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
                    table.PrimaryKey("PK_GuildBuffInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuildBuffInfos_Stats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "Stats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MonsterInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<ushort>(type: "INTEGER", nullable: false),
                    AI = table.Column<byte>(type: "INTEGER", nullable: false),
                    Effect = table.Column<byte>(type: "INTEGER", nullable: false),
                    ViewRange = table.Column<byte>(type: "INTEGER", nullable: false),
                    CoolEye = table.Column<byte>(type: "INTEGER", nullable: false),
                    Level = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Light = table.Column<byte>(type: "INTEGER", nullable: false),
                    AttackSpeed = table.Column<ushort>(type: "INTEGER", nullable: false),
                    MoveSpeed = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Experience = table.Column<uint>(type: "INTEGER", nullable: false),
                    DropPath = table.Column<string>(type: "TEXT", nullable: true),
                    CanTame = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanPush = table.Column<bool>(type: "INTEGER", nullable: false),
                    AutoRev = table.Column<bool>(type: "INTEGER", nullable: false),
                    Undead = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasSpawnScript = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasDieScript = table.Column<bool>(type: "INTEGER", nullable: false),
                    StatsId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterInfo_Stats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "Stats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GuildBuffs",
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
                    table.PrimaryKey("PK_GuildBuffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuildBuffs_GuildBuffInfos_InfoId",
                        column: x => x.InfoId,
                        principalTable: "GuildBuffInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuildBuffs_GuildInfos_GuildInfoGuildIndex",
                        column: x => x.GuildInfoGuildIndex,
                        principalTable: "GuildInfos",
                        principalColumn: "GuildIndex");
                });

            migrationBuilder.CreateTable(
                name: "QuestKillTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MonsterId = table.Column<int>(type: "INTEGER", nullable: true),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestKillTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestKillTask_MonsterInfo_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "MonsterInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemUniqueID = table.Column<ulong>(type: "INTEGER", nullable: true),
                    ConsignmentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<uint>(type: "INTEGER", nullable: false),
                    CurrentBid = table.Column<uint>(type: "INTEGER", nullable: false),
                    SellerIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    SellerId = table.Column<int>(type: "INTEGER", nullable: true),
                    CurrentBuyerIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentBuyerId = table.Column<int>(type: "INTEGER", nullable: true),
                    Expired = table.Column<bool>(type: "INTEGER", nullable: false),
                    Sold = table.Column<bool>(type: "INTEGER", nullable: false),
                    ItemType = table.Column<byte>(type: "INTEGER", nullable: false),
                    AccountInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_AccountInfo_AccountInfoId",
                        column: x => x.AccountInfoId,
                        principalTable: "AccountInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Buffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ObjectID = table.Column<uint>(type: "INTEGER", nullable: false),
                    ExpireTime = table.Column<long>(type: "INTEGER", nullable: false),
                    StatsId = table.Column<int>(type: "INTEGER", nullable: true),
                    CharacterInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buffs_Stats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "Stats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CharacterInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Level = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Class = table.Column<byte>(type: "INTEGER", nullable: false),
                    Gender = table.Column<byte>(type: "INTEGER", nullable: false),
                    Hair = table.Column<byte>(type: "INTEGER", nullable: false),
                    GuildIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationIP = table.Column<string>(type: "TEXT", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Banned = table.Column<bool>(type: "INTEGER", nullable: false),
                    BanReason = table.Column<string>(type: "TEXT", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ChatBanned = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChatBanExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastIP = table.Column<string>(type: "TEXT", nullable: true),
                    LastLogoutDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Married = table.Column<int>(type: "INTEGER", nullable: false),
                    MarriedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Mentor = table.Column<int>(type: "INTEGER", nullable: false),
                    MentorDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsMentor = table.Column<bool>(type: "INTEGER", nullable: false),
                    MentorExp = table.Column<long>(type: "INTEGER", nullable: false),
                    CurrentMapIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    Direction = table.Column<byte>(type: "INTEGER", nullable: false),
                    BindMapIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    BindLocationX = table.Column<int>(type: "INTEGER", nullable: false),
                    BindLocationY = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentLocationX = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentLocationY = table.Column<int>(type: "INTEGER", nullable: false),
                    HP = table.Column<int>(type: "INTEGER", nullable: false),
                    MP = table.Column<int>(type: "INTEGER", nullable: false),
                    Experience = table.Column<long>(type: "INTEGER", nullable: false),
                    AMode = table.Column<byte>(type: "INTEGER", nullable: false),
                    PMode = table.Column<byte>(type: "INTEGER", nullable: false),
                    AllowGroup = table.Column<bool>(type: "INTEGER", nullable: false),
                    AllowTrade = table.Column<bool>(type: "INTEGER", nullable: false),
                    AllowObserve = table.Column<bool>(type: "INTEGER", nullable: false),
                    PKPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    NewDay = table.Column<bool>(type: "INTEGER", nullable: false),
                    Thrusting = table.Column<bool>(type: "INTEGER", nullable: false),
                    HalfMoon = table.Column<bool>(type: "INTEGER", nullable: false),
                    CrossHalfMoon = table.Column<bool>(type: "INTEGER", nullable: false),
                    DoubleSlash = table.Column<bool>(type: "INTEGER", nullable: false),
                    MentalState = table.Column<byte>(type: "INTEGER", nullable: false),
                    MentalStateLvl = table.Column<byte>(type: "INTEGER", nullable: false),
                    InventoryJson = table.Column<string>(type: "TEXT", nullable: true),
                    EquipmentJson = table.Column<string>(type: "TEXT", nullable: true),
                    TradeJson = table.Column<string>(type: "TEXT", nullable: true),
                    QuestInventoryJson = table.Column<string>(type: "TEXT", nullable: true),
                    RefineJson = table.Column<string>(type: "TEXT", nullable: true),
                    HasRentedItem = table.Column<bool>(type: "INTEGER", nullable: false),
                    CurrentRefineUniqueID = table.Column<ulong>(type: "INTEGER", nullable: true),
                    CollectTime = table.Column<long>(type: "INTEGER", nullable: false),
                    PearlCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CompletedQuests = table.Column<string>(type: "TEXT", nullable: true),
                    Flags = table.Column<string>(type: "TEXT", nullable: true),
                    AccountInfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    MountId = table.Column<int>(type: "INTEGER", nullable: true),
                    MaximumHeroCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentHeroIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    HeroSpawned = table.Column<bool>(type: "INTEGER", nullable: false),
                    HeroBehaviour = table.Column<byte>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    AutoPot = table.Column<bool>(type: "INTEGER", nullable: true),
                    Grade = table.Column<byte>(type: "INTEGER", nullable: true),
                    HPItemIndex = table.Column<int>(type: "INTEGER", nullable: true),
                    MPItemIndex = table.Column<int>(type: "INTEGER", nullable: true),
                    AutoHPPercent = table.Column<byte>(type: "INTEGER", nullable: true),
                    AutoMPPercent = table.Column<byte>(type: "INTEGER", nullable: true),
                    SealCount = table.Column<ushort>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterInfo_AccountInfo_AccountInfoId",
                        column: x => x.AccountInfoId,
                        principalTable: "AccountInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CharacterInfo_MountInfo_MountId",
                        column: x => x.MountId,
                        principalTable: "MountInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FriendInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Blocked = table.Column<bool>(type: "INTEGER", nullable: false),
                    Memo = table.Column<string>(type: "TEXT", nullable: true),
                    CharacterInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendInfo_CharacterInfo_CharacterInfoId",
                        column: x => x.CharacterInfoId,
                        principalTable: "CharacterInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemRentalInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    ItemName = table.Column<string>(type: "TEXT", nullable: true),
                    RentingPlayerName = table.Column<string>(type: "TEXT", nullable: true),
                    ItemReturnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CharacterInfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    CharacterInfoId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRentalInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemRentalInformations_CharacterInfo_CharacterInfoId",
                        column: x => x.CharacterInfoId,
                        principalTable: "CharacterInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemRentalInformations_CharacterInfo_CharacterInfoId1",
                        column: x => x.CharacterInfoId1,
                        principalTable: "CharacterInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MailInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MailID = table.Column<ulong>(type: "INTEGER", nullable: false),
                    Sender = table.Column<string>(type: "TEXT", nullable: true),
                    RecipientIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    RecipientInfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    Gold = table.Column<uint>(type: "INTEGER", nullable: false),
                    DateSent = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Locked = table.Column<bool>(type: "INTEGER", nullable: false),
                    Collected = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanReply = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MailInfo_CharacterInfo_RecipientInfoId",
                        column: x => x.RecipientInfoId,
                        principalTable: "CharacterInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PetInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MonsterIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    HP = table.Column<int>(type: "INTEGER", nullable: false),
                    Experience = table.Column<uint>(type: "INTEGER", nullable: false),
                    Level = table.Column<byte>(type: "INTEGER", nullable: false),
                    MaxPetLevel = table.Column<byte>(type: "INTEGER", nullable: false),
                    TameTime = table.Column<long>(type: "INTEGER", nullable: false),
                    CharacterInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetInfo_CharacterInfo_CharacterInfoId",
                        column: x => x.CharacterInfoId,
                        principalTable: "CharacterInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestProgressInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    InfoIndex = table.Column<int>(type: "INTEGER", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TaskList = table.Column<string>(type: "TEXT", nullable: true),
                    CharacterInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestProgressInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestProgressInfo_CharacterInfo_CharacterInfoId",
                        column: x => x.CharacterInfoId,
                        principalTable: "CharacterInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestProgressInfo_QuestInfo_InfoIndex",
                        column: x => x.InfoIndex,
                        principalTable: "QuestInfo",
                        principalColumn: "Index");
                });

            migrationBuilder.CreateTable(
                name: "UserIntelligentCreature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PetType = table.Column<byte>(type: "INTEGER", nullable: false),
                    InfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    FilterId = table.Column<int>(type: "INTEGER", nullable: true),
                    petMode = table.Column<byte>(type: "INTEGER", nullable: false),
                    CustomName = table.Column<string>(type: "TEXT", nullable: true),
                    Fullness = table.Column<int>(type: "INTEGER", nullable: false),
                    SlotIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    Expire = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BlackstoneTime = table.Column<long>(type: "INTEGER", nullable: false),
                    MaintainFoodTime = table.Column<long>(type: "INTEGER", nullable: false),
                    CharacterInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIntelligentCreature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserIntelligentCreature_CharacterInfo_CharacterInfoId",
                        column: x => x.CharacterInfoId,
                        principalTable: "CharacterInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserIntelligentCreature_IntelligentCreatureInfo_InfoId",
                        column: x => x.InfoId,
                        principalTable: "IntelligentCreatureInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserIntelligentCreature_IntelligentCreatureItemFilter_FilterId",
                        column: x => x.FilterId,
                        principalTable: "IntelligentCreatureItemFilter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserMagic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Spell = table.Column<byte>(type: "INTEGER", nullable: false),
                    InfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Level = table.Column<byte>(type: "INTEGER", nullable: false),
                    Key = table.Column<byte>(type: "INTEGER", nullable: false),
                    Experience = table.Column<ushort>(type: "INTEGER", nullable: false),
                    IsTempSpell = table.Column<bool>(type: "INTEGER", nullable: false),
                    CastTime = table.Column<long>(type: "INTEGER", nullable: false),
                    CharacterInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMagic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMagic_CharacterInfo_CharacterInfoId",
                        column: x => x.CharacterInfoId,
                        principalTable: "CharacterInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMagic_MagicInfo_InfoId",
                        column: x => x.InfoId,
                        principalTable: "MagicInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestFlagTaskProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false),
                    InfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    QuestProgressInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestFlagTaskProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestFlagTaskProgress_QuestFlagTask_InfoId",
                        column: x => x.InfoId,
                        principalTable: "QuestFlagTask",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestFlagTaskProgress_QuestProgressInfo_QuestProgressInfoId",
                        column: x => x.QuestProgressInfoId,
                        principalTable: "QuestProgressInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestItemTaskProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemID = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    InfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    QuestProgressInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestItemTaskProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestItemTaskProgress_QuestItemTask_InfoId",
                        column: x => x.InfoId,
                        principalTable: "QuestItemTask",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestItemTaskProgress_QuestProgressInfo_QuestProgressInfoId",
                        column: x => x.QuestProgressInfoId,
                        principalTable: "QuestProgressInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestKillTaskProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MonsterID = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    InfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    QuestProgressInfoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestKillTaskProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestKillTaskProgress_QuestKillTask_InfoId",
                        column: x => x.InfoId,
                        principalTable: "QuestKillTask",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestKillTaskProgress_QuestProgressInfo_QuestProgressInfoId",
                        column: x => x.QuestProgressInfoId,
                        principalTable: "QuestProgressInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemUniqueID = table.Column<ulong>(type: "INTEGER", nullable: true),
                    RequiredFlag = table.Column<string>(type: "TEXT", nullable: true),
                    RequiredLevel = table.Column<ushort>(type: "INTEGER", nullable: true),
                    RequiredQuest = table.Column<string>(type: "TEXT", nullable: true),
                    RequiredClass = table.Column<string>(type: "TEXT", nullable: true),
                    RequiredGender = table.Column<byte>(type: "INTEGER", nullable: true),
                    Chance = table.Column<byte>(type: "INTEGER", nullable: false),
                    Gold = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeInfo", x => x.Id);
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
                    MailInfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    MountInfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    ParentItemID = table.Column<ulong>(type: "INTEGER", nullable: true),
                    RecipeInfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    RecipeInfoId1 = table.Column<int>(type: "INTEGER", nullable: true)
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
                        name: "FK_UserItems_ItemInfos_ItemIndex",
                        column: x => x.ItemIndex,
                        principalTable: "ItemInfos",
                        principalColumn: "Index",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserItems_MailInfo_MailInfoId",
                        column: x => x.MailInfoId,
                        principalTable: "MailInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserItems_MountInfo_MountInfoId",
                        column: x => x.MountInfoId,
                        principalTable: "MountInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserItems_RecipeInfo_RecipeInfoId",
                        column: x => x.RecipeInfoId,
                        principalTable: "RecipeInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserItems_RecipeInfo_RecipeInfoId1",
                        column: x => x.RecipeInfoId1,
                        principalTable: "RecipeInfo",
                        principalColumn: "Id");
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

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_AccountInfoId",
                table: "Auctions",
                column: "AccountInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_CurrentBuyerId",
                table: "Auctions",
                column: "CurrentBuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_ItemUniqueID",
                table: "Auctions",
                column: "ItemUniqueID");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_SellerId",
                table: "Auctions",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Buffs_CharacterInfoId",
                table: "Buffs",
                column: "CharacterInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Buffs_StatsId",
                table: "Buffs",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterInfo_AccountInfoId",
                table: "CharacterInfo",
                column: "AccountInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterInfo_CurrentRefineUniqueID",
                table: "CharacterInfo",
                column: "CurrentRefineUniqueID");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterInfo_MountId",
                table: "CharacterInfo",
                column: "MountId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquestArcherInfo_ConquestInfoId",
                table: "ConquestArcherInfo",
                column: "ConquestInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquestFlagInfo_ConquestInfoId",
                table: "ConquestFlagInfo",
                column: "ConquestInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquestFlagInfo_ConquestInfoId1",
                table: "ConquestFlagInfo",
                column: "ConquestInfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_ConquestGateInfo_ConquestInfoId",
                table: "ConquestGateInfo",
                column: "ConquestInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquestGuildArcherInfo_ConquestGuildInfoId",
                table: "ConquestGuildArcherInfo",
                column: "ConquestGuildInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquestGuildGateInfo_ConquestGuildInfoId",
                table: "ConquestGuildGateInfo",
                column: "ConquestGuildInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquestGuildSiegeInfo_ConquestGuildInfoId",
                table: "ConquestGuildSiegeInfo",
                column: "ConquestGuildInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquestGuildWallInfo_ConquestGuildInfoId",
                table: "ConquestGuildWallInfo",
                column: "ConquestGuildInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquestSiegeInfo_ConquestInfoId",
                table: "ConquestSiegeInfo",
                column: "ConquestInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquestWallInfo_ConquestInfoId",
                table: "ConquestWallInfo",
                column: "ConquestInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendInfo_CharacterInfoId",
                table: "FriendInfo",
                column: "CharacterInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_GameShopItems_ItemIndex",
                table: "GameShopItems",
                column: "ItemIndex");

            migrationBuilder.CreateIndex(
                name: "IX_GuildBuffInfos_StatsId",
                table: "GuildBuffInfos",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_GuildBuffs_GuildInfoGuildIndex",
                table: "GuildBuffs",
                column: "GuildInfoGuildIndex");

            migrationBuilder.CreateIndex(
                name: "IX_GuildBuffs_InfoId",
                table: "GuildBuffs",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_GuildMembers_GuildRankId",
                table: "GuildMembers",
                column: "GuildRankId");

            migrationBuilder.CreateIndex(
                name: "IX_GuildRanks_GuildInfoGuildIndex",
                table: "GuildRanks",
                column: "GuildInfoGuildIndex");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRentalInformations_CharacterInfoId",
                table: "ItemRentalInformations",
                column: "CharacterInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRentalInformations_CharacterInfoId1",
                table: "ItemRentalInformations",
                column: "CharacterInfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_MailInfo_RecipientInfoId",
                table: "MailInfo",
                column: "RecipientInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_MineZones_MapInfoId",
                table: "MineZones",
                column: "MapInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterInfo_StatsId",
                table: "MonsterInfo",
                column: "StatsId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementInfos_MapInfoId",
                table: "MovementInfos",
                column: "MapInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_NPCInfo_MapInfoId",
                table: "NPCInfo",
                column: "MapInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PetInfo_CharacterInfoId",
                table: "PetInfo",
                column: "CharacterInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestFlagTaskProgress_InfoId",
                table: "QuestFlagTaskProgress",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestFlagTaskProgress_QuestProgressInfoId",
                table: "QuestFlagTaskProgress",
                column: "QuestProgressInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestItemTask_ItemIndex",
                table: "QuestItemTask",
                column: "ItemIndex");

            migrationBuilder.CreateIndex(
                name: "IX_QuestItemTaskProgress_InfoId",
                table: "QuestItemTaskProgress",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestItemTaskProgress_QuestProgressInfoId",
                table: "QuestItemTaskProgress",
                column: "QuestProgressInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestKillTask_MonsterId",
                table: "QuestKillTask",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestKillTaskProgress_InfoId",
                table: "QuestKillTaskProgress",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestKillTaskProgress_QuestProgressInfoId",
                table: "QuestKillTaskProgress",
                column: "QuestProgressInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestProgressInfo_CharacterInfoId",
                table: "QuestProgressInfo",
                column: "CharacterInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestProgressInfo_InfoIndex",
                table: "QuestProgressInfo",
                column: "InfoIndex");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeInfo_ItemUniqueID",
                table: "RecipeInfo",
                column: "ItemUniqueID");

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
                name: "IX_UserIntelligentCreature_CharacterInfoId",
                table: "UserIntelligentCreature",
                column: "CharacterInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIntelligentCreature_FilterId",
                table: "UserIntelligentCreature",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIntelligentCreature_InfoId",
                table: "UserIntelligentCreature",
                column: "InfoId");

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
                name: "IX_UserItems_MailInfoId",
                table: "UserItems",
                column: "MailInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_MountInfoId",
                table: "UserItems",
                column: "MountInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_ParentItemID",
                table: "UserItems",
                column: "ParentItemID");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_RecipeInfoId",
                table: "UserItems",
                column: "RecipeInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_RecipeInfoId1",
                table: "UserItems",
                column: "RecipeInfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_RentalInformationId",
                table: "UserItems",
                column: "RentalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItems_SealedInfoId",
                table: "UserItems",
                column: "SealedInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMagic_CharacterInfoId",
                table: "UserMagic",
                column: "CharacterInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMagic_InfoId",
                table: "UserMagic",
                column: "InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_CharacterInfo_CurrentBuyerId",
                table: "Auctions",
                column: "CurrentBuyerId",
                principalTable: "CharacterInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_CharacterInfo_SellerId",
                table: "Auctions",
                column: "SellerId",
                principalTable: "CharacterInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_UserItems_ItemUniqueID",
                table: "Auctions",
                column: "ItemUniqueID",
                principalTable: "UserItems",
                principalColumn: "UniqueID");

            migrationBuilder.AddForeignKey(
                name: "FK_Buffs_CharacterInfo_CharacterInfoId",
                table: "Buffs",
                column: "CharacterInfoId",
                principalTable: "CharacterInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacterInfo_UserItems_CurrentRefineUniqueID",
                table: "CharacterInfo",
                column: "CurrentRefineUniqueID",
                principalTable: "UserItems",
                principalColumn: "UniqueID");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeInfo_UserItems_ItemUniqueID",
                table: "RecipeInfo",
                column: "ItemUniqueID",
                principalTable: "UserItems",
                principalColumn: "UniqueID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacterInfo_AccountInfo_AccountInfoId",
                table: "CharacterInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_MailInfo_CharacterInfo_RecipientInfoId",
                table: "MailInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeInfo_UserItems_ItemUniqueID",
                table: "RecipeInfo");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "BuffInfo");

            migrationBuilder.DropTable(
                name: "Buffs");

            migrationBuilder.DropTable(
                name: "ConquestArcherInfo");

            migrationBuilder.DropTable(
                name: "ConquestFlagInfo");

            migrationBuilder.DropTable(
                name: "ConquestGateInfo");

            migrationBuilder.DropTable(
                name: "ConquestGuildArcherInfo");

            migrationBuilder.DropTable(
                name: "ConquestGuildGateInfo");

            migrationBuilder.DropTable(
                name: "ConquestGuildSiegeInfo");

            migrationBuilder.DropTable(
                name: "ConquestGuildWallInfo");

            migrationBuilder.DropTable(
                name: "ConquestSiegeInfo");

            migrationBuilder.DropTable(
                name: "ConquestWallInfo");

            migrationBuilder.DropTable(
                name: "DragonInfo");

            migrationBuilder.DropTable(
                name: "FriendInfo");

            migrationBuilder.DropTable(
                name: "GameShopItems");

            migrationBuilder.DropTable(
                name: "GTMaps");

            migrationBuilder.DropTable(
                name: "GuildBuffs");

            migrationBuilder.DropTable(
                name: "GuildMembers");

            migrationBuilder.DropTable(
                name: "ItemRentalInformations");

            migrationBuilder.DropTable(
                name: "MineZones");

            migrationBuilder.DropTable(
                name: "MovementInfos");

            migrationBuilder.DropTable(
                name: "NPCInfo");

            migrationBuilder.DropTable(
                name: "PetInfo");

            migrationBuilder.DropTable(
                name: "QuestFlagTaskProgress");

            migrationBuilder.DropTable(
                name: "QuestItemTaskProgress");

            migrationBuilder.DropTable(
                name: "QuestKillTaskProgress");

            migrationBuilder.DropTable(
                name: "RespawnInfo");

            migrationBuilder.DropTable(
                name: "SafeZoneInfos");

            migrationBuilder.DropTable(
                name: "UserIntelligentCreature");

            migrationBuilder.DropTable(
                name: "UserMagic");

            migrationBuilder.DropTable(
                name: "ConquestGuildInfo");

            migrationBuilder.DropTable(
                name: "ConquestInfo");

            migrationBuilder.DropTable(
                name: "GuildBuffInfos");

            migrationBuilder.DropTable(
                name: "GuildRanks");

            migrationBuilder.DropTable(
                name: "QuestFlagTask");

            migrationBuilder.DropTable(
                name: "QuestItemTask");

            migrationBuilder.DropTable(
                name: "QuestKillTask");

            migrationBuilder.DropTable(
                name: "QuestProgressInfo");

            migrationBuilder.DropTable(
                name: "MapInfo");

            migrationBuilder.DropTable(
                name: "IntelligentCreatureInfo");

            migrationBuilder.DropTable(
                name: "IntelligentCreatureItemFilter");

            migrationBuilder.DropTable(
                name: "MagicInfo");

            migrationBuilder.DropTable(
                name: "GuildInfos");

            migrationBuilder.DropTable(
                name: "MonsterInfo");

            migrationBuilder.DropTable(
                name: "QuestInfo");

            migrationBuilder.DropTable(
                name: "AccountInfo");

            migrationBuilder.DropTable(
                name: "CharacterInfo");

            migrationBuilder.DropTable(
                name: "UserItems");

            migrationBuilder.DropTable(
                name: "Awakes");

            migrationBuilder.DropTable(
                name: "ExpireInfos");

            migrationBuilder.DropTable(
                name: "MailInfo");

            migrationBuilder.DropTable(
                name: "MountInfo");

            migrationBuilder.DropTable(
                name: "RecipeInfo");

            migrationBuilder.DropTable(
                name: "RentalInformations");

            migrationBuilder.DropTable(
                name: "SealedInfos");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "ItemInfos");
        }
    }
}
