using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CateringSystem.Data;
using CateringSystem.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using CateringSystem.Services;
using CateringSystem.Data.Models;

namespace CateringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]    //użytkownik i zalogowany od którego jest to zamówienie i ci wyżej rangą
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDto> GetOrder(int id)
        {
            var order = _orderService.GetById(id);

            if(order == null) 
                return NotFound();

            return Ok(order);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrderDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<OrderDto>> GetAllOrders([FromQuery] Query query)
        {
            var orders = _orderService.GetAll(query);

            return Ok(orders);
        }



    }
}
