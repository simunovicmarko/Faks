using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Win32;


namespace VIZ_FrekvencnaAnaliza_Simunovic_DotNetFramework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<char, int> AnaliticDictionary = new Dictionary<char, int>();
        Dictionary<char, int> CipherDictionary = new Dictionary<char, int>();

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

        //private void SortByValue(ref Dictionary<char, int> dick)
        //{
        //    Dictionary<char, int> tempDick = new Dictionary<char, int>();
        //    foreach (var item in dick.OrderBy(x => x.Value))
        //        tempDick.Add(item.Key, item.Value);
        //    dick = tempDick;
        //}

        private string AddAndReadTxtFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text file|*.txt";
            ofd.Multiselect = false;


            if (ofd.ShowDialog() == true)
                using (TextReader tr = new StreamReader(ofd.FileName))
                    return tr.ReadToEnd();

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
        /// Combines the key of both dictonaries
        /// </summary>
        /// <returns></returns>
        private Dictionary<char, char> Change()
        {
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
        /// <param name="s"></param>
        /// <returns></returns>
        private string Decipher(string s)
        {
            Dictionary<char, char> dick = Change();
            //string returnString = "";
            StringBuilder temp = new StringBuilder(s);

            //For every letter set its value to the value from the orderd dictionary 
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                {
                    //returnString += dick[char.ToUpper(s[i])];
                    temp[i] = dick[char.ToUpper(s[i])]; ;
                }
            }
            return temp.ToString();
        }

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



        private void AddAnalitic_Click(object sender, RoutedEventArgs e)
        {
            string s = AddAndReadTxtFile();
            if (s != null)
            {
                CountCharsFromStrings(s, ref AnaliticDictionary);
            }
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
            }
            else
                MessageBox.Show("Dodajte šifrirano besedilo");
        }

        private void AddCipher_Click(object sender, RoutedEventArgs e)
        {
            cipher = AddAndReadTxtFile();
            OriginalText.Text = cipher;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog svg = new SaveFileDialog();
            svg.Filter = "Tekstovna datoteka | *.txt";
            if (svg.ShowDialog() == true)
                using (TextWriter tw = new StreamWriter(svg.FileName))
                    tw.Write(decipherd);
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
