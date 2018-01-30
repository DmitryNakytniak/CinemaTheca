using CinemaTheca.BLL.Interfaces;
using System;
using System.Threading.Tasks;

namespace CinemaTheca.BLL.Services
{
    public interface IAppService : IDisposable
    {
        IUserService UserService { get; }
        IFilmPersonService FilmPersonService { get; }
        IFilmService FilmService { get; }
        Task SaveAsync();
    }
}
