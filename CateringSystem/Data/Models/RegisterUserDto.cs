using System;
using System.ComponentModel.DataAnnotations;

namespace CateringSystem.Data.Models
{
    public class RegisterUserDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; } = 1;
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
