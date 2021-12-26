using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.ViewModel;
using BLL.Interfaces;
using WpfApp1.Util;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для ChefWindow.xaml
    /// </summary>
    public partial class ChefWindow : Window
    {
        public ChefWindow(IDbCrud dbCrud, IMenu menu, IOrder order, IDialogService dialogService)
        {
            InitializeComponent();

            this.DataContext = new ChefVM(dbCrud, menu, order);
        }
    }
}
