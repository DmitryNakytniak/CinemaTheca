using CinemaTheca.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CinemaTheca.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationContext()
        {
            Database.SetInitializer(new ApplicationContextInitializer());
        }

        public ApplicationContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmPersonProfile> FilmPeople { get; set; }
    }
}
