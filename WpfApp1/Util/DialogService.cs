using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.View;
using BLL.Interfaces;

namespace WpfApp1.Util
{
    public class DialogService : IDialogService
    {
        public void OpenChef(IDbCrud dbCrud, IMenu menu, IOrder order, IDialogService dialogService)
        {
            ChefWindow chefWindow = new ChefWindow(dbCrud, menu, order, dialogService);
            chefWindow.Show();
        }

        public void OpenClient(IDbCrud dbCrud, IMenu menu, IOrder order, IDialogService dialogService)
        {
            MainWindow mainWindow = new MainWindow(dbCrud, menu,  order, dialogService);
            mainWindow.Show();
        }

        public void OpenAdmin(IDbCrud dbCrud, IMenu menu, IOrder order, IDialogService dialogService, IAdmin admin)
        {
            AdminWindow adminWindow = new AdminWindow(dbCrud, menu, order, dialogService, admin);
            adminWindow.Show();
        }

        public void OpenMainMenu(IDbCrud dbCrud, IMenu menu, IOrder order, IDialogService dialogService)
        {

        }
    }
}
