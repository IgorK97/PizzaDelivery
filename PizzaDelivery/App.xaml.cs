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
            _user = new AccountModel(os);
            _navigationStore.CurrentViewModel = new AuthorizationVM(_navigationStore, _user);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
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
    }

}
