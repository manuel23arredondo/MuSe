namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Repositories;

    [Route("api/[Controller]")]
    public class MoodsController : Controller
    {
        private readonly IMoodRepository repository;

        public MoodsController(IMoodRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetMoods()
        {
            return Ok(this.repository.GetAll());
        }
    }
}
