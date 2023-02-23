using RestSharp;
using System.Net.Http.Headers;
using RestSharp.Authenticators;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AmadeusApiIntegration.Models;
using System.Web.Mvc;
using System.Security.Policy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySqlX.XDevAPI;
using System.Threading.Tasks;
using System.IdentityModel.Protocols.WSTrust;
using System.Web;

namespace AmadeusApiIntegration.Controllers
{
    public class CheckflightAvailablityController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Token Generate webApi
        public ActionResult GenerateToken()
        {
            GenerateToken generateToken = new GenerateToken();
            var results = generateToken.token();
            Session["token"] = results;
            return RedirectToAction("Index");
        }

        //Airport and City Search Method webApi

        public ActionResult SearchAirportCity()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchAirportCity(string IATAcode)
        {
            if (Session["token"] == null)
            {
                GenerateToken();
            }

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri("https://test.api.amadeus.com/v1/reference-data/locations");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());


                var responseTask = client.GetAsync("?subType=AIRPORT&keyword=" + IATAcode + "&page%5Blimit%5D=10&page%5Boffset%5D=0&sort=analytics.travelers.score&view=FULL");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result.Content.ReadAsStringAsync().Result;
                var rootData = JsonConvert.DeserializeObject<Root>(result);
                var airpoNameandAddress = rootData.data.Select(
                    x => new
                    {
                        address = x.address,
                        name = x.name,
                        iataCode = x.iataCode
                    }
                    ).ToList();
                // var replace=result.Replace(""", "\"");
                // Address address = (Address)JsonConvert.DeserializeObject(result, Address);
                //RESTJSONDeserializer data = new RESTJSONDeserializer();
                //var datas =data.Deserializerdata(result);

                // model = JsonConvert.DeserializeObject<List<Address>>(result);
                //return View(address.cityName,address.countryName);

                //var Name = (from N in address
                //            where N.cityName.StartsWith(IATAcode)
                //            select new { N.cityName });


