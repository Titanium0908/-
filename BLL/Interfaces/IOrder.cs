using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BLL.Interfaces;
using BLL;
using BLL.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace BLL.Interfaces
{
    public interface IOrder
    {
        int MakeOrder(int total, ObservableCollection<DishModel> dishes);
        List<ChefOrderModel> GetOrdersForChef(int chef_id);
    }
}
