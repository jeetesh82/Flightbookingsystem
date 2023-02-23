using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AmadeusApiIntegration.Models
{
    public class SeatMapApiRequest
    {
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    [DataContract(Name = "Aircraft")]
    public class SeatMapApiReqAircraft
    {
        [DataMember(Name = "code")]
        public string code { get; set; }
    }

    [DataContract(Name = "Arrival")]
    public class SeatMapApiReqArrival
    {
        public string iataCode { get; set; }
        public DateTime at { get; set; }
        public string terminal { get; set; }
    }

    [DataContract(Name = "Datum")]
    public class SeatMapApiReqDatum
    {
        public string type { get; set; }
        public string id { get; set; }
        public string source { get; set; }
        public bool instantTicketingRequired { get; set; }
        public bool nonHomogeneous { get; set; }
        public bool oneWay { get; set; }
        public string lastTicketingDate { get; set; }
        public int numberOfBookableSeats { get; set; }
        public List<SeatMapApiReqItinerary> itineraries { get; set; }
        public SeatMapApiReqPrice price { get; set; }
        public SeatMapApiReqPricingOptions pricingOptions { get; set; }
        public List<string> validatingAirlineCodes { get; set; }
        public List<SeatMapApiReqTravelerPricing> travelerPricings { get; set; }
    }

    [DataContract(Name = "Departure")]
    public class SeatMapApiReqDeparture
    {
        public string iataCode { get; set; }
        public string terminal { get; set; }
        public DateTime at { get; set; }
    }

    [DataContract(Name = "FareDetailsBySegment")]
    public class SeatMapApiReqFareDetailsBySegment
    {
        public string segmentId { get; set; }
        public string cabin { get; set; }
        public string fareBasis { get; set; }
        public string @class { get; set; }
        public SeatMapApiReqIncludedCheckedBags includedCheckedBags { get; set; }
    }


    [DataContract(Name = "Fee")]
    public class SeatMapApiReqFee
    {
        public string amount { get; set; }
        public string type { get; set; }
    }

    [DataContract(Name = "IncludedCheckedBags")]
    public class SeatMapApiReqIncludedCheckedBags
    {
        public int weight { get; set; }
        public string weightUnit { get; set; }
    }

    [DataContract(Name = "Itinerary")]
    public class SeatMapApiReqItinerary
    {
        public string duration { get; set; }
        public List<SeatMapApiReqSegment> segments { get; set; }
    }

    [DataContract(Name = "Operating")]
    public class SeatMapApiReqOperating
    {
        public string carrierCode { get; set; }
    }

    [DataContract(Name = "Price")]
    public class SeatMapApiReqPrice
    {
        public string currency { get; set; }
        public string total { get; set; }
        public string @base { get; set; }
        public List<SeatMapApiReqFee> fees { get; set; }
        public string grandTotal { get; set; }
    }

    [DataContract(Name = "PricingOptions")]
    public class SeatMapApiReqPricingOptions
    {
        public List<string> fareType { get; set; }
        public bool includedCheckedBagsOnly { get; set; }
    }

    [DataContract(Name = "Root")]
    public class SeatMapApiReqRoot
    {
        public List<SeatMapApiReqDatum> data { get; set; }
    }

    [DataContract(Name = "Segment")]
    public class SeatMapApiReqSegment
    {
        public Departure departure { get; set; }
        public Arrival arrival { get; set; }
        public string carrierCode { get; set; }
        public string number { get; set; }
        public SeatMapApiReqAircraft aircraft { get; set; }
        public SeatMapApiReqOperating operating { get; set; }
        public string duration { get; set; }
        public string id { get; set; }
        public int numberOfStops { get; set; }
        public bool blacklistedInEU { get; set; }
    }

    [DataContract(Name = "TravelerPricing")]
    public class SeatMapApiReqTravelerPricing
    {
        public string travelerId { get; set; }
        public string fareOption { get; set; }
        public string travelerType { get; set; }
        public SeatMapApiReqPrice price { get; set; }
        public List<SeatMapApiReqFareDetailsBySegment> fareDetailsBySegment { get; set; }
    }


}