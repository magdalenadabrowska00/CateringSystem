using System;

namespace CateringSystem.Data.Models
{
    public class CreateOrderDto
    {
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryPostalCode { get; set; }
        public int DeliveryMenId { get; set; } //????
        public int OrderDeliveryId { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public int OrderDeliveryStartHour { get; set; }
        public int OrderDeliveryEndHour { get; set; }
        //public int MenuId { get; set; }

    }
}
