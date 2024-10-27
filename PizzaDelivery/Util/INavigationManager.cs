﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Util
{
    public interface INavigationManager
    {
        void Navigate(string navigationKey, object arg = null);
    }
}
