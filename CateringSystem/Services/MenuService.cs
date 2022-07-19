using AutoMapper;
using CateringSystem.Data;
using CateringSystem.Data.Entities;
using CateringSystem.Data.Models;
using CateringSystem.Exceptions;
using CateringSystem.ServicesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CateringSystem.Services
{
    public class MenuService : IMenuService
    {
        private readonly CateringDbContext _dbContext;
        private readonly IMapper _mapper;

        public MenuService(CateringDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MenuDto> GetAll()
        {
            var menus = _dbContext.Menus
                .Include(x => x.Meals)
                .Include(x => x.MenuType);
            
            var menusDto = _mapper.Map<List<MenuDto>>(menus);
            return menusDto;

        }

        private IQueryable<Restaurant> GetRestaurant()
        {
            var restaurant = _dbContext.Restaurants
                .Include(x => x.Meals);

            return restaurant;
        }
    }
}
