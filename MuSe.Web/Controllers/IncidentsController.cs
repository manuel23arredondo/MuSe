namespace MuSe.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using MuSe.Web.Helpers;
    using MuSe.Web.Models;
    using System.Threading.Tasks;

    [Authorize(Roles = "Woman,Monitor")]
    public class IncidentsController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ICombosHelper combosHelper;
        private readonly IIncidentRepository repository;

        public IncidentsController(IIncidentRepository repository,
            ICombosHelper combosHelper, DataContext dataContext)
        {
            this.repository = repository;
            this.combosHelper = combosHelper;
            this.dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View(this.repository.GetIncidentsWithViolentometersAndUsers(User.Identity.Name));
        }

        [Authorize(Roles = "Woman")]
        [HttpGet]
        public IActionResult Create()
        {
            var model = new IncidentViewModel
            {
                Violentometers = this.combosHelper.GetComboViolentometers()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IncidentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var incident = new Incident
                {
                    AgressorDescription = model.AgressorDescription,
                    IncidentDescription = model.IncidentDescription,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    IncidentDate = model.IncidentDate,
                    User = await this.dataContext.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name),
                    Violentometer = await this.repository.GetViolentometersByIdAsync(model.ViolentometerId)
                };
                await this.repository.CreateAsync(incident);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
