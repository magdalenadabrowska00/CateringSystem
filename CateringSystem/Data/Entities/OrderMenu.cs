namespace CateringSystem.Data.Entities
{
    public class OrderMenu
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
