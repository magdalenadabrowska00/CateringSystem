using System;

namespace CateringSystem.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public Order Order { get; set; }

    }
}
