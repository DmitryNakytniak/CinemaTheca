using System;
using System.Threading.Tasks;
using CinemaTheca.DAL.EF;
using CinemaTheca.DAL.Entities;
using CinemaTheca.DAL.Identity;
using CinemaTheca.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CinemaTheca.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;
        private IFilmEntityRepository<Film> films;
        private IFilmEntityRepository<FilmPersonProfile> filmPeople;

        public IdentityUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            clientManager = new ClientManager(db);
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }
        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }
        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public IFilmEntityRepository<FilmPersonProfile> FilmPeople
        {
            get
            {
                if (filmPeople == null)
                {
                    filmPeople = new FilmPersonRepository(db);
                }
                return filmPeople;
            }
        }

        public IFilmEntityRepository<Film> Films
        {
            get
            {
                if (films == null)
                {
                    films = new FilmRepository(db);
                }
                return films;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                    Films.Dispose();
                    FilmPeople.Dispose();
                }
                disposed = true;
            }
        }
    }
}