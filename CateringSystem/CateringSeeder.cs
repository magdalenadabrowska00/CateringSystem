using CateringSystem.Data;
using CateringSystem.Data.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CateringSystem
{
    public class CateringSeeder
    {
        private readonly CateringDbContext _dbContext;

        public CateringSeeder(CateringDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {

        }

        private List<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Client"
                },
                new Role()
                {
                    Name = "Restaurant manager"
                },
                new Role()
                {
                    Name = "Restaurant worker"
                },
                new Role()
                {
                    Name = "Admin"
                },
            };

            return roles;
        }

        private List<MenuType> GetMenuTypes()
        {
            var menuTypes = new List<MenuType>()
            {
                new MenuType()
                {
                    Name = "Sport",
                    NumberOFMeals = 5
                },
                new MenuType()
                {
                    Name = "Vegetarian",
                    NumberOFMeals = 4
                },
                new MenuType()
                {
                    Name = "Vegan",
                    NumberOFMeals = 4
                },
                new MenuType()
                {
                    Name = "No gluten",
                    NumberOFMeals = 4
                },
                new MenuType()
                {
                    Name = "Without lactose",
                    NumberOFMeals = 4
                },
                new MenuType()
                {
                    Name = "Low glycemin index",
                    NumberOFMeals = 4
                },
                new MenuType()
                {
                    Name = "Ketogenic diet",
                    NumberOFMeals = 4
                },
            };

            return menuTypes;
        }

        private List<DeliveryMan> GetDeliveryMen()
        {
            return new List<DeliveryMan>()
            {
                new DeliveryMan()
                {
                    CompanyName = "DPD",
                    PhoneNumber = 333999222,
                },
                new DeliveryMan()
                {
                    CompanyName = "Inpost",
                    PhoneNumber = 333999222,
                },
                new DeliveryMan()
                {
                    CompanyName = "globKurier",
                    PhoneNumber = 333999222,
                },
            };
        }

        private List<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    LastName = "Smith",
                    FirstName = "John",
                    DateOfBirth = new DateTime(1997,05,03),
                    Email = "j.smith@gmail.com",
                    PhoneNumber = "444999222",
                    Address = new Address()
                    {
                        City = "Warszawa",
                        Street = "3 maja 19",
                        PostalCode = "50-200",
                        Country = "Poland"
                    },
                    RoleId = 1,
                    Orders = new List<Order>()
                    {
                        new Order()
                        {
                            Name = RandomNameOfOrder(),
                            OrderDate = new DateTime(2020, 10,20),
                            DeliveryDate = new DateTime(2020, 11, 02),
                            DeliveryCity = "Warszawa",
                            DeliveryAddress = "3 maja 19",
                            DeliveryPostalCode = "50-200",
                            DeliveryMenId = 1,
                            OrdersDelivery = new OrderDelivery()
                            {
                                DeliveryDate = new DateTime(2020,11,02),
                                DeliveryStartHour = 8,
                                DeliveryEndHour = 10,
                            }
                        },
                        new Order()
                        {
                            Name = RandomNameOfOrder(),
                            OrderDate = new DateTime(2020, 08,23),
                            DeliveryDate = new DateTime(2020, 08, 25),
                            DeliveryCity = "Warszawa",
                            DeliveryAddress = "3 maja 19",
                            DeliveryPostalCode = "50-200",
                            DeliveryMenId = 2,
                            OrdersDelivery = new OrderDelivery()
                            {
                                DeliveryDate = new DateTime(2020,08,25),
                                DeliveryStartHour = 8,
                                DeliveryEndHour = 10,
                            }
                        }
                    }
                }
            };
            return users;
        }




        public static string RandomNameOfOrder()
        {

            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
