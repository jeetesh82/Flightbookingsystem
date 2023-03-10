using AmadeusApiIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmadeusApiIntegration.Controllers
{
    public class FlightBookingdetailsController : Controller
    {
        // GET: FlightBookingdetails
        public ActionResult Bookingdetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bookingdetails(string getFlightId)
        {
            fligSearofferRoot Finalflightdata = (fligSearofferRoot)Session["flightdata"];
            var listofIddata = (from x in Finalflightdata.data
                                where x.id == getFlightId
                                select x).ToList();
            return View(listofIddata);
        }
    }
}