using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using BLL.Interfaces;
using DAL.Classes;
using BLL.Models;

namespace BLL
{
    public class DBDataOperations: IDbCrud
    {
        IntDbRepository dataBase;
        public DBDataOperations(IntDbRepository repos)
        {
            dataBase = repos;
        }
        public List<OrderModel> GetAllOrderModels()
        {
            var result = dataBase.Orders.GetAll().Select(i => new OrderModel(i)).ToList();
            foreach (var i in result)
            {
                foreach (var j in dataBase.Statuss.GetAll())
                {
                    if (i.Status_FK == j.Status_ID)
                    {
                        i.Status = j.Status1;
                    }
                }
            }
            return result;
        }
        public List<DishOrdersModel> GetAllOrderDishes()
        {
            return dataBase.DishOrders.GetAll().Select(i => new DishOrdersModel { Ready = i.Ready, Order_FK = i.Order_FK }).ToList();
        }
        public List<CategoryModel> GetAllCategories()
        {
            return dataBase.Categorys.GetAll().Select(i => new CategoryModel(i)).ToList();
        }

        public List<ChefModel> GetAllChefs()
        {
            return dataBase.Chefs.GetAll().Select(i => new ChefModel(i)).ToList();
        }
        
        public void TakeOrder(int orderId)
        {
            Order order = dataBase.Orders.GetItem(orderId);
            order.Status_FK = 2;
            Save();
        }
        public void GiveDish(int doId)
        {
            DishOrder order = dataBase.DishOrders.GetItem(doId);
            order.Ready = true;
            Save();
        }
        public void GiveOrder(int orderId)
        {
            Order order = dataBase.Orders.GetItem(orderId);
            order.Status_FK = 1;
            Save();
        }
        public bool Save()
        {
            if (dataBase.Save() > 0) return true;
            return false;
        }
    }

}
