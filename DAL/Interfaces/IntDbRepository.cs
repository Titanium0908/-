using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;

namespace DAL.Interfaces
{
    public interface IntDbRepository
    {
        IntRepository<Category> Categorys { get; }
        IntRepository<Chef> Chefs { get; }
        IntRepository<Dish> Dishs { get; }
        IntRepository<DishOrder> DishOrders { get; }
        IntRepository<Ingredient> Ingredients { get; }
        IntRepository<IngredientString> IngredientStrings { get; }
        IntRepository<Order> Orders { get; }
        IntRepository<Status> Statuss { get; }
        IServiceRepository Services { get; }

        int Save();

    }
}
