using CateringSystem.Data.Models;
using System.Collections.Generic;

namespace CateringSystem.ServicesInterfaces
{
    public interface IMenuService
    {
        //List<MenuDto> GetAll();
        List<MenuDto> GetAllFromRestaurant(int restaurantId, string language);
        List<MealDto> GetAllMealsForMenu(int restaurantId, int menuId, string language);
        MenuDto GetMenuFromrestaurant(int restaurantId, int menuId, string language);
        int CreateMenuForRestaurant(CreateMenuDto dto, int restaurantId);
    }
}
