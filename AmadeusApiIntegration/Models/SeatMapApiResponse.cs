using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AmadeusApiIntegration.Models
{
    public class SeatMapApiResponse
    {
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    [DataContract(Name= "Aircraft")]
    public class SeatMapApiResAircraft
    {
        public string code { get; set; }
    }

    public class AircraftCabinAmenities
    {
        public Power power { get; set; }
        public Seat seat { get; set; }
        public Wifi wifi { get; set; }
        public List<Entertainment> entertainment { get; set; }
        public Food food { get; set; }
        public Beverage beverage { get; set; }
    }

    [DataContract(Name = "Arrival")]
    public class SeatMapApiResArrival
    {
        public string iataCode { get; set; }
        public DateTime at { get; set; }
        public string terminal { get; set; }
    }

    public class AvailableSeatsCounter
    {
        public string travelerId { get; set; }
        public int value { get; set; }
    }

    public class Beverage
    {
        public bool isChargeable { get; set; }
        public string beverageType { get; set; }
    }

    public class CMB
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    public class Coordinates
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    [DataContract(Name = "Datum")]
    public class SeatMapApiResDatum
    {
        public string id { get; set; }
        public string type { get; set; }
        public Departure departure { get; set; }
        public Arrival arrival { get; set; }
        public string carrierCode { get; set; }
        public string number { get; set; }
        public Operating operating { get; set; }
        public Aircraft aircraft { get; set; }
        public string @class { get; set; }
        public string flightOfferId { get; set; }
        public string segmentId { get; set; }
        public List<Deck> decks { get; set; }
        public AircraftCabinAmenities aircraftCabinAmenities { get; set; }
        public List<AvailableSeatsCounter> availableSeatsCounters { get; set; }
    }

    public class Deck
    {
        public string deckType { get; set; }
        public DeckConfiguration deckConfiguration { get; set; }
        public List<Facilities> facilities { get; set; }
        public List<Seat> seats { get; set; }
    }

    public class DeckConfiguration
    {
        public int width { get; set; }
        public int length { get; set; }
        public int startSeatRow { get; set; }
        public int endSeatRow { get; set; }
        public int startWingsX { get; set; }
        public int endWingsX { get; set; }
        public int startWingsRow { get; set; }
        public int endWingsRow { get; set; }
        public List<int> exitRowsX { get; set; }
    }

    [DataContract(Name = "DEL")]
    public class SeatMapApiResDEL
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    [DataContract(Name = "Departure")]
    public class SeatMapApiResDeparture
    {
        public string iataCode { get; set; }
        public string terminal { get; set; }
        public DateTime at { get; set; }
    }

    public class Description
    {
        public string text { get; set; }
        public string lang { get; set; }
    }

    [DataContract(Name = "Dictionaries")]
    public class SeatMapApiResDictionaries
    {
        public SeatMapApiResLocations locations { get; set; }
        public Facilities facilities { get; set; }
        public SeatCharacteristics seatCharacteristics { get; set; }
    }

    public class Entertainment
    {
        public bool isChargeable { get; set; }
        public string entertainmentType { get; set; }
    }

    public class Facilities
    {
        public string LA { get; set; }
        public string G { get; set; }
        public string MV { get; set; }
        public string CL { get; set; }
        public string code { get; set; }
        public string column { get; set; }
        public string row { get; set; }
        public string position { get; set; }
        public Coordinates coordinates { get; set; }
    }

    public class Food
    {
        public bool isChargeable { get; set; }
        public string foodType { get; set; }
    }

    [DataContract(Name = "LHR")]
    public class SeatMapApiResLHR
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    [DataContract(Name = "Locations")]
    public class SeatMapApiResLocations
    {
        public SeatMapApiResLHR LHR { get; set; }
        public CMB CMB { get; set; }
        public SeatMapApiResDEL DEL { get; set; }
    }

    public class Media
    {
        public string title { get; set; }
        public string href { get; set; }
        public Description description { get; set; }
        public string mediaType { get; set; }
    }

    [DataContract(Name = "Meta")]
    public class SeatMapApiResMeta
    {
        public int count { get; set; }
    }

    [DataContract(Name = "Operating")]
    public class SeatMapApiResOperating
    {
        public string carrierCode { get; set; }
    }

    public class Power
    {
        public bool isChargeable { get; set; }
        public string powerType { get; set; }
        public string usbType { get; set; }
    }

    [DataContract(Name = "Price")]
    public class SeatMapApiResPrice
    {
        public string currency { get; set; }
        public string total { get; set; }
        public string @base { get; set; }
        public List<Taxis> taxes { get; set; }
    }

    [DataContract(Name = "Root")]
    public class SeatMapApiResRoot
    {
        public SeatMapApiResMeta meta { get; set; }
        public List<SeatMapApiResDatum> data { get; set; }
        public SeatMapApiResDictionaries dictionaries { get; set; }
    }

    public class Seat
    {
        public string cabin { get; set; }
        public string number { get; set; }
        public List<string> characteristicsCodes { get; set; }
        public List<SeatMapApiResTravelerPricing> travelerPricing { get; set; }
        public Coordinates coordinates { get; set; }
    }

    public class Seat2
    {
        public int legSpace { get; set; }
        public string spaceUnit { get; set; }
        public string tilt { get; set; }
        public List<Media> medias { get; set; }
    }

    public class SeatCharacteristics
    {
        public string A { get; set; }
        public string AB { get; set; }
        public string DE { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string CH { get; set; }
        public string E { get; set; }
        public string OW { get; set; }
        public string H { get; set; }
        public string I { get; set; }
        public string K { get; set; }
        public string L { get; set; }

        [JsonProperty("1A_AQC_PREMIUM_SEAT")]
        public string _1A_AQC_PREMIUM_SEAT { get; set; }
        public string O { get; set; }

        [JsonProperty("1")]
        public string _1 { get; set; }
        public string AT { get; set; }
        public string U { get; set; }
        public string W { get; set; }

        [JsonProperty("9")]
        public string _9 { get; set; }
        public string IE { get; set; }
    }

    public class Taxis
    {
        public string amount { get; set; }
        public string code { get; set; }
    }

    [DataContract(Name= "TravelerPricing")]
    public class SeatMapApiResTravelerPricing
    {
        public string travelerId { get; set; }
        public string seatAvailabilityStatus { get; set; }
        public SeatMapApiResPrice price { get; set; }
    }

    public class Wifi
    {
        public bool isChargeable { get; set; }
        public string wifiCoverage { get; set; }
    }


}