using CateringSystem.Data.Models;
using CateringSystem.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CateringSystem.Controllers
{
    [Route("api/restaurant/{restaurantId}/meal")]
    [ApiController]
    //[Authorize]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;

        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MealDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<MealDto>> GetAllMealFromRestaurant([FromRoute] int restaurantId)
        {
            var result = _mealService.GetAllMeals(restaurantId);
            return Ok(result);
        }

    }
}
