using CinemaTheca.BLL.Interfaces;
using System.Threading.Tasks;
using CinemaTheca.BLL.DTO;
using CinemaTheca.BLL.Infrastructure;
using CinemaTheca.DAL.Interfaces;
using CinemaTheca.DAL.Entities;
using System.Linq;
using AutoMapper;

namespace CinemaTheca.BLL.Services
{
    class FilmService : IFilmService
    {
        IUnitOfWork DataBase;
        public FilmService(IUnitOfWork uow)
        {
            DataBase = uow;
        }

        public async Task<OperationDetails> CreateFilm(FilmDTO filmDto)
        {
            Film film = await DataBase.Films.FindByNameAsync(filmDto.Name);

            if (film == null)
            {
                film = new Film
                {
                    Budget = filmDto.Budget,
                    Characters = filmDto.Characters,
                    Composer = filmDto.Composer,
                    Countries = filmDto.Countries,
                    Director = filmDto.Director,
                    Frames = filmDto.Frames,
                    Genres = filmDto.Genres,
                    Length = filmDto.Length,
                    Name = filmDto.Name,
                    Poster = filmDto.Poster,
                    Premiere = filmDto.Premiere,
                    Producer = filmDto.Producer,
                    Scenario = filmDto.Scenario,
                    Year = filmDto.Year,
                    InFavorites = filmDto.InFavorites
                };

                DataBase.Films.InsertOrUpdate(film);
                await DataBase.SaveAsync();

                return new OperationDetails(true, $"Заявка на создание фильма {film.Name} была отправлена на обработку модераторам. Спасибо!", "");
            }
            else
            {
                return new OperationDetails(false, "Фильм с таким названием уже существует", "Name");
            }
        }


        public async Task<OperationDetails> DeleteFilm(FilmDTO filmDto)
        {
            Film film = await DataBase.Films.FindByNameAsync(filmDto.Name);

            if (film != null)
            {
                DataBase.Films.Remove(film);
                await DataBase.SaveAsync();
                return new OperationDetails(true, $"Заявка на удаление фильма {film.Name} была отправлена на обработку модераторам", "Name");
            }

            return new OperationDetails(false, $"Фильма с таким именем не существует", film.Name);
        }

        public async Task<OperationDetails> EditFilm(FilmDTO filmDto)
        {
            Film film = await DataBase.Films.FindByNameAsync(filmDto.Name);

            if (film != null)
            {
                DataBase.Films.InsertOrUpdate(film);
                await DataBase.SaveAsync();
                return new OperationDetails(true, $"Заявка на внесение изменений в фильм {film.Name} была отправлена на обработку модераторам", "Name");
            }

            return new OperationDetails(false, $"Фильма с таким именем не существует", film.Name);
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }

        public IQueryable<FilmDTO> GetAllFilms()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Film, FilmDTO>());
            return Mapper.Map<IQueryable<Film>, IQueryable<FilmDTO>>(DataBase.Films.All);
        }
    }
}


