namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class MoodsController : Controller
    {
        private readonly IMoodRepository moodRepository;

        public MoodsController(IMoodRepository repository)
        {
            this.moodRepository = repository;
        }

        [HttpGet]
        public IActionResult GetMoods()
        {
            return Ok(this.moodRepository.GetMoodWithWomanDiaries());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mood>> GetMood(int id)
        {
            var mood = await this.moodRepository.GetByIdAsync(id);

            if (mood == null)
            {
                return NotFound();
            }

            return mood;
        }

        [HttpPost]
        public async Task<IActionResult> PostMood([FromBody] MoodResponse moodResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mood = new Mood
            {
                Description = moodResponse.Description,
                WomanDiaries = (System.Collections.Generic.ICollection<WomanDiary>)moodResponse.WomanDiaries,
                Id = moodResponse.Id
            };

            var newMood = await moodRepository.CreateAsync(mood);
            return Ok(newMood);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMood([FromRoute] int id, [FromBody] MoodResponse moodResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != moodResponse.Id)
            {
                return BadRequest();
            }

            var oldMood = await this.moodRepository.GetByIdAsync(id);

            if (oldMood == null)
            {
                return BadRequest("Mood not exists");
            }

            oldMood.Description = moodResponse.Description;
            oldMood.WomanDiaries = (System.Collections.Generic.ICollection<WomanDiary>)moodResponse.WomanDiaries;

            var updateMood = await moodRepository.UpdateAsync(oldMood);
            return Ok(updateMood);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMood([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mood = await this.moodRepository.GetByIdAsync(id);

            if (mood == null)
            {
                return BadRequest("Mood not exists");
            }

            await moodRepository.DeleteAsync(mood);
            return Ok(mood);
        }
    }
}
