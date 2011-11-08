using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Geakets.Models;

namespace Geakets.Controllers
{
    public class UsersController : Controller
    {
        GeaketsEntities dataContext = new GeaketsEntities();

        //
        // GET: /Users/

        public ActionResult Details(int id, int? page)
        {
            ViewBag.PageSize = 10;

            page = page ?? 1;
            int take = ViewBag.PageSize;
            int skip = (int)page * take - take;

            ViewBag.PageCount = (int)Math.Ceiling((double)dataContext.Geakets.Where(g => g.UserId == id).Count() / take);
            ViewBag.CurrentPage = page;

            ViewBag.UserName = dataContext.Users.Where(u => u.Id == id).Select(u => u.Name).FirstOrDefault() ?? "Unknown";

            return View(dataContext.Geakets.Where(g => g.UserId == id).OrderByDescending(g => g.UpdatedAt).Skip(skip).Take(take).ToList());
        }
    }
}
