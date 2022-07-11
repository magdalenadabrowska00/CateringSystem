using AutoMapper;
using CateringSystem.Data.Entities;
using CateringSystem.Data.Models;

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
                .ForMember(x => x.OrderDeliveryDate, y => y.MapFrom(z => z.OrdersDelivery.DeliveryDate));
        }
    }
}
