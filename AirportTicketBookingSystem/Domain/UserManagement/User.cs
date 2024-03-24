namespace AirportTicketBookingSystem.Domain.UserManagement
{
    public class User
    {
        public required int Id { get; init; }
        public string? UserName { get; init; }
        //CHANGE TO ROLE 
        public UserRole Role { get; init; }

        public bool IsManager()
        {
            return this.Role == UserRole.Manager;
        }
    }
}
