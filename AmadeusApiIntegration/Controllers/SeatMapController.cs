using AmadeusApiIntegration.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AmadeusApiIntegration.Controllers
{
    public class SeatMapController : Controller
    {
        // GET: SeatMap
        public ActionResult CheckSeatAvailablity()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckSeatAvailablity(string getFlightId)
        {
            fligSearofferRoot Finalflightdata = (fligSearofferRoot)Session["flightdata"];
            var listofIddata = (from x in Finalflightdata.data
                                where x.id == getFlightId
                                select x).ToList();

            //var jsondata = JsonConvert.SerializeObject(listofIddata);
            //var Iddata = JsonConvert.DeserializeObject<List<fligSearofferDatum>>(jsondata);
            //SeatMap Api url 
            string Url = "https://test.api.amadeus.com/v1/shopping/seatmaps";

            SeatMapApiHelperRequest seatMapApiHelperRequest = new SeatMapApiHelperRequest()
            {
                data = new List<SeatMapApiReqDatum>
                 {
                     new SeatMapApiReqDatum()
                     {

                         type=listofIddata.Select(x=>x.type).FirstOrDefault(),
                         id=listofIddata.Select(x=>x.id).FirstOrDefault(),
                         source=listofIddata.Select(x=>x.source).FirstOrDefault(),
                         instantTicketingRequired=listofIddata.Select(x=>x.instantTicketingRequired).FirstOrDefault(),
                         nonHomogeneous=listofIddata.Select(x=>x.nonHomogeneous).FirstOrDefault(),
                         oneWay=listofIddata.Select(x=>x.oneWay).FirstOrDefault(),
                         lastTicketingDate=listofIddata.Select(x=>x.lastTicketingDate).FirstOrDefault(),
                         numberOfBookableSeats=listofIddata.Select(x=>x.numberOfBookableSeats).FirstOrDefault(),

                         itineraries=GetAllItenararyDetails(listofIddata.Select(x=>x.itineraries).ToList())
                         //itineraries=new List<SeatMapApiReqItinerary>
                         //{
                         //    new SeatMapApiReqItinerary()
                         //    {
                         //        duration=listofIddata.Select(x=>x.itineraries.Select(x=>x.duration).FirstOrDefault()).FirstOrDefault(),
                         //        segments=new List<SeatMapApiReqSegment>
                         //        {
                         //            new SeatMapApiReqSegment()
                         //            {
                         //              departure=new SeatMapApiReqDeparture()
                         //              {

                         //                      iataCode=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.departure.iataCode).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                         //                      terminal=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.departure.terminal).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                         //                      at=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.departure.at).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),

                         //              },
                         //              arrival=new SeatMapApiReqArrival()
                         //              {
                         //                  iataCode=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.arrival.iataCode).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                         //                  terminal=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.arrival.terminal).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                         //                  at=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.arrival.at).FirstOrDefault()).FirstOrDefault()).FirstOrDefault()
                         //              },

                         //              carrierCode=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.carrierCode).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                         //              number=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.number).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                         //              aircraft=new SeatMapApiReqAircraft()
                         //              {
                         //                  code=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.aircraft.code).FirstOrDefault()).FirstOrDefault()).FirstOrDefault()
                         //              },
                         //              operating=new SeatMapApiReqOperating()
                         //              {
                         //                  carrierCode=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.operating.carrierCode).FirstOrDefault()).FirstOrDefault()).FirstOrDefault()
                         //              },
                         //              duration=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.duration).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                         //              id=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.id).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                         //              numberOfStops=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.numberOfStops).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                         //              blacklistedInEU=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.blacklistedInEU).FirstOrDefault()).FirstOrDefault()).FirstOrDefault()

                         //            }
                         //        }.ToList()
                         //    }
                         //},
                         ,

                           price=new SeatMapApiReqPrice()
                           {
                               currency=listofIddata.Select(x=>x.price.currency).FirstOrDefault(),
                               total=listofIddata.Select(x=>x.price.total).FirstOrDefault(),
                               @base=listofIddata.Select(x=>x.price.@base).FirstOrDefault(),
                               fees=new List<SeatMapApiReqFee>
                               {
                                   new SeatMapApiReqFee()
                                   {
                                       amount=listofIddata.Select(x=>x.price.fees.Select(y=>y.amount).FirstOrDefault()).FirstOrDefault(),
                                       type=listofIddata.Select(x=>x.price.fees.Select(y=>y.type).FirstOrDefault()).FirstOrDefault()

                                   },
                                   new SeatMapApiReqFee()
                                   {
                                       amount=listofIddata.Select(x=>x.price.fees.Select(y=>y.amount).LastOrDefault()).LastOrDefault(),
                                       type=listofIddata.Select(x=>x.price.fees.Select(y=>y.type).LastOrDefault()).LastOrDefault()

                                   }

                               },
                               grandTotal=listofIddata.Select(x=>x.price.grandTotal).FirstOrDefault(),
                               additionalServices=new List<AdditionalService>
                               {
                                   new AdditionalService()
                                   {
                                       amount="0.00",
                                       type="CHECKED_BAGS"
                                   }

                               }

                           },
                           pricingOptions=new SeatMapApiReqPricingOptions()
                           {
                               fareType=(listofIddata.Select(x=>x.pricingOptions.fareType).FirstOrDefault()),

                               includedCheckedBagsOnly=listofIddata.Select(x=>x.pricingOptions.includedCheckedBagsOnly).FirstOrDefault()
                           },
                           validatingAirlineCodes=(listofIddata.Select(x=>x.validatingAirlineCodes).FirstOrDefault()),


                           travelerPricings=new List<SeatMapApiReqTravelerPricing>
                           {
                               new SeatMapApiReqTravelerPricing()
                               {
                                   travelerId=listofIddata.Select(x=>x.travelerPricings.Select(y=>y.travelerId).FirstOrDefault()).FirstOrDefault(),
                                   fareOption=listofIddata.Select(x=>x.travelerPricings.Select(y=>y.fareOption).FirstOrDefault()).FirstOrDefault(),
                                   travelerType=listofIddata.Select(x=>x.travelerPricings.Select(y=>y.travelerType).FirstOrDefault()).FirstOrDefault(),
                                   price=new SeatMapApiReqPrice()
                                   {
                                       currency=listofIddata.Select(x=>x.travelerPricings.Select(y=>y.price.currency).FirstOrDefault()).FirstOrDefault(),
                                       total=listofIddata.Select(x=>x.travelerPricings.Select(y=>y.price.total).FirstOrDefault()).FirstOrDefault(),
                                       @base=listofIddata.Select(x=>x.travelerPricings.Select(y=>y.price.@base).FirstOrDefault()).FirstOrDefault()
                                   },

                                   fareDetailsBySegment=new List<SeatMapApiReqFareDetailsBySegment>
                                   {
                                       new SeatMapApiReqFareDetailsBySegment()
                                       {
                                           segmentId=listofIddata.Select(x=>x.travelerPricings.Select(y=>y.fareDetailsBySegment.Select(z=>z.segmentId).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                                           cabin=listofIddata.Select(x=>x.travelerPricings.Select(y=>y.fareDetailsBySegment.Select(z=>z.cabin).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                                           fareBasis=listofIddata.Select(x=>x.travelerPricings.Select(y=>y.fareDetailsBySegment.Select(z=>z.fareBasis).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                                           brandedFare=listofIddata.Select(x=>x.travelerPricings.Select(y=>y.fareDetailsBySegment.Select(z=>z.brandedFare).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                                           @class=listofIddata.Select(x=>x.travelerPricings.Select(y=>y.fareDetailsBySegment.Select(z=>z.@class).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                                           includedCheckedBags=new SeatMapApiReqIncludedCheckedBags()
                                           {
                                               quantity=0
                                           }
                                       }
                                   }
                               }
                           }
                     }
                 }

            };

            FlightBookingSystemEntities db = new FlightBookingSystemEntities();

            SeatMapApiHelperResponse result = Post<SeatMapApiHelperResponse>(Url, seatMapApiHelperRequest);
            //flightDetail flightdetail = new flightDetail()
            //{
            //    travelerId = result.data.Select(x =>Convert.ToInt32(x.id)).FirstOrDefault(),
            //    Origin_Location=result.data.Select(x=>x.departure.iataCode).FirstOrDefault(),
            //    Destination_Location=result.data.Select(x=>x.arrival.iataCode).FirstOrDefault(),
            //    From_Date_Time= result.data.Select(x => x.departure.at).FirstOrDefault(),
            //    To_Date_Time= result.data.Select(x => x.arrival.at).FirstOrDefault(),
            //    Airline_Code= result.data.Select(x => x.carrierCode).FirstOrDefault(),
            //    Aircraft_Code=result.data.Select(x => x.aircraft.code).FirstOrDefault(),
            //    segmentId= result.data.Select(x =>Convert.ToInt32(x.segmentId)).FirstOrDefault(),
            //    flightOfferId= result.data.Select(x => Convert.ToInt32(x.flightOfferId)).FirstOrDefault(),
            //    @class= result.data.Select(x => x.@class).FirstOrDefault(),
            //    number= result.data.Select(x =>Convert.ToInt32(x.number)).FirstOrDefault()
            //};
            //SeatAvailabilityDetail availabilityDetail = new SeatAvailabilityDetail()
            //{
            //    cabin = result.data.Select(x => x.decks.Select(y=>y.seats.Select(z=>z.cabin).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
            //    Seat_Number= result.data.Select(x => x.decks.Select(y => y.seats.Select(z =>z.number).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
            //    Seat_total_Price= result.data.Select(x => x.decks.Select(y => y.seats.Select(z => z.travelerPricing.Select(c=>c.price.total).FirstOrDefault()).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
            //    Seat_base_Price= result.data.Select(x => x.decks.Select(y => y.seats.Select(z => z.travelerPricing.Select(c => c.price.@base).FirstOrDefault()).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
            //    Taxes_Amount= result.data.Select(x => x.decks.Select(y => y.seats.Select(z => z.travelerPricing.Select(c => c.price.taxes.Select(s=>s.amount).FirstOrDefault()).FirstOrDefault()).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
            //    coordinates= result.data.Select(x => x.decks.Select(y => y.seats.Select(z =>Convert.ToString(z.coordinates)).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
            //    seatAvailabilityStatus= result.data.Select(x => x.decks.Select(y => y.seats.Select(z => z.travelerPricing.Select(c => c.seatAvailabilityStatus).FirstOrDefault()).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
            //    segmentId = result.data.Select(x => Convert.ToInt32(x.segmentId)).FirstOrDefault(),
            //    flightOfferId = result.data.Select(x => Convert.ToInt32(x.flightOfferId)).FirstOrDefault()
            //};
            //db.flightDetails.Add(flightdetail);
            //db.SeatAvailabilityDetails.Add(availabilityDetail);
            //db.SaveChanges();
            return View(result);
        }

        public List<SeatMapApiReqItinerary> GetAllItenararyDetails(List<Itinerary> itinerarycol)
        {
            List<SeatMapApiReqItinerary> seatMapApiReqItineraries = new List<SeatMapApiReqItinerary>();

            foreach (var itinerary in itinerarycol)
            {
                seatMapApiReqItineraries.Add(
                    new SeatMapApiReqItinerary()
                    {
                        duratio
                    }

                    );
            }
            
            var segmentdetailscol = listofIddatacol.Select(x => x.itineraries).ToList();
            foreach (var listofIddata in itineraryobj)
            {
                itineraryobj.Add(new SeatMapApiReqItinerary()
                {
                    segments = new List<SeatMapApiReqSegment>()
                    {
                        new SeatMapApiReqSegment()
                        {
                             departure=new SeatMapApiReqDeparture()
                                       {

                                               iataCode=listofIddata.segments.Select(z=>z.departure.iataCode).FirstOrDefault(),
                                               //terminal=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.departure.terminal).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                                               //at=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.departure.at).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),

                                       }
                             

                                       //arrival=new SeatMapApiReqArrival()
                                       //{
                                       //    iataCode=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.arrival.iataCode).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                                       //    terminal=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.arrival.terminal).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                                       //    at=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.arrival.at).FirstOrDefault()).FirstOrDefault()).FirstOrDefault()
                                       //},

                                       //carrierCode=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.carrierCode).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                                       //number=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.number).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                                       //aircraft=new SeatMapApiReqAircraft()
                                       //{
                                       //    code=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.aircraft.code).FirstOrDefault()).FirstOrDefault()).FirstOrDefault()
                                       //},
                                       //operating=new SeatMapApiReqOperating()
                                       //{
                                       //    carrierCode=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.operating.carrierCode).FirstOrDefault()).FirstOrDefault()).FirstOrDefault()
                                       //},
                                       //duration=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.duration).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                                       //id=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.id).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                                       //numberOfStops=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.numberOfStops).FirstOrDefault()).FirstOrDefault()).FirstOrDefault(),
                                       //blacklistedInEU=listofIddata.Select(x=>x.itineraries.Select(y=>y.segments.Select(z=>z.blacklistedInEU).FirstOrDefault()).FirstOrDefault()).FirstOrDefault()


                        }
                    }
                });
            }

            return itineraryobj;


        }

        internal T Post<T>(string postUrl, object data)
        {
            T output = default(T);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(postUrl);
                //string strToken = Helper.GetEnumValue(KeyTypes.UserId) + ":" + Helper.GetEnumValue(KeyTypes.HeaderPassword);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var jsonData = JsonConvert.SerializeObject(data);

                var jsondata = JsonConvert.SerializeObject(data).Replace("@class", "class");
                var JsonData = jsondata.Replace("@base", "base");
                HttpContent content = new StringContent(JsonData, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage messge = client.PostAsync(postUrl, content).Result;

                if (messge.IsSuccessStatusCode)
                {
                    string result = messge.Content.ReadAsStringAsync().Result;
                    output = JsonConvert.DeserializeObject<T>(result);
                }
            }

            return output;
        }

    }

}