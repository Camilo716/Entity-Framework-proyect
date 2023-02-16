using APITask.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<APITaskContext>(opt => opt.UseInMemoryDatabase("taskDb"));
builder.Services.AddSqlServer<APITaskContext>(builder.Configuration.GetConnectionString("TaskDb"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", 
    async ([FromServices] APITaskContext dbContext)=>
    {
        dbContext.Database.EnsureCreated();

        return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
    }
);

app.MapGet("/API/tasks",
    async ([FromServices] APITaskContext dbContext)=>
    {
        return Results.Ok(
            dbContext.Tasks
                .Include(p => p.categoryOfTask)
        );
    }
);

app.MapPost("/API/tasks",
    async ([FromServices] APITaskContext dbContext, [FromBody] APITask.Models.Task task)=>
    {
        task.TaskID = Guid.NewGuid();
        task.creationDate = DateTime.Now;

        await dbContext.AddAsync(task);
        await dbContext.SaveChangesAsync();

        Results.Ok();
    }
);

app.MapPut("/API/tasks/{id}",
    async ([FromServices] APITaskContext dbContext, [FromBody] APITask.Models.Task task, [FromRoute] Guid id) =>
    {
        var actualTask = dbContext.Tasks.Find(id);

        if (actualTask != null)
        {
            actualTask.CategoryID = task.CategoryID;
            actualTask.tittle = task.tittle;
            actualTask.Priority = task.Priority;
            actualTask.description = task.description;

            await dbContext.SaveChangesAsync();

		    Results.Ok();
        }
        Results.NotFound();
    }
);

app.MapDelete("/API/tasks/{id}",
    async ([FromServices] APITaskContext dbContext, [FromRoute] Guid id) =>
    {
        var actualTask = dbContext.Tasks.Find(id);

        if (actualTask != null)
        {
            dbContext.Remove(actualTask);

            await dbContext.SaveChangesAsync();
		    Results.Ok();
        }

        Results.NotFound();
    }
);


app.MapGet("/API/categories",
    async ([FromServices] APITaskContext dbContext)=>
    {
        return Results.Ok(
            dbContext.Categories
        );
    }
);

app.MapPost("/API/categories",
     async([FromServices] APITaskContext dbcontext, [FromBody] APITask.Models.Category category) =>
    {
        category.CategoryID = Guid.NewGuid();

        await dbcontext.AddAsync(category);
        await dbcontext.SaveChangesAsync();

        Results.Ok();
    }
);

app.MapPut("API/categories/{id}", 
    async([FromServices] APITaskContext dbcontext, [FromBody] APITask.Models.Category category, [FromRoute] Guid id)=>
    {
        var actualCategory = dbcontext.Categories.Find(id);

        if (actualCategory != null)
        {
            actualCategory.name = category.name;
            actualCategory.description = category.description;
            actualCategory.peso = category.peso;

            await dbcontext.SaveChangesAsync();

            Results.Ok();
        }

        Results.NotFound();
    }
);

app.MapDelete("/API/categories/{id}",
    async ([FromServices] APITaskContext dbContext, [FromRoute] Guid id) =>
    {
        var actualCategory = dbContext.Categories.Find(id);

        if (actualCategory != null)
        {
            dbContext.Remove(actualCategory);

            await dbContext.SaveChangesAsync();
		    Results.Ok();
        }
        
        Results.NotFound();
    }
);


app.Run("https://localhost:7157");

 