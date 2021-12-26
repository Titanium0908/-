using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;

namespace BLL.Models
{
    public class DishOrdersModel
    {
        public int DIshOrder_Id { get; set; }

        public int Dish_FK { get; set; }

        public int Order_FK { get; set; }
        public bool Ready { get; set; }

        public DishOrdersModel() { }
        public DishOrdersModel(DishOrder Do)
        {
            DIshOrder_Id = Do.DIshOrder_Id;
            Dish_FK = Do.Dish_FK;
            Order_FK = Do.Order_FK;

        }
    }
}
