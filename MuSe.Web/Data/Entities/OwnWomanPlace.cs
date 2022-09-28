using System.ComponentModel.DataAnnotations;

namespace MuSe.Web.Data.Entities
{
    public class OwnWomanPlace
    {
        [Display(Name = "Clave")]
        public int Id { get; set; }

        public double Latitud { get; set; }

        public double Longitude { get; set; }

        public Woman Woman { get; set; }
        public KindOfPlace KindOfPlace { get; set; }
    }
}
