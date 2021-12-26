using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BLL.Interfaces;
using WpfApp1.Util;
using BLL;
using BLL.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace WpfApp1.ViewModel
{
    public class MainMenuVM : INotifyPropertyChanged
    {

        private readonly IDbCrud _crud;
        private readonly IMenu _menu;
        private readonly IOrder _order;
        private readonly IDialogService _dialogService;
        private readonly IAdmin _adminService;

        public MainMenuVM(IDbCrud dbCrud, IMenu menu, IOrder order, IDialogService dialogService, IAdmin admin)
        {
            _crud = dbCrud;
            _menu = menu;
            _order = order;
            _dialogService = dialogService;
            _adminService = admin;
        }

        private ICommand chef;
        public ICommand Chef
        {
            get
            {
                if (chef == null)
                    chef = new RelayCommand(args => OpenChef(args));
                return chef;
            }
        }
        private void OpenChef(object args)
        {
            _dialogService.OpenChef(_crud, _menu, _order, _dialogService);
        }
        private ICommand client;
        public ICommand Client
        {
            get
            {
                if (client == null)
                    client = new RelayCommand(args => OpenClient(args));
                return client;
            }
        }
        private void OpenClient(object args)
        {
            _dialogService.OpenClient(_crud, _menu, _order, _dialogService);
        }

        private ICommand admin;
        public ICommand Admin
        {
            get
            {
                if (admin == null)
                    admin = new RelayCommand(args => OpenAdmin(args));
                return admin;
            }
        }
        private void OpenAdmin(object args)
        {
            _dialogService.OpenAdmin(_crud, _menu, _order, _dialogService, _adminService);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
