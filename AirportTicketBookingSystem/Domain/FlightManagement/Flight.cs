using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Domain.FlightManagement
{
    public class Flight
    {
        public decimal Price {  get; set; }
        public string DepartureCountry { get; init; }
        public string DestinationCountry { get; init; }
        public DateTime DepartureDate { get; init; }
        public string DepartureAirport { get; init; }
        public string ArrivalAirport { get; set;}
        public Enum FlightClass { get; init; }

        
    }
}
