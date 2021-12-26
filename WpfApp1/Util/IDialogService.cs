using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;

namespace WpfApp1.Util
{
    public interface IDialogService
    {
        void OpenChef(IDbCrud dbCrud, IMenu menu, IOrder order, IDialogService dialogService);
        void OpenClient(IDbCrud dbCrud, IMenu menu, IOrder order, IDialogService dialogService);
        void OpenAdmin(IDbCrud dbCrud, IMenu menu, IOrder order, IDialogService dialogService, IAdmin admin);
        void OpenMainMenu(IDbCrud dbCrud, IMenu menu, IOrder order, IDialogService dialogService);
    }
}
