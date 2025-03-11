using Microsoft.EntityFrameworkCore;
using Server.Library.MirDatabase;
using Server.MirEnvir;
using Server.MirNetwork;
using Server.MirObjects;

namespace Server.MirDatabase
{
    public class GameDbContext : DbContext
    {
        public DbSet<MapInfo> MapInfos { get; set; }
        public DbSet<NPCInfo> NPCInfos { get; set; }
        public DbSet<MovementInfo> MovementInfos { get; set; }
        public DbSet<SafeZoneInfo> SafeZoneInfos { get; set; }
        public DbSet<RespawnInfo> RespawnInfos { get; set; }
        public DbSet<GuildInfo> GuildInfos { get; set; }
        public DbSet<HeroInfo> HeroInfos { get; set; }
        public DbSet<MagicInfo> MagicInfos { get; set; }
        public DbSet<ItemInfo> Items { get; set; }
        public DbSet<UserItem> UserItems { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<ExpireInfo> ExpireInfos { get; set; }
        public DbSet<RentalInformation> RentalInformations { get; set; }
        public DbSet<SealedInfo> SealedInfos { get; set; }
        public DbSet<Awake> Awakes { get; set; }
        public DbSet<GTMap> GTMaps { get; set; }
        public DbSet<DragonInfo> DragonInfos { get; set; }
        public DbSet<QuestInfo> QuestInfos { get; set; }
        public DbSet<BuffInfo> BuffInfos { get; set; }
        public DbSet<GuildBuffInfo> GuildBuffInfos { get; set; }
        public DbSet<MineZone> MineZones { get; set; }
        public DbSet<AuctionInfo> AuctionInfos { get; set; }
        public DbSet<GameShopItem> GameShopItems { get; set; }
        public DbSet<CharacterInfo> CharacterInfos { get; set; }

        public GameDbContext() { }

        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=game.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Envir>();
            modelBuilder.Ignore<MirConnection>();
            modelBuilder.Ignore<GuildObject>();
            modelBuilder.Ignore<MapObject>();
            modelBuilder.Ignore<PlayerObject>();

            modelBuilder.Entity<ItemInfo>()
                .HasOne(i => i.Stats)
                .WithOne()
                .HasForeignKey<Stats>("ItemInfoIndex");

            modelBuilder.Entity<UserItem>()
                .HasOne(u => u.Info)
                .WithMany()
                .HasForeignKey(u => u.ItemIndex);

            modelBuilder.Entity<UserItem>()
                .HasMany(u => u.Slots)
                .WithOne()
                .HasForeignKey("ParentItemID");
        }
    }
}
