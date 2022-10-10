namespace MuSe.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Helpers;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    public class Seeder
    {
        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;

        public Seeder(DataContext dataContext, IUserHelper userHelper)
        {
            this.dataContext = dataContext;
            this.userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await userHelper.CheckRoleAsync("Admin");
            await userHelper.CheckRoleAsync("Woman");
            await userHelper.CheckRoleAsync("Monitor");

            if (!this.dataContext.Admins.Any())
            {
                var user = await CheckUser("Bill", "Gates", "Hernández","272 560 8922", DateTime.Now, "XXX", "bill.microsoft@gmail.com", "123456");
                await CheckAdmin(user, "Admin");
            }

            if (!this.dataContext.Womans.Any())
            {
                var user = await CheckUser("Monica", "Lopez", "Cruz", "272 115 0000", DateTime.Now, "XXX", "armando.l@gmail.com", "123456");
                await CheckWoman(user, "Woman");
                user = await CheckUser("María", "Ruiz", "Contreras", "272 155 1000", DateTime.Now, "XXX", "tony.rl@gmail.com", "123456");
                await CheckWoman(user, "Woman");
                user = await CheckUser("Natalia", "Cortés", "Ruiz","272 895 0560", DateTime.Now, "XXX", "cortes.peter@gmail.com", "123456");
                await CheckWoman(user, "Woman");
            }

            if (!this.dataContext.Monitors.Any())
            {
                var user = await CheckUser("Carlos", "Lopez", "Cruz", "272 115 0000", DateTime.Now, "XXX", "armando.l@gmail.com", "123456");
                await CheckMonitor(user, "Monitor");
                user = await CheckUser("Martín", "Ruiz", "Contreras", "272 155 1000", DateTime.Now, "XXX", "tony.rl@gmail.com", "123456");
                await CheckMonitor(user, "Monitor");
                user = await CheckUser("Manuel", "Cortés", "Ruiz", "272 895 0560", DateTime.Now, "XXX", "cortes.peter@gmail.com", "123456");
                await CheckMonitor(user, "Monitor");
            }

            if (!this.dataContext.HelpTypes.Any())
            {
                await CheckHelpType("Legal");
                await CheckHelpType("Psicológica");
            }

            if (!this.dataContext.KindOfPlaces.Any())
            {
                await CheckKindOfPlace("Riesgo");
                await CheckKindOfPlace("Seguro");
            }

            if (!this.dataContext.Moods.Any())
            {
                await CheckMood ("Feliz");
                await CheckMood("Triste");
                await CheckMood("Enojada");
                await CheckMood("Disgustada");
                await CheckMood("Confundida");
                await CheckMood("Preocupada");
                await CheckMood("Asustada");
                await CheckMood("Avergonzada");
                await CheckMood("Frustrada");
            }

            if (!this.dataContext.Reliabilities.Any())
            {
                await CheckReliability("Leve");
                await CheckReliability("Intermedia");
                await CheckReliability("Grave");
            }
        }

        private async Task<User> CheckUser(string firstName, string fathersName, string mothersName, string phoneNumber, DateTime birthdate, string imageUrl, string email, string password)
        {
            var user = await userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    FathersName = fathersName,
                    MothersName = mothersName,
                    PhoneNumber = phoneNumber,
                    BirhtDate = birthdate,
                    ImageUrl = imageUrl,
                    Email = email,
                    UserName = email
                };
                var result = await userHelper.AddUserAsync(user, password);
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Error no se pudo crear el usuario");
                }
            }
            return user;
        }

        private async Task CheckAdmin(User user, string rol)
        {
            this.dataContext.Admins.Add(new Admin
            {
                User = user
            });
            await this.dataContext.SaveChangesAsync();
            await userHelper.AddUserToRoleAsync(user, rol);
        }

        private async Task CheckWoman(User user, string rol)
        {
            this.dataContext.Womans.Add(new Woman
            {
                User = user,
            });
            await this.dataContext.SaveChangesAsync();
            await userHelper.AddUserToRoleAsync(user, rol);
        }

        private async Task CheckMonitor(User user, string rol)
        {
            this.dataContext.Monitors.Add(new Monitor
            {
                User = user,
            });
            await this.dataContext.SaveChangesAsync();
            await userHelper.AddUserToRoleAsync(user, rol);
        }

        private async Task CheckHelpType(string description)
        {
            this.dataContext.HelpTypes.Add(new HelpType { Description = description });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckKindOfPlace(string description)
        {
            this.dataContext.KindOfPlaces.Add(new KindOfPlace { Description = description });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckMood(string description)
        {
            this.dataContext.Moods.Add(new Mood { Description = description });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckReliability(string description)
        {
            this.dataContext.Reliabilities.Add(new Reliability{ Description = description });
            await this.dataContext.SaveChangesAsync();
        }
    }
}
