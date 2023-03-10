using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AmadeusApiIntegration.Models
{
    [DataContract(Name = "Root")]
    public class SeatMapApiHelperResponse
    {
        [DataMember(Name = "meta")]
        public SeatMapApiResMeta meta { get; set; }


        [DataMember(Name = "data")]
        public List<SeatMapApiResDatum> data { get; set; }


        [DataMember(Name = "dictionaries")]
        public SeatMapApiResDictionaries dictionaries { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    [DataContract(Name = "Aircraft")]
    public class SeatMapApiResAircraft
    {
        [DataMember(Name = "code")]
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
        [DataMember(Name = "iataCode")]
        public string iataCode { get; set; }

        [DataMember(Name = "at")]
        public DateTime at { get; set; }
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

    public class Coordinates
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    [DataContract(Name = "Datum")]
    public class SeatMapApiResDatum
    {
        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "departure")]
        public SeatMapApiResDeparture departure { get; set; }

        [DataMember(Name = "arrival")]
        public SeatMapApiResArrival arrival { get; set; }

        [DataMember(Name = "carrierCode")]
        public string carrierCode { get; set; }

        [DataMember(Name = "number")]
        public string number { get; set; }

        [DataMember(Name = "operating")]
        public SeatMapApiResOperating operating { get; set; }

        [DataMember(Name = "aircraft")]
        public SeatMapApiResAircraft aircraft { get; set; }

        [DataMember(Name = "@class")]
        public string @class { get; set; }

        [DataMember(Name = "flightOfferId")]
        public string flightOfferId { get; set; }

        [DataMember(Name = "segmentId")]
        public string segmentId { get; set; }

        [DataMember(Name = "decks")]
        public List<Deck> decks { get; set; }

        [DataMember(Name = "aircraftCabinAmenities")]
        public AircraftCabinAmenities aircraftCabinAmenities { get; set; }

        [DataMember(Name = "availableSeatsCounters")]
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
        [DataMember(Name = "cityCode")]
        public string cityCode { get; set; }

        [DataMember(Name = "countryCode")]
        public string countryCode { get; set; }
    }

    [DataContract(Name = "Departure")]
    public class SeatMapApiResDeparture
    {
        [DataMember(Name = "iataCode")]
        public string iataCode { get; set; }

        [DataMember(Name = "terminal")]
        public string terminal { get; set; }

        [DataMember(Name = "at")]
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
        [DataMember(Name = "locations")]
        public SeatMapApiResLocations locations { get; set; }

        [DataMember(Name = "facilities")]
        public Facilities facilities { get; set; }

        [DataMember(Name = "seatCharacteristics")]
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

    [DataContract(Name = "Locations")]
    public class SeatMapApiResLocations
    {
        [DataMember(Name = "PNQ")]
        public SeatMapApiResPNQ PNQ { get; set; }

        [DataMember(Name = "DEL")]
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
        [DataMember(Name = "count")]
        public int count { get; set; }
    }

    [DataContract(Name = "Operating")]
    public class SeatMapApiResOperating
    {
        [DataMember(Name = "carrierCode")]
        public string carrierCode { get; set; }
    }

    [DataContract(Name = "PNQ")]
    public class SeatMapApiResPNQ
    {
        [DataMember(Name = "cityCode")]
        public string cityCode { get; set; }

        [DataMember(Name = "countryCode")]
        public string countryCode { get; set; }
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
        [DataMember(Name = "currency")]
        public string currency { get; set; }

        [DataMember(Name = "total")]
        public string total { get; set; }

        [DataMember(Name = "@base")]
        public string @base { get; set; }

        [DataMember(Name = "taxes")]
        public List<Taxis> taxes { get; set; }
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

        [JsonProperty("1")]
        public string _1 { get; set; }
        public string B { get; set; }
        public string CH { get; set; }
        public string E { get; set; }
        public string W { get; set; }

        [JsonProperty("9")]
        public string _9 { get; set; }
        public string L { get; set; }
        public string FC { get; set; }
    }

    public class Taxis
    {
        public string amount { get; set; }
        public string code { get; set; }
    }

    [DataContract(Name = "TravelerPricing")]
    public class SeatMapApiResTravelerPricing
    {
        [DataMember(Name = "travelerId")]
        public string travelerId { get; set; }

        [DataMember(Name = "seatAvailabilityStatus")]
        public string seatAvailabilityStatus { get; set; }

        [DataMember(Name = "price")]
        public SeatMapApiResPrice price { get; set; }
    }

    public class Wifi
    {
        public bool isChargeable { get; set; }
        public string wifiCoverage { get; set; }
    }


}