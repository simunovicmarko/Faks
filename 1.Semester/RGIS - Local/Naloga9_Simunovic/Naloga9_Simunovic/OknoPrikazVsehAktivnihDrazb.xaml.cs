using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Naloga9_Simunovic
{
    /// <summary>
    /// Interaction logic for OknoPrikazVsehAktivnihDrazb.xaml
    /// </summary>
    public partial class OknoPrikazVsehAktivnihDrazb : Window
    {
        SeznamZelja seznamZelja = new SeznamZelja();

        public OknoPrikazVsehAktivnihDrazb()
        {
            InitializeComponent();
            VsiPredmetiLV.ItemsSource = VsiPredmeti.predmeti;
            SeznamZeljaLV.ItemsSource = seznamZelja.PredmetiNaSeznamuZelja;
        }

        private void dodajNaSeznamBtn_Click(object sender, RoutedEventArgs e)
        {
            if (VsiPredmetiLV.SelectedItem != null)
            {
                seznamZelja.DodajNaSeznamŽelja((Predmet)VsiPredmetiLV.SelectedItem);
            }
        }
    }
}
