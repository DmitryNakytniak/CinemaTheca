using CinemaTheca.DAL.EF;
using CinemaTheca.DAL.Entities;
using CinemaTheca.DAL.Interfaces;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTheca.DAL.Repositories
{
    class FilmPersonRepository : IFilmEntityRepository<FilmPersonProfile>
    {
        ApplicationContext DataBase;
        public FilmPersonRepository(ApplicationContext db)
        {
            DataBase = db;
        }

        public IQueryable<FilmPersonProfile> All
        {
            get
            {
                return DataBase.FilmPeople;
            }
        }

        public async Task<FilmPersonProfile> FindByNameAsync(string filmPersonName)
        {
            return await DataBase.FilmPeople.Where(fp => fp.Name.Contains(filmPersonName)).FirstOrDefaultAsync();
        }

        public async Task<FilmPersonProfile> GetAsync(int id)
        {
            return await DataBase.FilmPeople.FirstOrDefaultAsync(fp => fp.Id == id);
        }

        public void InsertOrUpdate(FilmPersonProfile filmPerson)
        {
            if (filmPerson.Id == default(int))
            {
                DataBase.FilmPeople.Add(filmPerson);
            }
            else
            {
                DataBase.Entry(filmPerson).State = EntityState.Modified;
            }
        }

        public void Remove(FilmPersonProfile filmPerson)
        {
            DataBase.Entry(filmPerson).State = EntityState.Deleted;
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
