namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Repositories;

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
    }
}
