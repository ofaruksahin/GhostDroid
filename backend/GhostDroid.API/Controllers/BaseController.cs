using Microsoft.AspNetCore.Mvc;

namespace GhostDroid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IMediator _meditor;

        protected BaseController(IMediator meditor)
        {
            _meditor = meditor ?? throw new ArgumentNullException(nameof(meditor));
        }
    }
}
