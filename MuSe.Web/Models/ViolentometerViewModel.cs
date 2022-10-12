namespace MuSe.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MuSe.Web.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ViolentometerViewModel : Violentometer
    {
        [Display(Name = "Gravedad de la acción violenta")]
        public int ReliabilityId { get; set; }

        public IEnumerable<SelectListItem> Reliabilities { get; set; }
    }
}
