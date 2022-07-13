using AutoMapper;
using CateringSystem.Data;
using CateringSystem.Data.Models;
using CateringSystem.ServicesInterfaces;
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
    }
}
