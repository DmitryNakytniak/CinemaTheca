using CinemaTheca.BLL.DTO;
using CinemaTheca.BLL.Infrastructure;
using CinemaTheca.BLL.Interfaces;
using CinemaTheca.DAL.Entities;
using CinemaTheca.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaTheca.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork DataBase;

        public UserService(IUnitOfWork uow)
        {
            DataBase = uow;
        }

        public async Task<OperationDetails> CreateUser(UserDTO userDto)
        {
            ApplicationUser user = await DataBase.UserManager.FindByEmailAsync(userDto.Email);

            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };

                var result = await DataBase.UserManager.CreateAsync(user, userDto.Password);

                if (result.Errors.Count() > 0)
                {
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                }
                // Add role
                await DataBase.UserManager.AddToRoleAsync(user.Id, userDto.Role);

                // CreateUser user profile
                ClientProfile clientProfile = new ClientProfile { Id = user.Id, City = userDto.City, Name = userDto.Name };
                DataBase.ClientManager.Create(clientProfile);
                await DataBase.SaveAsync();

                return new OperationDetails(true, "Регистрация прошла успешно", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;

            // Search user
            ApplicationUser user = await DataBase.UserManager.FindAsync(userDto.Email, userDto.Password);

            // Authenticate user
            if (user != null)
            {
                claim = await DataBase.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }
            return claim;

        }

        //public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        //{
        //    foreach (string roleName in roles)
        //    {
        //        var role = await DataBase.RoleManager.FindByNameAsync(roleName);

        //        if (role == null)
        //        {
        //            role = new ApplicationRole { Name = roleName };
        //            await DataBase.RoleManager.CreateAsync(role);
        //        }
        //    }
        //    await CreateUser(adminDto);
        //}

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
