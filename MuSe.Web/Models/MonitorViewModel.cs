namespace MuSe.Web.Models
{
    using Microsoft.AspNetCore.Http;
    using MuSe.Web.Data.Entities;
    using System.ComponentModel.DataAnnotations;
    public class MonitorViewModel:Monitor
    {
        [Display(Name = "Foto")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }
    }
}
