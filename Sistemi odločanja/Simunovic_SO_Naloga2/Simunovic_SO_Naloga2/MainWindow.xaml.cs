using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Simunovic_SO_Naloga2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BindingList<Parameter> parameters = new BindingList<Parameter>() { new Parameter(10, "Najemnina"), new Parameter(8, "Lokacija"), new Parameter(5, "Velikost stanovanja") };
        ObservableCollection<Alternative> alternatives = new ObservableCollection<Alternative>() { new Alternative("Garsonjera"), new Alternative("Prizidek") };

        public MainWindow()
        {
            InitializeComponent();
            SetParams();
            SetAlternatives();
        }

        private void SetParams()
        {
            KTDataGridParams.ItemsSource = parameters;
        }

        private void SetAlternatives()
        {
            KTDataGridAlts.Items.Clear();
            foreach (var alt in alternatives)
            {
                alt.Parameters = parameters.ToList();
                var temp = new DataGridTextColumn() { Header = "Točke" };
                var temp2 = new DataGridTextColumn() { Header = "Utež x Točke" };
                KTDataGridAlts.Columns.Add(temp);
                KTDataGridAlts.Columns.Add(temp2);
                //List<int> 


                foreach (var param in alt.GetParamterAndPoints())
                {
                    //KTDataGridAlts.ItemsSource = alt.GetParamterAndPoints(); ;
                    KTDataGridAlts.Items.Add(param.point);
                }

            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                alternatives.Add(new Alternative(AltNameTB.Text));
                KTDataGridAlts.ItemsSource = null;
                KTDataGridAlts.Columns.Clear();
                SetAlternatives();
            }
            catch (Exception)
            {

                MessageBox.Show("Dodajanje ni uspelo");
            }
        }


    }
}
