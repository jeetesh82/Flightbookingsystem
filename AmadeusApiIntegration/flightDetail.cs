//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmadeusApiIntegration
{
    using System;
    using System.Collections.Generic;
    
    public partial class flightDetail
    {
        public int travelerId { get; set; }
        public string Origin_Location { get; set; }
        public Nullable<System.DateTime> From_Date_Time { get; set; }
        public string Destination_Location { get; set; }
        public Nullable<System.DateTime> To_Date_Time { get; set; }
        public string Airline_Code { get; set; }
        public string Aircraft_Code { get; set; }
        public Nullable<int> number { get; set; }
        public string @class { get; set; }
        public Nullable<int> flightOfferId { get; set; }
        public Nullable<int> segmentId { get; set; }
    
        public virtual SeatAvailabilityDetail SeatAvailabilityDetail { get; set; }
        public virtual SeatMap_deckConfiguration SeatMap_deckConfiguration { get; set; }
    }
}
