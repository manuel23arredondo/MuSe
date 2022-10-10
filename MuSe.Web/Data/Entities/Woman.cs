namespace MuSe.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Woman : IEntity
    {
        public int Id { get; set; }

        public User User { get; set; }
        public ICollection<CurrentRiskSituation> CurrentRiskSituations { get; set; }    
        public ICollection<Incident> Incidents { get; set; }
        public ICollection<OwnWomanPlace> OwnWomanPlaces { get; set; }
        public ICollection<CodeTemp> CodeTemps { get; set; }
    }
}
