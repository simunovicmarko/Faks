using Simunovic_SO_Naloga2;
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

namespace Test
{
    /// <summary>
    /// Interaction logic for AlternativeControl.xaml
    /// </summary>
    public partial class AlternativeControl : UserControl
    {
        public List<int> Values = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public int PointValue { get; set; }
        public string PointWeightValue { get; set; }

        Parameter parameter;
        Dictionary<Parameter, int> Dick;

        public AlternativeControl()
        {
            InitializeComponent();
            //ValueLabel.Content = LabelValue;
            ValuesTB.ItemsSource = Values;
            ValuesTB.SelectedIndex = 0;
            if (parameter != null)
            {
                ValueLabel.Content = PointValue * parameter.Weight;
            }
        }

        int combinedValue;
        public AlternativeControl(Parameter parameter, ref Dictionary<Parameter, int> dick, ref int combinedValue)
        {
            InitializeComponent();
            //ValueLabel.Content = LabelValue;
            ValuesTB.ItemsSource = Values;
            ValuesTB.SelectedIndex = 0;
            this.combinedValue = combinedValue;
            this.parameter = parameter;
            this.Dick = dick;

            if (parameter != null)
            {
                ValueLabel.Content = PointValue * parameter.Weight;
            }
        }
        public AlternativeControl(Parameter parameter, ref Dictionary<Parameter, int> dick)
        {
            InitializeComponent();
            //ValueLabel.Content = LabelValue;
            ValuesTB.ItemsSource = Values;
            ValuesTB.SelectedIndex = 0;
            this.parameter = parameter;
            this.Dick = dick;
            if (parameter != null)
            {
                ValueLabel.Content = PointValue * parameter.Weight;
            }
        }

        private void ValuesTB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PointValue = (int)ValuesTB.SelectedValue;
                if (Dick != null && parameter != null)
                {
                    Dick[parameter] = PointValue;
                    ValueLabel.Content = PointValue * parameter.Weight;
                    combinedValue += PointValue * parameter.Weight;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
