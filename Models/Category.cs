using System.ComponentModel.DataAnnotations;

namespace APITask.Models;

public class Category
{
    [Key]
    public Guid CategoryID {get;set;}

    [Required]
    [MaxLength(150)]
    public string name;
    public string description;
    public virtual ICollection<Task> task{get;set;}
}
