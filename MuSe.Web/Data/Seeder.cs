namespace MuSe.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
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
                var user = await CheckUser("Bill", "Gates", "272 560 8922", DateTime.Now, "bill.microsoft@gmail.com", "123456");
                await CheckAdmin(user, "Admin");
            }


            if (!this.dataContext.HelpTypes.Any())
            {
                await CheckHelpType("Legal");
                await CheckHelpType("Psicológica");
                await CheckHelpType("Pro ayuda de la mujer");
                await CheckHelpType("Atención médica");
            }

            if (!this.dataContext.KindOfPlaces.Any())
            {
                await CheckKindOfPlace("Riesgo");
                await CheckKindOfPlace("Seguro");
            }

            if (!this.dataContext.Moods.Any())
            {
                await CheckMood("Feliz");
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

            if (!this.dataContext.Violentometers.Any())
            {
                var reliability = dataContext.Reliabilities.FirstOrDefault(c => c.Description == "Leve");
                await CheckViolentometer("Bromas hirientes", reliability);
                await CheckViolentometer("Chantajear", reliability);
                await CheckViolentometer("Mentir/Engañar", reliability);
                await CheckViolentometer("Ignorar/Ley del Hielo", reliability);
                await CheckViolentometer("Celar", reliability);
                await CheckViolentometer("Culpabilizar", reliability);
                await CheckViolentometer("Descalificar", reliability);
                await CheckViolentometer("Ridiculizar/Ofender", reliability);
                await CheckViolentometer("Humillar en público", reliability);
                await CheckViolentometer("Intimidar/Amenazar", reliability);
                await CheckViolentometer("Controlar/Prohibir", reliability);

                reliability = dataContext.Reliabilities.FirstOrDefault(c => c.Description == "Intermedia");
                await CheckViolentometer("Destruir artículos personales", reliability);
                await CheckViolentometer("Manosear", reliability);
                await CheckViolentometer("Caricias agresivas", reliability);
                await CheckViolentometer("Golpear jugando", reliability);
                await CheckViolentometer("Pellizcar/Arañar", reliability);
                await CheckViolentometer("Empujar/Jalonear", reliability);
                await CheckViolentometer("Cachetear", reliability);
                await CheckViolentometer("Patear", reliability);
                await CheckViolentometer("Encerrar/Aislar", reliability);

                reliability = dataContext.Reliabilities.FirstOrDefault(c => c.Description == "Grave");
                await CheckViolentometer("Amenazar con objetos o armas", reliability);
                await CheckViolentometer("Amenazar de muerte", reliability);
                await CheckViolentometer("Forzar a una relación sexual", reliability);
                await CheckViolentometer("Abuso sexual", reliability);
                await CheckViolentometer("Violar", reliability);
                await CheckViolentometer("Mutilar", reliability);
                await CheckViolentometer("Asesinar", reliability);

            }

            if (!this.dataContext.HelpDirectories.Any())
            {
                var helpType = dataContext.HelpTypes.FirstOrDefault(c => c.Description == "Legal");
                await CheckHelpDirectory("Centro de Atención a la violencia intrafamiliar C.A.V.I.", "5553455229", "Gral. Gabriel Hernández", "56", "Sin número", "Cuauhtémoc", 06720, "cavi@cavi.org", helpType);
                
                helpType = dataContext.HelpTypes.FirstOrDefault(c => c.Description == "Atención médica");
                await CheckHelpDirectory("Ascociación para el Desarrollo Integral de Personas Violadas A.C.", "56827969", "Santa María La Ribera", "140", "Sin número", "Cuauhtémoc", 14562, "adivac@adivac.org", helpType);
            }
        }
            private async Task<User> CheckUser(string firstName, string lastname, string phoneNumber, DateTime birthdate, string email, string password)
        {
            var user = await userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastname,
                    PhoneNumber = phoneNumber,
                    BirhtDate = birthdate,
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
                User = user
            });
            await this.dataContext.SaveChangesAsync();
            await userHelper.AddUserToRoleAsync(user, rol);
        }

        private async Task CheckMonitor(User user, string rol)
        {
            this.dataContext.Monitors.Add(new Monitor
            {
                User = user
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

        private async Task CheckViolentometer(string description, Reliability reliability)
        {
            this.dataContext.Violentometers.Add(new Violentometer
            {
                Description = description,
                Reliability = reliability
            });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckHelpDirectory(string organizationName, string phoneNumber, string street, string outsideNumber, string insideNumber, string colony, int postCode, string email, HelpType helpType)
        {
            this.dataContext.HelpDirectories.Add(new HelpDirectory
            {
                OrganizationName = organizationName,
                PhoneNumber = phoneNumber,
                Street = street,
                OutsideNumber = outsideNumber,
                InsideNumber = insideNumber,
                Colony = colony,
                PostCode = postCode,
                Email = email,
                HelpType = helpType
            });
            await this.dataContext.SaveChangesAsync();
        }
    }
}
