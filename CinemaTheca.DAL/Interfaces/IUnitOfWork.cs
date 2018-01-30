using CinemaTheca.DAL.Entities;
using CinemaTheca.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace CinemaTheca.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IFilmEntityRepository<FilmPersonProfile> FilmPeople { get; }
        IFilmEntityRepository<Film> Films { get; }
        Task SaveAsync();
    }
}
