using CateringSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CateringSystem.Data
{
    public class CateringDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<DeliveryMan> DeliveryMen { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuMeal> MenuMeals { get; set; }
        public DbSet<MenuType> MenuTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDelivery> OrdersDeliveries { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderMenu> OrdersMenus { get; set; }

        public CateringDbContext(DbContextOptions<CateringDbContext> options): base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
                .HasMany(p => p.Menus)
                .WithMany(x => x.Meals)
                .UsingEntity<MenuMeal>(
                  w=>w.HasOne(wit=>wit.Menu)
                  .WithMany()
                  .HasForeignKey(wit => wit.MenuId),
                   
                  w => w.HasOne(wit => wit.Meal)
                  .WithMany()
                  .HasForeignKey(wit => wit.MealId),

                  wit =>
                  {
                      wit.HasKey(x => new { x.MenuId, x.MealId });
                      wit.Property(x => x.MealAssessment);
                  }
                );

            modelBuilder.Entity<Address>()
                .Property(x => x.Street).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Address>()
                .Property(x => x.City).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Address>()
                .Property(x => x.Country).HasMaxLength(20).IsRequired();

            modelBuilder.Entity<DeliveryMan>()
                .Property(x=>x.CompanyName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<DeliveryMan>()
                .Property(x => x.PhoneNumber).HasMaxLength(15).IsRequired();

            modelBuilder.Entity<Meal>()
                .Property(x=>x.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Meal>()
                .Property(x=>x.Description).HasMaxLength(200);
            modelBuilder.Entity<Meal>()
                .Property(x => x.Price).IsRequired();

            modelBuilder.Entity<MenuType>()
                .Property(x => x.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<MenuType>()
                .Property(x => x.NumberOFMeals).IsRequired();

            modelBuilder.Entity<Order>()
                .Property(x => x.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Order>()
                .Property(x => x.OrderDate).IsRequired();
            modelBuilder.Entity<Order>()
                .Property(x => x.DeliveryDate).IsRequired();
            modelBuilder.Entity<Order>()
                .Property(x => x.DeliveryAddress).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Order>()
                .Property(x => x.DeliveryPostalCode).IsRequired();
            modelBuilder.Entity<Order>()
                .Property(x => x.DeliveryCity).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Order>()
                .Property(x => x.UserId).IsRequired();
            modelBuilder.Entity<Order>()
                .Property(x => x.OrderDeliveryId).IsRequired();
            modelBuilder.Entity<Order>()
                .Property(x => x.DeliveryMenId).IsRequired();

            modelBuilder.Entity<OrderDelivery>()
                 .Property(x => x.DeliveryDate).IsRequired();
            modelBuilder.Entity<OrderDelivery>()
                .Property(x => x.DeliveryStartHour).IsRequired();
            modelBuilder.Entity<OrderDelivery>()
                .Property(x => x.DeliveryEndHour).IsRequired();

            modelBuilder.Entity<Restaurant>()
                .Property(x => x.NIP).IsRequired();
            modelBuilder.Entity<Restaurant>()
                .Property(x => x.CompanyName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Restaurant>()
                .Property(x => x.Email).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Restaurant>()
                .Property(x => x.PhoneNumber).IsRequired();
            modelBuilder.Entity<Restaurant>()
                .Property(x => x.UrlAddress).IsRequired();

            modelBuilder.Entity<Role>()
                .Property(x => x.Name).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.LastName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.DateOfBirth).IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.Email).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.PhoneNumber).IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.AddressId).IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.RoleId).IsRequired();

            modelBuilder.Entity<Menu>()
                .Property(x => x.Date).IsRequired();

            modelBuilder.Entity<Order>()
                .HasMany(p => p.Menus)
                .WithMany(x => x.Orders)
                .UsingEntity<OrderMenu>(
                  w => w.HasOne(wit => wit.Menu)
                  .WithMany()
                  .HasForeignKey(wit => wit.MenuId),

                  w => w.HasOne(wit => wit.Order)
                  .WithMany()
                  .HasForeignKey(wit => wit.OrderId),

                  wit => wit.HasKey(x => new { x.MenuId, x.OrderId }) 
                );
        }
    }
}
