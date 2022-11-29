namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

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
            return Ok(this.repository.GetMonitorsWithUsers());
        }


        // Checar método
        [HttpGet("{id}")]
        public async Task<ActionResult<Monitor>> GetMonitor(int id)
        {
            var monitor = await this.repository.GetByIdAsync(id);

            if (monitor == null)
            {
                return NotFound();
            }

            return monitor;
        }
    }
}
