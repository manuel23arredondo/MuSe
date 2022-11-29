namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

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
            return Ok(this.repository.GetAllWomanDiariesWithMoodsAndUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WomanDiary>> GetWomanDiary(int id)
        {
            var womanDiary = await this.repository.GetWomanDiariesWithMoodsAndUsersByIdAsync(id);

            if (womanDiary == null)
            {
                return NotFound();
            }

            return womanDiary;
        }
    }
}
