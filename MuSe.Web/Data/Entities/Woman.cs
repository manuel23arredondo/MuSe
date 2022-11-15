namespace MuSe.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Woman : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Imagen")]
        public string ImageUrl { get; set; }

        public User User { get; set; }
        public ICollection<CurrentRiskSituation> CurrentRiskSituations { get; set; }    
        public ICollection<OwnWomanPlace> OwnWomanPlaces { get; set; }
        public ICollection<CodeTemp> CodeTemps { get; set; }
        public ICollection<WomanDiary> WomanDiaries { get; set; }
    }
}
