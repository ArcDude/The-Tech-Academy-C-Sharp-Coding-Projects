using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSFinalProjectTechAcademy.Models;

namespace CSFinalProjectTechAcademy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Quote(string firstName, string lastName, string emailAddress, DateTime dateOfBirth,
                                    int carYear, string carMake, string carModel,int speedingTickets, bool dui, bool typeOfCoverage)
        {

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) ||
                string.IsNullOrEmpty(carMake) || string.IsNullOrEmpty(carModel))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (CarQuoteEntities db = new CarQuoteEntities())
                {
                    var quote = new Quote();
                    quote.FirstName = firstName;
                    quote.LastName = lastName;
                    quote.EmailAddress = emailAddress;
                    quote.DateOfBirth = dateOfBirth;
                    quote.CarYear = carYear;
                    quote.CarMake = carMake;
                    quote.CarModel = carModel;
                    quote.DUI = dui;
                    quote.SpeedingTickets = speedingTickets;
                    quote.TypeOfCoverage = typeOfCoverage;
                   
                    int startingPrice = 50;
                    DateTime now = DateTime.Now;
                    int age = now.Year - dateOfBirth.Year;
                    if (dateOfBirth <= now.AddYears(-age))
                    { 
                       if (age < 18) //if user is younger than 18
                        {
                          double price =  startingPrice + 100; // add 100
                            if (carYear < 2000 || carYear > 2015) // if the year of the car is less then 2000 or greater then 2015 
                            {
                                price += 25; // add 25
                            }
                            else
                            {
                                price += 0; // else add 0
                            }
                            if (carMake == "Porsche" && carModel == "911 Carrera") //if carMake is Porsche and the carModel is a 911 Carrera
                            {
                                price += 50; // add 50
                            }
                            else if (carMake == "Porsche") //else if the car make is Porsche and the model is not a 911 Carrera
                            {
                                price += 25; // add 25
                            }
                            else
                            {
                                price += 0; // add 0
                            }
                            if (speedingTickets > 0)
                            {
                              price += speedingTickets * 10;
                            }
                            else
                            {
                                price += 0;
                            }
                            if (dui == true) // If user has had a DUI
                            {
                                price += (25 / price) * 100; // add 25%
                            }
                            else
                            {
                                price += 0; // else add 0
                            }
                            if (typeOfCoverage == true) // If user is using full coverage
                            {
                                price += (50 / price) * 100; // add 50%
                            }
                            else
                            {
                                price += 0; // else add 0
                            }
                        }
                       else if (age < 25 || age > 100) // if user is younger than 25 or older then 100
                        {
                            double price = startingPrice += 25; // add 25
                            if (carYear < 2000 || carYear > 2015)// same as if statement starting on line 52
                            {
                                price += 25;
                            }
                            else
                            {
                                price += 0;
                            }
                            if (carMake == "Porsche" && carModel == "911 Carrera") //same as if statement starting on line 60
                            {
                                price += 50; 
                            }
                            else if (carMake == "Porsche") 
                            {
                                price += 25; 
                            }
                            else
                            {
                                price += 0; 
                            }
                            if (dui == true) // same as if statement starting on line 76
                            {
                                price += (25 / price) * 100; // add 25%
                            }
                            else
                            {
                                price += 0; // else add 0
                            }
                            if (typeOfCoverage == true) // If user is using full coverage
                            {
                                price += (50 / price) * 100; // add 50%
                            }
                            else
                            {
                                price += 0; // else add 0
                            }
                        }
                    }

                    db.Quotes.Add(quote);
                    db.SaveChanges();
                }
                return View("Success");
            }
        }

       
    }
}