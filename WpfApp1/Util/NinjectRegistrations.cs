using BLL.Interfaces;
using Ninject.Modules;
using BLL;
using BLL.Services;


namespace View.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbCrud>().To<DBDataOperations>();
            Bind<IMenu>().To<Menu>();
            Bind<IOrder>().To<Order>();
            Bind<IAdmin>().To<Admin>();
        }
    }
}
