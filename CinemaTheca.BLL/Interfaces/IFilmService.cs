using CinemaTheca.BLL.DTO;
using CinemaTheca.BLL.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTheca.BLL.Interfaces
{
    public interface IFilmService : IDisposable
    {
        IQueryable<FilmDTO> GetAllFilms();
        Task<OperationDetails> CreateFilm(FilmDTO filmDto);
        Task<OperationDetails> EditFilm(FilmDTO filmDto);
        Task<OperationDetails> DeleteFilm(FilmDTO filmDto);
    }
}
