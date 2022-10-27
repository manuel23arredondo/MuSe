namespace MuSe.Web.Models
{
    using Microsoft.AspNetCore.Http;
    using MuSe.Web.Data.Entities;
    using System.ComponentModel.DataAnnotations;
    public class WomanViewModel:Woman
    {
        [Display(Name = "Imagen")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }
    }
}
