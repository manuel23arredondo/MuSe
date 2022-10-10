using System;
using System.ComponentModel.DataAnnotations;

namespace MuSe.Web.Data.Entities
{
    public class CodeTemp:IEntity
    {
        public int Id { get; set; }

        [Required]
        public int Number 
        {
            get
            {
                Random r = new Random();
                int code = r.Next(1000, 9999);
                return code;
            } 
        }

        [Required]
        public Woman Woman { get; set; }

        public MonitorWoman MonitorWoman { get; set; }
    }
}
