using VSMDivine.Api.Filter;
using Microsoft.AspNetCore.Mvc;

namespace VSMDivine.Api.Controllers
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(AuthorizationFilterAttribute))]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}