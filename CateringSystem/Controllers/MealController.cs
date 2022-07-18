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

        [HttpGet("{mealId}")]
        public ActionResult<MealDto> GetMeal([FromRoute] int restaurantId, [FromRoute] int mealId)
        {
            var meal = _mealService.GetMeal(restaurantId, mealId);
            return meal;
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int restaurantId, [FromBody] CreateMealDto dto)
        {
            var newMealId = _mealService.Create(restaurantId, dto);

            return Created($"api/restaurant/{restaurantId}/meal/{newMealId}", null);
        }

        [HttpPut("{mealId}")]
        public ActionResult Edit([FromRoute] int restaurantId,[FromRoute] int mealId, [FromBody] UpdateMealDto dto)
        {
            _mealService.Update(restaurantId, mealId, dto);
            return Ok();
        }

        [HttpDelete("{mealId}")]
        public ActionResult Remove([FromRoute] int restaurantId, [FromRoute] int mealId)
        {
            _mealService.Delete(restaurantId, mealId);
            return NoContent();
        }

        //chyba nie ma sensu dodawać metody pobierz wszystko po prostu bez id restauracji
    }
}
