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
    [Route("api/order")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
 
        [HttpGet("{id}")]
        public ActionResult<OrderDto> GetOrder(int id)
        {
            var order = _orderService.GetById(id);

            if(order == null) 
                return NotFound();

            return Ok(order);
        }

        [HttpGet]
        public ActionResult<List<OrderDto>> GetAllOrders([FromQuery] Query query)
        {
            var orders = _orderService.GetAll(query);

            return Ok(orders);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateOrderDto dto)
        {
            var orderId = _orderService.Create(dto);
            return Created($"api/order/{orderId}", null);
        }
    }
}
