using PizzaDelivery.Util;
using PizzaDelivery.ViewModels;
using PizzaDelivery.Constants;
using System.Configuration;
using System.Data;
using System.Windows;
using PizzaDelivery.Views;
using BLL.Models;
using Interfaces.Services;
using Lab4POWinForms.Util;
using Ninject;

namespace PizzaDelivery
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private AccountModel _user;

        public App()
        {
            
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var kernel = new StandardKernel(new NinjectRegistrations(), new ReposModule("dbPizzaDelivery"));
            IOrderLineService ols = kernel.Get<IOrderLineService>();
            IOrderService os = kernel.Get<IOrderService>();
            IReportService report = kernel.Get<IReportService>();
            _user = new AccountModel(os);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_user)
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
