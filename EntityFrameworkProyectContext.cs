using System.Threading.Tasks;
namespace EntityFrameworkProyect.Context; 

using Microsoft.EntityFrameworkCore;
using EntityFrameworkProyect.Models;

public class EntityFrameworkProyectContext : DbContext
{
    public DbSet<Category> Categories{get;set;}
    public DbSet<Task> Tasks{get;set;}

    public EntityFrameworkProyectContext (DbContextOptions<EntityFrameworkProyectContext> options) : base(options){ }
}
