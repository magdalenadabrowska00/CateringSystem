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
using System.Reflection;

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

            object refObj = PriceMenuForDay();
            var obj = CastTo(refObj, new[] { new { Id = 0, SumPriceFOrOneDayMenu = 0M }}.ToList());
            foreach (var menu in menusDto)
            { 
                if(obj.Any(x=>x.Id == menu.Id))
                {
                    menu.TotalPriceForOneDay = obj.Where(x=>x.Id == menu.Id).Select(x=>x.SumPriceFOrOneDayMenu).Sum();
                }
            }

            return menusDto;

        }
        private static T CastTo<T>(object value, T targetType)
        {
            return (T)value;
        }

        object PriceMenuForDay()
        {
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
                    SumPriceFOrOneDayMenu = t.Sum(x => x.PriceForOneMenu),
                }).ToList();

            return groupedConn;
            
        }

        private IQueryable<Restaurant> GetRestaurant()
        {
            var restaurant = _dbContext.Restaurants
                .Include(x => x.Meals);

            return restaurant;
        }
    }
}
