using LanchesWeb.Models;

namespace LanchesWeb.Repositories
{
    public interface IOrderRepository
    {
        public void ProcessOrder(Order order);
    }
}
