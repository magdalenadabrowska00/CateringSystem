using CateringSystem.Data.Entities;
using System;
using System.Collections.Generic;

namespace CateringSystem.Data.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryPostalCode { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string DeliveryManCompanyName { get; set; }
        public int OrderDeliveryStartHour { get; set; }
        public int OrderDeliveryEndHour { get; set; }
        public DateTime OrderDeliveryDate { get; set; }

    }
}
