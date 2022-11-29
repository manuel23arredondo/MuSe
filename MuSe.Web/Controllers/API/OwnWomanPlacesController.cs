namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class OwnWomanPlacesController : Controller
    {
        private readonly IOwnWomanPlaceRepository repository;

        public OwnWomanPlacesController(IOwnWomanPlaceRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetOwnWomanPlaces()
        {
            return Ok(this.repository.GetAllOwnWomanPlacesWithKindOfPlacesAndUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OwnWomanPlace>> GetOwnWomanPlace(int id)
        {
            var ownWomanPlace = await this.repository.GetOwnWomanPlacesWithKindOfPlacesAndUsersByIdAsync(id);

            if (ownWomanPlace == null)
            {
                return NotFound();
            }

            return ownWomanPlace;
        }
    }
}
