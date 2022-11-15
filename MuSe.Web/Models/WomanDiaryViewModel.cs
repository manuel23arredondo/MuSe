namespace MuSe.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MuSe.Web.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class WomanDiaryViewModel : WomanDiary
    {
        [Display(Name = "Sentimiento")]
        public int MoodId { get; set; }

        public IEnumerable<SelectListItem> Moods { get; set; }
    }
}
