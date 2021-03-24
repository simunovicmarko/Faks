using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using OxyPlot;
using OxyPlot.Series;

namespace VIZ_FrekvencnaAnaliza_Simunovic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<char, int> AnaliticDictionary = new Dictionary<char, int>();
        Dictionary<char, int> CipherDictionary = new Dictionary<char, int>();
        Dictionary<char, int> DecipherdDictionary = new Dictionary<char, int>();

        string cipher, decipherd;

        public MainWindow()
        {
            InitializeComponent();
        }



        //private void RemoveHTML(ref string input)
        //{
        //    input = Regex.Replace(input, "<.*?>", String.Empty);
        //    using (TextWriter tw = new StreamWriter("Slovar.txt"))
        //    {
        //        tw.Write(input);
        //    }
        //}

       
        /// <summary>
        /// Returns the string from a txt file. If it doesn't it returns null
        /// </summary>
        /// <returns></returns>
        private string AddAndReadTxtFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text file|*.txt";
            ofd.Multiselect = false;


            if (ofd.ShowDialog() == true)
                using (TextReader tr = new StreamReader(ofd.FileName))
                {
                    return tr.ReadToEnd();
                }

            return null;
        }


        /// <summary>
        /// Counts how many of each char there is in the text
        /// </summary>
        /// <param name="input"></param>
        /// <param name="dick"></param>
        private void CountCharsFromStrings(string input, ref Dictionary<char, int> dick)
        {
            foreach (var letter in input)
            {
                if (char.IsLetter(char.ToUpper(letter)))
                {
                    if (!dick.ContainsKey(char.ToUpper(letter)))
                        dick.Add(char.ToUpper(letter), 1);
                    else
                        dick[char.ToUpper(letter)]++;
                }
            }
        }


        /// <summary>
        /// Combines the keys of both dictonaries
        /// </summary>
        /// <returns></returns>
        private Dictionary<char, char> Change()
        {

            //orders dictionaries into arrays
            KeyValuePair<char, int>[] anal = AnaliticDictionary.OrderBy(x => x.Value).ToArray();
            KeyValuePair<char, int>[] cipher = CipherDictionary.OrderBy(x => x.Value).ToArray();
            Dictionary<char, char> changed = new Dictionary<char, char>();
            //Setting the return dictionary
            for (int i = 0; i < cipher.Length; i++)
                changed.Add(cipher[i].Key, anal[i].Key);
            return changed;
        }

        /// <summary>
        /// Goes through the entire text and changes charecters to their coresponding values in Change() dictionary
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string Decipher(string input)
        {
            Dictionary<char, char> dick = Change();
            //string returnString = "";
            StringBuilder temp = new StringBuilder(input);

            //For every letter set its value to the value from the orderd dictionary 
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    temp[i] = dick[char.ToUpper(input[i])];
                }
            }


            foreach (var letter in temp.ToString())
            {
                if (char.IsLetter(char.ToUpper(letter)))
                {
                    if (!DecipherdDictionary.ContainsKey(char.ToUpper(letter)))
                        DecipherdDictionary.Add(char.ToUpper(letter), 1);
                    else
                        DecipherdDictionary[char.ToUpper(letter)]++;
                }
            }



            return temp.ToString();
        }

        /// <summary>
        /// Switches the characters
        /// </summary>
        /// <param name="input"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        private void SwitchChars(ref string input, char from, char to)
        {
            StringBuilder stringBuilder = new StringBuilder(input);
            from = char.ToUpper(from);
            to = char.ToUpper(to);
            for (int i = 0; i < input.Length; i++)
            {
                if (stringBuilder[i] == from)
                    stringBuilder[i] = to;
                else if (stringBuilder[i] == to)
                    stringBuilder[i] = from;
            }
            input = stringBuilder.ToString();
        }


        /// <summary>
        /// Creates a pie chart
        /// </summary>
        /// <param name="dick"></param>
        /// <param name="pv"></param>
        /// <param name="title"></param>
        private void CreateChart(Dictionary<char, int> dick, OxyPlot.Wpf.PlotView pv, string title = "Črke")
        {
            PlotModel pm = new PlotModel();

            pm.Title = title;
            dynamic seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };

            foreach (KeyValuePair<char, int> kvp in dick)
            {
                seriesP1.Slices.Add(new PieSlice(kvp.Key.ToString(), kvp.Value) { IsExploded = true });
            }
            pm.Series.Add(seriesP1);
            pv.Model = pm;


        }



        private void AddAnalitic_Click(object sender, RoutedEventArgs e)
        {
            string s = AddAndReadTxtFile();
            if (s != null)
            {
                CountCharsFromStrings(s, ref AnaliticDictionary);
                ClearAnalitics.IsEnabled = true;
            }
        }


        private void AddCipher_Click(object sender, RoutedEventArgs e)
        {
            cipher = AddAndReadTxtFile();
            OriginalText.Text = cipher;
            DeCipher.IsEnabled = true;
        }


        private void DeCipher_Click(object sender, RoutedEventArgs e)
        {
            if (AnaliticDictionary.Count <= 0)
                using (TextReader tr = new StreamReader("Slovar.txt"))
                    CountCharsFromStrings(tr.ReadToEnd(), ref AnaliticDictionary);

            if (cipher != null)
            {
                CipherDictionary = new Dictionary<char, int>();
                CountCharsFromStrings(cipher, ref CipherDictionary);
                decipherd = Decipher(cipher);
                DecipherdText.Text = decipherd;
                FromChar.IsEnabled = true;
                ToChar.IsEnabled = true;
                ChangeChar.IsEnabled = true;
                Save.IsEnabled = true;
                CreateChart(CipherDictionary, ChChars, "Šifrirano besedilo");
                CreateChart(AnaliticDictionary, DeChChars, "Dešifrirano besedilo");
                CreateChart(DecipherdDictionary, AnalChChars, "Razkrito besedilo");
                Charts.IsEnabled = true;
            }
            else
                MessageBox.Show("Dodajte šifrirano besedilo");
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog svg = new SaveFileDialog();
            svg.Filter = "Tekstovna datoteka | *.txt";
            if (svg.ShowDialog() == true)
                using (TextWriter tw = new StreamWriter(svg.FileName))
                    tw.Write(decipherd);
        }

        private void ClearAnalitics_Click(object sender, RoutedEventArgs e)
        {
            AnaliticDictionary = new Dictionary<char, int>();
            ClearAnalitics.IsEnabled = false;
        }

        private void ChangeChar_Click(object sender, RoutedEventArgs e)
        {
            if (FromChar.Text.Length > 0 && ToChar.Text.Length > 0)
            {
                SwitchChars(ref decipherd, FromChar.Text[0], ToChar.Text[0]);
                DecipherdText.Text = decipherd;
            }
            else
                MessageBox.Show("Vnesite obe črki");
        }


    }

}
