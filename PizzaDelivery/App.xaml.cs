using PizzaDelivery.Util;
using PizzaDelivery.ViewModels;
using PizzaDelivery.Constants;
using System.Configuration;
using System.Data;
using System.Windows;
using PizzaDelivery.Views;

namespace PizzaDelivery
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            
                var window = new MainWindow();
                var navigationManager = new NavigationManager(Dispatcher, window.FrameContent);

                var viewModel = new AuthorizationVM(navigationManager);
                window.DataContext = viewModel;

            navigationManager.Register<PizzaSelectionVM, PizzaSelectionView>
            (new PizzaSelectionVM(navigationManager), NavigationKeys.PizzaSelection);
            window.Show();
        }
    }

}
