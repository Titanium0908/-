using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DAL.Classes
{
    public class DishSelection
    {
        public int Dish_ID { get; set; }
        public string Dish_Name { get; set; }
        public int Dish_Grammers { get; set; }
        public bool? Dish_Aveliability { get; set; }
        public int Dish_Cost { get; set; }
        public string Category_Name { get; set; }
        public string Dish_Image { get; set; }
        public ObservableCollection<string> Ingredients { get; set; }
    }

    public class ChefOrder
    {
        public int Order_ID { get; set; }
        public int Order_Dish_ID { get; set; }
        public int Order_Number { get; set; }
        public DateTime Order_Date { get; set; }
        public int Status_FK { get; set; }
        public bool Ready { get; set; }
        public int Chef_FK { get; set; }
        public string Dish_Image { get; set; }
        public ObservableCollection<string> Ingredients { get; set; }
        public string Dish_Name { get; set; }
        public string Status { get; set; }
        public int Dish_ID { get; set; }
        public int Number { get; set; }
    }

    public class ChefChoose
    {
        public int Amount { get; set; }
        public int Chef_ID { get; set; }    
    }
}
