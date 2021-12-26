using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;

namespace DAL.Interfaces
{
    public interface IServiceRepository
    {
        List<DishSelection> GetDishinMenu(int category);
        int ChooseChef();
        List<ChefOrder> GetOrdersForChef(int chef_id);
    }
}
