﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IMenu
    {
        List<DishModel> GetDishinMenu(int category);
    }
}
