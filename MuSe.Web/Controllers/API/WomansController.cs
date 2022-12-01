namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using MuSe.Web.Helpers;
    using System;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class WomansController : Controller
    {
        private readonly IWomanRepository womanRepository;
        private readonly IUserHelper userHelper;


        public WomansController(IWomanRepository womanRepository, IUserHelper userHelper)
        {
            this.womanRepository = womanRepository;
            this.userHelper = userHelper;
        }

        [HttpGet]
        public IActionResult GetWomans()
        {
            return Ok(this.womanRepository.GetWomanWithUsers());
        }

        //Checar método
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetWoman(string id)
        {
            var woman = await this.womanRepository.GetUserByIdAsync(id);

            if (woman == null)
            {
                return NotFound();
            }

            return woman;
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> PostWoman([FromBody] UserResponse userResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await userHelper.GetUserByEmailAsync(userResponse.Username);
            if (user == null)
            {
                user = new User
                {
                    FirstName = userResponse.firstName,
                    LastName = userResponse.lastname,
                    Email = userResponse.email,
                    UserName = userResponse.email
                };
                var result = await userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    return BadRequest("Error no se pudo crear el usuario");
                }
                var woman = new Woman
                {
                    User = user
                };
                var newWoman = await womanRepository.CreateAsync(woman);
                await userHelper.AddUserToRoleAsync(user, "Woman");
                return Ok(newWoman);
            }
            else
            {
                var woman = await womanRepository.GetWomanWithUserByIdAsync(user.Id);
                if (woman != null)
                {
                    return BadRequest("This womamn already exists");
                }
                else
                {
                    //Crear usuario
                    woman = new Woman
                    {
                        User = user
                    };
                    var newWoman = await womanRepository.CreateAsync(woman);
                    await userHelper.AddUserToRoleAsync(user, "Woman");
                    return Ok(newWoman);
                }
            }
        }
    }
}
