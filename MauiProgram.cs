using TaskMaster.Services;
using TaskMaster.UI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskMaster.Data;
using TaskMaster;
using TaskMaster.UI.Views;


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

        // Enregistrement des services et ViewModels
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddTransient<TaskListViewModel>();
        builder.Services.AddTransient<RegisterPageViewModel>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<TaskListPage>();
        builder.Services.AddTransient<ITaskService, TaskService>(); 

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

