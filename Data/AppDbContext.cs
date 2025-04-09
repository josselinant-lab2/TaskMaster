using Microsoft.EntityFrameworkCore;
using TaskMaster.Models;

namespace TaskMaster.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Statut> Statuts { get; set; }
        public DbSet<Priorite> Priorites { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Etiquette> Etiquettes { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<RelationUserTasks> RelationUserTasks { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }
        public DbSet<Assimiler> Assimilations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration des relations
            modelBuilder.Entity<Categorie>()
                .HasOne(c => c.User)
                .WithMany(u => u.Categories)
                .HasForeignKey(c => c.Id_User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Etiquette>()
                .HasOne(e => e.User)
                .WithMany(u => u.Etiquettes)
                .HasForeignKey(e => e.Id_User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.Task>()
                .HasOne(t => t.Categorie)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.Id_Categorie)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.Task>()
                .HasOne(t => t.Priorite)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.Id_Priorite)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.Task>()
                .HasOne(t => t.Statut)
                .WithMany(s => s.Tasks)
                .HasForeignKey(t => t.Id_Statut)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SubTask>()
                .HasOne(st => st.Task)
                .WithMany(t => t.SubTasks)
                .HasForeignKey(st => st.Id_Task)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RelationUserTasks>()
                .HasOne(r => r.User)
                .WithMany(u => u.RelationUserTasks)
                .HasForeignKey(r => r.Id_User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RelationUserTasks>()
                .HasOne(r => r.Task)
                .WithMany(t => t.RelationUserTasks)
                .HasForeignKey(r => r.Id_Task)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Commentaire>()
                .HasOne(c => c.User)
                .WithMany(u => u.Commentaires)
                .HasForeignKey(c => c.Id_User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Commentaire>()
                .HasOne(c => c.Task)
                .WithMany(t => t.Commentaires)
                .HasForeignKey(c => c.Id_Task)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Assimiler>()
                .HasKey(a => new { a.Id_Task, a.Id_Etiquette });

            modelBuilder.Entity<Assimiler>()
                .HasOne(a => a.Task)
                .WithMany(t => t.Assimilations)
                .HasForeignKey(a => a.Id_Task)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Assimiler>()
                .HasOne(a => a.Etiquette)
                .WithMany(e => e.Assimilations)
                .HasForeignKey(a => a.Id_Etiquette)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
