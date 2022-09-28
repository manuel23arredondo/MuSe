namespace MuSe.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CurrentRiskSituation> CurrentRiskSituations { get; set; }
        public DbSet<HelpDirectory> HelpDirectories { get; set; }
        public DbSet<HelpType> HelpTypes { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<KindOfPlace> KindOfPlaces { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Violentometer> Violentometers { get; set; }
        public DbSet<Woman> Womans { get; set; }
        public DbSet<WomanDiary> WomanDiaries { get; set; }
        public DbSet<WomanMonitor> WomanMonitors { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}
