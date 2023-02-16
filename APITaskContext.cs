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
        List<Category> categorySeed = new List<Category>();

        categorySeed.Add(new Category(){
            CategoryID = Guid.Parse("790eebd4-ed89-4366-8561-cce9488e52fa"),
            name = "Pending activities",
            peso = 20
            });
        
        categorySeed.Add(new Category(){
            CategoryID = Guid.Parse("790eebd4-ed89-4366-8561-cce9488e5202"),
            name = "Personal activities",
            peso = 50
            });
        

        modelBuilder.Entity<Category>(category => 
        {
            category.ToTable("Category");
            category.HasKey(p=> p.CategoryID);

            category.Property(p=> p.name).IsRequired().HasMaxLength(150);
            category.Property(p=> p.description).IsRequired(false).HasMaxLength(150);
            category.Property(p=> p.peso);

            category.HasData(categorySeed);
        });

        List<Models.Task> taskSeed = new List<Models.Task>();

        taskSeed.Add(new Models.Task(){
            TaskID = Guid.Parse("790eebd4-ed89-4366-8561-cce9488e5210"),
            CategoryID = Guid.Parse("790eebd4-ed89-4366-8561-cce9488e52fa"),
            Priority = priority.medium,
            tittle = "Public services pay",
            creationDate = DateTime.Now
        });

        taskSeed.Add(new Models.Task(){
            TaskID = Guid.Parse("790eebd4-ed89-4366-8561-cce9488e5211"),
            CategoryID = Guid.Parse("790eebd4-ed89-4366-8561-cce9488e5202"),
            Priority = priority.Low,
            tittle = "Finish Netflix series",
            creationDate = DateTime.Now
        });


        modelBuilder.Entity<Models.Task>(task => 
        {
            task.ToTable("Task");
            task.HasKey(p=> p.TaskID);
            task.HasOne(p=> p.categoryOfTask).WithMany(p => p.tasks).HasForeignKey(p => p.CategoryID);

            task.Property(p=> p.tittle).IsRequired().HasMaxLength(200);
            task.Property(p=> p.description).IsRequired(false);
            task.Property(p=> p.Priority);
            task.Property(p=> p.creationDate);
            task.Property(p=> p.Deadline);

            task.Ignore(p=> p.summary);
            
            task.HasData(taskSeed);
        });
    }
}