namespace CateringSystem.Data.Entities
{
    public class MenuMeal
    {
        public int MenusId { get; set; }
        public Menus Menus { get; set; }
        public int MealsId { get; set; }
        public Meals Meals { get; set; }
        public int MealAssessment { get; set; }
    }
}
