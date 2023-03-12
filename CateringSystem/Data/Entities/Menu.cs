using System;
using System.Collections.Generic;

namespace CateringSystem.Data.Entities
{
    public class Menu //relacje wiele do wiele w menu i meal dokończyć, pośrednia jest okej
    {
        public int Id { get; set; }
        public int MenuTypeId { get; set; }
        public MenuType MenuType { get; set; }
        public DateTime Date { get; set; } //dzień w którym będzie to menu czyli 5 posiłków na przykład
        public List<Meal> Meals { get; set; } 
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int? RestaurantId { get; set; }
        //public List<MenuMeal> MenuMeals { get; set; } = new List<MenuMeal>();
    }
}
