using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;

namespace BLL.Services
{
    public class Menu : IMenu
    {
        IntDbRepository dataBase;

        public Menu(IntDbRepository dbRepository)
        {
            dataBase = dbRepository;
        }
        public List<DishModel> GetDishinMenu(int category)
        {
            return dataBase.Services.GetDishinMenu(category).Select(i => new DishModel { Dish_Name = i.Dish_Name, Dish_Image = i.Dish_Image, Dish_ID = i.Dish_ID, Dish_Grammers = i.Dish_Grammers, Dish_Cost = i.Dish_Cost, Dish_Aveliability = i.Dish_Aveliability, Category_Name = i.Category_Name, Ingredients = i.Ingredients}).ToList();
        }
    }
}
