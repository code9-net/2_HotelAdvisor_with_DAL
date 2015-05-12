using HotelAdvisorDAL.Managers;
using HotelAdvisorDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelAdvisor.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            HotelManager manager = new HotelManager();
            List<HotelDetailsViewModel> model = manager.GetHotels();

            return View(model);
        }

        [Authorize(Roles="Admin")]
        public ActionResult Create()
        {
            return View();
        }


        public FileContentResult getImages(int id)
        {
            return HotelManager.getImages(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Admin")]
        public  ActionResult Create(HotelViewModel model)
        {
            if(ModelState.IsValid)
            {
                if(model.Image == null)
                {
                    ModelState.AddModelError("CustomError", "Image is required please select image for upload");
                    return View();
                }
                if (model.Image.ContentLength > (2 * 1024 * 1024))
                {
                    ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                    return View();
                }
                if (!(model.Image.ContentType == "image/jpeg" || model.Image.ContentType == "image/gif"))
                {
                    ModelState.AddModelError("CustomError", "File type allowed : jpeg and gif");
                    return View();
                }

                byte[] imageData = new byte[model.Image.ContentLength];
                model.Image.InputStream.Read(imageData, 0, model.Image.ContentLength);

                HotelManager manager = new HotelManager();
                Hotel hotel = new Hotel();
                hotel.Name = model.Name;
                hotel.Description = model.Description;
                hotel.City = model.City;
                hotel.Address = model.Address;
                hotel.HouseNumber = model.HouseNumber;
                hotel.IsActive = model.IsActive;
                hotel.Image = imageData;
                manager.Create(hotel);

               return RedirectToAction("Index");
            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            HotelManager manager = new HotelManager();
            Hotel model = manager.Find(id);

            HotelViewModel hotel = new HotelViewModel();
            hotel.Id = model.Id;
            hotel.Name = model.Name;
            hotel.Description = model.Description;
            hotel.City = model.City;
            hotel.Address = model.Address;
            hotel.HouseNumber = model.HouseNumber;
            hotel.IsActive = model.IsActive;

            return View(hotel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(HotelViewModel model)
        {
            if (ModelState.IsValid)
            {

                byte[] imageData = new byte[0];

                if(model.Image != null)
                {
                    if (model.Image.ContentLength > (2 * 1024 * 1024))
                    {
                        ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                        return View();
                    }
                    if (!(model.Image.ContentType == "image/jpeg" || model.Image.ContentType == "image/gif"))
                    {
                        ModelState.AddModelError("CustomError", "File type allowed : jpeg and gif");
                        return View();
                    }

                    imageData = new byte[model.Image.ContentLength];
                    model.Image.InputStream.Read(imageData, 0, model.Image.ContentLength);
                }
              

                HotelManager manager = new HotelManager();
                Hotel hotel = new Hotel();
                hotel.Id = model.Id;
                hotel.Name = model.Name;
                hotel.Description = model.Description;
                hotel.City = model.City;
                hotel.Address = model.Address;
                hotel.HouseNumber = model.HouseNumber;
                hotel.IsActive = model.IsActive;
                hotel.Image = imageData;
                
                manager.Edit(hotel);

                return RedirectToAction("Index");
            }

            return View(model);
        }


        public ActionResult Details(int id)
        {
            HotelManager manager = new HotelManager();
            HotelDetailsViewModel model = manager.GetHotelDetails(id);
            return View(model);
        }

    }
}