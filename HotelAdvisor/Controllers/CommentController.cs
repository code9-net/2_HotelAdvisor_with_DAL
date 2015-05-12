using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using HotelAdvisorDAL.Managers;
using HotelAdvisorDAL.Models;

namespace HotelAdvisor.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        public ActionResult Index(int hotelId)
        {
            return View();
        }
        // GET: Comment
        public ActionResult Create(int hotelId)
        {
            Comment model = new Comment() { HotelId = hotelId };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment model)
        {
            if(ModelState.IsValid)
            {
                model.UserId = User.Identity.GetUserId();
                model.DateAdded = DateTime.Now;

                CommentManager manager = new CommentManager();
                manager.Create(model);
                return RedirectToAction("Details", "Hotel", new { id = model.HotelId });
            }

            return View(model);
        }
    }
}