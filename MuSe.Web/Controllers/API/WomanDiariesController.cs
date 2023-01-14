namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class WomanDiariesController : Controller
    {
        private readonly IWomanDiaryRepository womanDiaryRepository;
        private readonly IMoodRepository moodRepository;
        private readonly IWomanRepository womanRepository;

        public WomanDiariesController(IWomanDiaryRepository womanDiaryRepository, IMoodRepository moodRepository, IWomanRepository womanRepository)
        {
            this.womanDiaryRepository = womanDiaryRepository;
            this.moodRepository = moodRepository;
            this.womanRepository = womanRepository;
        }

        [HttpGet]
        public IActionResult GetWomanDiaries()
        {
            return Ok(this.womanDiaryRepository.GetAllWomanDiariesResponse());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WomanDiaryResponse>> GetWomanDiary(int id)
        {
            var womanDiary = await this.womanDiaryRepository.GetWomanDiaryResponseById(id);

            if (womanDiary == null)
            {
                return NotFound();
            }

            return womanDiary;
        }

        [HttpPost]
        public async Task<IActionResult> PostWomanDiary([FromBody] WomanDiaryResponse womanDiaryResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var woman = womanRepository.GetWomanUserById(womanDiaryResponse.WomanUserId);
            if (woman == null)
                return BadRequest("Woman does not exist");

            var mood = moodRepository.GetMoodByName(womanDiaryResponse.Mood);
            if (mood == null)
                return BadRequest("Mood does not exist");

            var womanDiary = new WomanDiary
            {
                Description = womanDiaryResponse.Description,
                DiaryDate = womanDiaryResponse.DiaryDate,
                Woman = woman,
                Mood = mood
            };

            var newWomanDiary = await womanDiaryRepository.CreateAsync(womanDiary);
            return Ok(newWomanDiary);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident([FromRoute] int id, [FromBody] WomanDiaryResponse womanDiaryResponse)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != womanDiaryResponse.Id)
                return BadRequest();

            var oldWomanDiary = await this.womanDiaryRepository.GetByIdAsync(id);
            if (oldWomanDiary == null)
                return BadRequest("The woman diary does not exist.");

            var mood = moodRepository.GetMoodByName(womanDiaryResponse.Mood);
            if (mood == null)
                return BadRequest("Mood does not exist");

            var woman = womanRepository.GetWomanUserById(womanDiaryResponse.WomanUserId);
            if (woman == null)
                return BadRequest("Woman does not exist");

            oldWomanDiary.Description = womanDiaryResponse.Description;
            oldWomanDiary.DiaryDate = womanDiaryResponse.DiaryDate;
            oldWomanDiary.Woman = woman;
            oldWomanDiary.Mood = mood;

            var updatedWomanDiary = await this.womanDiaryRepository.UpdateAsync(oldWomanDiary);

            return Ok(updatedWomanDiary);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWomanDiary([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var womanDiary = await this.womanDiaryRepository.GetWomanDiariesByIdAsync(id);
            if (womanDiary == null)
                return BadRequest("Woman Diary does not exist");

            await womanDiaryRepository.DeleteAsync(womanDiary);
            return Ok(womanDiary);
        }
    }
}
