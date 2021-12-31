using CoffeeShop.Data.Models;

namespace CoffeeShop.Data.BAL
{
    public interface IOrderService
    {
        void AddItem(Item item, Order order);
        void RemoveItem(string item, Order order);
    }
}