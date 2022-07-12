using AutoMapper;
using CateringSystem.Data;
using CateringSystem.Data.Entities;
using CateringSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
            var order = BasicOrderQuery()
                .FirstOrDefault(x=>x.Id == orderId);

            //if (order == null)
             //   throw new Exception("Order not found");
            

            var result = _mapper.Map<OrderDto>(order);
            return result;
        }

        public PagedResult<OrderDto> GetAll(Query query)
        {
            var baseQuery = BasicOrderQuery()
                .Where(x => query.SearchPhrase == null || (x.Name.ToLower().Contains(query.SearchPhrase.ToLower()) ||
                x.User.Email.ToLower().Contains(query.SearchPhrase.ToLower()) ||
                x.User.LastName.ToLower().Contains(query.SearchPhrase.ToLower()) ||
                x.User.FirstName.ToLower().Contains(query.SearchPhrase.ToLower())
                ));

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Order, object>>>
                {
                    {nameof(Order.Name), x=>x.Name },
                    {nameof(Order.User.Email), x=>x.User.Email },
                    {nameof(Order.User.LastName), x=>x.User.LastName },
                    {nameof(Order.User.FirstName), x=>x.User.FirstName },
                };

                var selectedColumn = columnsSelector[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC
                    ? baseQuery.OrderBy(selectedColumn) : baseQuery.OrderByDescending(selectedColumn);
            }

            var orders = baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToList();

            var totalItemsCount = baseQuery.Count();

            var ordersDtos = _mapper.Map<List<OrderDto>>(orders);

            var result = new PagedResult<OrderDto>(ordersDtos, totalItemsCount, query.PageSize, query.PageNumber);

            return result;
        }

        public int Create(CreateOrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);





        }


        private IQueryable<Order> BasicOrderQuery()
        {
            var basicOrder = _dbContext
                .Orders
                .Include(x => x.User)
                .Include(x => x.DeliveryMen)
                .Include(x => x.OrdersDelivery);
            return basicOrder;
        }

    }
}
