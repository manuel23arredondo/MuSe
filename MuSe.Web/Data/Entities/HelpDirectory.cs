namespace MuSe.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class HelpDirectory:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(200, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Nombre de la organización")]
        public string OrganizationName { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(15, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Número de celular")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Calle")]
        public string Street { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Número interior")]
        public string InsideNumber { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Número interior")]
        public string OutsideNumber { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Colonia")]
        public string Colony { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Código postal")]
        public int PostCode { get; set; }

        [Display(Name = "Dirección")]
        public string FullName => $"{Street} {OutsideNumber}, Número interior: {InsideNumber} , {Colony} {PostCode}";

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Longitud")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Latitud")]
        public double Latitude { get; set; }

        public HelpType HelpType { get; set; }
    }
}
