using AirportTicketBookingSystem.Domain.FlightManagement;
using AirportTicketBookingSystem.Domain.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem
  
{
   
    public class Utilities
    {
        private static List<User> users = new();
        private static List<Flight> flights = new();
        public static void InitializeUsers()
        {
            users.Add(new User { Id = 2, UserName = "User1", Token = UserToken.Passenger });
            users.Add(new User { Id=1,UserName="Manager1",Token= UserToken.Manager });

        }
        public static void InitializeFlights()
        {
            flights.Add(new Flight
            {
                Price = 900.00m,
                DepartureCountry = "China",
                DestinationCountry = "South Korea",
                DepartureDate = DateTime.Now.AddDays(7),
                DepartureAirport = "PEK",
                ArrivalAirport = "ICN",
                FlightClass = FlightClass.Business
            });
            flights.Add(new Flight
            {
                Price = 350.00m,
                DepartureCountry = "USA",
                DestinationCountry = "Canada",
                DepartureDate = DateTime.Now.AddDays(2),
                DepartureAirport = "JFK",
                ArrivalAirport = "YYZ",
                FlightClass = FlightClass.Economy
            });
            flights.Add(new Flight
            {
                Price = 750.00m,
                DepartureCountry = "France",
                DestinationCountry = "Italy",
                DepartureDate = DateTime.Now.AddDays(5),
                DepartureAirport = "CDG",
                ArrivalAirport = "FCO",
                FlightClass = FlightClass.Business
            });
        }




    }
}
