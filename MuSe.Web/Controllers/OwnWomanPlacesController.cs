namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using MuSe.Web.Data;
    using MuSe.Web.Helpers;
    using MuSe.Web.Models;
    using System.Data;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    [Authorize(Roles = "Woman,Monitor")]
    public class OwnWomanPlacesController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;
        private readonly IOwnWomanPlaceRepository repository;

        public OwnWomanPlacesController(IOwnWomanPlaceRepository repository,
            ICombosHelper combosHelper, DataContext dataContext)
        {
            this.repository = repository;
            this.combosHelper = combosHelper;
            this.dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View(this.repository.GetOwnWomanPlacesWithKindOfPlacesAndUsers(User.Identity.Name));
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
        public async Task<IActionResult> Create(OwnWomanPlaceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ownWomanPlace = new OwnWomanPlace
                {
                    Latitud = model.Latitud,
                    Longitude = model.Longitude,
                    User = await this.dataContext.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name),
                    KindOfPlace = await this.repository.GetKindOfPlacesByIdAsync(model.KindOfPlaceId)
                };
                await this.repository.CreateAsync(ownWomanPlace);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
