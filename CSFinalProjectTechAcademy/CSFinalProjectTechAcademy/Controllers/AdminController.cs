using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSFinalProjectTechAcademy.Models;

namespace CSFinalProjectTechAcademy.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (CarQuoteEntities db = new CarQuoteEntities())
            return View();
        }
    }
}