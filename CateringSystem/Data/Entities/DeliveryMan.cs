using System.Collections.Generic;

namespace CateringSystem.Data.Entities
{
    public class DeliveryMan
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public long PhoneNumber { get; set; }
        List<Order> Orders { get; set; } = new List<Order>();
    }
}
