using AirportTicketBookingSystem.Domain.FlightManagement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;



namespace AirportTicketBookingSystem
{
    internal class FlightRepository
    {
        private string directory = @"C:\Users\Lenovo\source\repos\AirportTicketBookingSystemProject\AirportTicketBookingSystem\Data\";
        private string flightFileName = "flights.txt";

        //for the booked 

        private string bookedFileName = "booked.txt";


        private void CheckForExistingFile(string fileName)
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
        public List<Flight> LoadFlightsFromFile()
        {
            List<Flight> flights = [];

            string path = $"{directory}{flightFileName}";
            try
            {
                CheckForExistingFile(flightFileName);
                string[] flightsAsString = File.ReadAllLines(path);
                for (int i = 0; i < flightsAsString.Length; i++)
                {
                    string[] flightSplits = flightsAsString[i].Split(';');

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
                    flights.Add(new Flight { FlightId = flightID, Price = price, DepartureCountry = departureCountry, DestinationCountry = destinationCountry, DepartureDate = parsedDepartureDate, DepartureAirport = departureAirport, ArrivalAirport = arrivalAirport, FlightClass = flightClass });
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

            return flights;
        }
        public List<Flight> LoadBookedFlightsFromFile()
        {
            List<Flight> booked = [];

            string path = $"{directory}{bookedFileName}";
            try
            {
                CheckForExistingFile(bookedFileName);
                string[] flightsAsString = File.ReadAllLines(path);
                for (int i = 0; i < flightsAsString.Length; i++)
                {
                    string[] flightSplits = flightsAsString[i].Split(';');

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

