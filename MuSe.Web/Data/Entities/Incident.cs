namespace MuSe.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Incident
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Descripción del incidente")]
        public string IncidentDescription { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Descripción del agresor")]
        public string AgressorDescription { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Longitud")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Latitud")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha de incidente")]
        public DateTime IncidentDate { get; set; }

        public Woman Woman { get; set; }
        public Violentometer Violentometer { get; set; }
    }
}
