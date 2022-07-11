﻿using CateringSystem.Data;
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
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.MenuTypes.Any())
                {
                    var menuTypes = GetMenuTypes();
                    _dbContext.MenuTypes.AddRange(menuTypes);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.DeliveryMen.Any())
                {
                    var deliveryMen = GetDeliveryMen();
                    _dbContext.DeliveryMen.AddRange(deliveryMen);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private List<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    NIP= 478234967,
                    CompanyName = "FitToBe",
                    Email = "fittobe@gmail.com",
                    PhoneNumber = "164378532",
                    UrlAddress = "fittobe.pl",
                    Meals = new List<Meal>()
                    {
                        new Meal()
                        {
                            Name = "Banana Bread",
                            WayOfGiving = "cold",
                            Description = "Oat banana bread with pomegranate and Greek yogurt",
                            Price = 7.00M,
                            Menus = new List<Menu>()
                            {
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 1,
                                },
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 2,
                                }
                            }
                        },
                        new Meal()
                        {
                            Name = "Lithuanian soup",
                            WayOfGiving = "cold",
                            Description = "Lithuanian cold soup with egg and wasa bread",
                            Price = 6.50M,
                            Menus = new List<Menu>()
                            {
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 1,
                                },
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 2,
                                }
                            }
                        },
                        new Meal()
                        {
                            Name = "Turkey leg",
                            WayOfGiving = "hot",
                            Description = "Turkey leg in bbq sauce with quinoa and broccoli",
                            Price = 29.00M,
                            Menus = new List<Menu>()
                            {
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 1,
                                },                                
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 2,
                                }
                            }
                        },
                        new Meal()
                        {
                            Name = "Vegetable salad with a chicken",
                            WayOfGiving = "cold",
                            Description = "Vegetable salad with a leg of chicken",
                            Price = 14.00M,
                            Menus = new List<Menu>()
                            {
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 1,
                                },                                
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 2,
                                }
                            }
                        }
                        ,new Meal()
                        {
                            Name = "Wrap with chicken and vegetables",
                            WayOfGiving = "hot",
                            Description = "Whole wheat wrap with chicken, colorful cabbage salad, and garlic sauce",
                            Price = 13.50M,
                            Menus = new List<Menu>()
                            {
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 1,
                                },                                
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 2,
                                }

                            }
                        }
                        ,new Meal()
                        {
                            Name = "Chocolate-apple risotto",
                            WayOfGiving = "cold",
                            Description = null,
                            Price = 6.00M,
                            Menus = new List<Menu>()
                            {
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 1,
                                },                                
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 2,
                                }
                            }
                        }
                        ,new Meal()
                        {
                            Name = "Egg omelette",
                            WayOfGiving = "hot",
                            Description = "Egg omelette from the oven with stewed leek, parsley and pumpernickel",
                            Price = 10.00M,
                            Menus = new List<Menu>()
                            {
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 1,
                                },                                
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 2,
                                }
                            }
                        }
                        ,new Meal()
                        {
                            Name = "Poultry strogon",
                            WayOfGiving = "hot",
                            Description = "Poultry strogon with pickled cucumber and pearl barley",
                            Price = 17.00M,
                            Menus = new List<Menu>()
                            {
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 1,
                                },
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 2,
                                }
                            }
                        }
                        ,new Meal()
                        {
                            Name = "Mediterranean salad",
                            WayOfGiving = "cold",
                            Description = "Mediterranean salad with spicy grilled pork neck",
                            Price = 12.00M,
                            Menus = new List<Menu>()
                            {
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 1,
                                },                                
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 2,
                                }
                            }
                        }
                        ,new Meal()
                        {
                            Name = "Baked potatoes with guacamole",
                            WayOfGiving = "hot",
                            Description = "Baked sweet potatoes with chickpeas, cauliflower, and guacamole",
                            Price = 12.00M,
                            Menus = new List<Menu>()
                            {
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 1,
                                },
                                new Menu()
                                {
                                    MenuTypeId = 1,
                                    OrderId = 2,
                                }
                            }

                        },
                    },

                   
                   

                },

            };
            return restaurants;
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
