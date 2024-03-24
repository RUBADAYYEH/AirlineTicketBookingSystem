using AirportTicketBookingSystem.Domain.UserManagement;
using System;
using System.Collections.Generic;
using System.IO;


namespace AirportTicketBookingSystem
{
    internal class UserRepository
    {
        private string directory = @"C:\Users\Lenovo\source\repos\AirportTicketBookingSystemProject\AirportTicketBookingSystem\Data\";
        private string usersFileName = "users.txt";

        private void CheckForExistingFile()
        {
            string path = $"{directory}{usersFileName}";
            bool exists = File.Exists(path);
            if (!exists)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using FileStream fs = File.Create(path);
            }

        }
        public List<User> LoadUsersFromFile()
        {
            List<User> users = [];
            string path = $"{directory}{usersFileName}";
            try
            {
                CheckForExistingFile();
                string[] usersAsString = File.ReadAllLines(path);
                for (int i = 0; i < usersAsString.Length; i++)
                {
                    string[] userSplits = usersAsString[i].Split(';');
                    bool success = int.TryParse(userSplits[0], out int userId);
                    if (!success)
                    {
                        userId = 0;
                    }
                    string username = userSplits[1];
                    success = Enum.TryParse(userSplits[2], out UserRole userRole);
                    if (!success)
                    {
                        userRole = UserRole.Passenger;
                    }
                    users.Add(new User { Id = userId, UserName = username, Role = userRole });
                }
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong when reading the file. ");
                Console.WriteLine(iex.Message);

            }catch (FileNotFoundException fex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The file couldn't be found!");
                Console.WriteLine(fex.Message);
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong while loading the file!");
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Console.ResetColor();
            }

            return users;
        }
    }
}
