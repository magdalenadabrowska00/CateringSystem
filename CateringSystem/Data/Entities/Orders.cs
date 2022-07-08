using System;

namespace CateringSystem.Data.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryPostalCode { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }
        public int DeliveryMenId { get; set; }
        public DeliveryMen DeliveryMen { get; set; }
        public int OrdersDeliveryId { get; set; }
        public OrdersDelivery OrdersDelivery { get; set; }

    }
}
