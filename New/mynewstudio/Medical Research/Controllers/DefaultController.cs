using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medical_Research.Models;
using EntityLayer;
using ExceptionLayer;

namespace Medical_Research.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult addDiseaseDetails()
        {


            ModelManager modelManager = new ModelManager();
            ViewBag.Severity = modelManager.displaySeverity();
            ViewBag.Cause = modelManager.displayCause();
            return View(new DiseaseModel());
        }
        [HttpPost]
        public ActionResult addDiseaseDetails(DiseaseModel diseaseModel)
        {
            try
            {


                ModelManager modelManager = new ModelManager();
                modelManager.addDiseaseDetails(diseaseModel);
                return RedirectToAction("Index");
            }
            catch (MedicalException e)
            {
                TempData["result"] = e.Message;
                return View();
            }
        }
        [HttpGet]
        public ActionResult addSymptomsDisease()
        {
            ModelManager modelManager = new ModelManager();
            ViewBag.SymptomName = modelManager.DisplaySymptom();
            ViewBag.DiseaseName = modelManager.displayDisease();
            return View(new DiseaseWithSymptomModel());
        }
        [HttpPost]
        public ActionResult addSymptomsDisease(DiseaseWithSymptomModel diseaseWithSymptomModel)
        {
            ModelManager modelManager = new ModelManager();
            modelManager.addSymptomsDisease(diseaseWithSymptomModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult showdiagnoses()
        {
            ModelManager modelManager = new ModelManager();
            ViewBag.Diagnose = modelManager.DisplaySymptom();
            return View();
        }
        [HttpPost]
       

        public ActionResult showdiagnoses(string patientName, int id1, int id2)
        {
            try
            {
                ModelManager modelManager = new ModelManager();
                ViewBag.Diagnose = modelManager.showdiagnoses(patientName, id1, id2);
                return View("showdiagnoses1");
            }
            catch (selectSymptomException e)
            {
                TempData["result"] = e.Message;
                return View();
            }
            catch(sameSymptomException e)
            {
                TempData["result"] = e.Message;
                return View();
            }
        }
    
        public ActionResult showdiagnoses1()
        {
            return RedirectToAction("showdiagnoses");
        }




    }
}