namespace MuSe.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class HelpDirectory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Nombre de la organización")]
        public string OrganizationName { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(15, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Número de celular")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Calle")]
        public string Street { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Número interior")]
        public string InsideNumber { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [Display(Name = "Número interior")]
        public int OutsideNumber { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Colonia")]
        public string Colony { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(6, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Código postal")]
        public int PostCode { get; set; }

        [Display(Name = "Dirección")]
        public string FullName => $"{Street} {InsideNumber} {OutsideNumber} {Colony} {PostCode}";

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        public HelpType HelpType { get; set; }
    }
}
