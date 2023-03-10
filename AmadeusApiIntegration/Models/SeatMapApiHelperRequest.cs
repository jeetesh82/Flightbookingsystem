using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AmadeusApiIntegration.Models
{
    [DataContract(Name = "Root")]
    public class SeatMapApiHelperRequest
    {
        [DataMember(Name = "data")]
        public List<SeatMapApiReqDatum> data { get; set; }

    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AdditionalService
    {
        public string amount { get; set; }
        public string type { get; set; }
    }


    [DataContract(Name = "Aircraft")]
    public class SeatMapApiReqAircraft
    {
        [DataMember(Name = "code")]
        public string code { get; set; }
    }

    [DataContract(Name = "Arrival")]
    public class SeatMapApiReqArrival
    {
        [DataMember(Name = "iataCode")]
        public string iataCode { get; set; }

        [DataMember(Name = "terminal")]
        public string terminal { get; set; }

        [DataMember(Name = "at")]
        public DateTime at { get; set; }
    }

    [DataContract(Name = "Datum")]
    public class SeatMapApiReqDatum
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "source")]
        public string source { get; set; }

        [DataMember(Name = "instantTicketingRequired")]
        public bool instantTicketingRequired { get; set; }

        [DataMember(Name = "nonHomogeneous")]
        public bool nonHomogeneous { get; set; }

        [DataMember(Name = "oneWay")]
        public bool oneWay { get; set; }

        [DataMember(Name = "lastTicketingDate")]
        public string lastTicketingDate { get; set; }

        [DataMember(Name = "numberOfBookableSeats")]
        public int numberOfBookableSeats { get; set; }

        [DataMember(Name = "itineraries")]
        public List<SeatMapApiReqItinerary> itineraries { get; set; }

        [DataMember(Name = "price")]
        public SeatMapApiReqPrice price { get; set; }

        [DataMember(Name = "pricingOptions")]
        public SeatMapApiReqPricingOptions pricingOptions { get; set; }

        [DataMember(Name = "validatingAirlineCodes")]
        public List<string> validatingAirlineCodes { get; set; }

        [DataMember(Name = "travelerPricings")]
        public List<SeatMapApiReqTravelerPricing> travelerPricings { get; set; }
    }


    [DataContract(Name = "Departure")]
    public class SeatMapApiReqDeparture
    {
        [DataMember(Name = "iataCode")]
        public string iataCode { get; set; }

        [DataMember(Name = "terminal")]
        public string terminal { get; set; }

        [DataMember(Name = "at")]
        public DateTime at { get; set; }
    }

    [DataContract(Name = "FareDetailsBySegment")]
    public class SeatMapApiReqFareDetailsBySegment
    {
        [DataMember(Name = "segmentId")]
        public string segmentId { get; set; }

        [DataMember(Name = "cabin")]
        public string cabin { get; set; }

        [DataMember(Name = "fareBasis")]
        public string fareBasis { get; set; }

        [DataMember(Name = "brandedFare")]
        public string brandedFare { get; set; }

        [DataMember(Name = "@class")]
        public string @class { get; set; }

        [DataMember(Name = "includedCheckedBags")]
        public SeatMapApiReqIncludedCheckedBags includedCheckedBags { get; set; }
    }

    [DataContract(Name = "Fee")]
    public class SeatMapApiReqFee
    {
        [DataMember(Name = "amount")]
        public string amount { get; set; }

        [DataMember(Name = "type")]
        public string type { get; set; }
    }

    [DataContract(Name = "IncludedCheckedBags")]
    public class SeatMapApiReqIncludedCheckedBags
    {
        [DataMember(Name = "quantity")]
        public int quantity { get; set; }
    }

    [DataContract(Name = "Itinerary")]
    public class SeatMapApiReqItinerary
    {
        [DataMember(Name = "duration")]
        public string duration { get; set; }

        [DataMember(Name = "segments")]
        public List<SeatMapApiReqSegment> segments { get; set; }
    }

    [DataContract(Name = "Operating")]
    public class SeatMapApiReqOperating
    {
        [DataMember(Name = "carrierCode")]
        public string carrierCode { get; set; }
    }

    [DataContract(Name = "Price")]
    public class SeatMapApiReqPrice
    {
        [DataMember(Name = "currency")]
        public string currency { get; set; }

        [DataMember(Name = "total")]
        public string total { get; set; }

        [DataMember(Name = "@base")]
        public string @base { get; set; }

        [DataMember(Name = "fees")]
        public List<SeatMapApiReqFee> fees { get; set; }

        [DataMember(Name = "grandTotal")]
        public string grandTotal { get; set; }

        [DataMember(Name = "additionalServices")]
        public List<AdditionalService> additionalServices { get; set; }
    }

    [DataContract(Name = "PricingOptions")]
    public class SeatMapApiReqPricingOptions
    {
        [DataMember(Name = "fareType")]
        public List<string> fareType { get; set; }

        [DataMember(Name = "includedCheckedBagsOnly")]
        public bool includedCheckedBagsOnly { get; set; }
    }


    [DataContract(Name = "Segment")]
    public class SeatMapApiReqSegment
    {
        [DataMember(Name = "departure")]
        public SeatMapApiReqDeparture departure { get; set; }

        [DataMember(Name = "arrival")]
        public SeatMapApiReqArrival arrival { get; set; }

        [DataMember(Name = "carrierCode")]
        public string carrierCode { get; set; }

        [DataMember(Name = "number")]
        public string number { get; set; }

        [DataMember(Name = "aircraft")]
        public SeatMapApiReqAircraft aircraft { get; set; }

        [DataMember(Name = "operating")]
        public SeatMapApiReqOperating operating { get; set; }

        [DataMember(Name = "duration")]
        public string duration { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "numberOfStops")]
        public int numberOfStops { get; set; }

        [DataMember(Name = "blacklistedInEU")]
        public bool blacklistedInEU { get; set; }
    }

    [DataContract(Name = "TravelerPricing")]
    public class SeatMapApiReqTravelerPricing
    {
        [DataMember(Name = "travelerId")]
        public string travelerId { get; set; }

        [DataMember(Name = "fareOption")]
        public string fareOption { get; set; }

        [DataMember(Name = "travelerType")]
        public string travelerType { get; set; }

        [DataMember(Name = "price")]
        public SeatMapApiReqPrice price { get; set; }

        [DataMember(Name = "fareDetailsBySegment")]
        public List<SeatMapApiReqFareDetailsBySegment> fareDetailsBySegment { get; set; }
    }


}