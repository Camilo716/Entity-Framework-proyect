namespace EntityFrameworkProyect.Models;

public class Task
{
    public Guid taskID;
    public Guid categoryID;
    public string tittle;
    public string description;
    public priority taskPriority;
    public DateTime creationDate;
    public virtual Category category{get;set;}
}

public enum priority
{
    Low,
    medium,
    high,  
}



