namespace MuSe.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MuSe.Web.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class OwnWomanPlaceViewModel : OwnWomanPlace
    {
        [Display(Name = "Tipo de lugar")]
        public int KindOfPlaceId { get; set; }

        public IEnumerable<SelectListItem> KindOfPlaces { get; set; }
    }
}
