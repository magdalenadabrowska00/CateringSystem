using CateringSystem.Data.Models;
using CateringSystem.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CateringSystem.Controllers
{
    [Route("api/restaurant/{restaurantId}/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
      
        [HttpGet]
        public ActionResult<List<MenuDto>> GetAll([FromRoute] int restaurantId)
        {
            var result = _menuService.GetAllFromRestaurant(restaurantId);//_menuService.GetAll();
            return Ok(result);
        }
        
        [HttpGet("{menuId}")]
        public ActionResult<MenuDto> GetMenuFromRestaurant([FromRoute] int restaurantId, [FromRoute] int menuId)
        {
            var result = _menuService.GetMenuFromrestaurant(restaurantId, menuId);
            return Ok(result);
        }
        
        [HttpPost]
        public ActionResult<CreateMenuDto> CreateMenu([FromRoute] int restaurantId, [FromBody] CreateMenuDto dto)
        {
            var menuId = _menuService.CreateMenuForRestaurant(dto, restaurantId);
            return Created($"api/restaurant/{restaurantId}/menu/{menuId}", null);
        }
    }
}
