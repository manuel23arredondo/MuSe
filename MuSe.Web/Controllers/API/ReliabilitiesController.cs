namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Repositories;

    [Route("api/[Controller]")]
    public class ReliabilitiesController : Controller
    {
        private readonly IReliabilityRepository repository;

        public ReliabilitiesController(IReliabilityRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetReliabilities()
        {
            return Ok(this.repository.GetAll());
        }
    }
}
