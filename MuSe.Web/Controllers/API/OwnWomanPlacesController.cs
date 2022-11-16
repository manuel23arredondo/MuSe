namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Repositories;

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
            return Ok(this.repository.GetAll());
        }
    }
}
