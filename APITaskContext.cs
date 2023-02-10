using Microsoft.EntityFrameworkCore;
using APITask.Models;

namespace APITask.Context; 

public class APITaskContext : DbContext
{
    public DbSet<Category> Categories{get;set;}
    public DbSet<Models.Task> Tasks{get;set;}

    public APITaskContext (DbContextOptions<APITaskContext> options) : base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(category => 
        {
            category.ToTable("Category");
            category.HasKey(p=> p.CategoryID);

            category.Property(p=>p.name).IsRequired().HasMaxLength(150);
            category.Property(p=>p.description).IsRequired().HasMaxLength(150);

        });

        modelBuilder.Entity<Models.Task>(task => 
        {
            task.ToTable("Task");
            task.HasKey(p => p.taskID);
            task.HasOne(p => p.categoryInTask).WithMany(p => p.tasks).HasForeignKey(p => p.CategoryID);

            task.Property(p => p.tittle).IsRequired().HasMaxLength(200);
            task.Property(p => p.description);
            task.Property(p => p.Priority);
            task.Property(p => p.creationDate);

            task.Ignore(p=>p.summary);
        });
    }
}