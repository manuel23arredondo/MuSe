namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class WomansController : Controller
    {
        private readonly IWomanRepository repository;

        public WomansController(IWomanRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetWomans()
        {
            return Ok(this.repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Woman>> GetWoman(int id)
        {
            var woman = await this.repository.GetByIdAsync(id);

            if (woman == null)
            {
                return NotFound();
            }

            return woman;
        }
    }
}
