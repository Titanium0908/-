using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;
using System.Collections.ObjectModel;

namespace BLL.Models
{
    public class DishModel
    {
        public int Dish_ID { get; set; }
        public string Dish_Name { get; set; }
        public int Dish_Grammers { get; set; }
        public bool? Dish_Aveliability { get; set; }
        public int Amount { get; set; }
        public int Category_FK { get; set; }
        public int Dish_Cost { get; set; }
        public string Category_Name { get; set; }
        public string Dish_Image { get; set; }
        public string CostForView { get; set; }
        public int Number { get; set; }
        public ObservableCollection<string> Ingredients { get; set; }
        public DishModel() { }
        public DishModel(Dish d)
        {
            Dish_ID = d.Dish_ID;
            Dish_Name = d.Dish_Name;
            Dish_Grammers = d.Dish_Grammers;
            Dish_Aveliability = d.Dish_Aveliability;
            Category_FK = d.Category_FK;
            Dish_Cost = d.Dish_Cost;
            Dish_Image = d.Dish_Image;
        }
    }
}
