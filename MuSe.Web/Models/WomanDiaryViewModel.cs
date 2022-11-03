namespace MuSe.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MuSe.Web.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class WomanDiaryViewModel : WomanDiary
    {
        [Display(Name = "Tipo de sentimiento")]
        public int MoodId { get; set; }

        public int WomanId { get; set; }

        public IEnumerable<SelectListItem> Moods { get; set; }
        public IEnumerable<SelectListItem> Womans { get; set; }
    }
}