                return Json(airpoNameandAddress, JsonRequestBehavior.AllowGet);
            }

        }


        //Flight Availabilities Search Method webApi
        //public ActionResult SearchFlightAvailable()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public  ActionResult SearchFlightAvailable( DateTime Departuredate, string OriginLocation, string destinationLocation)
        //{

        //    if (Session["token"] == null)
        //    {
        //        GenerateToken();
        //    }
        //    string Url = "https://test.api.amadeus.com/v1/shopping/availability/flight-availabilities";
        //    var record = new Roots()
        //            {
        //                originDestinations=new List<OriginDestination>
        //                {
        //                    new OriginDestination()
        //                    {
        //                        id="1",
        //                        originLocationCode=OriginLocation.Substring(OriginLocation.Length-3),
        //                      destinationLocationCode=destinationLocation.Substring(destinationLocation.Length-3),
        //                      departureDateTime=new DepartureDateTime()
        //                    {
        //                          date=Departuredate.ToString("yyyy-MM-dd"),
        //                          time=DateTime.Now.ToString("HH:mm:ss")
        //                    }
        //                }
        //                },
        //                travelers=new List<Traveler>
        //                {
        //                    new Traveler()
        //                    {
        //                        id="1",
        //                        travelerType="ADULT"
        //                    }
        //                },
        //                sources=new List<string>
        //                {
        //                    "GDS"
        //                }
        //        };
        //   SearchFlightAviResponse result=Post<SearchFlightAviResponse>(Url, record);
        //    if (result.data==null || result.dictionaries==null || result.meta==null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(result);
        //    }


        //}

        //internal  T Post<T>(string postUrl, object data)
        //{
        //    T output = default(T);
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new System.Uri(postUrl);
        //        //string strToken = Helper.GetEnumValue(KeyTypes.UserId) + ":" + Helper.GetEnumValue(KeyTypes.HeaderPassword);
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        var jsonData = JsonConvert.SerializeObject(data);
        //        HttpContent content = new StringContent(jsonData, UTF8Encoding.UTF8, "application/json");
        //        HttpResponseMessage messge = client.PostAsync(postUrl, content).Result;

        //        if (messge.IsSuccessStatusCode)
        //        {
        //            string result = messge.Content.ReadAsStringAsync().Result;
        //            output = JsonConvert.DeserializeObject<T>(result);
        //        }
        //    }

        //    return output;
        //}



        //Flight Offer Search Api

        public ActionResult flightAvailableData()
        {
            return View();
        }

        [HttpPost]

        public ActionResult flightAvailableData(flightsearch flightsearch)
        {

            if (flightsearch.travelclass == "Economy class")
            {
                flightsearch.travelclass = "ECONOMY";
            }
            else if (flightsearch.travelclass == "Business class")
            {
                flightsearch.travelclass = "BUSINESS";
            }
            else if (flightsearch.travelclass == "First class")
            {
                flightsearch.travelclass = "FIRST";
            }
            else
            {
                flightsearch.travelclass = "null";
            }


            if (Session["token"] != null)
            {
                GenerateToken();
            }

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri("https://test.api.amadeus.com/v2/shopping/flight-offers");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());
                if (flightsearch.returndate.Year == DateTime.Now.Year)
                {

                    //taking return date -  roundtrip

                    string Url2 = "?originLocationCode=" + flightsearch.OriginLocation.Substring(flightsearch.OriginLocation.Length - 3) + "&destinationLocationCode=" + flightsearch.destinationLocation.Substring(flightsearch.destinationLocation.Length - 3) + "&departureDate=" + flightsearch.Departuredate.ToString("yyyy-MM-dd") + "&returnDate=" + flightsearch.returndate.ToString("yyyy-MM-dd") + "&adults=" + flightsearch.travelertypeAdult + "&travelClass=" + flightsearch.travelclass + "&nonStop=" + flightsearch.flighttype + "&currencyCode=INR&max=250";
                    var responseTask = client.GetAsync(Url2);
                    responseTask.Wait();
                    var result = responseTask.Result.Content.ReadAsStringAsync().Result;
                    //fligSearofferRoot _fligSearofferRoot = new fligSearofferRoot();
                    //_fligSearofferRoot = JsonConvert.DeserializeObject<fligSearofferRoot>(result);
                    //Session["flightdata"] = _fligSearofferRoot;
                    //var flightdatas = Session["flightdata"];
                    //ModelState.Clear();
                    //return View(_fligSearofferRoot);
                    var flightAvidata = JsonConvert.DeserializeObject<fligSearofferRoot>(result);
                    Session["flightdata"] = flightAvidata;
                    var finaldata = Session["flightdata"];
                    ModelState.Clear();
                    return View(flightAvidata);


                }
                else
                {
                    //not taking return date - one way

                    string Url2 = "?originLocationCode=" + flightsearch.OriginLocation.Substring(flightsearch.OriginLocation.Length - 3) + "&destinationLocationCode=" + flightsearch.destinationLocation.Substring(flightsearch.destinationLocation.Length - 3) + "&departureDate=" + flightsearch.Departuredate.ToString("yyyy-MM-dd") + "&adults=" + flightsearch.travelertypeAdult + "&travelClass=" + flightsearch.travelclass + "&nonStop=" + flightsearch.flighttype + "&currencyCode=INR&max=250";
                    var responseTask = client.GetAsync(Url2);
                    responseTask.Wait();
                    var result = responseTask.Result.Content.ReadAsStringAsync().Result;
                    var flightAvidata = JsonConvert.DeserializeObject<fligSearofferRoot>(result);
                    Session["flightdata"] = flightAvidata;
                    ModelState.Clear();
                    return View(flightAvidata);

                }

            }

            return View();

        }
        [HttpGet]
        public ActionResult Appliedfilter()
        {
            return View("Appliedfilter");
        }

        [HttpPost]
        public ActionResult Appliedfilter(string checkboxvalue)
        {
            if (Session["flightdata"] == null)
            {
                return View("flightAvailableData");
            }
            if (Session["flightdata"] != null && checkboxvalue != null && checkboxvalue == "true")
            {
                fligSearofferRoot allflightdata = (fligSearofferRoot)Session["flightdata"];
                if (checkboxvalue != null && checkboxvalue == "true")
                {

                    var roundtripnonstopflights = new List<fligSearofferDatum>();
                    foreach (var item in allflightdata.data)
                    {
                        //var itemsdata = item.itineraries.Where(x => x.segments.Count == 1).ToList();
                        //if (itemsdata.Any())
                        //{
                        //    roundtripnonstopflights.Add(item);
                        //}
                        //else
                        //{
                        int inbouundsegment = item.itineraries[0].segments.Count();
                        int outboundsegment = item.itineraries[1].segments.Count();
                        if (inbouundsegment == 1 && outboundsegment == 1)
                        {
                            roundtripnonstopflights.Add(item);
                        }


                    }


                    if (roundtripnonstopflights.Any())
                    {

                        allflightdata.data = roundtripnonstopflights.ToList();
                        ModelState.Clear();
                        return RedirectToAction("Appliedfilter", "CheckflightAvailablity");
                        //return Json(allflightdata, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        allflightdata = null;
                        ModelState.Clear();
                        return View("Appliedfilter", allflightdata);
                    }

                }
            }
            else if (Session["flightdata"] != null && checkboxvalue != null && checkboxvalue == "false")
            {
                fligSearofferRoot allflightdata = (fligSearofferRoot)Session["flightdata"];
                if (checkboxvalue != null && checkboxvalue == "false")
                {

                    var roundtripOnestopflights = new List<fligSearofferDatum>();
                    foreach (var item in allflightdata.data)
                    {

                        int inbouundsegment = item.itineraries[0].segments.Count();
                        int outboundsegment = item.itineraries[1].segments.Count();
                        if (inbouundsegment == 2 && outboundsegment == 2)
                        {
                            roundtripOnestopflights.Add(item);
                        }


                    }


                    if (roundtripOnestopflights.Any())
                    {

                        allflightdata.data = roundtripOnestopflights.ToList();
                        ModelState.Clear();
                        return View("Appliedfilter", allflightdata);
                        //return Json(allflightdata, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        allflightdata = null;
                        ModelState.Clear();
                        return View("Appliedfilter", allflightdata);
                    }

                }
            }
            //if (checkboxvalue != null && checkboxvalue == "false")
            //{

            //    var OneStop = (from x in allflightdata.data
            //                   where x.itineraries.Select(x => x.segments).Count() > 1
            //                   select x);
            //    if (OneStop.Any())
            //    {

            //        allflightdata.data = OneStop.ToList();
            //        ModelState.Clear();
            //        return View("flightAvailableData", allflightdata);

            //    }
            //    else
            //    {
            //        allflightdata = null;
            //        ModelState.Clear();
            //        return View("flightAvailableData", allflightdata);
            //    }



            else if (Session["flightdata"] != null && checkboxvalue != null && checkboxvalue == "cheapprice")
            {
                fligSearofferRoot allflightdata = (fligSearofferRoot)Session["flightdata"];
                if (checkboxvalue != null && checkboxvalue == "cheapprice")
                {
                    var Cheapest_Price = allflightdata.data.OrderBy(x => Convert.ToDouble(x.price.grandTotal));
                    ModelState.Clear();
                    return View("Appliedfilter", Cheapest_Price);

                    //return Json(allflightdata, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    allflightdata = null;
                    ModelState.Clear();
                    return View("Appliedfilter", allflightdata);
                }

            }
            else
            {
                return RedirectToAction("flightAvailableData");
                //return View("Appliedfilter");
            }

            return View("Appliedfilter");
        }
    }
}






