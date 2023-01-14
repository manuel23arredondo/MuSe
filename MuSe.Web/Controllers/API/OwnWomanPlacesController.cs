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
        private readonly IWomanRepository womanRepository;

        public OwnWomanPlacesController(IOwnWomanPlaceRepository ownWomanPlacerepository, IKindOfPlaceRepository kindOfPlaceRepository, IWomanRepository womanRepository)
        {
            this.ownWomanPlacerepository = ownWomanPlacerepository;
            this.kindOfPlaceRepository = kindOfPlaceRepository;
            this.womanRepository = womanRepository;
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
                return BadRequest("Own woman place does not exist");
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
                return BadRequest("Kind Of Place does not exist");

            var woman = womanRepository.GetWomanUserById(ownWomanPlaceResponse.WomanUserId);
            if (woman == null)
                return BadRequest("Woman does not exist");

            var ownWomaPlace = new OwnWomanPlace
            {
                Latitud = ownWomanPlaceResponse.Latitud,
                Longitude= ownWomanPlaceResponse.Longitude,
                Woman = woman,
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
                return BadRequest("Own woman place does not exists");

            var oldOwnWomanPlace= await this.ownWomanPlacerepository.GetByIdAsync(id);
            if (oldOwnWomanPlace == null)
                return BadRequest("Incident does not exist");

            var kindOfPlace = kindOfPlaceRepository.GetKindOfPlaceByName(ownWomanPlaceResponse.KindOfPlace);
            if (kindOfPlace == null)
                return BadRequest("Kind Of Place does not exist");

            var woman = womanRepository.GetWomanUserById(ownWomanPlaceResponse.WomanUserId);
            if (woman == null)
                return BadRequest("Woman does not exist");

            oldOwnWomanPlace.Latitud = ownWomanPlaceResponse.Latitud;
            oldOwnWomanPlace.Longitude = ownWomanPlaceResponse.Longitude;
            oldOwnWomanPlace.Woman = woman;
            oldOwnWomanPlace.KindOfPlace = kindOfPlace;

            var updatedOwnWomanPlace = await this.ownWomanPlacerepository.UpdateAsync(oldOwnWomanPlace);
            return Ok(updatedOwnWomanPlace);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ownWomanPlace = await this.ownWomanPlacerepository.GetOwnWomanPlacesByIdAsync(id);
            if (ownWomanPlace == null)
                return BadRequest("Own woman place does not exist");

            await ownWomanPlacerepository.DeleteAsync(ownWomanPlace);
            return Ok(ownWomanPlace);
        }
    }
}
