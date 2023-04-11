using System;
using System.Collections.Generic;

namespace CateringSystem.Data.Models
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryPostalCode { get; set; }
        public int DeliveryMenId { get; set; } 
        public DateTime OrderDeliveryDate { get; set; }
        public int OrderDeliveryStartHour { get; set; }
        public int OrderDeliveryEndHour { get; set; }
        public List<MenuIdsDto> MenuIds { get; set; }

    }
}
