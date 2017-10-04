using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProgramaDescontoDomain _domain = new ProgramaDescontoDomain();
            var teste = _domain.GetAll().AsEnumerable();
            return View();
        }
    }
}
