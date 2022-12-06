namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.IO;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class HelpDirectoriesController : Controller
    {
        private readonly IHelpDirectoryRepository helpDirectoryRepository;
        private readonly IHelpTypeRepository helpTypeRepository;

        public HelpDirectoriesController(IHelpDirectoryRepository repository, IHelpTypeRepository helpTypeRepository)
        {
            this.helpDirectoryRepository = repository;
            this.helpTypeRepository = helpTypeRepository;
        }

        [HttpGet]
        public IActionResult GetHelpDirectories()
        {
            return Ok(this.helpDirectoryRepository.GetAllHelpDirectoriesResponse());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HelpDirectoryResponse>> GetHelpDirectory(int id)
        {
            var helpDirectory = await this.helpDirectoryRepository.GetHelpDirectoriesResponseById(id);

            if (helpDirectory == null)
            {
                return NotFound();
            }

            return helpDirectory;
        }

        [HttpPost]
        public async Task<IActionResult> PostHelpDirectory([FromBody] HelpDirectoryResponse helpDirectoryResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var helpType = helpTypeRepository.GetHelpTypeByName(helpDirectoryResponse.HelpType);
            if (helpType == null)
                return BadRequest("Help type doesn´t exist");

            var helpDirectory = new HelpDirectory
            {
                OrganizationName = helpDirectoryResponse.OrganizationName,
                PhoneNumber = helpDirectoryResponse.PhoneNumber,
                Street = helpDirectoryResponse.Street,
                InsideNumber = helpDirectoryResponse.InsideNumber,
                OutsideNumber = helpDirectoryResponse.OutsideNumber,
                Colony = helpDirectoryResponse.Colony,
                PostCode = helpDirectoryResponse.PostCode,
                Email = helpDirectoryResponse.Email,
                Longitude = helpDirectoryResponse.Longitude,
                Latitude = helpDirectoryResponse.Latitude,
                HelpType = helpType
            };

            var newHelpDirectory = await helpDirectoryRepository.CreateAsync(helpDirectory);
            return Ok(newHelpDirectory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHelpDirectory([FromRoute] int id, [FromBody] HelpDirectoryResponse helpDirectoryResponse)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != helpDirectoryResponse.Id)
                return BadRequest();

            var oldHelpDirectory = await this.helpDirectoryRepository.GetByIdAsync(id);
            if (oldHelpDirectory == null)
                return BadRequest("The Help Directory does not exist.");

            var helpType = helpTypeRepository.GetHelpTypeByName(helpDirectoryResponse.HelpType);
            if (helpType == null)
                return BadRequest("Help type doesn´t exist");

            oldHelpDirectory.OrganizationName = helpDirectoryResponse.OrganizationName;
            oldHelpDirectory.PhoneNumber = helpDirectoryResponse.PhoneNumber;
            oldHelpDirectory.Street = helpDirectoryResponse.Street;
            oldHelpDirectory.InsideNumber = helpDirectoryResponse.InsideNumber;
            oldHelpDirectory.OutsideNumber = helpDirectoryResponse.OutsideNumber;
            oldHelpDirectory.Colony = helpDirectoryResponse.Colony;
            oldHelpDirectory.PostCode = helpDirectoryResponse.PostCode;
            oldHelpDirectory.Email = helpDirectoryResponse.Email;
            oldHelpDirectory.Longitude = helpDirectoryResponse.Longitude;
            oldHelpDirectory.Latitude = helpDirectoryResponse.Latitude;
            oldHelpDirectory.HelpType = helpType;

            var updatedHelpDirectory = await this.helpDirectoryRepository.UpdateAsync(oldHelpDirectory);

            return Ok(updatedHelpDirectory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHelpDirectory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var HelpDirectory = await this.helpDirectoryRepository.GetByIdAsync(id);
            if (HelpDirectory == null)
                return BadRequest("Help Directory not exists");

            await helpDirectoryRepository.DeleteAsync(HelpDirectory);
            return Ok(HelpDirectory);
        }
    }
}
