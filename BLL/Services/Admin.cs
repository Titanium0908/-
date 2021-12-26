using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Services
{
    public class Admin : IAdmin
    {
        IntDbRepository dataBase;
        public Admin(IntDbRepository dbRepository)
        {
            dataBase = dbRepository;
        }

        public List<OrderModel> GetDailyMoney(DateTime dateTime)
        {
            List<OrderModel> orderModels = new List<OrderModel>();
            var result = dataBase.Orders.GetAll();
            foreach(var i in result)
            {                
                if (i.Order_Date.Date == dateTime.Date)
                {
                    string name = null;
                    foreach (var j in dataBase.Chefs.GetAll())
                    {
                        if (j.Chef_ID == i.Chef_FK) name = j.Chef_FullName;
                    }
                    orderModels.Add(new OrderModel
                    { Order_Number = i.Order_Number, Order_Number_View = $"Номер заказа: {i.Order_Number}", Total = i.Total, Chef_Name = name  });
                }
            }
            return orderModels;
        }

        public List<DishModel> GetThreeMostPopular()
        {
            var dishes = dataBase.Dishs.GetAll().Select(i => new DishModel{ Dish_ID = i.Dish_ID, Dish_Image = i.Dish_Image, Dish_Name = i.Dish_Name, Number = 0 }).ToList();
            var dishOrd = dataBase.DishOrders.GetAll();

            foreach (var i in dishOrd)
            {
                foreach (var j in dishes)
                {
                    if (i.Dish_FK == j.Dish_ID)
                    {
                        j.Number+= i.Number;
                    }
                }
            }
            var temp = dishes.OrderBy(i => i.Number * -1).ToList();
            dishes = temp;
            return dishes;
        }

        public List<OrderModel> GetChefsOrdersNumber(int chefId)
        {
            var chefs = dataBase.Orders.GetAll().Where(i => i.Chef_FK == chefId).Select(i => new OrderModel { Total = i.Total }).ToList();
            return chefs;
        }
    }
}
