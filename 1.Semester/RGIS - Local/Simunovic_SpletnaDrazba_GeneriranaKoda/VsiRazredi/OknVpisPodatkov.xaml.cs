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
    /// Interaction logic for OknVpisPodatkov.xaml
    /// </summary>
    public partial class OknVpisPodatkov : Window
    {
        OknoPrikazVsehAktivnihDrazb ovp;

        public OknVpisPodatkov()
        {
            InitializeComponent();
        }

        public OknVpisPodatkov(OknoPrikazVsehAktivnihDrazb ovp)
        {
            InitializeComponent();
            this.ovp = ovp;
        }


        public bool PreveriPodatke(string naziv, decimal izklicnaCena, DateTime datumPrenehanjaPrejemanjaPonudb)
        {
            try
            {
                if (naziv.Length > 0 && izklicnaCena > 0 && datumPrenehanjaPrejemanjaPonudb > DateTime.Today.Date)
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }

        private void dodajBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PreveriPodatke(nazivTB.Text, decimal.Parse(izklicnaCenaTB.Text), DP.SelectedDate.Value.Date))
                {
                    VsiPredmeti.predmeti.Add(new Predmet(ovp.VsiPredmetiLV.Items.Count + 1, nazivTB.Text, decimal.Parse(izklicnaCenaTB.Text), DP.SelectedDate.Value.Date));
                    this.Close();
                }
                else
                    MessageBox.Show("Nepravilni podatki");
            }
            catch
            {
                MessageBox.Show("Nepravilni podatki");
            }
        }
    }
}
