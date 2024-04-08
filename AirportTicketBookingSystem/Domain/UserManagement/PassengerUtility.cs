using AirportTicketBookingSystem.Domain.FlightManagement;
using AirportTicketBookingSystem.Domain.StandardMessages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;


namespace AirportTicketBookingSystem.Domain.UserManagement
{
    public class PassengerUtility : Utilities
    {
        public void Initialize()
        {
            ShowAllActionsToPassenger();
        }
        public  void ShowAllActionsToPassenger()
        {
            PrintListOfActionsToPassenger();

            string? userSelection = Console.ReadLine();
            if (userSelection != null)
            {
                switch (userSelection)
                {
                    case "1":
                        ShowBookFlightList();
                        ShowAllActionsToPassenger();
                        break;
                    case "2":
                        SearchOnFlightsToBook();
                        ShowAllActionsToPassenger();

                        break;
                    case "3":
                        PassengerManagesBooking();
                        ShowAllActionsToPassenger();
                        break;
                    case "4":
                        WriteBookingToBookedFlightsFile();
                        WriteflightsToFlightsFile();
                        break;
                    case "0":
                        break;
                    default:
                        StandardMessage.InvalidInputMessage();
                        break;
                }
            }

        }
        public static void PrintListOfActionsToPassenger()
        {
            Console.ResetColor();
            Console.Clear();
            StandardMessage.Organize();
            Console.WriteLine("* PASSENGER PANEL *");
            Console.WriteLine("* Select an Action *");
            StandardMessage.Organize();
            Console.WriteLine("1: Book a flight");
            Console.WriteLine("2: Search for available flights");
            Console.WriteLine("3: Manage bookings");
            Console.WriteLine("4: Save and Exit.");
            Console.WriteLine("0: Close application");
            Console.WriteLine("Your selection: ");
        }
        public static void PrintManageBookingListToPassenger()
        {
            Console.WriteLine("* Manage Booking *");
            Console.WriteLine("* Select an Action *");
            StandardMessage.Organize();
            Console.WriteLine("1: View personal booking");
            Console.WriteLine("2: Cancel a booking");
            Console.WriteLine("0: exit");
        }

        private static void PassengerManagesBooking()
        {
            PrintManageBookingListToPassenger();

            string? userSelection = Console.ReadLine();
            if (userSelection != null)
            {
                switch (userSelection)
                {
                    case "1":
                        ViewPersonalBookingList();
                        break;
                    case "2":
                        PassengerCancelsBooking();
                        break;
                    case "0":
                        break;
                    default:
                        break;


                }
            }
        }

        public static void PassengerCancelsBooking()
        {
            ViewPersonalBookingList();
            Console.WriteLine("Enter the id of the flight you want to cancel: ");
            bool success = int.TryParse(Console.ReadLine(), out int id);
            if (!success)
            {
                StandardMessage.InvalidInputMessage();
                return;
            }

            var flight = bookedFlights.First(f => f.FlightId == id);
            bookedFlights.Remove(flight);
            flights.Add(flight);
            StandardMessage.FlightCancelationMessage(flight);
            StandardMessage.EscapeEventByAnyKeyMessage();

        }

        private static void ViewPersonalBookingList()
        {
            Console.WriteLine("* YOUR BOOKING LIST ");
            if (bookedFlights.Count > 0)
            {
                foreach (var b in bookedFlights)
                {
                    Console.WriteLine(b.ToString());
                }
            }
            else
            {
               StandardMessage.ListEmptyMessage();  
            }
        }

