using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;


namespace BLL.Interfaces
{
    public interface IDbCrud
    {
        List<CategoryModel> GetAllCategories();
        List<OrderModel> GetAllOrderModels();
        List<DishOrdersModel> GetAllOrderDishes();
        List<ChefModel> GetAllChefs();
        void TakeOrder(int orderId);
        void GiveDish(int doId);
        void GiveOrder(int orderId);
    }
}
