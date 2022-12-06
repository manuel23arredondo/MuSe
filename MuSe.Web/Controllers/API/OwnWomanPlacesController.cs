namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class OwnWomanPlacesController : Controller
    {
        private readonly IOwnWomanPlaceRepository ownWomanPlacerepository;
        private readonly IKindOfPlaceRepository kindOfPlaceRepository;

        public OwnWomanPlacesController(IOwnWomanPlaceRepository ownWomanPlacerepository, IKindOfPlaceRepository kindOfPlaceRepository)
        {
            this.ownWomanPlacerepository = ownWomanPlacerepository;
            this.kindOfPlaceRepository = kindOfPlaceRepository;
        }

        [HttpGet]
        public IActionResult GetOwnWomanPlaces()
        {
            return Ok(this.ownWomanPlacerepository.GetAllOwnWomanPlacesResponse());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OwnWomanPlaceResponse>> GetOwnWomanPlace(int id)
        {
            var ownWomanPlace = await this.ownWomanPlacerepository.GetOwnWomanPlaceResponseById(id);

            if (ownWomanPlace == null)
            {
                return NotFound();
            }

            return ownWomanPlace;
        }

        [HttpPost]
        public async Task<IActionResult> PostOwnWomanPlace([FromBody] OwnWomanPlaceResponse ownWomanPlaceResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kindOfPlace = kindOfPlaceRepository.GetKindOfPlaceByName(ownWomanPlaceResponse.KindOfPlace);
            if (kindOfPlace == null)
                return BadRequest("Kind Of Place doesn´t exist");

            var ownWomaPlace = new OwnWomanPlace
            {
                Latitud = ownWomanPlaceResponse.Latitud,
                Longitude= ownWomanPlaceResponse.Longitude,
                //Woman = await incidentRepository.GetWoman(),
                KindOfPlace = kindOfPlace
            };

            var newOwnWomanPlace = await ownWomanPlacerepository.CreateAsync(ownWomaPlace);
            return Ok(newOwnWomanPlace);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwnWomaPlace([FromRoute] int id, [FromBody] OwnWomanPlaceResponse ownWomanPlaceResponse)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != ownWomanPlaceResponse.Id)
                return BadRequest();

            var oldOwnWomanPlace= await this.ownWomanPlacerepository.GetByIdAsync(id);
            if (oldOwnWomanPlace == null)
                return BadRequest("The Incident does not exist.");

            var kindOfPlace = kindOfPlaceRepository.GetKindOfPlaceByName(ownWomanPlaceResponse.KindOfPlace);
            if (kindOfPlace == null)
                return BadRequest("Kind Of Place doesn´t exist");

            oldOwnWomanPlace.Latitud = ownWomanPlaceResponse.Latitud;
            oldOwnWomanPlace.Longitude = ownWomanPlaceResponse.Longitude;
            oldOwnWomanPlace.KindOfPlace = kindOfPlace;

            var updatedOwnWomanPlace = await this.ownWomanPlacerepository.UpdateAsync(oldOwnWomanPlace);
            return Ok(updatedOwnWomanPlace);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ownWomanPlace = await this.ownWomanPlacerepository.GetByIdAsync(id);
            if (ownWomanPlace == null)
                return BadRequest("Own woman place not exists");

            await ownWomanPlacerepository.DeleteAsync(ownWomanPlace);
            return Ok(ownWomanPlace);
        }
    }
}
