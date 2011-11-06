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

        public ActionResult Details(int id)
        {
            return View(dataContext.Geakets.SingleOrDefault(g => g.Id == id));
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
                geaket.UpdatedAt = geaket.CreatedAt = DateTime.UtcNow;
                dataContext.SaveChanges();

                var dict = new Dictionary<string, string>();
                dict.Add("notice", "New geaket created.");
                Session["flash"] = dict;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
