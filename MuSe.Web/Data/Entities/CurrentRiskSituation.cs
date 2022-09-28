namespace MuSe.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class CurrentRiskSituation
    {
        [Display(Name = "Clave")]
        public int Id { get; set; }

        [Display(Name = "Imagen")]
        public string Image { get; set; }

        public double Latitud { get; set; }

        public double Longitude { get; set; }

        public Woman Woman { get; set; }
    }
}
