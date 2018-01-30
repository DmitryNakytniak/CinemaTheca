using System.Collections.Generic;

namespace CinemaTheca.BLL.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Role { get; set; }
        public List<FilmDTO> FavouriteFilms { get; set; }
        public List<FilmPersonDTO> FavouriteStars { get; set; }
    }
}
