using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;

namespace BLL.Models
{
    public class IngredientModel
    {
        public int Ingredient_ID { get; set; }

        public decimal Ingredient_Cost { get; set; }

        public string Ingredient_Name { get; set; }

        public bool? Ingredient_Aveliability { get; set; }

        public IngredientModel() { }
        public IngredientModel(Ingredient i)
        {
            Ingredient_ID = i.Ingredient_ID;
            Ingredient_Cost = i.Ingredient_Cost;
            Ingredient_Name = i.Ingredient_Name;
            Ingredient_Aveliability = i.Ingredient_Aveliability;
        }

    }
}
