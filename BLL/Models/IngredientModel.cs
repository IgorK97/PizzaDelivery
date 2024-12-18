﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class IngredientModel
    {
        public int Id { get; set; }

        public string C_name { get; set; }

        public decimal price_per_gram { get; set; }

        public decimal small { get; set; }

        public decimal medium { get; set; }

        public decimal big { get; set; }

        public bool active { get; set; }
        public byte[]? ingrimage { get; set; }

        public bool IsSelected { get; set; }
        public IngredientModel(IngredientDto i)
        {
            Id = i.Id;
            C_name = i.C_name;
            price_per_gram = i.price_per_gram;
            small = i.small;
            medium = i.medium;
            big = i.big;
            active = i.active;
            ingrimage = i.ingrimage;
            IsSelected=i.IsSelected;
        }
        public bool UpdateSelf(IngredientDto i)
        {
            C_name = i.C_name;
            price_per_gram = i.price_per_gram;
            small = i.small;
            medium = i.medium;
            big = i.big;
            active = i.active;
            ingrimage = i.ingrimage;
            return active;
        }
        public decimal GetPrice(int i)
        {
            if (i == 1)
                return small * price_per_gram;
            if(i==2)
                return medium * price_per_gram;
            return big * price_per_gram;
        }
        public decimal GetWeight(int i)
        {
            if (i == 1)
                return small;
            if (i == 2)
                return medium;
            return big;
        }
    }
}
