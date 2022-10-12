namespace MuSe.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MuSe.Web.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class DirectorViewModel : HelpDirectory
    {
        [Display(Name = "Tipo de ayuda")]
        public int HelpTypeId { get; set; }

        public IEnumerable<SelectListItem> HelpTypes { get; set; }
    }
}
