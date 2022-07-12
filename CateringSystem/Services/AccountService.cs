using CateringSystem.Data;
using CateringSystem.Data.Entities;
using CateringSystem.Data.Models;
using CateringSystem.ServicesInterfaces;
using Microsoft.AspNetCore.Identity;

namespace CateringSystem.Services
{
    public class AccountService : IAccountService
    {
        private CateringDbContext _context;
        private IPasswordHasher<User> _passwordHasher;
        public AccountService(CateringDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                RoleId = dto.RoleId,
                PhoneNumber = dto.PhoneNumber,
                Address = new Address { City = dto.City, 
                    Country = dto.Country, 
                    Street = dto.Street, 
                    PostalCode = dto.PostalCode},
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}

/***
{
  "lastName": "borowska",
  "firstName": "angela",
  "dateOfBirth": "2000-07-12T11:43:17.147Z",
  "email": "bor@ang",
  "phoneNumber": "936458234",
  "password": "boraBora123",
  "roleId": 1,
  "city": "Katowice",
  "street": "Tyska",
  "postalCode": "40-777",
  "country": "Poland"
}
***/
