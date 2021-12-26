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

namespace WpfApp1.ViewModel
{
    public class OrderVM : INotifyPropertyChanged
    {

        private readonly IDbCrud _crud;
        private readonly IMenu _menu;

        public OrderVM(IDbCrud dbCrud, IMenu menu)
        {
            _crud = dbCrud;
            _menu = menu;

            Orders = new ObservableCollection<OrderModel>();
            var orders = _crud.GetAllOrderModels();
            foreach (var i in orders)
            {
                i.Order_Number_View = $"Номер заказа: {i.Order_Number}";
                i.Status = $"Статус: {i.Status}";
                Orders.Add(i);
            }

            Messenger.Default.Register<GenericMessage<DishModel>>(this, Update);
        }

        private void Update(GenericMessage<DishModel> msg)
        {
            Orders.Clear();
            var orders = _crud.GetAllOrderModels();
            foreach (var i in orders)
            {
                i.Order_Number_View = $"Номер заказа: {i.Order_Number}";
                i.Status = $"Статус: {i.Status}";
                Orders.Add(i);
            }
        }


        public ObservableCollection<OrderModel> orders;
        public ObservableCollection<OrderModel> Orders 
        {
            get
            {
                return orders;
            }
            set
            {
                orders = value;
                NotifyPropertyChanged("Orders");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
