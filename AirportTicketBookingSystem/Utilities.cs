using AirportTicketBookingSystem.Data;
using AirportTicketBookingSystem.Domain.FlightManagement;
using AirportTicketBookingSystem.Domain.UserManagement;
using AirportTicketBookingSystem.Domain.StandardMessages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace AirportTicketBookingSystem

{

    public class Utilities
    {
         static List<User> users = [];
         static List<Flight> flights = [];
         static List<Flight> bookedFlights = [];

        public static  void InitializeUsers()
        {
            users = UserRepository.LoadUsersFromFile();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Loaded {users.Count} users!");
            StandardMessage.EscapeEventByAnyKeyMessage();
   
        }
        public static void InitializeFlights()
        {
            flights = FlightRepository.LoadFlightsFromFile("self");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Loaded {flights.Count} flights!");
            StandardMessage.EscapeEventByAnyKeyMessage();
        }
        public static void LoadBookedTickets()
        {
            bookedFlights = FlightRepository.LoadBookedFlightsFromFile("self");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Loaded {bookedFlights.Count} booked flights!");
            StandardMessage.EscapeEventByAnyKeyMessage();
        }
        public static void LogIn()
        {
            Console.WriteLine("Write your username to enter: ");
            string? username = Console.ReadLine() ?? "";
            bool usernameIsNotNull=UserValidator.ValidateUserByUsername(username);
            if (usernameIsNotNull) { 
                if (users.Where(u => u.UserName == username).Any()) 
                {
                    if (users.Single(u => u.UserName == username).IsManager())
                    {
                        StandardMessage.WelcomeUserMessage(username);
                        ManagerUtility managerUtility=new ();
                        managerUtility.Initialize();
                    }
                    else
                    {
                        StandardMessage.WelcomeUserMessage(username);
                        PassengerUtility passengerUtility = new();
                        passengerUtility.Initialize();
                    }
                }

            }
        }
        public  static void WriteflightsToFlightsFile()
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
