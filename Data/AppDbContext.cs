using Microsoft.EntityFrameworkCore;
using Windows.System;

public class AppDbContext : DbContext
{
  public DbSet<User> Users { get; set; }

  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      var connectionString = "server=localhost;port=3306;database=appdb;user=root;password=";
      optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
  }
}
