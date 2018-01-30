using System.Collections.Generic;

namespace CinemaTheca.DAL.Entities
{
    public class Film
    {
        public Film()
        {
            Countries = new List<string>();
            Scenario = new List<FilmPersonProfile>();
            Genres = new List<Genre>();
            Votes = new List<int>();
            Frames = new List<string>();
            Characters = new Dictionary<string, FilmPersonProfile>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public ICollection<string> Countries { get; set; }
        public int Year { get; set; }
        public virtual FilmPersonProfile Director { get; set; }
        public ICollection<FilmPersonProfile> Scenario { get; set; }
        public virtual FilmPersonProfile Producer { get; set; }
        public virtual FilmPersonProfile Composer { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public int Budget { get; set; }
        public int Premiere { get; set; }
        public int Length { get; set; }
        public IDictionary<string, FilmPersonProfile> Characters { get; set; }
        public ICollection<int> Votes { get; set; }
        public ICollection<string> Frames { get; set; }
    }
}