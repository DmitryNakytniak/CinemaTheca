using CinemaTheca.DAL.Entities;
using System;
using System.Collections.Generic;

namespace CinemaTheca.BLL.DTO
{
    public class FilmPersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePhoto { get; set; }
        public ICollection<FilmPersonOccupation> Career { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public IDictionary<string, Film> Films { get; set; }
        public ICollection<string> Photos { get; set; }
        public ICollection<string> SocialNetworks { get; set; }
        public ICollection<ClientProfile> InFavorites { get; set; }
    }
}
