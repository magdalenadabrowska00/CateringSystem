using System;

namespace CateringSystem.Data.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public int AddressId { get; set; }
        public Addresses Addresses { get; set; }
        public int RoleId { get; set; }
        public Roles Roles { get; set; }

    }
}
