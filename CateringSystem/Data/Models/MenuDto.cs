using CateringSystem.Data.Entities;
using System;
using System.Collections.Generic;

namespace CateringSystem.Data.Models
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string MenuTypeName { get; set; }
        //public string RestaurantName { get; set; }
        public decimal TotalPriceForOneDay { get; set; }
        public DateTime Date { get; set; }
        public List<MealDtoForMenu> Meals { get; set; }
    }
}
