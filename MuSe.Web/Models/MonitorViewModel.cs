namespace MuSe.Web.Models
{
    using Microsoft.AspNetCore.Http;
    using MuSe.Web.Data.Entities;
    using System.ComponentModel.DataAnnotations;
    public class MonitorViewModel:Monitor
    {
        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }

        [Display(Name = "Imágen")]
        public IFormFile ImageFile { get; set; }
    }
}
