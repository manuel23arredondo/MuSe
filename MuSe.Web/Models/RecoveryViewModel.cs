using System.ComponentModel.DataAnnotations;

namespace MuSe.Web.Models
{
    public class RecoveryViewModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
