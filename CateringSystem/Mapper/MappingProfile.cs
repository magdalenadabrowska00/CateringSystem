using AutoMapper;
using CateringSystem.Data.Entities;
using CateringSystem.Data.Models;
using System.Collections.Generic;

namespace CateringSystem.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(x => x.UserLastName, y => y.MapFrom(z => z.User.LastName))
                .ForMember(x => x.UserFirstName, y => y.MapFrom(x => x.User.FirstName))
                .ForMember(x => x.UserEmail, y => y.MapFrom(z => z.User.Email))
                .ForMember(x => x.DeliveryManCompanyName, y => y.MapFrom(z => z.DeliveryMen.CompanyName))
                .ForMember(x => x.OrderDeliveryStartHour, y => y.MapFrom(z => z.OrdersDelivery.DeliveryStartHour))
                .ForMember(x => x.OrderDeliveryEndHour, y => y.MapFrom(z => z.OrdersDelivery.DeliveryEndHour))
                .ForMember(x => x.OrderDeliveryDate, y => y.MapFrom(z => z.OrdersDelivery.DeliveryDate)).ReverseMap();

            CreateMap<Order, CreateOrderDto>()
                .ForMember(x => x.OrderDeliveryDate, y => y.MapFrom(z => z.OrdersDelivery.DeliveryDate))
                .ForMember(x => x.OrderDeliveryStartHour, y => y.MapFrom(z => z.OrdersDelivery.DeliveryStartHour))
                .ForMember(x => x.OrderDeliveryEndHour, y => y.MapFrom(z => z.OrdersDelivery.DeliveryEndHour))
                .ReverseMap();

            CreateMap<Meal, MealDto>()
                .ForMember(x => x.RestaurantName, y => y.MapFrom(z => z.Restaurants.CompanyName)).ReverseMap();
            CreateMap<Meal, CreateMealDto>().ReverseMap();
            CreateMap<Meal, UpdateMealDto>().ReverseMap();
            CreateMap<Meal, MealDtoForMenu>().ReverseMap();

            CreateMap<Menu, MenuDto>()
                .ForMember(x => x.MenuTypeName, y => y.MapFrom(z => z.MenuType.Name));
            CreateMap<Menu, CreateMenuDto>().ReverseMap();
            CreateMap<Menu, MenuIdsDto>().ReverseMap();
            CreateMap<Menu, MenuCardDto>().ReverseMap();

            //CreateMap<Menu, MealsForMenuDay>();
            //CreateMap<Meal, MealsForMenuDay>()
            //    .ForMember(x=>x.RestaurantName, y=>y.MapFrom(z=>z.Restaurants.CompanyName));

            CreateMap<Restaurant, RestaurantDto>().ReverseMap();
            CreateMap<Restaurant, RestaurantListDto>().ReverseMap();

            CreateMap<Restaurant, CreateRestaurantDto>().ReverseMap();

            CreateMap<Restaurant, UpdateRestaurantDto>().ReverseMap();


        }
    }
}
