namespace CMS.Domain.Models.Category;

public class Category
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string Description { get; set; } 

    public ICollection<Content.Content> Contents { get; set; }
}
