using Simunovic_SO_Naloga2;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Test_TaJePraviUnNEDela;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Parameter> parameters = new ObservableCollection<Parameter>();
        ObservableCollection<Alternative> alternatives = new ObservableCollection<Alternative>();
        Dictionary<Parameter, int> ParamVal = new Dictionary<Parameter, int>();
        Dictionary<Alternative, Dictionary<Parameter, int>> AltParamVal = new Dictionary<Alternative, Dictionary<Parameter, int>>();
        Dictionary<Alternative, int> AltCombinedValue;


        public MainWindow()
        {
            InitializeComponent();

            //TestValues();
        }

        private void TestValues()
        {
            parameters = new ObservableCollection<Parameter>() { new Parameter(10, "Najemnina"), new Parameter(8, "Lokacija"), new Parameter(5, "Velikost stanovanja") };
            alternatives = new ObservableCollection<Alternative>() { new Alternative("Garsonjera"), new Alternative("Prizidek") };
            SetParameters();
            SetAlternatives();
        }

        



        private void SetParameters()
        {
            ParameterContainer.Children.Clear();
            for (int i = 0; i < parameters.Count; i++)
            {
                var tmp = parameters.ElementAt(i);
                var neki = new ParamterControl(ref tmp);
                parameters.ElementAt(i).Weight = tmp.Weight;
                neki.Padding = new Thickness(5);
                ParameterContainer.Children.Add(neki);
            }

            ParamCB.ItemsSource = null;
            ParamCB.Items.Clear();
            ParamCB.ItemsSource = parameters;
            ParamCB.SelectedIndex = 0;
        }


        private void SetAlternatives()
        {
            AlternativeContainer.Children.Clear();
            foreach (var alt in alternatives)
            {
                AltParamVal.Add(alt, new Dictionary<Parameter, int>(ParamVal));
                alt.Parameters = parameters;
                AlternativeContainer.Children.Add(new AltAllControl(alt, ref AltParamVal));
            }
        }

        private void AddAltButton_Click(object sender, RoutedEventArgs e)
        {
            alternatives.Add(new Alternative(AltNameTB.Text, parameters));
            AltParamVal = new Dictionary<Alternative, Dictionary<Parameter, int>>();
            ParamVal = new Dictionary<Parameter, int>();
            SetAlternatives();
        }

        private void AddParamButton_Click(object sender, RoutedEventArgs e)
        {
            parameters.Add(new Parameter(0, ParamNameTB.Text));
            AltParamVal = new Dictionary<Alternative, Dictionary<Parameter, int>>();
            ParamVal = new Dictionary<Parameter, int>();
            SetParameters();
            SetAlternatives();
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            //List of all combined values
            GetListOfSums();

        }

        private void GetListOfSums()
        {
            List<int> ints = GetSum();
            AltCombinedValue = new Dictionary<Alternative, int>();
            for (int i = 0; i < alternatives.Count; i++)
            {
                AltCombinedValue.Add(alternatives.ElementAt(i), ints.ElementAt(i));
                alternatives.ElementAt(i).Points = ints.ElementAt(i);
            }


            ResultPanel.Children.Clear();
            foreach (var item in AltCombinedValue)
            {
                ResultPanel.Children.Add(new ResultControl(item.Key.Name, item.Value.ToString()));
            }
        }

        private Alternative GetBestAlternative()
        {
            GetListOfSums();
            var alt = AltCombinedValue.Where(x => x.Value == AltCombinedValue.Max(x => x.Value)).First().Key;
            return alt;
        }

        private List<int> GetSum()
        {
            List<int> ints = new List<int>();
            foreach (var altParamVal in AltParamVal)
            {
                int sum = 0;
                foreach (var paramVal in altParamVal.Value)
                {
                    sum += paramVal.Key.Weight * paramVal.Value;
                }
                ints.Add(sum);
            }

            return ints;
        }

        private void FindBest_Click(object sender, RoutedEventArgs e)
        {
            Alternative best = GetBestAlternative();
            MessageBox.Show($"Najboljša alternativa je {best.Name} z {best.Points} točkami");
            SetChart();
            SetChartPie();
        }


        private void SetChart()
        {
            TempChart.Series.Clear();
            TempChart.PrimaryAxis = new CategoryAxis();
            TempChart.SecondaryAxis = new NumericalAxis();
            ColumnSeries series = new ColumnSeries();
            series.ItemsSource = (new ViewModel(AltCombinedValue)).Data;
            series.XBindingPath = "Name";
            series.YBindingPath = "Value";

            TempChart.Series.Add(series);
        }

        private void SetChartPie()
        {
            TempChart2.Series.Clear();
            TempChart2.DataContext = new ViewModelParam(parameters.ToList());
            TempChart2.Legend = new ChartLegend();


            PieSeries series = new PieSeries();
            series.ItemsSource = (new ViewModelParam(parameters.ToList())).Data;
            series.XBindingPath = "Name";
            series.YBindingPath = "Value";

            series.AdornmentsInfo = new ChartAdornmentInfo()
            {
                ShowLabel = true
            };

            TempChart2.Series.Add(series);
        }

        private void SetChartLine()
        {
            Parameter par = (Parameter)ParamCB.SelectedItem;
            if (par != null)
            {


                TempChart3.Series.Clear();
                TempChart3.DataContext = new ViewModelLine();
                TempChart3.Header = par.Name;

                TempChart3.PrimaryAxis = new NumericalAxis();
                TempChart3.SecondaryAxis = new NumericalAxis();
                TempChart3.PrimaryAxis.Header = "Utež";
                TempChart3.SecondaryAxis.Header = "Ocena";
                ChartLegend legend = new ChartLegend();
                foreach (var altParamVal in AltParamVal)
                {
                    LineSeries series = new LineSeries();
                    ViewModelLine viewModelLine = new ViewModelLine();


                    for (int i = 0; i < 11; i++)
                    {
                        int sum = 0;
                        foreach (var paramVal in altParamVal.Value)
                        {
                            if (paramVal.Key != par)
                            {
                                sum += paramVal.Key.Weight * paramVal.Value;
                            }
                            else
                                sum += i * paramVal.Value;
                        }
                        Console.WriteLine($"{i} ... {sum}");
                        viewModelLine.Data.Add(new DisplayValueLine(i, sum));
                    }

                    series.ItemsSource = viewModelLine.Data;
                    series.XBindingPath = "ValueX";
                    series.YBindingPath = "ValueY";
                    
                    TempChart3.Series.Add(series);
                }
            }

        }

        private void ParamCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SetChartLine();
        }

        private void AltNameTB_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                AddAltButton_Click(sender, e);
            }
        }

        private void ParamNameTB_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                AddParamButton_Click(sender, e);
            }
        }
    }
}

