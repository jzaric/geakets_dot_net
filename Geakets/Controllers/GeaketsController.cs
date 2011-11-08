using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Geakets.Models;

namespace Geakets.Controllers
{
    public class GeaketsController : Controller
    {
        GeaketsEntities dataContext = new GeaketsEntities();

        //
        // GET: /Geakets/
        public ActionResult List(int? page)
        {
            ViewBag.PageSize = 10;

            page = page ?? 1;
            int take = ViewBag.PageSize;
            int skip = (int)page * take - take;

            ViewBag.PageCount = (int)Math.Ceiling((double)dataContext.Geakets.Count() / take);
            ViewBag.CurrentPage = page;

            return View(dataContext.Geakets.OrderByDescending(g => g.UpdatedAt).Skip(skip).Take(take).ToList());
        }

        public ActionResult Details(int id)
        {
            var geaket = dataContext.Geakets.SingleOrDefault(g => g.Id == id);
            geaket.ViewCount++;
            dataContext.SaveChanges();
            return View(geaket);
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(GeaketViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = dataContext.Users.SingleOrDefault(u => u.Email == model.Email);
                if (user == null)
                {
                    user = dataContext.Users.CreateObject();
                    user.Name = model.Name;
                    user.Email = model.Email;
                    user.UpdatedAt = user.CreatedAt = DateTime.UtcNow;
                    dataContext.Users.AddObject(user);
                    dataContext.SaveChanges();
                }

                var geaket = dataContext.Geakets.CreateObject();
                user.Geakets.Add(geaket);
                geaket.Title = model.Title;
                geaket.Code = model.Code;
                geaket.ViewCount = 0;
                geaket.UpdatedAt = geaket.CreatedAt = DateTime.UtcNow;
                dataContext.SaveChanges();

                var dict = new Dictionary<string, string>();
                dict.Add("notice", "New geaket created.");
                Session["flash"] = dict;
                return RedirectToAction("List", "Geakets");
            }
            return View();
        }
    }
}
