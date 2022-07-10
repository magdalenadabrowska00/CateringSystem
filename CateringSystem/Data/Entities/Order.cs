using System;

namespace CateringSystem.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryPostalCode { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DeliveryMenId { get; set; }
        public DeliveryMan DeliveryMen { get; set; }
        public int OrderDeliveryId { get; set; }
        public OrderDelivery OrdersDelivery { get; set; }

    }
}
