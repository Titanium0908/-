using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BLL.Models
{
    public class ChefOrderModel
    {
        public int Order_ID { get; set; }
        public int Dish_Order_ID { get; set; }
        public int Order_Number { get; set; }
        public DateTime Order_Date { get; set; }
        public int Status_FK { get; set; }
        public int Chef_FK { get; set; }
        public string Dish_Image { get; set; }
        public ObservableCollection<string> Ingredients { get; set; }
        public string Dish_Name { get; set; }
        public string DishStatus { get; set; }
        public string Status { get; set; }
        public int Number { get; set; }
        public bool CanGive { get; set; }
        public bool Ready { get; set; }
        public string Order_Number_View { get; set; }

    }
}
