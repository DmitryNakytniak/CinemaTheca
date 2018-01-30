using CinemaTheca.BLL.Interfaces;
using CinemaTheca.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaTheca.Web.Controllers
{
    public class HomeController : Controller
    {
        private IAppService AppService
        {
            get
            {
                return new AppServiceCreator().CreateAppService("DefaultConnection");
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Cabinet()
        {
            return View();
        }

        public ActionResult AutocompleteSearch(string term)
        {
            var filmAndPeople = AppService.FilmService.GetAllFilms().Select(f => new { Name = f.Name }).
                Union(AppService.FilmPersonService.GetAllFilmsPeople().Select(fp => new { Name = fp.Name }));
            var models = filmAndPeople.Where(a => a.Name.Contains(term))
                            .Select(a => new { value = a.Name })
                            .Distinct();

            return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
}