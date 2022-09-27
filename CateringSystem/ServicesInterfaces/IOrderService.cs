using CateringSystem.Data.Models;

namespace CateringSystem.Services
{
    public interface IOrderService
    {
        OrderDto GetById(int id);
        PagedResult<OrderDto> GetAll(Query query);
        int Create(CreateOrderDto dto, int restaurantId, int menuId);
        //void Delete(int id);
        //void Update(int id, UpdateOrderDto dto);
    }
}
