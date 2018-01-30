using CinemaTheca.BLL.DTO;
using CinemaTheca.BLL.Infrastructure;
using CinemaTheca.BLL.Interfaces;
using CinemaTheca.BLL.Services;
using CinemaTheca.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CinemaTheca.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IAppService AppService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IAppService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel model)
        {
            //await SetInitialDataAsync();

            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await AppService.UserService.Authenticate(userDto);

                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            //await SetInitialDataAsync();

            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    City = model.City,
                    Name = model.Name,
                    Role = "user"
                };

                OperationDetails operationDetails = await AppService.UserService.CreateUser(userDto);
                if (operationDetails.Succeeded)
                {
                    ClaimsIdentity claim = await AppService.UserService.Authenticate(userDto);
                    AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, claim);
                    return View("SuccessRegister");
                }
                else
                {
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
                }
            }

            return View(model);
        }

        //[NonAction]
        //private async Task SetInitialDataAsync()
        //{
        //    await AppService.UserService.SetInitialData(new UserDTO
        //    {
        //        Email = "nakytniak.dmitry@gmail.com",
        //        UserName = "DmitryNakytniak",
        //        Password = "ad46D_ewr3",
        //        Name = "Накитняк Дмитрий",
        //        City = "Киев",
        //        Role = "admin",
        //    }, new List<string> { "user", "admin", "moderator" });
        //}
    }
}