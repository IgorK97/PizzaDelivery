using DTO;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.ViewModels
{
    public class PizzaViewModel : ViewModelBase
    {
        private readonly PizzaDto _dto;
        public string Name => _dto.C_name;

        public PizzaViewModel(PizzaDto dto)
        {
            _dto = dto;
        }
    }
}
