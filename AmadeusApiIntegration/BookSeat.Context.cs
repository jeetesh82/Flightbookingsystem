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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FlightBookingSystemEntities : DbContext
    {
        public FlightBookingSystemEntities()
            : base("name=FlightBookingSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<flightDetail> flightDetails { get; set; }
        public virtual DbSet<SeatAvailabilityDetail> SeatAvailabilityDetails { get; set; }
        public virtual DbSet<SeatMap_deckConfiguration> SeatMap_deckConfiguration { get; set; }
    }
}
