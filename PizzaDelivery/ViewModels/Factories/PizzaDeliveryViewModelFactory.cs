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
        private readonly CreateViewModel<ProfilePresentationManagerVM> _createProfileManagerViewModel;
        private readonly CreateViewModel<ProfilePresentationCourierVM> _createProfileCourierViewModel;
        private readonly CreateViewModel<AuthorizationVM> _createAuthViewModel;
        private readonly CreateViewModel<RegistrationVM> _createRegViewModel;
        private readonly CreateViewModel<BasketViewModel> _createBasketViewModel;
        private readonly CreateViewModel<OrderHistoryViewModel> _createOrderHistoryViewModel;
        private readonly CreateViewModel<OrdersManagerVM> _createOrdersManagerVM;
        private readonly CreateViewModel<OrdersCourierVM> _createOrdersCourierVM;
        private readonly CreateViewModel<PizzaSelectionVM> _createShopViewModel;

        public PizzaDeliveryViewModelFactory(CreateViewModel<ProfilePresentationVM> createProfileViewModel,
            CreateViewModel<ProfilePresentationManagerVM> createProfileManagerViewModel,
            CreateViewModel<ProfilePresentationCourierVM> createProfileCourierViewModel,
            CreateViewModel<AuthorizationVM> createAuthViewModel, 
            CreateViewModel<RegistrationVM> createRegViewModel, 
            CreateViewModel<BasketViewModel> createBasketViewModel, 
            CreateViewModel<OrderHistoryViewModel> createOrderHistoryViewModel,
            CreateViewModel<OrdersManagerVM> createOrdersManagerVM, 
            CreateViewModel<OrdersCourierVM> createOrdersCourierVM,
            CreateViewModel<PizzaSelectionVM> createShopViewModel)
        {
            _createProfileViewModel = createProfileViewModel;
            _createProfileManagerViewModel = createProfileManagerViewModel;
            _createProfileCourierViewModel = createProfileCourierViewModel;
            _createAuthViewModel = createAuthViewModel;
            _createRegViewModel = createRegViewModel;
            _createBasketViewModel = createBasketViewModel;
            _createOrderHistoryViewModel = createOrderHistoryViewModel;
            _createOrdersManagerVM = createOrdersManagerVM;
            _createOrdersCourierVM = createOrdersCourierVM;
            _createShopViewModel = createShopViewModel;
        }

        public ViewModelBase CreateViewModel(State.Navigators.ViewType viewType)
        {
            switch (viewType)
            {
                case State.Navigators.ViewType.Basket:
                    return _createBasketViewModel();
                case State.Navigators.ViewType.OrderHistory:
                    return _createOrderHistoryViewModel();
                case State.Navigators.ViewType.Profile:
                    return _createProfileViewModel();
                case State.Navigators.ViewType.ProfileManager:
                    return _createProfileManagerViewModel();
                case State.Navigators.ViewType.ProfileCourier:
                    return _createProfileCourierViewModel();
                case State.Navigators.ViewType.Registration:
                    return _createRegViewModel();
                case State.Navigators.ViewType.Shop:
                    return _createShopViewModel();
                case State.Navigators.ViewType.Login:
                    return _createAuthViewModel();
                case State.Navigators.ViewType.OrdersManager:
                    return _createOrdersManagerVM();
                case State.Navigators.ViewType.OrdersCourier:
                    return _createOrdersCourierVM();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
