using CinemaTheca.DAL.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using CinemaTheca.DAL.Entities;
using CinemaTheca.DAL.EF;
using System.Data.Entity;

namespace CinemaTheca.DAL.Repositories
{
    public class FilmRepository : IFilmEntityRepository<Film>
    {
        ApplicationContext DataBase;

        public FilmRepository(ApplicationContext db)
        {
            DataBase = db;
        }

        public IQueryable<Film> All
        {
            get
            {
                return DataBase.Films;
            }
        }

        public async Task<Film> FindByNameAsync(string filmName)
        {
            return await DataBase.Films.Where(f => f.Name.Contains(filmName)).FirstOrDefaultAsync();
        }

        public async Task<Film> GetAsync(int id)
        {
            return await DataBase.Films.FirstOrDefaultAsync(f => f.Id == id);
        }

        public void InsertOrUpdate(Film film)
        {
            if (film.Id == default(int))
            {
                DataBase.Films.Add(film);
            }
            else
            {
                DataBase.Entry(film).State = EntityState.Modified;
            }
        }

        public void Remove(Film film)
        {
            DataBase.Entry(film).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}