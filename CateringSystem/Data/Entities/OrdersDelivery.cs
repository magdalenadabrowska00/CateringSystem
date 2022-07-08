﻿using System;

namespace CateringSystem.Data.Entities
{
    public class OrdersDelivery
    {
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }//short
        public int DeliveryStartHour { get; set; }
        public int DeliveryEndHour { get; set; }
    }
}
