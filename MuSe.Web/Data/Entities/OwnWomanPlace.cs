using System.ComponentModel.DataAnnotations;

namespace MuSe.Web.Data.Entities
{
    public class OwnWomanPlace:IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Latitud")]
        public double Latitud { get; set; }

        [Required]
        [Display(Name = "Longitud")]
        public double Longitude { get; set; }

        public Woman Woman { get; set; }
        public KindOfPlace KindOfPlace { get; set; }
    }
}
