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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User model)
        {
            model.UpdatedAt = model.CreatedAt = DateTime.UtcNow;
            if (ModelState.IsValid)
            {
                dataContext.Users.AddObject(model);
                dataContext.SaveChanges();
            }
            return View();
        }

    }
}
