using Simunovic_SO_Naloga2;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Test
{
    /// <summary>
    /// Interaction logic for ParamterControl.xaml
    /// </summary>
    public partial class ParamterControl : UserControl
    {
        public List<int> Values = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public ParamterControl(Parameter parameter)
        {
            InitializeComponent();
            ValuesTB.ItemsSource = Values;
            NameLabel.Content = parameter.Name;
            ValuesTB.SelectedIndex = parameter.Weight;
        }

        Parameter parameter;
        public ParamterControl(ref Parameter parameter)
        {
            InitializeComponent();
            ValuesTB.ItemsSource = Values;
            NameLabel.Content = parameter.Name;
            ValuesTB.SelectedIndex = parameter.Weight;
            this.parameter = parameter;
        }

        private void ValuesTB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (parameter != null)
            {
                parameter.Weight = (int)ValuesTB.SelectedValue;
            }
        }
    }
}
