using AirportTicketBookingSystem.Domain.FlightManagement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Domain.UserManagement
{
    internal class Filter:Utilities
    {
        public static List<Flight> FilterBasedOnDepartureLocation(List<Flight> flights, string location)
        {
            return flights.Where(flight => flight.DepartureCountry == location).ToList();

        }
        public static List<Flight> FilterBasedOnDepartureDate(List<Flight> flights, string departureDate)
        {
            if (!DateTime.TryParseExact(departureDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDepartureDate))
            {
                return [];
            }
            return flights.Where(flight => flight.DepartureDate.Date == parsedDepartureDate.Date).ToList();

        }
        public static List<Flight> FilterBasedOnDepartureAirport(List<Flight> flights, string location)
        {
            return flights.Where(flight => flight.ArrivalAirport == location).ToList();

        }
        public static List<Flight> FilterBasedOnDestinationLocation(List<Flight> flights, string location)
        {
            return flights.Where(flight => flight.DestinationCountry == location).ToList();

        }
        public static List<Flight> FilterBasedOnDestinationAirport(List<Flight> flights, string location)
        {
            return flights.Where(flight => flight.ArrivalAirport == location).ToList();

        }

        public static List<Flight> FilterBasedOnPrice(List<Flight> filteredList, decimal price)
        {
            return filteredList.Where(flight => flight.Price <= price).ToList();
        }
        public static List<Flight> FilterBasedOnClass(List<Flight> filteredList, FlightClass flightClass)
        {
            return flights.Where(flight => flight.FlightClass == flightClass).ToList();
        }
    }
}
