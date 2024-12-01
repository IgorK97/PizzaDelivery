using DTO;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.ViewModels
{
    public class IngredientViewModel : ViewModelBase
    {
        public int Id => _dto.Id;
        private PizzaSizes _size;
        public PizzaSizes PizzaSize
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged(nameof(Cost));
            }
        }
        
        private bool _isIngredientSelected;
        public bool IsIngredientSelected
        {
            get
            {
                return _isIngredientSelected;
            }
            set
            {
                _isIngredientSelected = value;
                OnPropertyChanged(nameof(IsIngredientSelected));
            }
        }
        private bool _isActive;
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }
        public IngredientViewModel(IngredientDto ingr)
        {
            _dto = ingr;
            _size = PizzaSizes.Small;
            _isActive = ingr.active;
        }
        private readonly IngredientDto _dto;
        public IngredientDto CurrentIngredient
        {
            get
            {
                return _dto;
            }
        }
        public string Name => _dto.C_name;


        public byte[]? Image => _dto.ingrimage;

        
        public string Cost
        {
            get
            {
                if (_size == PizzaSizes.Small)
                    return (_dto.small * _dto.price_per_gram).ToString();
                else if (_size == PizzaSizes.Medium)
                    return (_dto.medium * _dto.price_per_gram).ToString();
                return (_dto.big * _dto.price_per_gram).ToString();
            }
        }
    }
}
