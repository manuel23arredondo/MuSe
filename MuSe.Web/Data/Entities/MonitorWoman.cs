namespace MuSe.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class MonitorWoman:IEntity
    {
        public int Id { get; set; }

        public Monitor Monitor { get; set; }
        public IEnumerable<CodeTemp> CodeTemps { get; set; }
    }
}
