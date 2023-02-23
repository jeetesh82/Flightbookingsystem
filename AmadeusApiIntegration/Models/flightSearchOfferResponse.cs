using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AmadeusApiIntegration.Models
{
    public class flightSearchOfferResponse
    {
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    [DataContract(Name = "Aircraft")]
    public class fligSearOfferAircraft
    {
        [DataMember(Name = "code")]
        public string code { get; set; }

        [JsonProperty("320")]
        public string _320 { get; set; }

        [JsonProperty("737")]
        public string _737 { get; set; }

        [JsonProperty("788")]
        public string _788 { get; set; }

        [JsonProperty("32A")]
        public string _32A { get; set; }

        [JsonProperty("7M8")]
        public string _7M8 { get; set; }
        public string DH8 { get; set; }

        [JsonProperty("73H")]
        public string _73H { get; set; }

        [JsonProperty("32N")]
        public string _32N { get; set; }
    }

    public class AMD
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    [DataContract(Name ="Arrival")]
    public class fligSearOfferArrival
    {
        public string iataCode { get; set; }
        public DateTime at { get; set; }
        public string terminal { get; set; }
    }

    public class BLR
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    public class BOM
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    public class Carriers
    {
        public string G8 { get; set; }
        public string SG { get; set; }
        public string UK { get; set; }
        public string AI { get; set; }
        public string W2 { get; set; }
    }

    public class CCU
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    public class Currencies
    {
        public string EUR { get; set; }
    }


    [DataContract(Name = "Datum")]
    public class fligSearofferDatum
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
        public List<Itinerary> itineraries { get; set; }

        [DataMember(Name = "price")]
        public Price price { get; set; }

        [DataMember(Name = "pricingOptions")]
        public PricingOptions pricingOptions { get; set; }

        [DataMember(Name = "validatingAirlineCodes")]
        public List<string> validatingAirlineCodes { get; set; }

        [DataMember(Name = "travelerPricings")]
        public List<TravelerPricing> travelerPricings { get; set; }
    }

    public class DEL
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }
    [DataContract(Name = "Departure")]
    public class fligSearofferDeparture
    {
        public string iataCode { get; set; }
        public string terminal { get; set; }
        public DateTime at { get; set; }
    }
    [DataContract(Name = "Dictionaries")]
    public class fligSearofferDictionaries
    {

        public Locations locations { get; set; }
        public Aircraft aircraft { get; set; }
        public Currencies currencies { get; set; }
        [DataMember(Name ="carriers")]
        public Carriers carriers { get; set; }
    }

    public class FareDetailsBySegment
    {
        public string segmentId { get; set; }
        public string cabin { get; set; }
        public string fareBasis { get; set; }
        public string @class { get; set; }
        public IncludedCheckedBags includedCheckedBags { get; set; }
        public string brandedFare { get; set; }
    }

    public class Fee
    {
        public string amount { get; set; }
        public string type { get; set; }
    }

    public class GOI
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    public class GOX
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    public class HYD
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    public class IncludedCheckedBags
    {
        public int weight { get; set; }
        public string weightUnit { get; set; }
    }

    [DataContract(Name= "Itinerary")]
    public class Itinerary
    {
        [DataMember(Name = "duration")]
        public string duration { get; set; }
        [DataMember(Name = "segments")]
        public List<fligSearofferSegment> segments { get; set; }
    }

    public class JAI
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }
    [DataContract(Name = "Links")]
    public class fligSearofferLinks
    {
        public string self { get; set; }
    }
    [DataContract(Name = "Locations")]
    public class fligSearofferLocations
    {
        public GOI GOI { get; set; }
        public BOM BOM { get; set; }
        public GOX GOX { get; set; }
        public PNQ PNQ { get; set; }
        public HYD HYD { get; set; }
        public PAT PAT { get; set; }
        public JAI JAI { get; set; }
        public CCU CCU { get; set; }
        public AMD AMD { get; set; }
        public BLR BLR { get; set; }
        public DEL DEL { get; set; }
        public MAA MAA { get; set; }
    }

    public class MAA
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    [DataContract(Name = "Meta")]
    public class fligSearofferMeta
    {
        public int count { get; set; }
        public Links links { get; set; }
    }
    [DataContract(Name = "Operating")]
    public class fligSearofferOperating
    {
        public string carrierCode { get; set; }
    }

    public class PAT
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    public class PNQ
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    public class Price
    {
        [DataMember(Name = "currency")]
        public string currency { get; set; }

        [DataMember(Name = "total")]
        public string total { get; set; }

        public string @base { get; set; }
        public List<Fee> fees { get; set; }

        [DataMember(Name = "grandTotal")]
        public string grandTotal { get; set; }
    }

    public class PricingOptions
    {
        public List<string> fareType { get; set; }
        public bool includedCheckedBagsOnly { get; set; }
    }
    [DataContract(Name = "Root")]
    public class fligSearofferRoot
    {
        [DataMember(Name = "meta")]
        public fligSearofferMeta meta { get; set; }

        [DataMember(Name = "data")]
        public List<fligSearofferDatum> data { get; set; }

        [DataMember(Name = "dictionaries")]
        public fligSearofferDictionaries dictionaries { get; set; }
    }

    [DataContract(Name = "Segment")]
    public class fligSearofferSegment
    {
        [DataMember(Name = "departure")]
        public Departure departure { get; set; }
        [DataMember(Name = "arrival")]
        public Arrival arrival { get; set; }
        [DataMember(Name = "carrierCode")]
        public string carrierCode { get; set; }
        [DataMember(Name = "number")]
        public string number { get; set; }
        [DataMember(Name = "aircraft")]
        public Aircraft aircraft { get; set; }
        [DataMember(Name = "operating")]
        public Operating operating { get; set; }
        [DataMember(Name = "duration")]
        public string duration { get; set; }
        [DataMember(Name = "id")]
        public string id { get; set; }
        [DataMember(Name = "numberOfStops")]
        public int numberOfStops { get; set; }
        [DataMember(Name = "blacklistedInEU")]
        public bool blacklistedInEU { get; set; }
    }

    public class TravelerPricing
    {
        public string travelerId { get; set; }
        public string fareOption { get; set; }
        public string travelerType { get; set; }
        public Price price { get; set; }
        public List<FareDetailsBySegment> fareDetailsBySegment { get; set; }
    }


}