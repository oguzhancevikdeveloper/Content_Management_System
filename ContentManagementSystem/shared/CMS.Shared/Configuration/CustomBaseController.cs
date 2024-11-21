using CMS.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Shared.Configuration;

public class CustomBaseController : ControllerBase
{
    public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
    {
        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode,
        };
    }

}