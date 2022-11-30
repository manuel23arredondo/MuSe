namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class HelpTypesController : Controller
    {
        private readonly IHelpTypeRepository helpTypeRepository;

        public HelpTypesController(IHelpTypeRepository repository)
        {
            this.helpTypeRepository = repository;
        }

        [HttpGet]
        public IActionResult GetHelpTypes()
        {
            return Ok(this.helpTypeRepository.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<HelpType>> GetHelpType(int id)
        {
            var helpType = await this.helpTypeRepository.GetByIdAsync(id);

            if (helpType == null)
            {
                return NotFound();
            }

            return helpType;
        }

        [HttpPost]
        public async Task<IActionResult> PostHelpType([FromBody] HelpTypeResponse helpTypeResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var helpType = new HelpType
            {
                Description = helpTypeResponse.Description,
                HelpDirectories = (System.Collections.Generic.ICollection<HelpDirectory>)helpTypeResponse.HelpDirectories,
                Id = helpTypeResponse.Id
            };

            var newHelpType = await helpTypeRepository.CreateAsync(helpType);
            return Ok(newHelpType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHelpType([FromRoute] int id, [FromBody] HelpTypeResponse helpTypeResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != helpTypeResponse.Id)
            {
                return BadRequest();
            }

            var oldHelpType = await this.helpTypeRepository.GetByIdAsync(id);

            if (oldHelpType == null)
            {
                return BadRequest("Help type not exists");
            }

            oldHelpType.Description = helpTypeResponse.Description;
            oldHelpType.HelpDirectories = (System.Collections.Generic.ICollection<HelpDirectory>)helpTypeResponse.HelpDirectories;

            var updateHelpType = await helpTypeRepository.UpdateAsync(oldHelpType);
            return Ok(updateHelpType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHelpType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var helpType = await this.helpTypeRepository.GetByIdAsync(id);

            if (helpType == null)
            {
                return BadRequest("Help type not exists");
            }

            await helpTypeRepository.DeleteAsync(helpType);
            return Ok(helpType);
        }
    }
}
