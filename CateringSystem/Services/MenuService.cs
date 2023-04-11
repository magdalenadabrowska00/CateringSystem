using AutoMapper;
using CateringSystem.Data;
using CateringSystem.Data.Entities;
using CateringSystem.Data.Models;
using CateringSystem.Exceptions;
using CateringSystem.ServicesInterfaces;
using DeepL;
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
        private readonly ITranslationService _translationService;

        public MenuService(CateringDbContext dbContext, IMapper mapper, ITranslationService translationService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _translationService = translationService;
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


        public List<MenuDto> GetAllFromRestaurant(int restaurantId, string language)
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
                if (language == LanguageCode.Polish)
                {
                    menu.MenuTypeName = _translationService
                        .Translate(
                            menu.MenuTypeName.ToString(),
                            LanguageCode.English,
                            LanguageCode.Polish)
                        .Result;
                }
            }
            
            return result;
        }

        //bez mealsów w modelu i pobierania myślę
        public MenuDto GetMenuFromrestaurant(int restaurantId, int menuId, string language) //do złożenia zamówienia
        {
            var restaurant = _dbContext.Restaurants.FirstOrDefault(x => x.Id != restaurantId);

            if (restaurant == null)
            {
                throw new CateringSystem.Exceptions.NotFoundException("There isn't such restaurant.");
            }

            var menu = _dbContext.Menus.Where(x => x.RestaurantId == restaurantId && x.Id == menuId).Include(x => x.Meals).Include(x => x.MenuType).FirstOrDefault();
            var menuDto = _mapper.Map<MenuDto>(menu);
            menuDto.RestaurantName = restaurant.CompanyName;
            menuDto.TotalPriceForOneDay = menu.Meals.Sum(x => x.Price);

            if (language == LanguageCode.Polish)
            {
                menuDto.MenuTypeName = _translationService
                    .Translate(
                        menuDto.MenuTypeName.ToString(),
                        LanguageCode.English,
                        LanguageCode.Polish)
                    .Result;
            }

            return menuDto;
        }

        public List<MealDto> GetAllMealsForMenu(int restaurantId, int menuId, string language)
        {
            var mealsFromMenu = _dbContext
                .MenuMeals
                .Where(x => x.MenuId == menuId)
                .Include(x => x.Meal).ThenInclude(x => x.Restaurants)
                .Select(x => x.Meal)
                .ToList();

            var mealsToMenu = _mapper.Map<List<MealDto>>(mealsFromMenu);

            if (language == LanguageCode.Polish)
            {
                foreach (var meal in mealsToMenu)
                {
                    meal.Name = _translationService.Translate(meal.Name.ToString(), LanguageCode.English, LanguageCode.Polish).Result;
                    meal.WayOfGiving = _translationService.Translate(meal.WayOfGiving.ToString(), LanguageCode.English, LanguageCode.Polish).Result;
                    meal.Description = meal.Description != null ? _translationService.Translate(meal.Description.ToString(), LanguageCode.English, LanguageCode.Polish).Result : string.Empty;                   
                }
            }

            return mealsToMenu;
        }

        public int CreateMenuForRestaurant(CreateMenuDto dto, int restaurantId)
        {
            var mealsIds = dto.Meals.Select(x => x.Id).ToList(); //jeśli nie uda się z mapperem tylko z Id, to uprościć model o te Id, a nie całe obiekty, wtedy pobierać z frontu same Id też
            //var mealsEntities = _mapper.Map<List<Meal>>(dto.Meals);

            var menuEntity = new Menu
            {
                MenuTypeId = dto.MenuTypeId,
                Date = dto.Date,
                RestaurantId = restaurantId,
                Meals = _dbContext.Meals.Where(x => mealsIds.Contains(x.Id)).ToList() //mealsEntities
            };

            _dbContext.Menus.Add(menuEntity);
            _dbContext.SaveChanges();
            return menuEntity.Id;
        }
    }
}
