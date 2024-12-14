using Microsoft.EntityFrameworkCore;
using TaskManagement.Model.Entities;
using Task = TaskManagement.Model.Entities.Task;

namespace TaskManagement.Model
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Task>(taskOptions =>
            {
                taskOptions.ToTable("Task");

                taskOptions.HasKey(t => t.Id);

                taskOptions.Property(t => t.Title)
                    .HasMaxLength(500)
                    .IsRequired();

                taskOptions.Property(t => t.Description)
                    .HasMaxLength(2000)
                    .IsRequired(false);
            });

            modelBuilder.Entity<Project>(projectOptions =>
            {
                projectOptions.ToTable("Project");

                projectOptions.HasKey(p => p.Id);

                projectOptions.Property(p => p.Title)
                      .HasMaxLength(500)
                      .IsRequired();

                projectOptions.Property(p => p.Description)
                      .HasMaxLength(2000)
                      .IsRequired(false);

                projectOptions.HasMany(p => p.Tasks)
                       .WithOne(t => t.Project)
                       .HasForeignKey("project_id")
                       .IsRequired();
            });

            modelBuilder.Entity<User>(userOptions =>
            {
                userOptions.ToTable("User_");

                userOptions.HasKey(u => u.Id);

                userOptions.Property(u => u.Username)
                           .HasMaxLength(30)
                           .IsRequired();

                userOptions.Property(u => u.Password)
                           .HasMaxLength(30)
                           .IsRequired();

                userOptions.Property(u => u.FirstName)
                           .IsRequired();

                userOptions.Property(u => u.LastName)
                           .IsRequired();

                userOptions.HasMany(u => u.Projects)
                           .WithMany(p => p.Users)
                           .UsingEntity<Dictionary<string, object>>("UserOnAProject",
                           t => t.HasOne<Project>().WithMany().HasForeignKey("project_id"),
                           t => t.HasOne<User>().WithMany().HasForeignKey("user_id"));

            });


        }
    }
}
