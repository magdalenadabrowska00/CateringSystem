using System;
using System.ComponentModel.DataAnnotations;

namespace CateringSystem.Data.Models
{
    public class RegisterUserDto
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public int RoleId { get; set; } = 1;
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
