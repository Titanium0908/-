using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;

namespace BLL.Models
{
    public class CategoryModel
    {
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public CategoryModel() { }
        public CategoryModel(Category ca)
        {
            Category_ID = ca.Category_ID;
            Category_Name = ca.Category_Name;

        }

    }
}
