using log4net;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Server.MirDatabase;

namespace Server.MirForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Packet.IsServer = true;

            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            log4net.Config.XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            var services = new ServiceCollection();
            services.AddDbContext<GameDbContext>(options =>
                options.UseSqlite("Data Source=game.db"));

            services.AddMemoryCache();
            services.AddSingleton<AccountCacheService>();
            var serviceProvider = services.BuildServiceProvider();

            GlobalServices.AccountService = serviceProvider.GetRequiredService<AccountCacheService>();

            try
            {
                Settings.Load();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SMain());

                Settings.Save();
            }
            catch(Exception ex)
            {
                Logger.GetLogger().Error(ex);
            }
        }
    }
}
