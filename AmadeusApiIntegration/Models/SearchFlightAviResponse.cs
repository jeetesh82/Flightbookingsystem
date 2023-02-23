using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AmadeusApiIntegration.Models
{


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    [DataContract(Name = "Aircraft")]
    public class Aircraft
    {
        [DataMember(Name = "code")]
        public string code { get; set; }
    }

    public class AMS
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    [DataContract(Name = "Arrival")]
    public class Arrival
    {
        [DataMember(Name = "iataCode")]
        public string iataCode { get; set; }
        [DataMember(Name = "terminal")]
        public string terminal { get; set; }
        [DataMember(Name = "at")]
        public DateTime at { get; set; }
    }

    public class AvailabilityClass
    {
        public int numberOfBookableSeats { get; set; }
        public string @class { get; set; }
    }

    public class BOS
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    public class BRU
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    public class CDG
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    [DataContract(Name = "Datum")]
    public class FlightApiRespDatum
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }
        [DataMember(Name = "originDestinationId")]
        public string originDestinationId { get; set; }
        [DataMember(Name = "source")]
        public string source { get; set; }
        [DataMember(Name = "instantTicketingRequired")]
        public bool instantTicketingRequired { get; set; }
        [DataMember(Name = "paymentCardRequired")]
        public bool paymentCardRequired { get; set; }
        [DataMember(Name = "duration")]
        public string duration { get; set; }
        [DataMember(Name = "segments")]
        public List<Segment> segments { get; set; }
    }

    [DataContract(Name = "Departure")]
    public class Departure
    {
        [DataMember(Name = "iataCode")]
        public string iataCode { get; set; }
        [DataMember(Name = "terminal")]
        public string terminal { get; set; }
        [DataMember(Name = "at")]
        public DateTime at { get; set; }
    }

    public class Dictionaries
    {
        public Locations locations { get; set; }
    }

    public class FRA
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    public class LHR
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    public class LIS
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    public class Locations
    {
        public MAD MAD { get; set; }
        public ZRH ZRH { get; set; }
        public BRU BRU { get; set; }
        public FRA FRA { get; set; }
        public BOS BOS { get; set; }
        public LHR LHR { get; set; }
        public CDG CDG { get; set; }
        public LIS LIS { get; set; }
        public AMS AMS { get; set; }
        public MUC MUC { get; set; }
        public OPO OPO { get; set; }
    }

    public class MAD
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    [DataContract(Name = "Meta")]
    public class FlightApiRespMeta
    {
        public int count { get; set; }
    }

    public class MUC
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    public class Operating
    {
        public string carrierCode { get; set; }
    }

    public class OPO
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }

    [DataContract(Name = "Root")]
    public class SearchFlightAviResponse
    {
        [DataMember(Name = "meta")]
        public FlightApiRespMeta meta { get; set; }
        [DataMember(Name = "data")]
        public List<FlightApiRespDatum> data { get; set; }
        [DataMember(Name = "dictionaries")]
        public Dictionaries dictionaries { get; set; }
    }

    public class Segment
    {

        public string id { get; set; }
        public int numberOfStops { get; set; }
        public bool blacklistedInEU { get; set; }
        public Departure departure { get; set; }
        public Arrival arrival { get; set; }
        public string carrierCode { get; set; }
        public string number { get; set; }
        public Aircraft aircraft { get; set; }
        public List<AvailabilityClass> availabilityClasses { get; set; }
        public Operating operating { get; set; }
    }

    public class ZRH
    {
        public string cityCode { get; set; }
        public string countryCode { get; set; }
    }


}