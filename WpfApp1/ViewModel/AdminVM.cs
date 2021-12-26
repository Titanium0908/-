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
    public class AdminVM : INotifyPropertyChanged
    {
        private readonly IDbCrud _crud;
        private readonly IMenu _menu;
        private readonly IOrder _order;
        private readonly IAdmin _adminService;
        public AdminVM(IDbCrud dbCrud, IMenu menu, IOrder order, IAdmin admin)
        {
            _crud = dbCrud;
            _menu = menu;
            _order = order;
            _adminService = admin;

            Popular = new ObservableCollection<DishModel>();
            Orders = new ObservableCollection<OrderModel>();
            Total = new ObservableCollection<OrderModel>();
            Sum = 0;

            Chef = new ObservableCollection<ChefModel>();
            var chefs = _crud.GetAllChefs();
            foreach (var i in chefs)
            {
                Chef.Add(i);
            }

            var popular = _adminService.GetThreeMostPopular();
            for (int i = 0; i < popular.Count && i < 3; i++)
            {
                Popular.Add(popular[i]);
            }

            selectedChef = 1;

            var orders = _adminService.GetChefsOrdersNumber(selectedChef);
            foreach (var i in orders)
            {
                Sum += i.Total;
                Orders.Add(i);
            }
            Count =  $"Заказов: {Orders.Count}";
            SumView = $"На сумму: {Sum} руб.";

            DateTime dateTime = DateTime.Now;
            var total = _adminService.GetDailyMoney(dateTime);
            foreach(var i in total)
            {
                Total.Add(i);
            }
        }

        public ObservableCollection<ChefModel> Chef { get; set; }

        private int selectedChef;
        public int SelectedChef
        {
            get
            {
                return selectedChef;
            }
            set
            {
                selectedChef = value;
                NotifyPropertyChanged("SelectedChef");
            }
        }

        private ICommand selectedIndexChangedCommand;
        public ICommand SelectedIndexChangedCommand
        {
            get
            {
                if (selectedIndexChangedCommand == null)
                    selectedIndexChangedCommand = new RelayCommand(args => ChangeChef(args));
                return selectedIndexChangedCommand;
            }
        }
        private void ChangeChef(object args)
        {
            selectedChef = Chef[(int)args].Chef_ID;
            Sum = 0;
            Orders.Clear();

            var orders = _adminService.GetChefsOrdersNumber(selectedChef);
            foreach (var i in orders)
            {
                Sum += i.Total;
                Orders.Add(i);
            }
            SumView = $"На сумму: {Sum} руб.";
            Count = $"Заказов: {Orders.Count}";
        }

        private ICommand selectedChanged;
        public ICommand SelectedDate
        {
            get
            {
                if (selectedChanged == null)
                    selectedChanged = new RelayCommand(args => UpdateDate(args));
                return selectedChanged;
            }
        }
        private void UpdateDate(object args)
        {
            Total.Clear();
            var date = (ObservableCollection<DateTime>)args;
            var total = _adminService.GetDailyMoney(date[0]);
            foreach(var i in total)
            {
                
                Total.Add(i);
            }
        }

        public ObservableCollection<DishModel> Popular { get; set; }

        private string count;
        public string Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                NotifyPropertyChanged("Count");
            }
        }
        
        private string sumView;
        public string SumView
        {
            get
            {
                return sumView;
            }
            set
            {
                sumView = value;
                NotifyPropertyChanged("SumView");
            }
        }

        private int sum;
        public int Sum
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value;
                NotifyPropertyChanged("Sum");
            }
        }

        public ObservableCollection<OrderModel> Orders { get; set; }

        private ObservableCollection<OrderModel> total;
        public ObservableCollection<OrderModel> Total 
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
                NotifyPropertyChanged("Total");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
