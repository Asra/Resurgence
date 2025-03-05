using Microsoft.EntityFrameworkCore;

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

        }
    }
}
