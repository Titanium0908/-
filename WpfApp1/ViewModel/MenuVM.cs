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
    public class MenuVM : INotifyPropertyChanged
    {
        private readonly IDbCrud _crud;
        private readonly IMenu _menu;

        public MenuVM(IDbCrud dbCrud, IMenu menu)
        {
            _crud = dbCrud;
            _menu = menu;

            DishVisibility = "Hidden";

            Soupes = new ObservableCollection<DishModel>();
            var soup = _menu.GetDishinMenu(1);
            foreach (var i in soup)
            {
                i.CostForView = $"{i.Dish_Cost} руб.";
                Soupes.Add(i);
            }
            Hots = new ObservableCollection<DishModel>();
            var hots = _menu.GetDishinMenu(2);
            foreach (var i in hots)
            {
                i.CostForView = $"{i.Dish_Cost} руб.";
                Hots.Add(i);
            }
            Snacks = new ObservableCollection<DishModel>();
            var shack = _menu.GetDishinMenu(4);
            foreach (var i in shack)
            {
                i.CostForView = $"{i.Dish_Cost} руб.";
                Snacks.Add(i);
            }
            Drinks = new ObservableCollection<DishModel>();
            var drink = _menu.GetDishinMenu(5);
            foreach (var i in drink)
            {
                i.CostForView = $"{i.Dish_Cost} руб.";
                Drinks.Add(i);
            }
        }

        public ObservableCollection<DishModel> Soupes { get; set; }
        public ObservableCollection<DishModel> Hots { get; set; }
        public ObservableCollection<DishModel> Snacks { get; set; }
        public ObservableCollection<DishModel> Drinks { get; set; }

        private DishModel dish;
        public DishModel Dish 
        {
            get 
            {
                return dish;
            }
            set
            {
                dish = value;
                NotifyPropertyChanged("Dish");
            }
        }

        private string dishVisibility;
        public string DishVisibility 
        {
            get 
            {
                return dishVisibility;
            }
            set 
            {
                dishVisibility = value;
                NotifyPropertyChanged("DishVisibility");
            }
        }

        private ICommand showDescriptionForSoup;
        public ICommand ShowDescriptionForSoup
        {
            get
            {
                if (showDescriptionForSoup == null)
                    showDescriptionForSoup = new RelayCommand(args => ShowSoupDescr(args));
                return showDescriptionForSoup;
            }
        }
        private void ShowSoupDescr(object args)
        {
            Dish = Soupes[(int)args];
            DishVisibility = "Visible";
        }
       
        private ICommand addSoupTocartCommand;
        public ICommand AddSoupTocartCommand
        {
            get
            {
                if (addSoupTocartCommand == null)
                    addSoupTocartCommand = new RelayCommand(args => AddSoup(args));
                return addSoupTocartCommand;
            }
        }
        private void AddSoup(object args)
        {
            Dish = Soupes[(int)args];
            Dish.Amount = 1;
            Messenger.Default.Send(new GenericMessage<DishModel>(Dish));
        }

        private ICommand showDescriptionForHots;
        public ICommand ShowDescriptionForHots
        {
            get
            {
                if (showDescriptionForHots == null)
                    showDescriptionForHots = new RelayCommand(args => ShowHotsDescr(args));
                return showDescriptionForHots;
            }
        }
        private void ShowHotsDescr(object args)
        {
            Dish = Hots[(int)args];
            DishVisibility = "Visible";
        }

        private ICommand addHotsTocartCommand;
        public ICommand AddHotsTocartCommand
        {
            get
            {
                if (addHotsTocartCommand == null)
                    addHotsTocartCommand = new RelayCommand(args => AddHots(args));
                return addHotsTocartCommand;
            }
        }
        private void AddHots(object args)
        {
            Dish = Hots[(int)args];
            Dish.Amount = 1;
            Messenger.Default.Send(new GenericMessage<DishModel>(Dish));
        }

        private ICommand showDescriptionForSnacks;
        public ICommand ShowDescriptionForSnacks
        {
            get
            {
                if (showDescriptionForSnacks == null)
                    showDescriptionForSnacks = new RelayCommand(args => ShowSnacksDescr(args));
                return showDescriptionForSnacks;
            }
        }
        private void ShowSnacksDescr(object args)
        {
            Dish = Snacks[(int)args];
            DishVisibility = "Visible";
        }

        private ICommand addSnacksTocartCommand;
        public ICommand AddSnacksTocartCommand
        {
            get
            {
                if (addSnacksTocartCommand == null)
                    addSnacksTocartCommand = new RelayCommand(args => AddSnacks(args));
                return addSnacksTocartCommand;
            }
        }
        private void AddSnacks(object args)
        {
            Dish = Snacks[(int)args];
            Dish.Amount = 1;
            Messenger.Default.Send(new GenericMessage<DishModel>(Dish));
        }

        private ICommand showDescriptionForDrinks;
        public ICommand ShowDescriptionForDrinks
        {
            get
            {
                if (showDescriptionForDrinks == null)
                    showDescriptionForDrinks = new RelayCommand(args => ShowDrinksDescr(args));
                return showDescriptionForDrinks;
            }
        }
        private void ShowDrinksDescr(object args)
        {
            Dish = Drinks[(int)args];
            DishVisibility = "Visible";
        }

        private ICommand addDrinksTocartCommand;
        public ICommand AddDrinksTocartCommand
        {
            get
            {
                if (addDrinksTocartCommand == null)
                    addDrinksTocartCommand = new RelayCommand(args => AddDrinks(args));
                return addDrinksTocartCommand;
            }
        }
        private void AddDrinks(object args)
        {
            Dish = Drinks[(int)args];
            Dish.Amount = 1;
            Messenger.Default.Send(new GenericMessage<DishModel>(Dish));
        }

        private ICommand back;
        public ICommand Back
        {
            get
            {
                if (back == null)
                    back = new RelayCommand(args => GoBack(args));
                return back;
            }
        }
        private void GoBack(object args)
        {
            DishVisibility = "Hidden";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
