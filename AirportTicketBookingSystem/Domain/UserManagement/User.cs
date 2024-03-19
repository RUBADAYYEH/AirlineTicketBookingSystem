using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportTicketBookingSystem.Domain.UserManagement
{
    public class User
    {
        public int Id { get; init; }
        public string UserName { get; init; }
        public UserToken Token { get; init; }

        public bool IsManager()
        {
            return this.Token==UserToken.Manager;
        }
    }
}
