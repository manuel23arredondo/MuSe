﻿namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Repositories;

    [Route("api/[Controller]")]
    public class HelpTypesController : Controller
    {
        private readonly IHelpTypeRepository repository;

        public HelpTypesController(IHelpTypeRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetHelpTypes()
        {
            return Ok(this.repository.GetAll());
        }

        //[HttpPost]
        //public async Task<IActionResult> PostHelpType([FromBody])
        //{

        //}
    }
}
