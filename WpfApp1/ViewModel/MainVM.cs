using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BLL.Interfaces;

namespace WpfApp1.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        public MainVM(IDbCrud dbCrud, IMenu menu, IOrder order)
        {
            MenuContext = new MenuVM(dbCrud, menu);
            BasketContext = new DishBasketVM(dbCrud, menu, order);
            OrderContext = new OrderVM(dbCrud, menu);
        }

        public MenuVM MenuContext { get; set; }
        public DishBasketVM BasketContext { get; set; }
        public OrderVM OrderContext { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
