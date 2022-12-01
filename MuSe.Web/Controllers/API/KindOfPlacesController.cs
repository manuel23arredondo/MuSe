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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutKindOfPlace([FromRoute] int id, [FromBody] KindOfPlaceResponse kindOfPlaceResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kindOfPlaceResponse.Id)
            {
                return BadRequest();
            }

            var oldKindOfPlace = await this.kindOfPlaceRepository.GetByIdAsync(id);

            if (oldKindOfPlace == null)
            {
                return BadRequest("Help type not exists");
            }

            oldKindOfPlace.Description = kindOfPlaceResponse.Description;
            oldKindOfPlace.OwnWomanPlaces = (System.Collections.Generic.ICollection<OwnWomanPlace>)kindOfPlaceResponse.OwnWomanPlaces;

            var updateKindOfPlace = await kindOfPlaceRepository.UpdateAsync(oldKindOfPlace);
            return Ok(updateKindOfPlace);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKindOfPlace([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kindOfPlace = await this.kindOfPlaceRepository.GetByIdAsync(id);

            if (kindOfPlace == null)
            {
                return BadRequest("Kind of place not exists");
            }

            await kindOfPlaceRepository.DeleteAsync(kindOfPlace);
            return Ok(kindOfPlace);
        }
    }
}
