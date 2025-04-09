using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TaskMaster.Data;

//THIS FILE IS USED BY EF CORE AND NOT SUPPOSED TO BE USED BY MAUI
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
  public AppDbContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

    optionsBuilder.UseMySql(
        "server=localhost;port=3306;user=root;password=root;database=appdb",
        new MySqlServerVersion(new Version(8, 0, 36))
    );

    return new AppDbContext(optionsBuilder.Options);
  }
}
