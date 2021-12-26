using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BLL;
using BLL.Interfaces;
using View.Util;
using Ninject;


namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule());

            IDbCrud crudServ = kernel.Get<IDbCrud>();
            IMenu menuServ = kernel.Get<IMenu>();
            IOrder ordServ = kernel.Get<IOrder>();
            IAdmin admServ = kernel.Get<IAdmin>();

            Entrance window = new Entrance(crudServ, menuServ, ordServ, admServ);
            window.Show();
        }
    }
}
