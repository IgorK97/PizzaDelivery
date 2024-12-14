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
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.ViewModels.Factories;
using BLL.Services;
using DTO;
using DAL.Repository;
using Interfaces.Repository;
using Microsoft.AspNet.Identity;
using Interfaces.Services.AuthenticationServices;
using PizzaDelivery.State.Navigators;
using PizzaDelivery.AppCore.Tests.Services.AuthenticationServices;
using PizzaDelivery.Interfaces.Services;
using BLL.Models.Accounts;
using Interfaces.Services.Authenticators;
using BLL.Models.Authenticators;

namespace PizzaDelivery
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        

        public App()
        {
           
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            
            RegServices regServices = new RegServices();
            IServiceProvider serviceProvider = regServices.CreateServiceProvider();
            //IPizzaDeliveryViewModelFactory pizzaDeliveryViewModelFactory = 
            //    serviceProvider.GetRequiredService<IPizzaDeliveryViewModelFactory>();
            
            //IAuthenticationService authentication = serviceProvider.GetRequiredService<IAuthenticationService>();
            
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

            
        }

        //private IServiceProvider CreateServiceProvider()
        //{
        //    IServiceCollection services = new ServiceCollection();
        //    services.AddSingleton<IDbRepos, DbReposPgs>(s =>
        //    new DbReposPgs(ConfigurationManager.ConnectionStrings["dbPizzaDelivery"].ConnectionString));
        //    services.AddSingleton<IOrderLineService, OrderLinesService>();
        //    services.AddSingleton<IOrderService, OrderService>();
        //    services.AddSingleton<IOrderManagementService, OrderManagementService>();
        //    services.AddSingleton<IReportService, ReportService>();
        //    services.AddSingleton<IPasswordHasher, PasswordHasher>();
        //    services.AddSingleton<IAuthenticationService, AuthenticationService>();
        //    services.AddSingleton<IAccountService, AccountService>();
        //    services.AddSingleton<IAccountStore, AccountStore>();

        //    services.AddSingleton<IAuthenticator, Authenticator>();
        //    services.AddSingleton<IPriceBook, PriceBook>();
        //    services.AddSingleton<IPizzaDeliveryViewModelFactory, PizzaDeliveryViewModelFactory>();
        //    services.AddSingleton<OrderBook>(s =>
        //    new OrderBook(s.GetRequiredService<IAuthenticator>(), s.GetRequiredService<IPriceBook>(),
        //    s.GetRequiredService<IOrderService>()));
        //    services.AddSingleton<ManagementModel>(s =>
        //    new ManagementModel(s.GetRequiredService<IAuthenticator>(),
        //    s.GetRequiredService<IPriceBook>(),
        //    s.GetRequiredService<IOrderManagementService>()));
        //    services.AddSingleton<DeliverySystemModel>(s =>
        //    new DeliverySystemModel(s.GetRequiredService<IAuthenticator>(),
        //    s.GetRequiredService<IPriceBook>(),
        //    s.GetRequiredService<IOrderManagementService>()));
        //    services.AddSingleton<CreateViewModel<ProfilePresentationVM>>(services =>
        //    {
        //        return () => new ProfilePresentationVM(services.GetRequiredService<IAuthenticator>());
        //    });
        //    services.AddSingleton<CreateViewModel<ProfilePresentationManagerVM>>(services =>
        //    {
        //        return () => new ProfilePresentationManagerVM(services.GetRequiredService<IAuthenticator>());
        //    });
        //    services.AddSingleton<CreateViewModel<ProfilePresentationCourierVM>>(services =>
        //    {
        //        return () => new ProfilePresentationCourierVM(services.GetRequiredService<IAuthenticator>());
        //    });
        //    services.AddSingleton<CreateViewModel<AuthorizationVM>>(services =>
        //    {
        //        return () => new AuthorizationVM(services.GetRequiredService<IAuthenticator>());
        //    });
        //    services.AddSingleton<CreateViewModel<RegistrationVM>>(services =>
        //    {
        //        return () => new RegistrationVM(services.GetRequiredService<IAuthenticator>());
        //    });
        //    services.AddSingleton<CreateViewModel<ReportsManagerVM>>(services =>
        //    {
        //        return () => new ReportsManagerVM(services.GetRequiredService<IReportService>());
        //    });
        //    services.AddSingleton<AssortmentModel>();

        //    services.AddSingleton<CreateViewModel<BasketViewModel>>(services =>
        //    {
        //        return () => new BasketViewModel(services.GetRequiredService<AssortmentModel>(),
        //            services.GetRequiredService<IAuthenticator>(), services.GetRequiredService<IPriceBook>(),
        //            services.GetRequiredService<OrderBook>());
        //    }); 
        //    services.AddSingleton<CreateViewModel<OrderHistoryViewModel>>(services =>
        //    {
        //        return () => new OrderHistoryViewModel(services.GetRequiredService<OrderBook>());
        //    });
        //    services.AddSingleton<CreateViewModel<OrdersManagerVM>>(services =>
        //    {
        //        return () => new OrdersManagerVM(services.GetRequiredService<ManagementModel>(),
        //            services.GetRequiredService<IAuthenticator>(),
        //            services.GetRequiredService<IPriceBook>());
        //    });
        //    services.AddSingleton<CreateViewModel<OrdersCourierVM>>(services =>
        //    {
        //        return () => new OrdersCourierVM(services.GetRequiredService<DeliverySystemModel>(),
        //            services.GetRequiredService<IAuthenticator>(),
        //            services.GetRequiredService<IPriceBook>());
        //    });
        //    services.AddSingleton<CreateViewModel<PizzaSelectionVM>>(services =>
        //    {
        //        return () => new PizzaSelectionVM(services.GetRequiredService<AssortmentModel>(),
        //            services.GetRequiredService<IPriceBook>(),
        //            services.GetRequiredService<OrderBook>(),
        //            services.GetRequiredService<IOrderLineService>());
        //    });
        //    services.AddSingleton<INavigator, Navigator>();
        //    services.AddSingleton<MainViewModel>();
        //    services.AddSingleton<MainWindow>(s =>
        //    new MainWindow(s.GetRequiredService<MainViewModel>()));
        //    return services.BuildServiceProvider();
        //}
    }

}
