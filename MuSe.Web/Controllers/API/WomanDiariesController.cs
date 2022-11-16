namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Repositories;

    [Route("api/[Controller]")]
    public class WomanDiariesController : Controller
    {
        private readonly IWomanDiaryRepository repository;

        public WomanDiariesController(IWomanDiaryRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetWomanDiaries()
        {
            return Ok(this.repository.GetAll());
        }
    }
}
