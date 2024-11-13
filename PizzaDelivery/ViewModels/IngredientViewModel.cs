using DTO;
using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.ViewModels
{
    public class IngredientViewModel : ViewModelBase
    {
        private PizzaSizes _size;
        public PizzaSizes PizzaSize
        {
            get { return _size; }
            set
            {
                _size = value;
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
        public IngredientViewModel(IngredientDto ingr)
        {
            _dto = ingr;
        }
        private readonly IngredientDto _dto;
        public IngredientDto SelectedIngredient
        {
            get
            {
                return _dto;
            }
        }
        public string Name => _dto.C_name;

        //public string Description => _dto.description;

        public byte[]? Image => _dto.ingrimage;

        public string Weight
        {
            get
            {
                if (_size == PizzaSizes.Small)
                    return _dto.small.ToString();
                else if (_size == PizzaSizes.Medium)
                    return _dto.medium.ToString();
                else return _dto.big.ToString();
            }
        }
        public string Cost
        {
            get
            {
                if (_size == PizzaSizes.Small)
                    return (_dto.small * _dto.price_per_gram).ToString();
                else if (_size == PizzaSizes.Medium)
                    return (_dto.medium * _dto.price_per_gram).ToString();
                else return (_dto.big * _dto.price_per_gram).ToString();
            }
        }
    }
}
