using System.Text.Json.Serialization;

namespace APITask.Models;

public class Task
{
    //[Key]
    public Guid TaskID {get;set;}

    //[ForeignKey("CategoryID")]
    public Guid CategoryID {get;set;}

    //[Required]
    //[MaxLength(200)]
    public string tittle {get;set;}
    public string description {get;set;}
    public priority Priority {get;set;}
    public DateTime creationDate {get;set;}
    public DateTime Deadline {get;set;}
    public virtual Category categoryOfTask{get;set;}

    //[NotMapped]

    [JsonIgnore]
    public string summary {get;set;}
}

public enum priority
{
    Low,
    medium,
    high,  
}



