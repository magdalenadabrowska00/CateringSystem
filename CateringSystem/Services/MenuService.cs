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
            var restaurant = _dbContext.Restaurants.FirstOrDefault(x=>x.Id == restaurantId);
            
            if (restaurant == null)
            {
                throw new NotFoundException("There isn't such restaurant.");
            }
            var restaurantName = restaurant.CompanyName;

            var meals = _dbContext.Meals.Where(x => x.RestaurantsId == restaurant.Id).ToList();

            var mealsMenus = _dbContext.MenuMeals.ToList();

            var mealsWithMenuId = meals.Join(mealsMenus,
                x => x.Id,
                y => y.MealId,
                (x, y) => new { x.Price, y.MenuId });


            var groupedConn = mealsWithMenuId
                .GroupBy(x => x.MenuId)
                .Select(t => new
                {
                    Id = t.Key,
                    SumPriceFOrOneDayMenu = t.Sum(x => x.Price),
                }).ToList();

            var menus = _dbContext.Menus
                .Include(x => x.Meals).ThenInclude(x => x.Restaurants)
                .Include(x => x.MenuType);

            var menusDto = _mapper.Map<List<MenuDto>>(menus);

            foreach (var group in groupedConn)
            {
                foreach (var menu in menusDto)
                {
                    if (group.Id == menu.Id)
                    {
                        menu.RestaurantName = restaurantName;
                        menu.TotalPriceForOneDay = groupedConn.Where(x => x.Id == menu.Id).Select(x => x.SumPriceFOrOneDayMenu).Sum(); 
                    }                
                }
            }
            var menusDtoWithoutRestaurant = menusDto.Where(x => x.RestaurantName is null);

            var result = menusDto.Except(menusDtoWithoutRestaurant).ToList();
            return result;

        }


        public MenuDto GetMenuFromrestaurant(int restaurantId, int menuId)
        {
            
            var restaurant = _dbContext.Restaurants.FirstOrDefault(x => x.Id == restaurantId);

            if (restaurant == null)
            {
                throw new NotFoundException("There isn't such restaurant.");
            }
            var restaurantName = restaurant.CompanyName;

            var meals = _dbContext.Meals.Where(x => x.RestaurantsId == restaurant.Id).ToList();

            var mealsMenus = _dbContext.MenuMeals.Where(x => x.MenuId == menuId).ToList();

            var mealsWithMenuId = meals.Join(mealsMenus,
                x => x.Id,
                y => y.MealId,
                (x, y) => new { x.Price, y.MenuId });


            var groupedConn = mealsWithMenuId
                .GroupBy(x => x.MenuId)
                .Select(t => new
                {
                    Id = t.Key,
                    SumPriceFOrOneDayMenu = t.Sum(x => x.Price),
                }).ToList();

            if(!groupedConn.Any() || groupedConn.Count == 0)  
            {
                throw new NotFoundException("The restaurant and menu doesn't match.");
            }

            var menu = _dbContext.Menus
                .Include(x => x.Meals).ThenInclude(x => x.Restaurants)
                .Include(x => x.MenuType)
                .FirstOrDefault(x=>x.Id == menuId);


            var menuDto = _mapper.Map<MenuDto>(menu);

            menuDto.RestaurantName = restaurantName;
            menuDto.TotalPriceForOneDay = groupedConn.Where(x => x.Id == menuId).Select(x => x.SumPriceFOrOneDayMenu).Sum();
               
            return menuDto;
        }
    }
}
