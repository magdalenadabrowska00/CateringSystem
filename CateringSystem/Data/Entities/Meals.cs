namespace CateringSystem.Data.Entities
{
    public class Meals
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WayOfGiving { get; set; }//hot, cold
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantsId { get; set; }
        public Restaurants Restaurants { get; set; }
    }
}
