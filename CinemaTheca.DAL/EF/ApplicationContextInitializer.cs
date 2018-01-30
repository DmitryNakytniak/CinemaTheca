using CinemaTheca.DAL.Entities;
using CinemaTheca.DAL.Identity;
using CinemaTheca.DAL.Interfaces;
using CinemaTheca.DAL.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTheca.DAL.EF
{
    public class ApplicationContextInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        public async Task CreateAdmin(ApplicationContext context)
        {
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            IClientManager clientManager = new ClientManager(context);

            ApplicationUser user = new ApplicationUser { Email = "nakytniak.dmitry@gmail.com", UserName = "DmitryNakytniak" };

            var result = await userManager.CreateAsync(user, "ad46D_ewr3");

            // Add role
            await userManager.AddToRoleAsync(user.Id, "admin");

            // CreateUser user profile
            ClientProfile clientProfile = new ClientProfile { Id = user.Id, City = "Киев", Name = "Накитняк Дмитрий" };
            clientManager.Create(clientProfile);
            await context.SaveChangesAsync();
        }

        public async Task AddAdminAndRoles(ApplicationContext context, List<string> roles)
        {
            ApplicationRoleManager roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            foreach (string roleName in roles)
            {
                var role = await roleManager.FindByNameAsync(roleName);

                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await roleManager.CreateAsync(role);
                }
            }
            await CreateAdmin(context);
        }

        protected override void Seed(ApplicationContext context)
        {
            //await AddAdminAndRoles(context, new List<string> { "user", "admin", "moderator" });

            Random random = new Random();

            List<FilmPersonProfile> actors = new List<FilmPersonProfile>();

            for (int i = 1; i < 31; i++)
            {
                actors.Add(new FilmPersonProfile()
                {
                    Name = $"Actor{i}",
                    BirthDay = new DateTime(1900, 1, 1).AddDays(random.Next(1, 36524)),
                    Career = new List<FilmPersonOccupation>() { FilmPersonOccupation.actor, FilmPersonOccupation.producer }
                });
            }

            List<Film> films = new List<Film>();

            for (int i = 1; i < 6; i++)
            {
                List<int> votes = new List<int>();

                for (int j = 0; j < 100; j++)
                {
                    votes.Add(random.Next(1, 10));
                }

                Dictionary<string, FilmPersonProfile> characters = new Dictionary<string, FilmPersonProfile>();
                int length = random.Next(5, 15);

                for (int k = 1; k < length; k++)
                {
                    characters.Add($"Character{k}", actors.OrderBy(a => random.Next()).Take(1).FirstOrDefault());
                }

                films.Add(new Film()
                {
                    Name = $"Film{i}",
                    Year = random.Next(1900, 2018),
                    Genres = new List<Genre>() { Genre.comedy, Genre.adventure },
                    Budget = random.Next(1000, 100000) * 1000,
                    Producer = actors.OrderBy(a => random.Next()).Take(1).FirstOrDefault(),
                    Length = random.Next(90, 200),
                    Votes = votes,
                    Composer = actors.OrderBy(a => random.Next()).Take(1).FirstOrDefault(),
                    Countries = { "USA", "Ukraine", "Moldova" },
                    Scenario = { actors.OrderBy(a => random.Next()).Take(1).FirstOrDefault() },
                    Director = actors.OrderBy(a => random.Next()).Take(1).FirstOrDefault(),
                    Characters = characters
                });

                context.FilmPeople.AddRange(actors);
                context.Films.AddRange(films);
                context.SaveChanges();
            }
        }
    }
}
