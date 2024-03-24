using AirportTicketBookingSystem.Domain.FlightManagement;
using AirportTicketBookingSystem.Domain.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AirportTicketBookingSystem

{

    public class Utilities
    {
        protected static List<User> users = [];
        protected static List<Flight> flights = [];
        protected static List<Flight> bookedFlights = [];

        public static void InitializeFlightsAndUsers()
        {
            FlightRepository flightRepository = new FlightRepository();
            flights = flightRepository.LoadFlightsFromFile();

            UserRepository userRepository = new UserRepository();
            users = userRepository.LoadUsersFromFile();
            bookedFlights = flightRepository.LoadBookedFlightsFromFile();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Loaded {flights.Count} flights!");
            Console.WriteLine($"Loaded {bookedFlights.Count} booked flights!");
            Console.WriteLine($"Loaded {users.Count} users!");
            Console.WriteLine("Press enter to countinue!");
            Console.ResetColor();
            Console.ReadLine();

        }
        public static void LogIn()
        {
            Console.WriteLine("Write your username to enter: ");
            string? username = Console.ReadLine() ?? "";
            if (username != null)
            {
                if (users.Where(u => u.UserName == username).Count() > 0)
                {
                    if (users.First(u => u.UserName == username).IsManager())
                    {
                        Console.WriteLine($"Welcome {username}! Press any key to continue.");
                        Console.ReadLine();
                        ManagerUtility.Initialize();
                    }
                    else
                    {
                        Console.WriteLine($"Welcome {username}! Press any key to continue.");
                        Console.ReadLine();
                        PassengerUtility.Initialize();
                    }
                }

            }
        }











    }
}
