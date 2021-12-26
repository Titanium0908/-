using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using DAL.Classes;
using DAL.Interfaces;
using System.Collections.ObjectModel;

namespace BLL.Services
{
    public class Order : IOrder
    {
        private IntDbRepository dataBase;
        public Order(IntDbRepository repos)
        {
            dataBase = repos;
        }


        public int MakeOrder(int total, ObservableCollection<DishModel> dishes)
        {
            int chef = dataBase.Services.ChooseChef();
            var orders = dataBase.Orders.GetAll();
            int position = 0;
            if (dataBase.Orders.GetAll().Count != 0)
            {
                 position = orders[orders.Count - 1].Order_Number + 1 % 100; 
            }

            DAL.Classes.Order order = new DAL.Classes.Order 
            { 
                Chef_FK = chef,
                Order_Date = System.DateTime.UtcNow,
                Order_Number = position,
                Status_FK = 4, 
                Total = total
            };
            dataBase.Orders.Create(order);

            if (dataBase.Save() <= 0)    
                return 0;

            orders = dataBase.Orders.GetAll();

            foreach (var dish in dishes)
            {
                DAL.Classes.DishOrder dishOrder = new DishOrder();
                dishOrder.Ready = false;
                dishOrder.Dish_FK = dish.Dish_ID;
                dishOrder.Order_FK = orders[orders.Count - 1].Order_ID;
                dishOrder.Number = dish.Amount;
                dataBase.DishOrders.Create(dishOrder);
            }

            if (dataBase.Save() > 0)
                return position;
            else return 0;
        }

        public List<ChefOrderModel> GetOrdersForChef(int chef_id)
        {
            return dataBase.Services.GetOrdersForChef(chef_id).Select(i => new ChefOrderModel { Dish_Order_ID = i.Order_Dish_ID, Ready = i.Ready, CanGive = true, DishStatus = "Выдать", Status = i.Status, Chef_FK = i.Chef_FK, Dish_Image = i.Dish_Image, Number = i.Number, Dish_Name = i.Dish_Name, Ingredients = i.Ingredients, Order_Date = i.Order_Date, Order_ID = i.Order_ID, Order_Number = i.Order_Number, Status_FK = i.Status_FK }).ToList();
        }
    }
}
