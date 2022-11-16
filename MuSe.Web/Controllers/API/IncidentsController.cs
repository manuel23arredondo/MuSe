namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Repositories;

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
    }
}