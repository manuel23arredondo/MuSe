namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Repositories;
    using MuSe.Web.Data;
    using MuSe.Web.Helpers;
    using MuSe.Web.Models;
    using System.Data;
    using System.Threading.Tasks;
    using MuSe.Web.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System;

    [Authorize(Roles = "Woman,Monitor")]
    public class WomanDiariesController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;
        private readonly IWomanDiaryRepository repository;

        public WomanDiariesController(IWomanDiaryRepository repository,
            ICombosHelper combosHelper, DataContext dataContext)
        {
            this.repository = repository;
            this.combosHelper = combosHelper;
            this.dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View(this.repository.GetWomanDiariesWithMoodsAndUsers(User.Identity.Name));
        }

        [Authorize(Roles = "Woman")]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new WomanDiaryViewModel
            {
                Moods = this.combosHelper.GetComboMoods()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WomanDiaryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var womanDiary = new WomanDiary
                {
                    Description = model.Description,
                    DiaryDate = model.DiaryDate,
                    //User = await this.dataContext.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name),
                    Woman = await this.dataContext.Womans.FirstOrDefaultAsync(u => u.User.UserName == User.Identity.Name),
                    Mood = await this.repository.GetMoodsByIdAsync(model.MoodId)
                };
                await this.repository.CreateAsync(womanDiary);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var womanDiary = await this.repository.GetWomanDiariesWithMoodsAndUsersByIdAsync(id.Value);

            if (womanDiary == null)
            {
                return NotFound();
            }

            var model = new WomanDiaryViewModel
            {
                Description = womanDiary.Description,
                DiaryDate = womanDiary.DiaryDate,
                Mood = womanDiary.Mood,
                MoodId = womanDiary.Mood.Id,
                Woman = await this.dataContext.Womans.FirstOrDefaultAsync(u => u.User.UserName == User.Identity.Name),
                Moods = this.combosHelper.GetComboMoods()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WomanDiaryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var womanDiary = new WomanDiary
                {
                    Id = model.Id,
                    Description = model.Description,
                    DiaryDate = model.DiaryDate,
                    Woman = await this.dataContext.Womans.FirstOrDefaultAsync(u => u.User.UserName == User.Identity.Name),
                    Mood = await this.repository.GetMoodsByIdAsync(model.MoodId)
                };

                await this.repository.UpdateAsync(womanDiary);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var womanDiary = await this.repository.GetWomanDiariesWithMoodsAndUsersByIdAsync(id.Value);

            if (womanDiary == null)
            {
                return NotFound();
            }
            return View(womanDiary);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var womanDiary = await this.repository.GetWomanDiariesWithMoodsAndUsersByIdAsync(id);

            try
            {
                await this.repository.DeleteAsync(womanDiary);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "No se pueden eliminar registros");
            }
            return View(womanDiary);
        }
    }
}
