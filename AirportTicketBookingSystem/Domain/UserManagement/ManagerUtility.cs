using AirportTicketBookingSystem.Data;
using AirportTicketBookingSystem.Domain.FlightManagement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace AirportTicketBookingSystem.Domain.UserManagement
{
    public class ManagerUtility:Utilities
    {
        public  void Initialize()
        {
            ShowAllActionsToManager();
        }

        public  void ShowAllActionsToManager()
        {
            Console.ResetColor();
            Console.Clear();
            Organize();
            Console.WriteLine("* MANAGER PANEL *");
            Console.WriteLine("* Select an Action *");
            Organize();
            Console.WriteLine("1: View bookings");
            Console.WriteLine("2: Batch flight upload");
            Console.WriteLine("3: Save and Exit.");
            Console.WriteLine("0: Close application");
            Console.WriteLine("Your selection: ");
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
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
        }

        public  void BatchFlightsUpload()
        {
         
            Console.WriteLine("Enter the path of the file you want to upload data from: ");
            string? path= Console.ReadLine();
            if (path != null){

                flights.AddRange(FlightRepository.LoadFlightsFromFile(path).Except(flights));
               
            }
            else {
                Console.WriteLine("Invalid path aborting the import ...");
            }
            WriteflightsToFlightsFile();
        }

       

        public  void ViewBookingsToManager()
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("* Select an Action *");
            Organize();
            Console.WriteLine("1: View All bookings");
            Console.WriteLine("2: Filter Results");
            Console.WriteLine("0: Close application");
            Console.WriteLine("Your selection: ");
            string? userSelection = Console.ReadLine();
            if (userSelection != null)
            {
                switch (userSelection)
                {
                    case "1":
                        ViewAllBookings();
                        break;
                    case "2":
                        FilterBookingList();
                        break;
                    case "0":
                       
                        break;
                    default:
                        
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }



            }
        }

        public static void FilterBookingList()
        {
            List<Flight> filteredList = new List<Flight>(bookedFlights);
            Console.ResetColor();
            Console.Clear();
            string? userSelection;
            do
            {
                Console.ResetColor();
                Console.Clear();
                Organize();
                Console.WriteLine("* Filter the flights booking list / you can add more than one parameter *");
                Organize();
                Console.WriteLine("1: Choose Departure Location");
                Console.WriteLine("2: Choose Destination Location");
                Console.WriteLine("3: Choose Departure Date");
                Console.WriteLine("4: Choose Departure Airport");
                Console.WriteLine("5: Choose Destination Airport");
                Console.WriteLine("6: filter by price");
                Console.WriteLine("7: filter by Flight Class");
                Console.WriteLine("0: Finish filtering");
                Console.WriteLine("Your selection: ");
                string? departureLocation;
                string? destinationLocation;
                string? departureDate;
                string? departureAirport;
                string? destinationAirport;
                decimal price;
               FlightClass flightClass;
                userSelection = Console.ReadLine();
                if (userSelection != null)
                {
                    switch (userSelection)
                    {
                        case "1":
                            departureLocation = DisplayMessageAndReturnValue("Enter departure Location: ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            if (departureLocation != "")
                                Console.WriteLine($"you have selected a departure location {departureLocation}!");
                            filteredList = FilterBasedOnDepartureLocation(filteredList, departureLocation);
                            Console.WriteLine("Press any key to proceed!");
                            Console.ReadLine();

                            break;
                        case "2":
                            destinationLocation = DisplayMessageAndReturnValue("Enter destination Location: ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            if (destinationLocation != "")
                                Console.WriteLine($"you have selected a destination location {destinationLocation}!");
                            filteredList = FilterBasedOnDestinationLocation(filteredList, destinationLocation);
                            Console.WriteLine("Press any key to proceed!");
                            Console.ReadLine();

                            break;
                        case "3":
                            departureDate = DisplayMessageAndReturnValue("Enter a desired date: (IN THE FORMAT DD/MM/YYYY) ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            if (departureDate != "")
                            {
                                DateTime parsedDepartureDate;
                                if (DateTime.TryParseExact(departureDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDepartureDate))
                                {

                                    Console.WriteLine($"you have selected a departure date {departureDate}!");
                                    filteredList = FilterBasedOnDepartureDate(filteredList, departureDate);
                                    Console.WriteLine("Press any key to proceed!");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid date format entered.");
                                }
                            }

                            break;
                        case "4":
                            departureAirport = DisplayMessageAndReturnValue("Enter departure Airport: ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            if (departureAirport != "")
                                Console.WriteLine($"you have selected a departure Airport {departureAirport}!");
                            filteredList = FilterBasedOnDepartureAirport(filteredList, departureAirport);
                            Console.WriteLine("Press any key to proceed!");
                            Console.ReadLine();

                            break;
                        case "5":
                            destinationAirport = DisplayMessageAndReturnValue("Enter destination Airport: ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            if (destinationAirport != "")
                                Console.WriteLine($"you have selected a destination Airport {destinationAirport}!");
                            filteredList = FilterBasedOnDepartureAirport(filteredList, destinationAirport);
                            Console.WriteLine("Press any key to proceed!");

                            Console.ReadLine();

                            break;
                        case "6":
                            bool success = Decimal.TryParse(DisplayMessageAndReturnValue("Enter a maximum price: "),out price);
                            if (success)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                
                                    Console.WriteLine($"you have selected a maximum price {price}!");
                                filteredList = FilterBasedOnPrice(filteredList, price);
                                Console.WriteLine("Press any key to proceed!");

                                Console.ReadLine();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Cast To decimal. Please try again.");
                                Console.ResetColor();
                                Console.WriteLine("Press any key to proceed!");

                                Console.ReadLine();
                            }
                            
                            break;
                        case "7":
                             success = FlightClass.TryParse(DisplayMessageAndReturnValue("Enter a maximum price: "), out flightClass);
                            if (success)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;

                                Console.WriteLine($"you have selected a Flight Class {flightClass}!");
                                filteredList = FilterBasedOnClass(filteredList, flightClass);
                                Console.WriteLine("Press any key to proceed!");

                                Console.ReadLine();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Cast To Flight Class type. Please try again.");
                                Console.ResetColor();
                                Console.WriteLine("Press any key to proceed!");

                                Console.ReadLine();
                            }
                            break;

                        case "0":
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid selection. Please try again.");
                            break;
                    }




                }
            } while (userSelection != "0");
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
                Console.WriteLine("No Available Flights At The Moment! ");
            }
            Console.ResetColor();
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadLine();

        }

        private static List<Flight> FilterBasedOnClass(List<Flight> filteredList, FlightClass flightClass)
        {
            return flights.Where(flight => flight.FlightClass == flightClass).ToList();
        }

        public static List<Flight> FilterBasedOnPrice(List<Flight> filteredList, decimal price)
        {
            return flights.Where(flight => flight.Price <= price).ToList();
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
                Console.WriteLine("No Booked Flights At The Moment! ");
            }
            Console.ResetColor();
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadLine();
        }

        public static void Organize()
        {
            Console.WriteLine("********************");
        }
        public static string DisplayMessageAndReturnValue(string msg)
        {
            Console.WriteLine(msg);
            string? value = Console.ReadLine();
            return value ?? "";
        }
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
    }
}
