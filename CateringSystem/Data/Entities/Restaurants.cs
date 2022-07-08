namespace CateringSystem.Data.Entities
{
    public class Restaurants
    {
        public int Id { get; set; }
        public long NIP { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UrlAddress { get; set; }
        public int AddressId { get; set; }
        public Addresses Addresses { get; set; }
    }
}
