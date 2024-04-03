using AirportTicketBookingSystem.Domain.FlightManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;



namespace AirportTicketBookingSystem.Data
{
    internal class FlightRepository
    {
        private const string directory = @"C:\Users\Lenovo\source\repos\AirportTicketBookingSystemProject\AirportTicketBookingSystem\Data\";
        private const string flightFileName = "flights.txt";
      



        private const string bookedFileName = "booked.txt";


        private static void CheckForExistingFile(string fileName)
        {
            string path = $"{directory}{fileName}";
            bool exists = File.Exists(path);
            if (!exists)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using FileStream fs = File.Create(path);
            }

        }
        public static List<Flight> LoadFlightsFromFile(string path)
        {
            List<Flight> flights = [];
            if (path == "self")
            {
                path = $"{directory}{flightFileName}";

            }


            try
            {
                //CheckForExistingFile(flightFileName);
                string[] flightsAsString = File.ReadAllLines(path);
                for (int i = 0; i < flightsAsString.Length - 1; i++)
                {
                    string[] flightSplits = flightsAsString[i].Split(',');
                    if (flightSplits.Length < 8)
                    {
                        Console.WriteLine($"Invalid input format {flightsAsString[i]}");
                    }
                    else
                    {

                        //{FlightId};{Price};{DepartureCountry}{DestinationCountry}{DepartureDate}{DepartureAirport}{ArrivalAirport}{FlightClass}

                        bool success = int.TryParse(flightSplits[0], out int flightID);
                        if (!success)
                        {
                            flightID = 0;
                        }
                        success = decimal.TryParse(flightSplits[1], out decimal price);
                        if (!success)
                            price = 0;
                        string departureCountry = flightSplits[2];
                        string destinationCountry = flightSplits[3];
                        string departureDate = flightSplits[4];
                        success = DateTime.TryParseExact(departureDate, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDepartureDate);
                        if (!success)
                        {
                            parsedDepartureDate = DateTime.Now;
                        }

                        string departureAirport = flightSplits[5];
                        string arrivalAirport = flightSplits[6];
                        success = Enum.TryParse(flightSplits[7], out FlightClass flightClass);
                        if (!success)
                        {
                            flightClass = FlightClass.Economy;
                        }

                      //  Console.WriteLine(parsedDepartureDate);

                        Flight newFlight = new() 
                        {
                            FlightId = flightID,
                            Price = price,
                            DepartureCountry = departureCountry,
                            DestinationCountry = destinationCountry,
                            DepartureDate = parsedDepartureDate,
                            DepartureAirport = departureAirport,
                            ArrivalAirport = arrivalAirport,
                            FlightClass = flightClass 
                        };
                        var validationResults = new List<ValidationResult>();
                        var context = new ValidationContext(newFlight);
                        Validator.ValidateObject(newFlight, context);
                        if (!true)
                        {
                            foreach (var validationResult in validationResults)
                            {
                                Console.WriteLine(validationResult);
                            }
                        }
                        else
                        {
                            flights.Add(newFlight);
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Something went wrong when reading the file [{path}; ");
                Console.WriteLine(iex.Message);

            }
            catch (FileNotFoundException fex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The file couldn't be found!");
                Console.WriteLine(fex.Message);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong while loading the file!");
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Console.ResetColor();
            }

            return flights;
        }
        public static List<Flight> LoadBookedFlightsFromFile(string path)
        {
            List<Flight> booked = [];
            if (path == "self")
            {
                path = $"{directory}{bookedFileName}";

            }


            try
            {
                CheckForExistingFile(bookedFileName);
                string[] flightsAsString = File.ReadAllLines(path);
                for (int i = 0; i < flightsAsString.Length - 1; i++)
                {
                    string[] flightSplits = flightsAsString[i].Split(',');
                    if (flightSplits.Length < 8)
                    {
                        Console.WriteLine($"Invalid input format {flightsAsString[i]}");
                    }

                    //{FlightId};{Price};{DepartureCountry}{DestinationCountry}{DepartureDate}{DepartureAirport}{ArrivalAirport}{FlightClass}

                    bool success = int.TryParse(flightSplits[0], out int flightID);

                    if (!success)
                    {
                        flightID = 0;
                    }
                    success = decimal.TryParse(flightSplits[1], out decimal price);
                    if (!success)
                        price = 0;
                    string departureCountry = flightSplits[2];
                    string destinationCountry = flightSplits[3];
                    string departureDate = flightSplits[4];
                    success = DateTime.TryParseExact(departureDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDepartureDate);
                    if (!success)
                    {
                        parsedDepartureDate = DateTime.Now;
                    }

                    string departureAirport = flightSplits[5];
                    string arrivalAirport = flightSplits[6];
                    success = Enum.TryParse(flightSplits[7], out FlightClass flightClass);
                    if (!success)
                    {
                        flightClass = FlightClass.Economy;
                    }
                    booked.Add(new Flight { FlightId = flightID, Price = price, DepartureCountry = departureCountry, DestinationCountry = destinationCountry, DepartureDate = parsedDepartureDate, DepartureAirport = departureAirport, ArrivalAirport = arrivalAirport, FlightClass = flightClass });
                }
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong when reading the file. ");
                Console.WriteLine(iex.Message);

            }
            catch (FileNotFoundException fex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The file couldn't be found!");
                Console.WriteLine(fex.Message);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong while loading the file!");
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Console.ResetColor();
            }

            return booked;
        }
    }
}

