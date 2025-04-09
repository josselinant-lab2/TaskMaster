using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TaskMaster.Data;

namespace TaskMaster
{
  public static class MauiProgram
  {
    public static MauiApp CreateMauiApp()
    {
      var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

      var connectionString = "server=localhost;port=3306;database=appdb;user=root;password=root";

      builder.Services.AddDbContext<AppDbContext>(options =>
          options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

      // Initialisation de la base de données
      using (var scope = builder.Services.BuildServiceProvider().CreateScope())
      {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate();
      }

#if DEBUG
      builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
  }
}
