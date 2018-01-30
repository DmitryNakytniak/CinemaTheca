using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTheca.Web.Models
{
    public class FilmPersonProfileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePhoto { get; set; }
        public ICollection<FilmPersonOccupation> Career { get; set; }
        public DateTime? BirthDay { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public IDictionary<string, FilmModel> Films { get; set; }
        public ICollection<string> Photos { get; set; }
        public ICollection<string> SocialNetworks { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}