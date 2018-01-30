using System;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTheca.DAL.Interfaces
{
    public interface IFilmEntityRepository<TFilmEntity> : IDisposable where TFilmEntity : class
    {
        IQueryable<TFilmEntity> All { get; }
        Task<TFilmEntity> GetAsync(int id);
        void InsertOrUpdate(TFilmEntity filmEntity);
        void Remove(TFilmEntity filmEntity);
        Task<TFilmEntity> FindByNameAsync(string filmEntityName);
    }
}
