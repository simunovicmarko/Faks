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

namespace Naloga10
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

        private void DodajPredmetBtn_Click(object sender, RoutedEventArgs e)
        {
            OknVpisPodatkov ovp = new OknVpisPodatkov(this);
            ovp.ShowDialog();
            VsiPredmetiLV.ItemsSource = null;
            VsiPredmetiLV.ItemsSource = VsiPredmeti.predmeti;
        }
    }
}

