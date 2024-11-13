using BLL.Models;
using DTO;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.ViewModels
{
    public class AddingPizzaViewModel : ViewModelBase
    {
        private readonly AssortmentModel _assortmentModel;

        private OrderLineDto _orderLineDto;

        private IngredientViewModel _selectedIngredient;
        public IngredientViewModel SelectedIngredient
        {
            get
            {
                return _selectedIngredient;
            }
            set
            {
                _selectedIngredient = value;
                OnPropertyChanged(nameof(SelectedIngredient));
            }
        }
        
        private PizzaDto _pizza;
        public PizzaDto Pizza
        {
            get
            {
                return _pizza;
            }
            set
            {
                _pizza = value;
            }
        }

        private string _price;
        public string Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private string _finalweight;
        public string FinalWeight
        {
            get
            {
                return _finalweight;
            }
            set
            {
                _finalweight = value;
                OnPropertyChanged(nameof(FinalWeight));
            }
        }

        private PizzaSizes _size;
        public PizzaSizes PizzaSize
        {
            get { return _size; }
            set
            {
                _size = value;
            }
        }

        private ICommand selectIngredientCommand;
        public ICommand SelectIngredientCommand
        {
            get
            {
                return selectIngredientCommand;
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
        private ICommand exitCommand;
        public ICommand ExitCommand
        {
            get
            {
                return exitCommand ??= new Commands.DelegateCommand(obj =>
                {
                    //IsPizzaSelected = false;
                    //Dispose addingPizza
                });
            }
        }

        private ICommand updatePizzaSizeCommand;
        public ICommand UpdatePizzaSizeCommand
        {
            get
            {
                return updatePizzaSizeCommand ??= new Commands.DelegateCommand(obj =>
                {
                    PizzaSize = (PizzaSizes)obj;
                    foreach(IngredientViewModel ingr in _ingredientcollection)
                    {
                        ingr.PizzaSize = PizzaSize;
                    }
                    //OnPropertyChanged(nameof(IngredientCollection));
                });
            }
        }
        private ObservableCollection<IngredientViewModel> _ingredientcollection;
        public IEnumerable<IngredientViewModel> IngredientCollection {
            get
            {
                if(_ingredientcollection!=null)
                    return _ingredientcollection;
                else
                {
                    Load();
                    return _ingredientcollection;
                }
            }
        }

        public string Name => _pizza.C_name;

        public string Description => _pizza.description;

        public byte[]? Image => _pizza.pizzaimage;
        public AddingPizzaViewModel(AssortmentModel assortmentModel, PizzaDto pizza)
        {
            _pizza = pizza;
            _assortmentModel = assortmentModel;
            _ingredientcollection = null;
            
        }
        public void Load()
        {
            _ingredientcollection = new ObservableCollection<IngredientViewModel>();
            IEnumerable<IngredientDto> loadedIngredients = _assortmentModel.Ingredients;
            foreach (IngredientDto ingr in loadedIngredients)
            {
                IngredientViewModel ingrViewModel = new IngredientViewModel(ingr);
                _ingredientcollection.Add(ingrViewModel);
            }
        }
    }
}
