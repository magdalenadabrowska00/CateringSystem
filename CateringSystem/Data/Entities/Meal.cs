using System.Collections.Generic;

namespace CateringSystem.Data.Entities
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WayOfGiving { get; set; }//hot, cold
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantsId { get; set; }
        public Restaurant Restaurants { get; set; }
        public List<Menu> Menus { get; set; } 
        //public List<MenuMeal> MenuMeals { get; set; } = new List<MenuMeal>();
    }
}
