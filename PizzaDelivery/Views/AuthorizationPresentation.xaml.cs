using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaDelivery.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPresentation.xaml
    /// </summary>
    public partial class AuthorizationPresentation : UserControl
    {
        //    public ICommand LoginCommand
        //    {
        //        get { return (ICommand)GetValue(LoginCommandProperty); }
        //        set { SetValue(LoginCommandProperty, value); }

        //    }

        //public static readonly DependencyProperty LoginCommandProperty =
        //    DependencyProperty.Register("LoginCommand", typeof(ICommand), typeof(AuthorizationPresentation), new PropertyMetadata(null));
        public AuthorizationPresentation()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, EventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).TextPassword = ((PasswordBox)sender).SecurePassword;
            }
        }
    }
}
