using System.Text.Json.Serialization;

namespace APITask.Models;

public class Category
{
    // [Key]
    public Guid CategoryID {get;set;}

    //[Required]
    //[MaxLength(150)]
    public string name {get;set;}
    public string description {get;set;}
    public int peso {get;set;}

    [JsonIgnore]
    public virtual ICollection<Task> tasks{get;set;}
}
