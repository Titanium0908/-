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
    public class ChefVM
    {
        private readonly IDbCrud _crud;
        private readonly IMenu _menu;
        private readonly IOrder _order;
        public ChefVM(IDbCrud dbCrud, IMenu menu, IOrder order)
        {
            _crud = dbCrud;
            _menu = menu;
            _order = order;

            Chef = new ObservableCollection<ChefModel>();
            var chefs = _crud.GetAllChefs();
            foreach (var i in chefs)
            {
                Chef.Add(i);
            }

            Waiting = new ObservableCollection<OrderModel>();
            Cooking = new ObservableCollection<ChefOrderModel>();

            Update();
        }

        private ObservableCollection<OrderModel> waiting;
        public ObservableCollection<OrderModel> Waiting
        {
            get 
            {
                return waiting;
            }
            set
            {
                waiting = value;
                NotifyPropertyChanged("Waiting");
            }
        }

        private ObservableCollection<ChefOrderModel> cooking;
        public ObservableCollection<ChefOrderModel> Cooking
        {
            get
            {
                return cooking;
            }
            set
            {
                cooking = value;
                NotifyPropertyChanged("Cooking");
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

        private ICommand submit;
        public ICommand Submit
        {
            get
            {
                if (submit == null)
                    submit = new RelayCommand(args => Take(args));
                return submit;
            }
        }
        private void Take(object args)
        {
            _crud.TakeOrder(Waiting[(int)args].Order_ID);
            Update();
        }

        private ICommand give;
        public ICommand Give
        {
            get
            {
                if (give == null)
                    give = new RelayCommand(args => GiveDish(args));
                return give;
            }
        }
        private void GiveDish(object args)
        {
            _crud.GiveDish(Cooking[(int)args].Dish_Order_ID);
            bool flag = true;
            foreach (var i in _crud.GetAllOrderDishes())
            {
                if (Cooking[(int)args].Order_ID == i.Order_FK && i.Ready == false) flag = false;
            }
            if (flag)
            {
                _crud.GiveOrder(Cooking[(int)args].Order_ID);
            }
            Update();
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
            Update();
        }
        
        private void Update()
        {
            Waiting.Clear();
            Cooking.Clear();

            int chefId = Chef[selectedChef].Chef_ID;
            bool alreadyInOrder = false;
            var result = _order.GetOrdersForChef(chefId);

            foreach (var i in result)
            {
                string vis = "Hidden";
                if (i.Status_FK == 4)
                {
                    vis = "Visible"; 
                }

                foreach (var j in Waiting)
                {
                    if (i.Order_ID == j.Order_ID) alreadyInOrder = true;
                }
                if (!alreadyInOrder)
                {
                    Waiting.Add(new OrderModel
                    {
                        Order_ID = i.Order_ID,
                        Order_Date = i.Order_Date,
                        Order_Number_View = $"Заказ №{i.Order_Number}",
                        Status_FK = i.Status_FK,
                        Status = i.Status,
                        Visible = vis
                    });
                    alreadyInOrder = false;
                }
                if (i.Status_FK == 2)
                {
                    if (i.Ready == true)
                    {
                        i.DishStatus = "Готов";
                        i.CanGive = false;
                    }
                    i.Dish_Name = $"{i.Dish_Name} {i.Number}шт.";
                    i.Order_Number_View = $"Заказ №{i.Order_Number}";
                    Cooking.Add(i);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
