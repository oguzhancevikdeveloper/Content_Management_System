﻿using CMS.Domain.Models.User;

namespace CMS.Domain.Models.Content;

public class Content
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Language { get; set; }
    public string ImageUrl { get; set; }

    public Category.Category  Category { get; set; }
    public ICollection<ContentVariant> Variants { get; set; }
    public Content()
    {
        Id = Guid.NewGuid();
    }

}

