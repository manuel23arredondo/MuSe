namespace MuSe.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MuSe.Web.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class IncidentViewModel : Incident
    {
        [Display(Name = "Tipo de acción violenta")]
        public int ViolentometerId { get; set; }

        public IEnumerable<SelectListItem> Violentometers { get; set; }
    }
}
