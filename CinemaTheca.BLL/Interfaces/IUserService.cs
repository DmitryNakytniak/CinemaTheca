using CinemaTheca.BLL.DTO;
using CinemaTheca.BLL.Infrastructure;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaTheca.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateUser(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        //Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
