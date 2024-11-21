using CMS.Domain.DTOs.Content;

namespace CMS.Domain.DTOs.User;

public class UserContentDto
{
    public ContentVariantDto ContentVariantDto { get; set; }
    public ContentDto ContentDto { get; set; }
    public UserDto UserDto { get; set; }
}
