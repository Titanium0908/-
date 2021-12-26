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
    public class DishBasketVM : INotifyPropertyChanged
    {
        private readonly IDbCrud _crud;
        private readonly IMenu _menu;
        private readonly IOrder _order;

        public DishBasketVM(IDbCrud dbCrud, IMenu menu, IOrder order)
        {
            _crud = dbCrud;
            _menu = menu;
            _order = order;

            totalsum = 0;
            Total = $"Сумма заказа: 0 руб.";
            MessageVisibility = "Hidden";

            DishBasket = new ObservableCollection<DishModel>();
            Messenger.Default.Register<GenericMessage<DishModel>>(this, AddToBasket);
        }

        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null)
                    cancel = new RelayCommand(args => Cance(args));
                return cancel;
            }
        }
        private void Cance(object args)
        {
            DishBasket.Clear();
            totalsum = 0;
            Total = $"Сумма заказа: 0 руб.";
        }

        private ICommand ok;
        public ICommand OK
        {
            get
            {
                if (ok == null)
                    ok = new RelayCommand(args => Okey(args));
                return ok;
            }
        }
        private void Okey(object args)
        {
            MessageVisibility = "Hidden";
        }

        private ICommand makeOrder;
        public ICommand MakeOrder
        {
            get
            {
                if (makeOrder == null)
                    makeOrder = new RelayCommand(args => MakeNewOrder(args));
                return makeOrder;
            }
        }
        private void MakeNewOrder(object args)
        {
            if (DishBasket.Count != 0)
            {
                MessageVisibility = "Visible";
                Message = $"Ваш заказ под номером {_order.MakeOrder(totalsum, DishBasket)} оформлен";
                DishBasket.Clear();
                totalsum = 0;
                Total = $"Сумма заказа: 0 руб.";
                Messenger.Default.Send(new GenericMessage<DishModel>(null));
            }
        }

        private string messageVisibility;
        public string MessageVisibility
        {
            get
            {
                return messageVisibility;
            }
            set
            {
                messageVisibility = value;
                NotifyPropertyChanged("MessageVisibility");
            }
        }

        private string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                NotifyPropertyChanged("Message");
            }
        }

        private ICommand plus;
        public ICommand Plus
        {
            get
            {
                if (plus == null)
                    plus = new RelayCommand(args => Adds(args));
                return plus;
            }
        }
        private void Adds(object args)
        {
            var dish = new ObservableCollection<DishModel>();
            foreach (var i in DishBasket)
            {
                i.CostForView = $"{i.Dish_Cost * i.Amount} руб.";
                dish.Add(i);
            }
            dish[(int)args].Amount += 1;
            dish[(int)args].CostForView = $"{dish[(int)args].Dish_Cost * dish[(int)args].Amount} руб.";
            totalsum += dish[(int)args].Dish_Cost; 
            Total = $"Сумма заказа: {totalsum} руб.";
            DishBasket.Clear();
            DishBasket = dish;
        }

        private ICommand minus;
        public ICommand Minus
        {
            get
            {
                if (minus == null)
                    minus = new RelayCommand(args => RemoveOne(args));
                return minus;
            }
        }
        private void RemoveOne(object args)
        {
            var dish = new ObservableCollection<DishModel>();
            foreach (var i in DishBasket)
            {
                i.CostForView = $"{i.Dish_Cost * i.Amount} руб.";
                dish.Add(i);
            }
            if (dish[(int)args].Amount != 1)
            {                
                dish[(int)args].Amount -= 1;
                dish[(int)args].CostForView = $"{dish[(int)args].Dish_Cost * dish[(int)args].Amount} руб.";
                totalsum -= dish[(int)args].Dish_Cost;
                Total = $"Сумма заказа: {totalsum} руб.";
            }
            DishBasket.Clear();
            DishBasket = dish;            
        }

        private ICommand bin;
        public ICommand Bin
        {
            get
            {
                if (bin == null)
                    bin = new RelayCommand(args => Delete(args));
                return bin;
            }
        }
        private void Delete(object args)
        {
            totalsum -= DishBasket[(int)args].Dish_Cost * DishBasket[(int)args].Amount;
            Total = $"Сумма заказа: {totalsum} руб.";
            DishBasket.RemoveAt((int)args);
        }

        private void AddToBasket(GenericMessage<DishModel> msg)
        {
            if (msg.Content != null)
            {
                foreach (var i in DishBasket)
                {
                    if (i.Dish_Name == msg.Content.Dish_Name)
                    {
                        return;
                    }
                }
                msg.Content.CostForView = $"{msg.Content.Dish_Cost * msg.Content.Amount} руб.";
                DishBasket.Add(msg.Content);
                totalsum += msg.Content.Dish_Cost;
                Total = $"Сумма заказа: {totalsum} руб.";
            }
        }

        private ObservableCollection<DishModel> dishesBasket;
        public ObservableCollection<DishModel> DishBasket
        {
            get
            {
                return dishesBasket;
            }
            set
            {
                dishesBasket = value;
                NotifyPropertyChanged("DishBasket");
            }
        }

        private int totalsum;
        private string total;
        public string Total
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
