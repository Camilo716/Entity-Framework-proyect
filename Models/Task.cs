using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APITask.Models;

public class Task
{
    [Key]
    public Guid taskID {get;set;}

    [ForeignKey("CategoryID")]
    public Guid CategoryID {get;set;}

    [Required]
    [MaxLength(200)]
    public string tittle {get;set;}
    public string description {get;set;}
    public priority taskPriority {get;set;}
    public DateTime creationDate {get;set;}
    public virtual Category category{get;set;}

    [NotMapped]
    public string summary {get;set;}
}

public enum priority
{
    Low,
    medium,
    high,  
}



