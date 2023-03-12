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

        /***
        public List<MenuDto> GetAll()
        {
            var menus = _dbContext.Menus
                .Include(x => x.Meals).ThenInclude(x => x.Restaurants)
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
        ***/


        public List<MenuDto> GetAllFromRestaurant(int restaurantId)
        {
            var menus = _dbContext.Menus
                .Where(x => x.RestaurantId == restaurantId)
                .Include(x => x.Meals)
                    .ThenInclude(x => x.Restaurants)
                .Include(x => x.MenuType);

            var restaurantName = _dbContext.Restaurants.FirstOrDefault(x => x.Id == restaurantId).CompanyName;

            var result = _mapper.Map<List<MenuDto>>(menus);

            foreach (var menu in result)
            {
                menu.RestaurantName = restaurantName;
                menu.TotalPriceForOneDay = menu.Meals.Sum(x => x.Price);               
            }
            
            return result;
        }


        public MenuDto GetMenuFromrestaurant(int restaurantId, int menuId) //do złożenia zamówienia
        {
            var restaurant = _dbContext.Restaurants.FirstOrDefault(x => x.Id != restaurantId);

            if (restaurant == null)
            {
                throw new NotFoundException("There isn't such restaurant.");
            }

            var menu = _dbContext.Menus.Where(x => x.RestaurantId == restaurantId && x.Id == menuId).Include(x => x.Meals).Include(x => x.MenuType).FirstOrDefault();
            var menuDto = _mapper.Map<MenuDto>(menu);
            menuDto.RestaurantName = restaurant.CompanyName;
            menuDto.TotalPriceForOneDay = menu.Meals.Sum(x => x.Price);

            return menuDto;
        }
    }
}
