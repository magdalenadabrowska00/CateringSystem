using AutoMapper;
using CateringSystem.Data;
using CateringSystem.Data.Entities;
using CateringSystem.Data.Models;
using CateringSystem.ServicesInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace CateringSystem.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IMapper _mapper;
        private readonly CateringDbContext _dbContext;

        public RestaurantService(IMapper mapper, CateringDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public List<RestaurantDto> GetAll()
        {
            var restaurants = _dbContext.Restaurants.ToList();
            var result = _mapper.Map<List<RestaurantDto>>(restaurants);
            return result;
        }

        public RestaurantDto GetById(int id)
        {
            var restaurant = _dbContext.Restaurants.FirstOrDefault(x => x.Id == id);
            if(restaurant == null)
            {
                throw new System.Exception("There isn't such restaurant.");
            }

            var result = _mapper.Map<RestaurantDto>(restaurant);
            return result;
        }

        public int CreateRestaurant(CreateRestaurantDto dto)
        {
            var restaurantEntity = _mapper.Map<Restaurant>(dto);

            _dbContext.Restaurants.Add(restaurantEntity);
            _dbContext.SaveChanges();
            return restaurantEntity.Id;
        }
    }
}
