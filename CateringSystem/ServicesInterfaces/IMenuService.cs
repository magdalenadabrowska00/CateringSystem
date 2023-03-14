using CateringSystem.Data.Models;
using System.Collections.Generic;

namespace CateringSystem.ServicesInterfaces
{
    public interface IMenuService
    {
        //List<MenuDto> GetAll();
        List<MenuDto> GetAllFromRestaurant(int restaurantId);
        MenuDto GetMenuFromrestaurant(int restaurantId, int menuId);
        int CreateMenuForRestaurant(CreateMenuDto dto, int restaurantId);
    }
}
