namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Repositories;

    [Route("api/[Controller]")]
    public class MonitorsController : Controller
    {
        private readonly IMonitorRepository repository;

        public MonitorsController(IMonitorRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetMonitors()
        {
            return Ok(this.repository.GetAll());
        }
    }
}
