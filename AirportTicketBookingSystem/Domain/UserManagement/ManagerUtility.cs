using AirportTicketBookingSystem.Data;
using AirportTicketBookingSystem.Domain.FlightManagement;
using AirportTicketBookingSystem.Domain.StandardMessages;
using System;
using System.Collections.Generic;
using System.Linq;



namespace AirportTicketBookingSystem.Domain.UserManagement
{
    public class ManagerUtility : Utilities
    {
        public static void Initialize()
        {
            ShowAllActionsToManager();
        }

        public static void ShowAllActionsToManager()
        {
            PrintListOfActionsToManager();

            string? userSelection = Console.ReadLine();
            if (userSelection != null)
            {
                switch (userSelection)
                {
                    case "1":
                        ViewBookingsToManager();
                        ShowAllActionsToManager();
                        break;
                    case "2":
                        BatchFlightsUpload();
                        ShowAllActionsToManager();

                        break;
                    case "3":
                        BatchFlightsUpload();
                        ShowAllActionsToManager();
                        break;

                    case "0":
                        break;
                    default:
                        StandardMessage.InvalidInputMessage();
                        break;
                }
            }
        }
        public static void PrintListOfActionsToManager()
        {
            Console.ResetColor();
            Console.Clear();
            StandardMessage.Organize();
            Console.WriteLine("* MANAGER PANEL *");
            Console.WriteLine("* Select an Action *");
            StandardMessage.Organize();
            Console.WriteLine("1: View bookings");
            Console.WriteLine("2: Batch flight upload");
            Console.WriteLine("3: Save and Exit.");
            Console.WriteLine("0: Close application");
            Console.WriteLine("Your selection: ");
        }

        public static void BatchFlightsUpload()
        {

            Console.WriteLine("Enter the path of the file you want to upload data from: ");
            string? path = Console.ReadLine();
            if (path != null)
            {

                flights.AddRange(FlightRepository.LoadFlightsFromFile(path).Except(flights));

            }
            else
            {
                Console.WriteLine("Invalid path aborting the import ...");
            }
            WriteflightsToFlightsFile();
        }



        public static void ViewBookingsToManager()
        {
            PrintViewBookingListToManager();
            string? userSelection = Console.ReadLine();
            if (userSelection != null)
            {
                switch (userSelection)
                {
                    case "1":
                        ViewAllBookings();
                        break;
                    case "2":
                        CallFilterApplication();
                        break;
                    case "0":
                        break;
                    default:
                        StandardMessage.InvalidInputMessage();
                        break;
                }
            }
        }

        private static void CallFilterApplication()
        {
            List<Flight> filteredList = new(bookedFlights);
            filteredList = FilterApplication.FilterBookingList(filteredList);
            PrintFilteredFlights(filteredList);
        }

        public static void PrintViewBookingListToManager()
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("* Select an Action *");
            StandardMessage.Organize();
            Console.WriteLine("1: View All bookings");
            Console.WriteLine("2: Filter Results");
            Console.WriteLine("0: Close application");
            Console.WriteLine("Your selection: ");
        }
        public static void ViewAllBookings()
        {
            if (bookedFlights.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Booked Flights: ");
                foreach (var item in bookedFlights)
                {
                    Console.WriteLine(item);
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                StandardMessage.ListEmptyMessage();
            }
            Console.ResetColor();
            StandardMessage.EscapeEventByAnyKeyMessage();
        }


        public static void PrintFilteredFlights(List<Flight> filteredList)
        {
            if (filteredList.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Booked Flights: ");
                foreach (var item in filteredList)
                {
                    Console.WriteLine(item);
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                StandardMessage.ListEmptyMessage();
            }
            Console.ResetColor();
            StandardMessage.EscapeEventByAnyKeyMessage();
        }

       
    }
}
