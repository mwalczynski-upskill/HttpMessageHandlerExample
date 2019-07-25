namespace HttpMessageHandler.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    [Route("api/[controller]")]
    [ApiController]
    public class GitController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;

        public GitController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> Get(string userName)
        {
            var repositories = await _gitHubService.GetRepositories(userName);
            return Ok(repositories);
        }
    }
}
