using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APITask.Models;

public class Task
{
    [Key]
    public Guid taskID {get;set;}

    [ForeignKey("CategoryID")]
    public Guid CategoryID;

    [Required]
    [MaxLength(200  )]
    public string tittle;
    public string description;
    public priority taskPriority;
    public DateTime creationDate;
    public virtual Category category{get;set;}

    [NotMapped]
    public string summary;
}

public enum priority
{
    Low,
    medium,
    high,  
}



