namespace MuSe.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class WomanMonitor
    {
        [Display(Name = "Clave")]
        public int Id { get; set; }

        public Monitor Monitor { get; set; }
        public Woman Woman { get; set; }
    }
}
