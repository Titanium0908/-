using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;

namespace BLL.Models
{
    public class IngredientStringModel
    {
        public int IngredientString_ID { get; set; }

        public int? IngredientString_Grammers { get; set; }

        public int Ingredient_FK { get; set; }

        public int Dish_FK { get; set; }
        public IngredientStringModel() { }
        public IngredientStringModel(IngredientString Is)
        {
            IngredientString_ID = Is.IngredientString_ID;
            IngredientString_Grammers = Is.IngredientString_Grammers;
            Ingredient_FK = Is.Ingredient_FK;
            Dish_FK = Is.Dish_FK;
        }

    }
}
