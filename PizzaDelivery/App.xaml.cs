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
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.ViewModels.Factories;
using BLL.Services;
using DTO;
using DAL.Repository;
using Interfaces.Repository;
using Microsoft.AspNet.Identity;
using Interfaces.Services.AuthenticationServices;
using PizzaDelivery.State.Navigators;
using PizzaDelivery.State.Authenticators;
using PizzaDelivery.State.Accounts;
using PizzaDelivery.AppCore.Tests.Services.AuthenticationServices;

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
            //var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("dbPizzaDelivery"));
            //IOrderLineService ols = kernel.Get<IOrderLineService>();
            //IOrderService os = kernel.Get<IOrderService>();
            //IReportService report = kernel.Get<IReportService>();
            //INavigator nav = kernel.Get<INavigator>();
            //_user = new AccountModel(os);
            IServiceProvider serviceProvider = CreateServiceProvider();
            IPizzaDeliveryViewModelFactory pizzaDeliveryViewModelFactory = 
                serviceProvider.GetRequiredService<IPizzaDeliveryViewModelFactory>();
            //_navigationStore.CurrentViewModel = new AuthorizationVM(/*_navigationStore, _user*/);
            
            IAuthenticationService authentication = serviceProvider.GetRequiredService<IAuthenticationService>();
            //ClientDTO _user = new ClientDTO
            //{
            //    FirstName = "TestUserFirstName",
            //    LastName = "TestUserLastName",
            //    Surname = "TestUserSurname",
            //    Password = "mypassword",
            //    Login = "TestUserLogin",
            //    Phone = "90000000",
            //    Email = "TestEmail@mail.ru",
            //    AddressDel = "TestUserAddress"
            //};
            ////authentication.Register(_user, "mypassword");
            //UserDTO user = authentication.Login(_user.Login, "mypassword");
            MainWindow window = serviceProvider.GetRequiredService<MainWindow>();
            //MainWindow = new MainWindow()
            //{
            //    DataContext = new MainViewModel(nav, pizzaDeliveryViewModelFactory)
            //};
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
            services.AddSingleton<IDbRepos, DbReposPgs>();
            services.AddSingleton<IOrderLineService, OrderLinesService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<IAccountStore, AccountStore>();

            services.AddSingleton<IAuthenticator, Authenticator>();

            services.AddSingleton<IPizzaDeliveryViewModelFactory, PizzaDeliveryViewModelFactory>();
            services.AddSingleton<CreateViewModel<ProfilePresentationVM>>(services =>
            {
                return () => new ProfilePresentationVM(services.GetRequiredService<IAuthenticator>());
            });
            services.AddSingleton<CreateViewModel<AuthorizationVM>>(services =>
            {
                return () => new AuthorizationVM(services.GetRequiredService<IAuthenticator>());
            });
            services.AddSingleton<CreateViewModel<RegistrationVM>>(services =>
            {
                return () => new RegistrationVM(services.GetRequiredService<IAuthenticator>());
            }); 
            services.AddSingleton<CreateViewModel<BasketViewModel>>(services =>
            {
                return () => new BasketViewModel();
            }); 
            services.AddSingleton<CreateViewModel<OrderHistoryViewModel>>(services =>
            {
                return () => new OrderHistoryViewModel();
            });
            services.AddSingleton<AssortmentModel>();
            services.AddSingleton<CreateViewModel<PizzaSelectionVM>>(services =>
            {
                return () => new PizzaSelectionVM(services.GetRequiredService<AssortmentModel>());
            });
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>(s =>
            new MainWindow(s.GetRequiredService<MainViewModel>()));
            return services.BuildServiceProvider();
        }
    }

}
