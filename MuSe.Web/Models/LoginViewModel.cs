namespace MuSe.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recuérdame")]
        public bool RememberMe { get; set; }
    }
}
