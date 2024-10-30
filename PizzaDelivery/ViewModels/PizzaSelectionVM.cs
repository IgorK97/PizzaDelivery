using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.ViewModels
{
    public class PizzaSelectionVM : ViewModelBase
    {

        private readonly ObservableCollection<PizzaViewModel> _pizzacollection;

        public IEnumerable<PizzaViewModel> PizzaCollection => _pizzacollection;

        public PizzaSelectionVM()
        {
            _pizzacollection= new ObservableCollection<PizzaViewModel>();

            _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            {
                active = true,
                C_name = "name",
                description = "description",
                Id = 1
                
            }));
            _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            {
                active = true,
                C_name = "name1",
                description = "description",
                Id = 1

            })); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            {
                active = true,
                C_name = "name2",
                description = "description",
                Id = 1

            })); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            {
                active = true,
                C_name = "name3",
                description = "description",
                Id = 1

            })); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            {
                active = true,
                C_name = "name4",
                description = "description",
                Id = 1

            })); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            {
                active = true,
                C_name = "name4",
                description = "description",
                Id = 1

            })); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            {
                active = true,
                C_name = "name4",
                description = "description",
                Id = 1

            })); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            {
                active = true,
                C_name = "name4",
                description = "description",
                Id = 1

            })); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            {
                active = true,
                C_name = "name4",
                description = "description",
                Id = 1

            })); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            {
                active = true,
                C_name = "name4",
                description = "description",
                Id = 1

            })); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            {
                active = true,
                C_name = "name4",
                description = "description",
                Id = 1

            })); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            {
                active = true,
                C_name = "name4",
                description = "description",
                Id = 1

            })); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            {
                active = true,
                C_name = "name4",
                description = "description",
                Id = 1

            })); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            {
                active = true,
                C_name = "name4",
                description = "description",
                Id = 1

            }));
        }

        
    }
}
