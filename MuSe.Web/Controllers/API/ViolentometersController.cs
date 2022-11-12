namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Repositories;

    [Route("api/[Controller]")]
    public class ViolentometersController : Controller
    {
        private readonly IViolentometerRepository repository;

        public ViolentometersController(IViolentometerRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetViolentometers()
        {
            return Ok(this.repository.GetAll());
        }
    }
}
