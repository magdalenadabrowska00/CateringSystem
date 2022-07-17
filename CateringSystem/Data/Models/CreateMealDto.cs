namespace CateringSystem.Data.Models
{
    public class CreateMealDto
    {
        public string Name { get; set; }
        public string WayOfGiving { get; set; }//hot, cold
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
