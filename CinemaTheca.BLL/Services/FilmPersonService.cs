using CinemaTheca.BLL.Interfaces;
using System.Threading.Tasks;
using CinemaTheca.BLL.DTO;
using CinemaTheca.BLL.Infrastructure;
using CinemaTheca.DAL.Interfaces;
using CinemaTheca.DAL.Entities;
using System;
using System.Linq;
using AutoMapper;

namespace CinemaTheca.BLL.Services
{
    class FilmPersonService : IFilmPersonService
    {
        IUnitOfWork DataBase;

        public FilmPersonService(IUnitOfWork uow)
        {
            DataBase = uow;
        }

        public async Task<OperationDetails> CreatePerson(FilmPersonDTO filmPersonDto)
        {
            FilmPersonProfile personProfile = await DataBase.FilmPeople.FindByNameAsync(filmPersonDto.Name);

            if (personProfile == null)
            {
                personProfile = new FilmPersonProfile
                {
                    BirthDay = filmPersonDto.BirthDay,
                    Career = filmPersonDto.Career,
                    DateOfDeath = filmPersonDto.DateOfDeath,
                    Films = filmPersonDto.Films,
                    Name = filmPersonDto.Name,
                    Photos = filmPersonDto.Photos,
                    ProfilePhoto = filmPersonDto.ProfilePhoto,
                    SocialNetworks = filmPersonDto.SocialNetworks
                };
                DataBase.FilmPeople.InsertOrUpdate(personProfile);
                await DataBase.SaveAsync();

                return new OperationDetails(true, $"Заявка на создание профиля звезды {personProfile.Name} успешно создана и была отправлена на обработку модераторам. Спасибо!", "");
            }
            else
            {
                return new OperationDetails(false, "Звезда с таким именем уже существует", "Name");
            }
        }

        public async Task<OperationDetails> DeletePerson(FilmPersonDTO filmPersonDto)
        {
            FilmPersonProfile personProfile = await DataBase.FilmPeople.FindByNameAsync(filmPersonDto.Name);

            if (personProfile != null)
            {
                DataBase.FilmPeople.Remove(personProfile);
                return new OperationDetails(true, "Профиль звезды удален успешно", "Name");
            }
            return new OperationDetails(false, "Не удалось выполнить удаление, так как профиля звезды с таким именем не существует", "Name");
        }

        public async Task<OperationDetails> EditPerson(FilmPersonDTO filmPersonDto)
        {
            FilmPersonProfile personProfile = await DataBase.FilmPeople.FindByNameAsync(filmPersonDto.Name);

            if (personProfile != null)
            {
                DataBase.FilmPeople.InsertOrUpdate(personProfile);
                await DataBase.SaveAsync();

                return new OperationDetails(true, $"Заявка на изменения профиля звезды {personProfile.Name} успешно создана и была отправлена на обработку модераторам. Спасибо!", "");
            }
            else
            {
                return new OperationDetails(false, "Звезда с таким именем уже существует", "Name");
            }

        }

        public void Dispose()
        {
            DataBase.Dispose();
        }

        public IQueryable<FilmPersonDTO> GetAllFilmsPeople()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<FilmPersonProfile, FilmPersonDTO>());
            return Mapper.Map<IQueryable<FilmPersonProfile>, IQueryable<FilmPersonDTO>>(DataBase.FilmPeople.All);
        }
    }
}
