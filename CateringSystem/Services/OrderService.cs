using AutoMapper;
using CateringSystem.Data;
using CateringSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CateringSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly CateringDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderService(CateringDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public OrderDto GetById(int orderId)
        {
            var order = _dbContext
                .Orders
                .Include(x => x.User)
                .Include(x => x.DeliveryMen)
                .Include(x => x.OrdersDelivery)
                .FirstOrDefault(x=>x.Id == orderId);

            if (order == null)
                throw new Exception("Order not found");

            var result = _mapper.Map<OrderDto>(order);
            return result;
        }


    }
}
