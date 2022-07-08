namespace CateringSystem.Data.Entities
{
    public class Menus
    {
        public int Id { get; set; }
        public int MenuTypesId { get; set; }
        public MenuTypes MenuTypes { get; set; }
    }
}