        public  void ShowBookFlightList()
        {
            PrintBookFlightList();

            string? userSelection = Console.ReadLine();
            if (userSelection != null)
            {
                switch (userSelection)
                {
                    case "1":
                        SearchOnFlightsToBook();
                        break;
                    case "0":
                        ShowAllActionsToPassenger();
                        break;
                    default:
                        StandardMessage.InvalidInputMessage();
                        break;
                }


            }


        }
        public static void PrintBookFlightList()
        {
            Console.ResetColor();
            Console.Clear();
            StandardMessage.Organize();
            Console.WriteLine("* Help us find your flight *");
            StandardMessage.Organize();
            Console.WriteLine("1: Search for available flights");
            Console.WriteLine("0: Close application");
            Console.WriteLine("Your selection: ");
        }
        public  static void SearchOnFlightsToBook()
        {
            List<Flight> filteredList = new(flights);
           
            string? userSelection;
            do
            {
                PrintSearchTemplateList();

                string? departureLocation;
                string? destinationLocation;
                string? departureDate;
                string? departureAirport;
                string? destinationAirport;

                userSelection = Console.ReadLine();
                if (userSelection != null)
                {
                    switch (userSelection)
                    {
                        case "1":
                            departureLocation = StandardMessage.DisplayMessageAndReturnValue("Enter your departure Location: ");
                            filteredList = FilterHandler.HandleFilteringOnDepartureCountry(departureLocation,filteredList);
                            StandardMessage.EscapeEventByAnyKeyMessage();
                            break;
                        case "2":
                            destinationLocation = StandardMessage.DisplayMessageAndReturnValue("Enter your destination Location: ");
                            filteredList= FilterHandler.HandleFilteringOnDestinationCountry(destinationLocation, filteredList);
                            StandardMessage.EscapeEventByAnyKeyMessage();
                            break;
                        case "3":
                            departureDate = StandardMessage.DisplayMessageAndReturnValue("Enter your desired date: (IN THE FORMAT DD/MM/YYYY) ");
                            filteredList = FilterHandler.HandleFilteringBasedOnDate(departureDate, filteredList);
                            StandardMessage.EscapeEventByAnyKeyMessage();
                            break;
                        case "4":
                            departureAirport = StandardMessage.DisplayMessageAndReturnValue("Enter your departure Airport: ");
                            filteredList = FilterHandler.HandleFilteringOnDepartureAirport(departureAirport, filteredList);
                            StandardMessage.EscapeEventByAnyKeyMessage();
                            break;
                        case "5":
                            destinationAirport = StandardMessage.DisplayMessageAndReturnValue("Enter your destination Airport: ");
                            filteredList = FilterHandler.HandleFilteringOnDestinationAirport(destinationAirport, filteredList);
                            StandardMessage.EscapeEventByAnyKeyMessage();
                            break;
                        case "6":

                            break;
                        case "0":
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            StandardMessage.InvalidInputMessage();
                            break;
                    }

                }
            } while (userSelection != "0");

            PrintFilteredFlights(filteredList);

        }

        public static void PrintFilteredFlights(List<Flight> filteredList)
        {
            if (filteredList.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Available Flights: ");
                foreach (var item in filteredList)
                {
                    Console.WriteLine(item);
                }
                PrintBookFlightBasedOnInput();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                StandardMessage.ListEmptyMessage();
            }
            Console.ResetColor();
           StandardMessage.EscapeEventByAnyKeyMessage();
        }
        public static void PrintBookFlightBasedOnInput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Select the ID of the flight you want to book: (Select -1 if you want to cancel booking process)");
            Console.ResetColor();

            bool success = int.TryParse(Console.ReadLine() ?? "-1", out int userInput);
            if (success && userInput != -1)
            {
                BookFlightWithID(userInput);
            }
            else
            {
                StandardMessage.CancellingBookingProcess();
            }
        }

     

        public static void PrintSearchTemplateList()
        {
            Console.ResetColor();
            Console.Clear();
            StandardMessage.Organize();
            Console.WriteLine("* Help us find your flight / you can add more than one parameter *");
            StandardMessage.Organize();
            Console.WriteLine("1: Choose Departure Location");
            Console.WriteLine("2: Choose Destination Location");
            Console.WriteLine("3: Choose Departure Date");
            Console.WriteLine("4: Choose Departure Airport");
            Console.WriteLine("5: Choose Destination Airport");
            Console.WriteLine("6: filter by price");
            Console.WriteLine("0: Finish filtering");
            Console.WriteLine("Your selection: ");
        }
     
    
      
     
        public static void BookFlightWithID(int v)
        {
            bookedFlights.Add(flights.First(f => f.FlightId == v));
            flights.Remove(flights.First(f => f.FlightId == v));
            StandardMessage.BookingConfirmationMessage(v);
        }

        private static void WriteBookingToBookedFlightsFile()
        {
            string directory = @"C:\Users\Lenovo\source\repos\AirportTicketBookingSystemProject\AirportTicketBookingSystem\Data\";
            string FileName = "booked.txt";
            using StreamWriter writer = new($"{directory}{FileName}");
            StringBuilder sb = new();
            foreach (var i in bookedFlights)
            {
                sb.AppendLine(i.SaveToFile());
            }
            writer.WriteLine(sb.ToString());
            Console.WriteLine("Exported status to booked.txt file. Press to exit.");
            Console.ReadLine();
        }
      
    }
}
