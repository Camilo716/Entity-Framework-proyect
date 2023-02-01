using Microsoft.EntityFrameworkCore;
using APITask.Models;

namespace APITask.Context; 

public class APITaskContext : DbContext
{
    public DbSet<Category> Categories{get;set;}
    public DbSet<Models.Task> Tasks{get;set;}

    public APITaskContext (DbContextOptions<APITaskContext> options) : base(options){ }
}