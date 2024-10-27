using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PizzaDelivery.ViewModels
{
    class RootVM : INotifyPropertyChanged
    {
        object currentContentVM;
        public object CurrentContentVM
        {
            get => currentContentVM;

            set => currentContentVM = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
