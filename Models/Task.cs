namespace APITask.Models;

public class Task
{
    //[Key]
    public Guid taskID {get;set;}

    //[ForeignKey("CategoryID")]
    public Guid CategoryID {get;set;}

    //[Required]
    //[MaxLength(200)]
    public string tittle {get;set;}
    public string description {get;set;}
    public priority Priority {get;set;}
    public DateTime creationDate {get;set;}
    public virtual Category categoryInTask{get;set;}

    //[NotMapped]
    public string summary {get;set;}
}

public enum priority
{
    Low,
    medium,
    high,  
}



