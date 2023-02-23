using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmadeusApiIntegration.Models
{
    //public class SearchFligAvai
    //{
    //   public string originLocationCode { get; set; }
    //   public string destinationLocationCode { get; set; }
    //    public DateTime date { get; set; }
    //    public string travelerType { get; set; }

    //}

    public class DepartureDateTime
    {
        public string date { get; set; }
        public string time { get; set; }

       
    }

    public class OriginDestination
    {
        public string id { get; set; }
        public string originLocationCode { get; set; }
        public string destinationLocationCode { get; set; }
        public DepartureDateTime departureDateTime { get; set; }
    }

    public class Roots
    {
        public List<OriginDestination> originDestinations { get; set; }
        public List<Traveler> travelers { get; set; }
        public List<string> sources { get; set; }
    }

    public class Traveler
    {
        public string id { get; set; }
        public string travelerType { get; set; }
    }




}


