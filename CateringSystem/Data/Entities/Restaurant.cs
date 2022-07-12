using System.Collections.Generic;

namespace CateringSystem.Data.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public long NIP { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UrlAddress { get; set; }
        //public int AddressId { get; set; }
        //public Address Address { get; set; }
        public List<Meal> Meals { get; set; }
        public string PasswordHash { get; set; }
    }
}
