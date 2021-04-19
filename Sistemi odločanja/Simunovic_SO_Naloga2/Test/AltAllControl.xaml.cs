using Simunovic_SO_Naloga2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AltAllControl.xaml
    /// </summary>
    public partial class AltAllControl : UserControl
    {
        Dictionary<Parameter, int> ParamValues;
        int combinedValueInt = 0;
        //public Label CombinedValue {set {
        //        this.CombinedValueLabel.Content = value;    
        //    }
        //}

        public AltAllControl(Alternative alternative)
        {
            InitializeComponent();
            NameLabel.Content = alternative.Name;

            Dictionary<Parameter, int> ParamVal = new Dictionary<Parameter, int>();
            foreach (var item in alternative.Parameters)
            {
                ParamVal.Add(item, 0);
                var alternativeControl = new AlternativeControl(item, ref ParamVal, ref combinedValueInt);
                alternativeControl.Width = 200;
                alternativeControl.Padding = new Thickness(5);
                AltContainer.Children.Add(alternativeControl);
            }
        }
        public AltAllControl(Alternative alternative, ref Dictionary<Alternative, Dictionary<Parameter, int>> altParamVal)
        {
            InitializeComponent();
            NameLabel.Content = alternative.Name;

            ParamValues = altParamVal[alternative];
            foreach (var item in alternative.Parameters)
            {
                var alternativeControl = new AlternativeControl(item, ref ParamValues, ref combinedValueInt);
                alternativeControl.Width = 200;
                alternativeControl.Padding = new Thickness(5);
                AltContainer.Children.Add(alternativeControl);
            }
        }
    }
}
