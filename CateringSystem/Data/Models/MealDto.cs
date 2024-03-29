﻿namespace CateringSystem.Data.Models
{
    public class MealDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WayOfGiving { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string RestaurantName { get; set; }
    }
}
