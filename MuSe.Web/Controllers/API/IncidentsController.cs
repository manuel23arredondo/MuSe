namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class IncidentsController : Controller
    {
        private readonly IIncidentRepository repository;

        public IncidentsController(IIncidentRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetIncidents()
        {
            return Ok(this.repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Incident>> GetIncident(int id)
        {
            var incident = await this.repository.GetByIdAsync(id);

            if (incident == null)
            {
                return NotFound();
            }

            return incident;
        }
    }
}