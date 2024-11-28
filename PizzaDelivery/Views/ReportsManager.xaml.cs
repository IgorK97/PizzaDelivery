using LiveChartsCore.SkiaSharpView.SKCharts;
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
    /// Логика взаимодействия для ReportsManager.xaml
    /// </summary>
    public partial class ReportsManager : UserControl
    {
        public ReportsManager()
        {
            InitializeComponent();
        }
        public void Button1_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                //IDocumentPaginatorSource document = Chart1;
                printDialog.PrintVisual(Chart1, "Распечатываем элемент Canvas");
            }
            //var skChart = new SKPieChart(Chart1) { Width = 900, Height = 600, };
            //skChart.SaveImage("PieImageFromControl.png");
        }
    }
}
