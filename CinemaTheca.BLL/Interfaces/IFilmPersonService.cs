using CinemaTheca.BLL.DTO;
using CinemaTheca.BLL.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTheca.BLL.Interfaces
{
    public interface IFilmPersonService : IDisposable
    {
        IQueryable<FilmPersonDTO> GetAllFilmsPeople();
        Task<OperationDetails> CreatePerson(FilmPersonDTO filmPersonDto);
        Task<OperationDetails> EditPerson(FilmPersonDTO filmPersonDto);
        Task<OperationDetails> DeletePerson(FilmPersonDTO filmPersonDto);
    }
}
