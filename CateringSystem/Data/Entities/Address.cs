namespace CateringSystem.Data.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public virtual User User { get; set; }
        public virtual Restaurant Restaurant { get; set; }

    }
}
