using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Classes;

namespace BLL.Models
{
    public class StatusModel
    {
        public int Status_ID { get; set; }
        public string Status1 { get; set; }
        public StatusModel() { }
        public StatusModel(Status s)
        {
            Status_ID = s.Status_ID;
            Status1 = s.Status1;
        }

    }
}
