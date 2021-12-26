using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IAdmin
    {
        List<OrderModel> GetDailyMoney(DateTime dateTime);
        List<DishModel> GetThreeMostPopular();
        List<OrderModel> GetChefsOrdersNumber(int chefId);
    }
}
