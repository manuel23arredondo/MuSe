namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

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
            return Ok(this.repository.GetMoodWithWomanDiaries());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mood>> GetMood(int id)
        {
            var mood = await this.repository.GetByIdAsync(id);

            if (mood == null)
            {
                return NotFound();
            }

            return mood;
        }
    }
}
