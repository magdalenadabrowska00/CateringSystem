using AutoMapper;
using CateringSystem.Data;
using CateringSystem.Data.Entities;
using CateringSystem.Data.Models;
using CateringSystem.Exceptions;
using CateringSystem.ServicesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CateringSystem.Services
{
    public class MenuService : IMenuService
    {
        private readonly CateringDbContext _dbContext;
        private readonly IMapper _mapper;

        public MenuService(CateringDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MenuDto> GetAll()
        {
            var menus = _dbContext.Menus
                .Include(x => x.Meals)
                .Include(x => x.MenuType);
            
            var menusDto = _mapper.Map<List<MenuDto>>(menus);

            var meals = _dbContext.Meals.ToList();
            var menumeal = _dbContext.MenuMeals.ToList();

            var connection = meals.Join(menumeal,
                x => x.Id,
                y => y.MealId,
                (x, y) => new { Group = y.MenuId, PriceForOneMenu = x.Price });

            var groupedConn = connection
                .GroupBy(x => x.Group)
                .Select(t => new
                {
                    MenuId = t.Key,
                    SumPriceFOrOneDayMenu = t.Sum(x => x.PriceForOneMenu),
                }).ToList();

            foreach (var menu in menusDto)
            {
                if(groupedConn.Any(x=>x.MenuId == menu.Id))
                {
                    menu.TotalPriceForOneDay = groupedConn.Where(x=>x.MenuId == menu.Id).Select(x=>x.SumPriceFOrOneDayMenu).Sum();
                }
            }

            return menusDto;

        }

        public void PriceMenuForDay()
        {
            var menus = _dbContext.Menus.ToList();
            var meals = _dbContext.Meals.ToList();
            var menumeal = _dbContext.MenuMeals.ToList();

            var connection = meals.Join(menumeal, 
                x => x.Id, 
                y => y.MealId,
                (x,y) => new {Group = y.MenuId, PriceForOneMenu = x.Price});

            var groupedConn = connection
                .GroupBy(x => x.Group)
                .Select(t => new
                {
                    Id = t.Key,
                    SumPriceFOrOneDayMenu = t.Sum(x=>x.PriceForOneMenu),
                }).ToList();
            
        }

        private IQueryable<Restaurant> GetRestaurant()
        {
            var restaurant = _dbContext.Restaurants
                .Include(x => x.Meals);

            return restaurant;
        }
    }
}
