using System.Collections.Generic;

namespace CateringSystem.Data.Entities
{
    public class Menu //relacje wiele do wiele w menu i meal dokończyć, pośrednia jest okej
    {
        public int Id { get; set; }
        public int MenuTypeId { get; set; }
        public virtual MenuType MenuType { get; set; }
        public List<Meal> Meals { get; set; } 
        public int OrderId { get; set; }
        public Order Order { get; set; }
        //public List<MenuMeal> MenuMeals { get; set; } = new List<MenuMeal>();
    }
}
