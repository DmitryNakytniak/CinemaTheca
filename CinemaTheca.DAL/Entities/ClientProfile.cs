using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaTheca.DAL.Entities
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string City { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Film> FavouriteFilms { get; set; }
        public List<FilmPersonProfile> FavouriteStars { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}