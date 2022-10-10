namespace MuSe.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using System.Linq;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CurrentRiskSituation> CurrentRiskSituations { get; set; }
        public DbSet<HelpDirectory> HelpDirectories { get; set; }
        public DbSet<HelpType> HelpTypes { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<KindOfPlace> KindOfPlaces { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<MonitorWoman> MonitorWomen { get; set; }
        public DbSet<Mood> Moods { get; set; }
        public DbSet<OwnWomanPlace> OwnWomanPlaces { get; set; }
        public DbSet<Reliability> Reliabilities { get; set; }
        public DbSet<Violentometer> Violentometers { get; set; }
        public DbSet<Woman> Womans { get; set; }
        public DbSet<WomanDiary> WomanDiaries { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var cascadeFKs = builder.Model
           .G­etEntityTypes()
           .SelectMany(t => t.GetForeignKeys())
           .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(builder);
        }
    }
}
