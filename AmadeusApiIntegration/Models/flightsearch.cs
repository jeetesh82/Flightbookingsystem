using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmadeusApiIntegration.Models
{
    public class flightsearch
    {
       public DateTime Departuredate { get; set; }
       public DateTime returndate { get; set; }
        public string OriginLocation { get; set; }
        
        public string destinationLocation { get; set; }
       public string travelertypeAdult { get; set; }
       public string travelclass { get; set; }
       public string flighttype { get; set; }
    }
}