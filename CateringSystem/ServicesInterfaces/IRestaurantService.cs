using CateringSystem.Data.Models;
using System.Collections.Generic;

namespace CateringSystem.ServicesInterfaces
{
    public interface IRestaurantService
    {
        RestaurantDto GetById(int id);
        List<RestaurantDto> GetAll();
        int CreateRestaurant(CreateRestaurantDto dto);
        void Update(UpdateRestaurantDto dto, int id); 
        void Delete(int id);
    }
}
