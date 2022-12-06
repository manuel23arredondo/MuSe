namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class IncidentsController : Controller
    {
        private readonly IIncidentRepository incidentRepository;
        private readonly IViolentometerRepository violentometerRepository;

        public IncidentsController(IIncidentRepository incidentRepository, IViolentometerRepository violentometerRepository)
        {
            this.incidentRepository = incidentRepository;
            this.violentometerRepository = violentometerRepository;
        }

        [HttpGet]
        public IActionResult GetIncidents()
        {
            return Ok(this.incidentRepository.GetAllIncidentsResponse());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentResponse>> GetIncident(int id)
        {
            var incident = await this.incidentRepository.GetIncidentsResponseById(id);

            if (incident == null)
            {
                return NotFound();
            }

            return incident;
        }

        [HttpPost]
        public async Task<IActionResult> PostIncident([FromBody] IncidentResponse incidentResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var violentometer = violentometerRepository.GetViolentometerByName(incidentResponse.Violentometer);
            if (violentometer == null)
                return BadRequest("Violentometer doesn´t exist");

            var incident = new Incident
            {
                IncidentDescription= incidentResponse.IncidentDescription,
                AgressorDescription=incidentResponse.AgressorDescription,
                Longitude=incidentResponse.Longitude,
                Latitude=incidentResponse.Latitude,
                IncidentDate=incidentResponse.IncidentDate,
                //Woman = await incidentRepository.GetWoman(),
                Violentometer=violentometer
            };

            var newIncident = await incidentRepository.CreateAsync(incident);
            return Ok(newIncident);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident([FromRoute] int id, [FromBody] IncidentResponse incidentResponse)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != incidentResponse.Id)
                return BadRequest();

            var oldIncident = await this.incidentRepository.GetByIdAsync(id);
            if (oldIncident == null)
                return BadRequest("The Incident does not exist.");

            var violentometer = violentometerRepository.GetViolentometerByName(incidentResponse.Violentometer);
            if (violentometer == null)
                return BadRequest("Violentometer doesn´t exist");

            oldIncident.IncidentDescription= incidentResponse.IncidentDescription;
            oldIncident.AgressorDescription= incidentResponse.AgressorDescription;
            oldIncident.Longitude=incidentResponse.Longitude;
            oldIncident.Latitude=incidentResponse.Latitude;
            oldIncident.IncidentDate=incidentResponse.IncidentDate;
            oldIncident.Violentometer=violentometer;

            var updatedIncident = await this.incidentRepository.UpdateAsync(oldIncident);

            return Ok(updatedIncident);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var incident = await this.incidentRepository.GetByIdAsync(id);
            if (incident == null)
                return BadRequest("Incident not exists");

            await incidentRepository.DeleteAsync(incident);
            return Ok(incident);
        }
    }
}