using Microsoft.EntityFrameworkCore;
using Server.Library.MirDatabase;
using Server.MirEnvir;
using Server.MirNetwork;
using Server.MirObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

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
        public DbSet<ItemInfo> ItemInfos { get; set; }
        public DbSet<UserItem> UserItems { get; set; }
        public DbSet<MonsterInfo> MonsterInfos { get; set; }
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
        public DbSet<AccountInfo> AccountInfos { get; set; }
        public DbSet<MailInfo> MailInfos { get; set; }
        public DbSet<MountInfo> MountInfos { get; set; }
        public DbSet<GuildRank> GuildRanks { get; set; }
        public DbSet<GuildBuff> GuildBuffs { get; set; }
        public DbSet<GuildMember> GuildMembers { get; set; }
        public DbSet<UserIntelligentCreature> UserIntelligentCreatures { get; set; }
        public DbSet<UserMagic> UserMagics { get; set; }
        public DbSet<QuestProgressInfo> QuestProgressInfos { get; set; }
        public DbSet<QuestFlagTask> QuestFlagTasks { get; set; }
        public DbSet<QuestFlagTaskProgress> QuestFlagTaskProgresses { get; set; }
        public DbSet<QuestItemTask> QuestItemTasks { get; set; }
        public DbSet<QuestItemTaskProgress> QuestItemTaskProgresses { get; set; }
        public DbSet<QuestKillTask> QuestKillTasks { get; set; }
        public DbSet<QuestKillTaskProgress> QuestKillTaskProgresses { get; set; }
        public DbSet<ItemRentalInformation> ItemRentalInformations { get; set; }
        public DbSet<ConquestInfo> ConquestInfos { get; set; }
        public DbSet<ConquestGuildInfo> ConquestGuildInfos { get; set; }
        public DbSet<ConquestGuildArcherInfo> ConquestGuildArcherInfos { get; set; }
        public DbSet<ConquestGuildGateInfo> ConquestGuildGateInfos { get; set; }
        public DbSet<ConquestGuildWallInfo> ConquestGuildWallInfos { get; set; }
        public DbSet<ConquestGuildSiegeInfo> ConquestGuildSiegeInfos { get; set; }
        public DbSet<ConquestGuildFlagInfo> ConquestGuildFlagInfos { get; set; }
        public DbSet<ConquestArcherInfo> ConquestArcherInfos { get; set; }
        public DbSet<ConquestGateInfo> ConquestGateInfos { get; set; }
        public DbSet<ConquestWallInfo> ConquestWallInfos { get; set; }
        public DbSet<ConquestSiegeInfo> ConquestSiegeInfos { get; set; }
        public DbSet<ConquestFlagInfo> ConquestFlagInfos { get; set; }
        public DbSet<RecipeInfo> RecipeInfos { get; set; }
        public DbSet<IntelligentCreatureInfo> IntelligentCreatureInfos { get; set; }
        public DbSet<IntelligentCreatureItemFilter> IntelligentCreatureItemFilters { get; set; }
        public DbSet<PetInfo> PetInfos { get; set; }
        public DbSet<FriendInfo> FriendInfos { get; set; }

        public GameDbContext() { }

        public GameDbContext(DbContextOptions<GameDbContext> options) 
        : base(options) 
        {
            ChangeTracker.Tracked += OnEntityTracked;
        }

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

            // Map the JSON properties to database columns.
            modelBuilder.Entity<CharacterInfo>(entity =>
            {
                entity.Property(e => e.InventoryJson);
                entity.Property(e => e.EquipmentJson);
                entity.Property(e => e.TradeJson);
                entity.Property(e => e.QuestInventoryJson);
                entity.Property(e => e.RefineJson);

                // The array properties are marked as [NotMapped] so EF Core ignores them.
                entity.Ignore(e => e.Inventory);
                entity.Ignore(e => e.Equipment);
                entity.Ignore(e => e.Trade);
                entity.Ignore(e => e.QuestInventory);
                entity.Ignore(e => e.Refine);
            });
        }

        // This event fires when an entity is tracked (loaded or added).
        private void OnEntityTracked(object sender, EntityTrackedEventArgs e)
        {
            // Only process entities loaded from the database.
            if (!e.FromQuery)
                return;

            if (e.Entry.Entity is CharacterInfo character)
            {
                // For each JSON-backed property, if there is no data,
                // we initialise the in-memory array to its fixed size.
                if (string.IsNullOrEmpty(character.InventoryJson))
                {
                    character.Inventory = new UserItem[46];
                }
                else
                {
                    character.Inventory = JsonSerializer.Deserialize<UserItem[]>(character.InventoryJson);
                }

                if (string.IsNullOrEmpty(character.EquipmentJson))
                {
                    character.Equipment = new UserItem[14];
                }
                else
                {
                    character.Equipment = JsonSerializer.Deserialize<UserItem[]>(character.EquipmentJson);
                }

                if (string.IsNullOrEmpty(character.TradeJson))
                {
                    character.Trade = new UserItem[10];
                }
                else
                {
                    character.Trade = JsonSerializer.Deserialize<UserItem[]>(character.TradeJson);
                }

                if (string.IsNullOrEmpty(character.QuestInventoryJson))
                {
                    character.QuestInventory = new UserItem[40];
                }
                else
                {
                    character.QuestInventory = JsonSerializer.Deserialize<UserItem[]>(character.QuestInventoryJson);
                }

                if (string.IsNullOrEmpty(character.RefineJson))
                {
                    character.Refine = new UserItem[16];
                }
                else
                {
                    character.Refine = JsonSerializer.Deserialize<UserItem[]>(character.RefineJson);
                }
            }

            if (e.Entry.Entity is UserItem userItem)
            {
                if (string.IsNullOrEmpty(userItem.SlotsJson))
                {
                    userItem.Slots = new UserItem[0];
                }
            }
        }

        public override int SaveChanges()
        {
            UpdateJsonProperties();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateJsonProperties();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateJsonProperties()
        {
            // For every CharacterInfo entity being added or modified,
            // serialise the in-memory arrays into JSON strings.
            foreach (var entry in ChangeTracker.Entries<CharacterInfo>()
                                              .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                entry.Entity.InventoryJson = JsonSerializer.Serialize(entry.Entity.Inventory);
                entry.Entity.EquipmentJson = JsonSerializer.Serialize(entry.Entity.Equipment);
                entry.Entity.TradeJson = JsonSerializer.Serialize(entry.Entity.Trade);
                entry.Entity.QuestInventoryJson = JsonSerializer.Serialize(entry.Entity.QuestInventory);
                entry.Entity.RefineJson = JsonSerializer.Serialize(entry.Entity.Refine);
            }

            foreach (var entry in ChangeTracker.Entries<UserItem>()
                                              .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                entry.Entity.SlotsJson = JsonSerializer.Serialize(entry.Entity.Slots);
            }
        }
    }
}
