namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using MuSe.Web.Helpers;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class MonitorsController : Controller
    {
        private readonly IMonitorRepository monitorRepository;
        private readonly IUserHelper userHelper;


        public MonitorsController(IMonitorRepository monitorRepository, IUserHelper userHelper)
        {
            this.monitorRepository = monitorRepository;
            this.userHelper = userHelper;
        }

        [HttpGet]
        public IActionResult GetMonitors()
        {
            return Ok(this.monitorRepository.GetMonitorWithUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Monitor>> GetMonitor(string id)
        {
            var monitor = await this.monitorRepository.GetMonitorWithUserByIdAsync(id);

            if (monitor == null)
            {
                return NotFound();
            }

            return monitor;
        }

        [HttpPost]
        public async Task<IActionResult> PostMonitor([FromBody] MonitorResponse monitorResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userHelper.GetUserByEmailAsync(monitorResponse.Email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = monitorResponse.FirstName,
                    LastName = monitorResponse.LastName,
                    Email = monitorResponse.Email,
                    UserName = monitorResponse.Email
                };
                var result = await userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    return BadRequest("Error no se pudo crear el usuario");
                }
                var monitor = new Monitor
                {
                    User = user
                };
                var newMonitor = await monitorRepository.CreateAsync(monitor);
                await userHelper.AddUserToRoleAsync(user, "Monitor");
                return Ok(newMonitor);
            }
            else
            {
                var monitor = await monitorRepository.GetMonitorWithUserByIdAsync(user.Id);
                if (monitor != null)
                {
                    return BadRequest("This monitor already exists");
                }
                else
                {
                    monitor = new Monitor
                    {
                        User = user
                    };
                    var newMonitor = await monitorRepository.CreateAsync(monitor);
                    await userHelper.AddUserToRoleAsync(user, "Monitor");
                    return Ok(newMonitor);
                }
            }
        }
    }
}
