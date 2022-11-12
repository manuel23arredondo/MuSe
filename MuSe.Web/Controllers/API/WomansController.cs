namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Repositories;

    [Route("api/[Controller]")]
    public class WomansController : Controller
    {
        private readonly IWomanRepository repository;

        public WomansController(IWomanRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetWomans()
        {
            return Ok(this.repository.GetAll());
        }
    }
}
