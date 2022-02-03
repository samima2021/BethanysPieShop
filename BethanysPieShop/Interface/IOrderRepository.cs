using BethanysPieShop.Models;

namespace BethanysPieShop.Interface
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
