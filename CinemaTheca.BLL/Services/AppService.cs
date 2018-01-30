using System.Threading.Tasks;
using CinemaTheca.DAL.Interfaces;
using CinemaTheca.BLL.Interfaces;
using System;

namespace CinemaTheca.BLL.Services
{
    public class AppService : IAppService
    {
        private IUnitOfWork db;

        private IUserService userService;
        private IFilmService filmService;
        private IFilmPersonService filmPersonService;

        public AppService(IUnitOfWork uow)
        {
            db = uow;
            userService = new UserService(db);
            filmService = new FilmService(db);
            filmPersonService = new FilmPersonService(db);
        }
        public IUserService UserService
        {
            get
            {
                return userService;
            }
        }

        public IFilmPersonService FilmPersonService
        {
            get
            {
                return filmPersonService;
            }
        }

        public IFilmService FilmService
        {
            get
            {
                return filmService;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveAsync();
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
                    userService.Dispose();
                    filmService.Dispose();
                    filmPersonService.Dispose();
                }
                disposed = true;
            }
        }
    }
}
