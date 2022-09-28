namespace MuSe.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Woman : IEntity
    {
        [Display(Name = "Clave")]
        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<WomanMonitor> WomanMonitors { get; set; }
        public ICollection<CurrentRiskSituation> CurrentRiskSituations { get; set; }    
        public ICollection<Incident> Incidents { get; set; }
        public ICollection<OwnWomanPlace> OwnWomanPlaces { get; set; }
        public ICollection<WomanDiary> WomanDiaries { get; set; }
    }
}
