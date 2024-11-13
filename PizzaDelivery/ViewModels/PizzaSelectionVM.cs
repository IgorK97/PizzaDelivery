using BLL.Models;
using DTO;
using Interfaces.Services;
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
        public void OnExitEvent()
        {
            IsPizzaSelected = false;

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

        

        private ICommand selectPizzaCommand;
        public ICommand SelectPizzaCommand
        {
            get
            {
                return selectPizzaCommand ??= new Commands.DelegateCommand(obj =>
                {
                    IsPizzaSelected = true;
                    OrderLineModel orderLineModel = new OrderLineModel(_priceBook, _ols, new PizzaModel(SelectedPizza.SelectedPizza));
                    AddingPizza = new AddingPizzaViewModel(_assortmentmodel, orderLineModel);
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
        private readonly IPriceBook _priceBook;
        private readonly IOrderLineService _ols;
        public PizzaSelectionVM(AssortmentModel assortmentModel, IPriceBook priceBook, IOrderLineService ols)
        {
            _priceBook = priceBook;
            _ols = ols;
            AddingPizzaViewModel.OnExitDelegate += OnExitEvent;
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
