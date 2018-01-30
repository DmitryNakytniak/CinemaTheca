using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaTheca.Web.Models
{
    public class FilmModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Poster { get; set; }
        public ICollection<string> Countries { get; set; }
        public string Year { get; set; }
        public virtual FilmPersonProfileModel Director { get; set; }
        public ICollection<FilmPersonProfileModel> Scenario { get; set; }
        public virtual FilmPersonProfileModel Producer { get; set; }
        public virtual FilmPersonProfileModel Composer { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public int Budget { get; set; }
        public int Premiere { get; set; }
        public int Length { get; set; }
        public IDictionary<string, FilmPersonProfileModel> Characters { get; set; }
        public ICollection<int> Votes { get; set; }
        public ICollection<string> Frames { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}