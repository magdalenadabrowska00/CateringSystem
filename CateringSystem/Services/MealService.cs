using AutoMapper;
using CateringSystem.Data;
using CateringSystem.Data.Entities;
using CateringSystem.Data.Models;
using CateringSystem.ServicesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CateringSystem.Services
{
    public class MealService : IMealService
    {
        private readonly CateringDbContext _dbContext;
        private readonly IMapper _mapper;

        public MealService(CateringDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MealDto GetMeal(int restaurantId, int mealId)
        {
            var restaurant = GetRestaurant().FirstOrDefault(x => x.Id == restaurantId);

            if (restaurant == null)
            {
                throw new Exception("There isn't such restaurant.");
            }

            var meal = restaurant.Meals.FirstOrDefault(x=>x.Id == mealId);

            if (meal == null)
            {
                throw new Exception($"There isn't such meal for restaurant with id:{restaurantId}.");
            }

            var mealDto = _mapper.Map<MealDto>(meal);

            return mealDto;

        }

        public List<MealDto> GetAllMeals(int restaurantId)
        {
            var restaurant = GetRestaurant().FirstOrDefault(x=>x.Id == restaurantId);

            if (restaurant == null)
            {
                throw new Exception("There isn't such restaurant.");
            }

            var mealsFromRestaurant = restaurant.Meals;

            var mealsList = _mapper.Map<List<MealDto>>(mealsFromRestaurant);
            return mealsList;
        }

        private IQueryable<Restaurant> GetRestaurant()
        {
            var restaurant = _dbContext
                .Restaurants
                .Include(x => x.Meals);
            return restaurant;
        }
    }
}
