using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSFinalProjectTechAcademy.Models;
using CSFinalProjectTechAcademy.ViewModels;

namespace CSFinalProjectTechAcademy.Controllers
{

    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (CarQuoteEntities db = new CarQuoteEntities())
            {
                var quotes = (from c in db.Quotes
                              select c).ToList();
                var quoteVms = new List<QuoteVm>();
                foreach (var quote in quotes)
                {
                    var quoteVm = new QuoteVm();
                    quoteVm.Id = quote.Id;
                    quoteVm.FirstName = quote.FirstName;
                    quoteVm.LastName = quote.LastName;
                    quoteVm.EmailAddress = quote.EmailAddress;
                    quoteVms.Add(quoteVm);
                }

                return View(quoteVms);
            }
        }
    }
}