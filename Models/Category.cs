namespace EntityFrameworkProyect.Models;

    public class Category
    {
        public Guid categoryID;
        public string name;
        public string description;
        public virtual ICollection<Task> task{get;set;}
    }
