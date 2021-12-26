using System;
using DAL.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class OrderModel
    {
        public int Order_ID { get; set; }

        public int Order_Number { get; set; }

        public string Order_Number_View { get; set; }

        public DateTime Order_Date { get; set; }

        public int Status_FK { get; set; }

        public int Total { get; set; }

        public int Chef_FK { get; set; }

        public string Chef_Name { get; set; }

        public string Status { get; set; }

        public string Visible { get; set; }
        public OrderModel() { }
        public OrderModel(Order o)
        {
            Order_ID = o.Order_ID;
            Order_Number = o.Order_Number;
            Order_Date = o.Order_Date;
            Status_FK = o.Status_FK;
            Chef_FK = o.Chef_FK;
            Total = o.Total;
        }

    }
}
