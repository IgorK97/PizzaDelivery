﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Util
{
    public interface INavigationAware
    {
        void OnNavigatingTo(object arg);
        void OnNavigatingFrom();
    }
}
