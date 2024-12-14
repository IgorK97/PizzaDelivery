using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models.Accounts;
using BLL.Models.Authenticators;
using BLL.Models;
using BLL.Services;
using DAL.Repository;
using Interfaces.Repository;
using Interfaces.Services.AuthenticationServices;
using Interfaces.Services.Authenticators;
using Interfaces.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.Interfaces.Services;
using PizzaDelivery.State.Navigators;
using PizzaDelivery.ViewModels.Factories;
using PizzaDelivery.ViewModels;
using System.Configuration;

namespace PizzaDelivery.Util
{
    public class RegServices
    {
        public IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDbRepos, DbReposPgs>(s =>
            new DbReposPgs(ConfigurationManager.ConnectionStrings["dbPizzaDelivery"].ConnectionString));
            services.AddSingleton<IOrderLineService, OrderLinesService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IOrderManagementService, OrderManagementService>();
            services.AddSingleton<IReportService, ReportService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<IAccountStore, AccountStore>();

            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IPriceBook, PriceBook>();
            services.AddSingleton<IPizzaDeliveryViewModelFactory, PizzaDeliveryViewModelFactory>();
            services.AddSingleton<OrderBook>(s =>
            new OrderBook(s.GetRequiredService<IAuthenticator>(), s.GetRequiredService<IPriceBook>(),
            s.GetRequiredService<IOrderService>()));
            services.AddSingleton<ManagementModel>(s =>
            new ManagementModel(s.GetRequiredService<IAuthenticator>(),
            s.GetRequiredService<IPriceBook>(),
            s.GetRequiredService<IOrderManagementService>()));
            services.AddSingleton<DeliverySystemModel>(s =>
            new DeliverySystemModel(s.GetRequiredService<IAuthenticator>(),
            s.GetRequiredService<IPriceBook>(),
            s.GetRequiredService<IOrderManagementService>()));
            services.AddSingleton<CreateViewModel<ProfilePresentationVM>>(services =>
            {
                return () => new ProfilePresentationVM(services.GetRequiredService<IAuthenticator>());
            });
            services.AddSingleton<CreateViewModel<ProfilePresentationManagerVM>>(services =>
            {
                return () => new ProfilePresentationManagerVM(services.GetRequiredService<IAuthenticator>());
            });
            services.AddSingleton<CreateViewModel<ProfilePresentationCourierVM>>(services =>
            {
                return () => new ProfilePresentationCourierVM(services.GetRequiredService<IAuthenticator>());
            });
            services.AddSingleton<CreateViewModel<AuthorizationVM>>(services =>
            {
                return () => new AuthorizationVM(services.GetRequiredService<IAuthenticator>());
            });
            services.AddSingleton<CreateViewModel<RegistrationVM>>(services =>
            {
                return () => new RegistrationVM(services.GetRequiredService<IAuthenticator>());
            });
            services.AddSingleton<CreateViewModel<ReportsManagerVM>>(services =>
            {
                return () => new ReportsManagerVM(services.GetRequiredService<IReportService>());
            });
            services.AddSingleton<AssortmentModel>();

            services.AddSingleton<CreateViewModel<BasketViewModel>>(services =>
            {
                return () => new BasketViewModel(services.GetRequiredService<AssortmentModel>(),
                    services.GetRequiredService<IAuthenticator>(), services.GetRequiredService<IPriceBook>(),
                    services.GetRequiredService<OrderBook>());
            });
            services.AddSingleton<CreateViewModel<OrderHistoryViewModel>>(services =>
            {
                return () => new OrderHistoryViewModel(services.GetRequiredService<OrderBook>());
            });
            services.AddSingleton<CreateViewModel<OrdersManagerVM>>(services =>
            {
                return () => new OrdersManagerVM(services.GetRequiredService<ManagementModel>(),
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<IPriceBook>());
            });
            services.AddSingleton<CreateViewModel<OrdersCourierVM>>(services =>
            {
                return () => new OrdersCourierVM(services.GetRequiredService<DeliverySystemModel>(),
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<IPriceBook>());
            });
            services.AddSingleton<CreateViewModel<PizzaSelectionVM>>(services =>
            {
                return () => new PizzaSelectionVM(services.GetRequiredService<AssortmentModel>(),
                    services.GetRequiredService<IPriceBook>(),
                    services.GetRequiredService<OrderBook>(),
                    services.GetRequiredService<IOrderLineService>());
            });
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>(s =>
            new MainWindow(s.GetRequiredService<MainViewModel>()));
            return services.BuildServiceProvider();
        }
    }
}
