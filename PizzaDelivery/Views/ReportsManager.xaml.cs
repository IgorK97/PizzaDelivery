using LiveChartsCore.SkiaSharpView.SKCharts;
using Microsoft.Win32;
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
using IronPdf;
using IronPdf.Editing;

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
            //PrintDialog printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == true)
            //{
            //    //IDocumentPaginatorSource document = Chart1;
            //    printDialog.PrintVisual(Chart1, "Распечатываем элемент Canvas");
            //}
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = ".pdf";
                saveFileDialog.Filter = "PDF | *.pdf";
                saveFileDialog.AddExtension = true;
                if (saveFileDialog.ShowDialog() == true)
                {
                    string imageName = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss");
                    string imagePath = "Pie_" + imageName + ".jpeg";
                    var skChart = new SKPieChart(Chart1) { Width = 900, Height = 600 };
                    skChart.SaveImage(imagePath, SkiaSharp.SKEncodedImageFormat.Jpeg);
                    PdfDocument pdf = ImageToPdfConverter.ImageToPdf(imagePath);
                    imagePath = saveFileDialog.FileName;
                    //pdf.SaveAs(imagePath);
                    //var stamper = new TextHeaderFooter()
                    //{
                    //    CenterText = "<h2>" + txtBlock1.Text + "</h2>"
                    //};

                    //var pdf1 = PdfDocument.FromFile(imagePath);

                    pdf.SaveAs(imagePath);
                    MessageBox.Show("Файл успешно сохранён!", "Success", MessageBoxButton.OK,
                   MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
