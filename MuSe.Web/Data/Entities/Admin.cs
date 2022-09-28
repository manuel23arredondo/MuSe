namespace MuSe.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Admin : IEntity
    {
        [Display(Name = "Clave")]
        public int Id { get; set; }

        public User User { get; set; }
    }
}
