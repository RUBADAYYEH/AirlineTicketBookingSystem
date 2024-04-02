using AirportTicketBookingSystem.Data;
using AirportTicketBookingSystem.Domain.FlightManagement;
using AirportTicketBookingSystem.Domain.UserManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace AirportTicketBookingSystem

{

    public class Utilities
    {
        public static  List<User> users = [];
        public static List<Flight> flights = [];
        public static List<Flight> bookedFlights = [];

        public static void InitializeFlightsAndUsers()
        {

            flights = FlightRepository.LoadFlightsFromFile("self");
            users = UserRepository.LoadUsersFromFile();
            bookedFlights = FlightRepository.LoadBookedFlightsFromFile("self");

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
                if (users.Where(u => u.UserName == username).Any()) // count vs any 
                {
                    if (users.First(u => u.UserName == username).IsManager())
                    {
                        Console.WriteLine($"Welcome {username}! Press any key to continue.");
                        Console.ReadLine();
                        ManagerUtility managerUtility=new ();
                        ManagerUtility.Initialize();
                    }
                    else
                    {
                        Console.WriteLine($"Welcome {username}! Press any key to continue.");
                        Console.ReadLine();
                        PassengerUtility passengerUtility = new();
                        passengerUtility.Initialize();
                    }
                }

            }
        }
        public static void WriteflightsToFlightsFile()
        {
            string directory = @"C:\Users\Lenovo\source\repos\AirportTicketBookingSystemProject\AirportTicketBookingSystem\Data\";
            string FileName = "flights.txt";
            using StreamWriter writer = new($"{directory}{FileName}");
            StringBuilder sb = new();

            foreach (var i in flights)
            {
                sb.AppendLine(i.SaveToFile());
            }
            writer.WriteLine(sb.ToString());

            Console.WriteLine("Exported status to flights.txt file. Press to exit.");
            Console.ReadLine();

        }











    }
}
