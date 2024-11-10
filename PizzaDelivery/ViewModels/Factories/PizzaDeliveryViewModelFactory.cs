using PizzaDelivery.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.ViewModels.Factories
{
    public class PizzaDeliveryViewModelFactory :IPizzaDeliveryViewModelFactory
    {
        private readonly CreateViewModel<ProfilePresentationVM> _createProfileViewModel;
        private readonly CreateViewModel<AuthorizationVM> _createAuthViewModel;
        private readonly CreateViewModel<RegistrationVM> _createRegViewModel;
        private readonly CreateViewModel<BasketViewModel> _createBasketViewModel;
        private readonly CreateViewModel<OrderHistoryViewModel> _createOrderHistoryViewModel;
        private readonly CreateViewModel<PizzaSelectionVM> _createShopViewModel;

        public PizzaDeliveryViewModelFactory(CreateViewModel<ProfilePresentationVM> createProfileViewModel, 
            CreateViewModel<AuthorizationVM> createAuthViewModel, 
            CreateViewModel<RegistrationVM> createRegViewModel, 
            CreateViewModel<BasketViewModel> createBasketViewModel, 
            CreateViewModel<OrderHistoryViewModel> createOrderHistoryViewModel, 
            CreateViewModel<PizzaSelectionVM> createShopViewModel)
        {
            _createProfileViewModel = createProfileViewModel;
            _createAuthViewModel = createAuthViewModel;
            _createRegViewModel = createRegViewModel;
            _createBasketViewModel = createBasketViewModel;
            _createOrderHistoryViewModel = createOrderHistoryViewModel;
            _createShopViewModel = createShopViewModel;
        }

        public ViewModelBase CreateViewModel(Util.Navigators.ViewType viewType)
        {
            switch (viewType)
            {
                case Util.Navigators.ViewType.Basket:
                    return _createBasketViewModel();
                    case Util.Navigators.ViewType.OrderHistory:
                    return _createOrderHistoryViewModel();
                case Util.Navigators.ViewType.Profile:
                    return _createProfileViewModel();
                case Util.Navigators.ViewType.Registration:
                    return _createRegViewModel();
                case Util.Navigators.ViewType.Shop:
                    return _createShopViewModel();
                case Util.Navigators.ViewType.Login:
                    return _createAuthViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
