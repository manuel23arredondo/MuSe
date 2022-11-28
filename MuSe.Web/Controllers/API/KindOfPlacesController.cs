namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class KindOfPlacesController : Controller
    {
        private readonly IKindOfPlaceRepository repository;

        public KindOfPlacesController(IKindOfPlaceRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetKindOfPlaces()
        {
            return Ok(this.repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KindOfPlace>> GetKindOfPlace(int id)
        {
            var kindOfPlace = await this.repository.GetByIdAsync(id);

            if (kindOfPlace == null)
            {
                return NotFound();
            }

            return kindOfPlace;
        }
    }
}
