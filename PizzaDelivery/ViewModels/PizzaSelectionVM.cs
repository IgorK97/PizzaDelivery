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

        private AddingPizzaViewModel addingPizza;
        public AddingPizzaViewModel AddingPizza
        {
            get
            {
                return addingPizza;
            }
            set
            {
                addingPizza = value;
                OnPropertyChanged(nameof(AddingPizza));

            }
        }

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

        //private ICommand updatePizzaSizeCommand;
        //public ICommand UpdatePizzaSizeCommand
        //{
        //    get
        //    {
        //        return updatePizzaSizeCommand;
        //    }
        //}

        //private ICommand exitCommand;
        //public ICommand ExitCommand
        //{
        //    get
        //    {
        //        return exitCommand ??= new Commands.DelegateCommand(obj =>
        //        {
        //            IsPizzaSelected = false;
        //            //Dispose addingPizza
        //        });
        //    }
        //}

        private ICommand selectPizzaCommand;
        public ICommand SelectPizzaCommand
        {
            get
            {
                return selectPizzaCommand ??= new Commands.DelegateCommand(obj =>
                {
                    IsPizzaSelected = true;
                    AddingPizza = new AddingPizzaViewModel(_assortmentmodel, selectedPizza.SelectedPizza);
                    //AddingPizza.Load();
                });
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
        }

        
    }
}
