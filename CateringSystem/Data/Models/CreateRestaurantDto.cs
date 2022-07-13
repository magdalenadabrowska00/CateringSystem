namespace CateringSystem.Data.Models
{
    public class CreateRestaurantDto
    {
        public long NIP { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UrlAddress { get; set; }
    }
}
