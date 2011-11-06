using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Geakets.Models;

namespace Geakets.Controllers
{
    public class HomeController : Controller
    {
        GeaketsEntities dataContext = new GeaketsEntities();

        //
        // GET: /Home/

        public ActionResult Index(int? page)
        {
            ViewBag.PageSize = 10;

            page = page ?? 1;
            int take = ViewBag.PageSize;
            int skip = (int)page * take - take;

            ViewBag.PageCount = (int)Math.Ceiling((double)dataContext.Geakets.Count() / take);
            ViewBag.CurrentPage = page;

            return View(dataContext.Geakets.OrderByDescending(g => g.UpdatedAt).Skip(skip).Take(take).ToList());
        }
    }
}
