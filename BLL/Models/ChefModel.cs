using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;

namespace BLL.Models
{
    public class ChefModel
    {
        public int Chef_ID { get; set; }
        public string Chef_FullName { get; set; }
        public int Number { get; set; }
        public int? Chef_Experience { get; set; }
        public string Chef_Education { get; set; }
        public ChefModel() { }
        public ChefModel(Chef chef)
        {
            Chef_ID = chef.Chef_ID;
            Chef_FullName = chef.Chef_FullName;
            Chef_Experience = chef.Chef_Experience;
            Chef_Education = chef.Chef_Education;
        }
    }
}
