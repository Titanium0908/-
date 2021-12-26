using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BLL.Interfaces;
using BLL.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;


namespace WpfApp1.ViewModel
{
    public class HomeUserControlModel : INotifyPropertyChanged
    {
        private readonly IDbCrud _crud;
        private readonly IMenu _menu;
        
    }
}
