using PizzaDelivery.ViewModels;
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
    /// Логика взаимодействия для ProfilePresentation.xaml
    /// </summary>
    public partial class ProfilePresentation : UserControl
    {
        public ProfilePresentation()
        {
            InitializeComponent();
            //ProfilePresentationVM.OnPasswordBoxesIsNull += UpdatePasswordBoxes;

        }

        //public void UpdatePasswordBoxes(object sender, EventArgs e)
        //{
        //    pbPasswordBox.Password = ((ProfilePresentationVM)sender).Password;
        //    pbRepPasswordBox.Password = ((ProfilePresentationVM)sender).RepPassword;
        //}
        private void PasswordBox_PasswordChanged(object sender, EventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).Password = ((PasswordBox)sender).SecurePassword;
            }
        }

        private void RepPasswordBox_PasswordChanged(object sender, EventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).RepPassword = ((PasswordBox)sender).SecurePassword;
            }
        }
    }
}
