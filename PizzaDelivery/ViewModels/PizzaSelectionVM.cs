using BLL.Models;
using DTO;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.ViewModels
{
    public class PizzaSelectionVM : ViewModelBase
    {

        private readonly ObservableCollection<PizzaViewModel> _pizzacollection;
        private AssortmentModel _assortmentmodel;
        public IEnumerable<PizzaViewModel> PizzaCollection => _pizzacollection;

        private PizzaViewModel selectedPizza;
        public PizzaViewModel SelectedPizza
        {
            get
            {
                return selectedPizza;
            }
            set
            {
                selectedPizza = value;
                OnPropertyChanged(nameof(SelectedPizza));
            }
        }

        private ICommand updatePizzaSizeCommand;
        public ICommand UpdatePizzaSizeCommand
        {
            get
            {
                return updatePizzaSizeCommand;
            }
        }

        private ICommand exitCommand;
        public ICommand ExitCommand
        {
            get
            {
                return exitCommand ??= new Commands.DelegateCommand(obj =>
                {
                    IsPizzaSelected = false;
                });
            }
        }

        private ICommand selectPizzaCommand;
        public ICommand SelectPizzaCommand
        {
            get
            {
                return selectPizzaCommand ??= new Commands.DelegateCommand(obj =>
                {
                        IsPizzaSelected = true;
                   
                });
            }
        }

        private ICommand buyPizzaCommand;

        public ICommand BuyPizzaCommand
        {
            get
            {
                return buyPizzaCommand;
            }
        }
        private bool isPizzaSelected;
        public bool IsPizzaSelected
        {
            get
            {
                return isPizzaSelected;
            }
            set
            {
                isPizzaSelected = value;
                OnPropertyChanged(nameof(IsPizzaSelected));
            }
        }
        public PizzaSelectionVM(AssortmentModel assortmentModel)
        {
            _assortmentmodel = assortmentModel;
            _pizzacollection= new ObservableCollection<PizzaViewModel>();
            IEnumerable<PizzaDto> loadedPizzas = _assortmentmodel.Pizzas;
            foreach(PizzaDto pizza in loadedPizzas)
            {
                PizzaViewModel pizzaViewModel = new PizzaViewModel(pizza);
                _pizzacollection.Add(pizzaViewModel);
            }


            //_pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            //{
            //    active = true,
            //    C_name = "name",
            //    description = "description",
            //    Id = 1
                
            //}));
            //_pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            //{
            //    active = true,
            //    C_name = "name1",
            //    description = "description",
            //    Id = 1

            //})); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            //{
            //    active = true,
            //    C_name = "name2",
            //    description = "description",
            //    Id = 1

            //})); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            //{
            //    active = true,
            //    C_name = "name3",
            //    description = "description",
            //    Id = 1

            //})); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            //{
            //    active = true,
            //    C_name = "name4",
            //    description = "description",
            //    Id = 1

            //})); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            //{
            //    active = true,
            //    C_name = "name4",
            //    description = "description",
            //    Id = 1

            //})); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            //{
            //    active = true,
            //    C_name = "name4",
            //    description = "description",
            //    Id = 1

            //})); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            //{
            //    active = true,
            //    C_name = "name4",
            //    description = "description",
            //    Id = 1

            //})); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            //{
            //    active = true,
            //    C_name = "name4",
            //    description = "description",
            //    Id = 1

            //})); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            //{
            //    active = true,
            //    C_name = "name4",
            //    description = "description",
            //    Id = 1

            //})); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            //{
            //    active = true,
            //    C_name = "name4",
            //    description = "description",
            //    Id = 1

            //})); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            //{
            //    active = true,
            //    C_name = "name4",
            //    description = "description",
            //    Id = 1

            //})); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            //{
            //    active = true,
            //    C_name = "name4",
            //    description = "description",
            //    Id = 1

            //})); _pizzacollection.Add(new PizzaViewModel(new DTO.PizzaDto
            //{
            //    active = true,
            //    C_name = "name4",
            //    description = "description",
            //    Id = 1

            //}));
        }

        
    }
}
