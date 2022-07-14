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
    [Authorize] // TO POTEM MA BYC!
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RestaurantDto))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _restaurantService.GetById(id);
            return Ok(restaurant);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<RestaurantDto>> GetAll()
        {
            var restaurantList = _restaurantService.GetAll();
            return Ok(restaurantList);
        }

        [HttpPost] 
        [Authorize(Roles = "Admin,Restaurant manager")] 
        public ActionResult Post([FromBody] CreateRestaurantDto dto)
        {
            //HttpContext.User.IsInRole("Admin")
            var newRestaurantId = _restaurantService.CreateRestaurant(dto);
            return Created($"api/restaurant/{newRestaurantId}", null);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Restaurant manager")] 
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id);
            return NoContent();
        }

    }
}
/***
 {
  "lastName": "Mowak",
  "firstName": "Jerzy",
  "dateOfBirth": "2000-07-14T09:47:36.908Z",
  "email": "mii.jerzy@o2.pl",
  "phoneNumber": "980987890",
  "password": "jasfasola",
  "confirmPassword": "jasfasola",
  "roleId": 4,
  "city": "Chorzów",
  "street": "Gliwicka",
  "postalCode": "33-222",
  "country": "Poland"
}
***/