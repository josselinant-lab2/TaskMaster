using TaskMaster.Services;
using TaskMaster.UI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskMaster.Data;
using TaskMaster;


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

        // Enregistrer le service et le ViewModel
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddTransient<RegisterPageViewModel>();

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
