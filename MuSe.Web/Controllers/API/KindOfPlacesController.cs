namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class KindOfPlacesController : Controller
    {
        private readonly IKindOfPlaceRepository kindOfPlaceRepository;

        public KindOfPlacesController(IKindOfPlaceRepository repository)
        {
            this.kindOfPlaceRepository = repository;
        }

        [HttpGet]
        public IActionResult GetKindOfPlaces()
        {
            return Ok(this.kindOfPlaceRepository.GetKindOfPlaceWithOwnWomanPlaces());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KindOfPlace>> GetKindOfPlace(int id)
        {
            var kindOfPlace = await this.kindOfPlaceRepository.GetByIdAsync(id);

            if (kindOfPlace == null)
            {
                return NotFound();
            }

            return kindOfPlace;
        }

        [HttpPost]
        public async Task<IActionResult> PostKindOfPlace([FromBody] KindOfPlaceResponse kindOfPlaceResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kindOfPlace = new KindOfPlace
            {
                Description = kindOfPlaceResponse.Description,
                OwnWomanPlaces = (System.Collections.Generic.ICollection<OwnWomanPlace>)kindOfPlaceResponse.OwnWomanPlaces,
                Id = kindOfPlaceResponse.Id
            };

            var newKindOfPlace = await kindOfPlaceRepository.CreateAsync(kindOfPlace);
            return Ok(newKindOfPlace);
        }
    }
}
