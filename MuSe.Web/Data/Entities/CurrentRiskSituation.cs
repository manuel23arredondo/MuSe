namespace MuSe.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class CurrentRiskSituation
    {
        public int Id { get; set; }

        [Display(Name = "Imagen")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "Latitud")]
        public double Latitud { get; set; }

        [Required]
        [Display(Name = "Longitud")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha actual")]
        public DateTime CurrentDate
        {
            get
            {
                return DateTime.Now;
            }
        }

        public Woman Woman { get; set; }
    }
}
