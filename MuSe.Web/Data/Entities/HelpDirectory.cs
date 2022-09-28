namespace MuSe.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class HelpDirectory
    {
        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Nombre de la organización")]
        public string OrganizationName { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(15, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Número de celular")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(80, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        public HelpType HelpType { get; set; }
    }
}
