using BLL.Models;
using DAL.Repository;
using Interfaces.DTO;
using Interfaces.Services;
using LiveCharts.Wpf;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using PizzaDelivery.Util;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaDelivery.ViewModels
{
    public class ReportsManagerVM : ViewModelBase
    {
        private List<OrdersByMonthDto> _pizzas;
        private IReportService _reportService;
        //public Dictionary<string, int> Months = new Dictionary<string, int>()
        //{
        //    {"Январь", 1 },
        //    {"Февраль", 2 },
        //    {"Март", 3 },
        //    {"Апрель", 4 },
        //    {"Май", 5 },
        //    {"Июнь", 6 },
        //    {"Июль", 7 },
        //    {"Август", 8},
        //    {"Сентябрь", 9 },
        //    {"Октябрь", 10 },
        //    {"Ноябрь", 11 },
        //    {"Декабрь", 12 }


        //};
        private List<MyMonth> _months = new List<MyMonth>()
        {
            new MyMonth("Январь", 1),
            new MyMonth("Февраль", 2),
            new MyMonth("Март", 3),
            new MyMonth("Апрель", 4),
            new MyMonth("Май", 5),
            new MyMonth("Июнь", 6),
            new MyMonth("Июль", 7),
            new MyMonth("Август", 8),
            new MyMonth("Сентябрь", 9),
            new MyMonth("Октябрь", 10),
            new MyMonth("Ноябрь", 11),
            new MyMonth("Декабрь", 12),

        };
        public List<MyMonth> Months
        {
            get
            {
                return _months;
            }
            set
            {
                _months = value;
                OnPropertyChanged(nameof(Months));
            }
        }
        private MyMonth _selectedMonth;
        public MyMonth SelectedMonth
        {
            get
            {
                return _selectedMonth;
            }
            set
            {
                _selectedMonth = value;
                OnPropertyChanged(nameof(SelectedMonth));
            }
        }
        public class MyMonth
        {
            public string Name
            {
                get; set;
            }
            public int Value;
            public MyMonth(string name, int value)
            {
                Name = name;
                Value = value;
            }
        }

        private bool _isFirstPizzaReport;
        public bool IsFirstPizzaReport
        {
            get
            {
                return _isFirstPizzaReport;
            }
            set
            {
                _isFirstPizzaReport = value;
                OnPropertyChanged(nameof(IsFirstPizzaReport));
            }
        }
        private bool _isSecondPizzaReport;
        public bool IsSecondPizzaReport
        {
            get
            {
                return _isSecondPizzaReport;
            }
            set
            {
                _isSecondPizzaReport = value;
                OnPropertyChanged(nameof(IsSecondPizzaReport));
            }
        }
        //private int _month;
        //public int Month
        //{
        //    get
        //    {
        //        return _month;
        //    }
        //    set
        //    {
        //        _month = value;
        //        OnPropertyChanged(nameof(Month));
        //    }
        //}
        private int _year;
        public int Year
        {
            get
            {
                return _year;
            
            }
            set
            {
                _year = value;
                OnPropertyChanged(nameof(Year));
            }
        }
        private ICommand reportCommand;
        public ICommand ReportCommand => reportCommand ??= new Commands.DelegateCommand(obj =>
        {

            if (IsFirstPizzaReport)
            {
                _pizzas = _reportService.ExecuteSP(SelectedMonth.Value, Year);
                //ISeries[] series1 = new ISeries[_pizzas.Count];
                //for (int i = 0; i < _pizzas.Count; i++)
                //{
                //    series1[i] = new PieSeries<int>(_pizzas[i].quantity);
                //    series1[i].Name = _pizzas[i].pizzaName;
                //    //series1[i].Data
                //}

                //Series = series1;

                var vals = new PieSeries<double>[_pizzas.Count];
                for (int i = 0; i < _pizzas.Count; i++)
                {
                    vals[i] = new PieSeries<double>
                    {
                        Values = [_pizzas[i].quantity],
                        DataLabelsPaint = new SolidColorPaint(SKColors.White),
                        DataLabelsFormatter = point =>
                        {
                            var pv = point.Coordinate.PrimaryValue;
                            var sv = point.StackedValue!;

                            var a = $"{pv}{Environment.NewLine}{sv.Share:P2}";
                            return a;
                        }
                    };
                    vals[i].Name = _pizzas[i].pizzaName;
                }
                ReportSeries = vals;
                LabelVisual lv = new LabelVisual()
                {
                    Text = "Отчет (кол-во доставленных пицц, шт), " + new DateTime(Year, SelectedMonth.Value, 1).ToString("MMMM yyyy"),
                    TextSize = 25,
                    Padding = new LiveChartsCore.Drawing.Padding(15)
                };
                Title = lv;
            }
            else if (IsSecondPizzaReport)
            {
                _pizzas = _reportService.ExecuteSP(SelectedMonth.Value, Year);
                //ISeries[] series1 = new ISeries[_pizzas.Count];
                //for (int i = 0; i < _pizzas.Count; i++)
                //{
                //    series1[i] = new PieSeries<int>(_pizzas[i].quantity);
                //    series1[i].Name = _pizzas[i].pizzaName;
                //    //series1[i].Data
                //}

                //Series = series1;

                var vals = new PieSeries<double>[_pizzas.Count];
                for (int i = 0; i < _pizzas.Count; i++)
                {
                    vals[i] = new PieSeries<double>
                    {
                        Values = [(double)_pizzas[i].cost],
                        DataLabelsPaint = new SolidColorPaint(SKColors.White),
                        DataLabelsFormatter = point =>
                        {
                            var pv = point.Coordinate.PrimaryValue;
                            var sv = point.StackedValue!;

                            var a = $"{pv}{Environment.NewLine}{sv.Share:P2}";
                            return a;
                        }
                    };
                    vals[i].Name = _pizzas[i].pizzaName;
                }
                ReportSeries = vals;
                LabelVisual lv = new LabelVisual()
                {
                    Text = "Отчет (стоимость доставленных пицц, руб), " + new DateTime(Year, SelectedMonth.Value, 1).ToString("MMMM yyyy"),
                    TextSize = 25,
                    Padding = new LiveChartsCore.Drawing.Padding(15)
                };
                Title = lv;
            }
        });
        private ICommand updateReport;
        public ICommand UpdateReport
        {
            get
            {
                return updateReport ??= new Commands.DelegateCommand(obj =>
                {
                    if (obj.ToString() == "first")
                    {
                        IsFirstPizzaReport = true;
                        IsSecondPizzaReport = false;
                    }
                    else
                    {
                        IsFirstPizzaReport = false;
                        IsSecondPizzaReport = true;
                    }
                });
            }
        }
        private LabelVisual title;
        public LabelVisual Title {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        //new LabelVisual
        //{
        
        //};
        private string _reportImage;
        public string ReportImage
        {
            get
            {
                return _reportImage;
                //return "/ImagesForProject/pizzaicon.png";
            }
        }
        //private ISeries[] _series;
        //public ISeries[] Series
        //{
        //    get
        //    {
        //        return _series;
        //    }
        //    set
        //    {
        //        _series = value;
        //        OnPropertyChanged(nameof(Series));
        //    }
        //}
        private PieSeries<double>[] _reportSeries;
        public PieSeries<double>[] ReportSeries
        {
            get
            {
                return _reportSeries;
            }
            set
            {
                _reportSeries = value;
                OnPropertyChanged(nameof(ReportSeries));
            }
        }

        private IEnumerable<ISeries> _series;
        public IEnumerable<ISeries> Series
        {
            get
            {
                return _series;
            }
            set
            {
                _series = value;
                OnPropertyChanged(nameof(Series));
            }
        }

        //= new ISeries[]
        //{
        //    //new PieSeries<double>{Values = new double[] {2 } },
        //    //new PieSeries<double>{Values = new double[] {1 } },
        //    //new PieSeries<double>{Values = new double[] {4 } },
        //    //new PieSeries<double>{Values = new double[] {5 } }
        //};
        public ReportsManagerVM(IReportService reportService)
        {
            _reportService= reportService;
            IsSecondPizzaReport = false;
            IsFirstPizzaReport= true;
            SelectedMonth = Months[0];
            Year = 2024;
            //List<OrdersByMonthDto> report = _reportService.ExecuteSP(11, 2024);
        }
    }
}
