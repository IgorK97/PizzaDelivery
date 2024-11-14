using BLL.Models;
using DTO;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace PizzaDelivery.ViewModels
{
    public delegate void ExitDelegate();

    public class AddingPizzaViewModel : ViewModelBase
    {
        public static event ExitDelegate OnExitDelegate;
        private readonly AssortmentModel _assortmentModel;

        private OrderLineModel _orderLineModel;
        private OrderBook _orderBook;
        private readonly OrderModel _order;

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
        private int CountSelections;
        public bool Custom
        {
            get
            {
                return _orderLineModel.Custom;
            }
            set
            {
                _orderLineModel.Custom = value;

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

        private int _count;
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                _orderLineModel.Quantity = _count;
                decimal price, weight;
                (price, weight) = _orderLineModel.CalculateLine();
                FinalWeight = weight.ToString();
                Price = price.ToString();
                OnPropertyChanged(nameof(Count));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(FinalWeight));
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
                return selectIngredientCommand ??= new Commands.DelegateCommand(obj =>
                {
                    foreach(IngredientViewModel ingr in _ingredientcollection)
                    {
                        if ((int)obj == ingr.Id)
                        {
                            ingr.IsIngredientSelected = !ingr.IsIngredientSelected;
                            IngredientModel curIngr = new IngredientModel(ingr.CurrentIngredient);

                            if (ingr.IsIngredientSelected)
                            {
                                (decimal price, decimal weight) = _orderLineModel.AddIngredient(curIngr);
                                Price = price.ToString();
                                FinalWeight = weight.ToString();
                            }
                            else
                            {
                                (decimal price, decimal weight) = _orderLineModel.DeleteIngredient(curIngr);
                                Price = price.ToString();
                                FinalWeight = weight.ToString();
                            }
                        }
                    }
                    //((IngredientViewModel)obj).IsIngredientSelected = !((IngredientViewModel)obj).IsIngredientSelected;
                });
            }
        }
        private ICommand buyPizzaCommand;

        public ICommand BuyPizzaCommand
        {
            get
            {
                return buyPizzaCommand ??= new Commands.DelegateCommand(obj =>
                {
                    _order.AddOrderLine(_orderLineModel);
                    OnExitDelegate?.Invoke();
                });
            }
        }
        private ICommand exitCommand;
        public ICommand ExitCommand
        {
            get
            {
                return exitCommand ??= new Commands.DelegateCommand(obj =>
                {
                    OnExitDelegate?.Invoke();
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
                    decimal price, weight;
                    (price, weight) = _orderLineModel.ChangeSize((int)PizzaSize);
                    Price = price.ToString();
                    FinalWeight = weight.ToString();
                    //OnPropertyChanged(nameof(IngredientCollection));
                });
            }
        }
        private ObservableCollection<IngredientViewModel> _ingredientcollection;
        public IEnumerable<IngredientViewModel> IngredientCollection {
            get
            {
                //return _ingredientcollection;
                if(_ingredientcollection != null)
                    return _ingredientcollection;
                else
                {
                    Load();
                    return _ingredientcollection;
                }
            }
        }

        public string Name => _orderLineModel.Pizza.C_name;

        public string Description => _orderLineModel.Pizza.description;

        public byte[]? Image => _orderLineModel.Pizza.pizzaimage;
        public AddingPizzaViewModel(AssortmentModel assortmentModel, OrderLineModel orderLineModel, OrderBook orderBook)
        {
            _orderLineModel = orderLineModel;
            CountSelections = _orderLineModel.addedingredients.Count;
            //Custom = _orderLineModel.Custom;
            _orderBook = orderBook;
            _order = _orderBook.GetBasketContent();
            Price = _orderLineModel.Position_price.ToString();
            FinalWeight = _orderLineModel.Weight.ToString();
            _assortmentModel = assortmentModel;
            _ingredientcollection = null;
            _orderBook = orderBook;
            Count = 1;
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
