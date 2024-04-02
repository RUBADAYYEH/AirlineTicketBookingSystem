using AirportTicketBookingSystem.Domain.UserManagement;


namespace AirportTicketBookingSystemTest
{
    public class UnitTest1
    {
        [Fact]
        public void IsManagerReturnsTrue()
        {
            var user = new User { Id = 1, UserName = "manager1", Token = UserRole.Manager };
            Assert.True(user.IsManager());
            
        }
    }
}