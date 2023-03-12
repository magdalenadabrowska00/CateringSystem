namespace CateringSystem.Data.Entities
{
    public class MenuMeal
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int? MealAssessment { get; set; }
    }
}
