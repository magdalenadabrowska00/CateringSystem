using CateringSystem.Data.Models;
using CateringSystem.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CateringSystem.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _restaurantService.GetById(id);
            return Ok(restaurant);
        }

        [HttpGet]
        public ActionResult<List<RestaurantDto>> GetAll()
        {
            var restaurantList = _restaurantService.GetAll();
            return Ok(restaurantList);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateRestaurantDto dto)
        {
            var newRestaurantId = _restaurantService.CreateRestaurant(dto);
            return Created($"api/restaurant/{newRestaurantId}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] UpdateRestaurantDto dto)
        {
            _restaurantService.Update(dto, id);
            return Ok();
        }

    }
}