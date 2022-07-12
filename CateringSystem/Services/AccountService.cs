using CateringSystem.Data;
using CateringSystem.Data.Entities;
using CateringSystem.Data.Models;
using CateringSystem.ServicesInterfaces;

namespace CateringSystem.Services
{
    public class AccountService : IAccountService
    {
        private CateringDbContext _context;
        public AccountService(CateringDbContext context)
        {
            _context = context;
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
