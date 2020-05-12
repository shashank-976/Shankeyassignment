using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ReservationSystem.Models.GuestModel;

namespace ReservationSystem.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult addGuest()
        {
            ModelManager modelManager = new ModelManager();
            ViewBag.reservation = modelManager.displayReservation();

            return View(new GuestModel());
        }
        [HttpPost]
        public ActionResult addGuest(GuestModel guestModel)
        {
           
                ModelManager modelManager = new ModelManager();
                modelManager.addGuest(guestModel);
                return RedirectToAction("Index");
           
        }
        [HttpGet]
        public ActionResult UpdateBill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateBill(GuestModel guestModel,int GuestId)
        {
            ModelManager modelManager = new ModelManager();
            modelManager.UpdateBillDetails(guestModel,GuestId);
            return RedirectToAction("Index");
        }

      
        public ActionResult displayGuest()
        {
          
            ModelManager modelManager = new ModelManager();
            List<GuestModel> guestModels = new List<GuestModel>();
            ViewBag.guest= modelManager.displayGuest();
          
            return View();

        }

        public ActionResult displayLGuest()
        {

            ModelManager modelManager = new ModelManager();
            List<GuestModel> guestModels = new List<GuestModel>();
            ViewBag.guest1 = modelManager.displayLGuest();
          
            return View();

        }

       
        public ActionResult displayGuestId()
        {
            ModelManager modelManager = new ModelManager();
            ViewBag.display1=modelManager.displayGuestId();
            return View();
        }


        public ActionResult displayNames()
        {

            ModelManager modelManager = new ModelManager();
            List<GuestModel> guestModels = new List<GuestModel>();
            GuestModelCompare guestModelCompare = new GuestModelCompare();
            ViewBag.guest2 = modelManager.displayNames();
            guestModels.Sort(guestModelCompare);
            guestModels.Reverse();
          
            return View();
        }

       

        }
}