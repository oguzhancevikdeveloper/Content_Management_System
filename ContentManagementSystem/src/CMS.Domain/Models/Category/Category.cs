namespace CMS.Domain.Models.Category;

public class Category
{
    public Guid Id { get; set; } 
    public string Name { get; set; } 
    public string Description { get; set; } 

    public ICollection<Content.Content> Contents { get; set; }

    public Category()
    {
        Id = Guid.NewGuid();
    }
}
