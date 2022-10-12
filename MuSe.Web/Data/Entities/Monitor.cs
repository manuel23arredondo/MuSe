namespace MuSe.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Monitor
    {
        public int Id { get; set; }



        [Display(Name = "Imagen")]
        public string ImageUrl { get; set; }

        public User User { get; set; }
        public ICollection<MonitorWoman> WomanMonitors { get; set; }
    }
}
