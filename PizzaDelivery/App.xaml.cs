using PizzaDelivery.Util;
using PizzaDelivery.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;
using PizzaDelivery.Views;
using BLL.Models;
using Interfaces.Services;
using Lab4POWinForms.Util;
using Ninject;
using PizzaDelivery.Stores;
using PizzaDelivery.Util.Navigators;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.ViewModels.Factories;

namespace PizzaDelivery
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private AccountModel _user;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("dbPizzaDelivery"));
            IOrderLineService ols = kernel.Get<IOrderLineService>();
            IOrderService os = kernel.Get<IOrderService>();
            IReportService report = kernel.Get<IReportService>();
            INavigator nav = kernel.Get<INavigator>();
            _user = new AccountModel(os);
            IServiceProvider serviceProvider = CreateServiceProvider();
            IPizzaDeliveryViewModelFactory pizzaDeliveryViewModelFactory = 
                serviceProvider.GetRequiredService<IPizzaDeliveryViewModelFactory>();
            //_navigationStore.CurrentViewModel = new AuthorizationVM(/*_navigationStore, _user*/);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(nav, pizzaDeliveryViewModelFactory)
            };
            MainWindow.Show();
            base.OnStartup(e);
            
            //    var window = new MainWindow();
            //    var navigationManager = new NavigationManager(Dispatcher, window.FrameContent);

            //    var viewModel = new AuthorizationVM(navigationManager);
            //    window.DataContext = viewModel;

            //navigationManager.Register<PizzaSelectionVM, PizzaSelectionView>
            //(new PizzaSelectionVM(navigationManager), NavigationKeys.PizzaSelection);
            //window.Show();
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IPizzaDeliveryViewModelFactory, PizzaDeliveryViewModelFactory>();
            services.AddSingleton<CreateViewModel<ProfilePresentationVM>>(services =>
            {
                return () => new ProfilePresentationVM();
            });
            services.AddSingleton<CreateViewModel<AuthorizationVM>>(services =>
            {
                return () => new AuthorizationVM();
            });
            services.AddSingleton<CreateViewModel<RegistrationVM>>(services =>
            {
                return () => new RegistrationVM();
            }); services.AddSingleton<CreateViewModel<BasketViewModel>>(services =>
            {
                return () => new BasketViewModel();
            }); services.AddSingleton<CreateViewModel<OrderHistoryViewModel>>(services =>
            {
                return () => new OrderHistoryViewModel();
            }); services.AddSingleton<CreateViewModel<PizzaSelectionVM>>(services =>
            {
                return () => new PizzaSelectionVM();
            });
            return services.BuildServiceProvider();
        }
    }

}
