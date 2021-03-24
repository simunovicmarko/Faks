using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIZ_Simunovic_Naloga2
{
    class Temp
    {
    }
}




//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using System.Security.Cryptography;
//using System.IO;
//using Microsoft.Win32;

//namespace VIZ_Simunovic_Naloga2
//{


//    public partial class MainWindow : Window
//    {
//        byte[] key;
//        byte[] iv;
//        string globalFilePath = "";

//        List<string> AEScomboBoxItems = new List<string>() { "128", "192", "256" };
//        public MainWindow()
//        {
//            InitializeComponent();
//            getKeyOnStart();
//            SetComboBoxValues();
//        }

//        private void getKeyOnStart()
//        {
//            using (StreamReader sr = new StreamReader("key.key"))
//            {
//                this.key = Convert.FromBase64String(sr.ReadLine());
//                this.iv = Convert.FromBase64String(sr.ReadLine());
//            }
//        }

//        private void SetComboBoxValues()
//        {
//            KeyLengthCB.ItemsSource = AEScomboBoxItems;
//            KeyLengthCB.SelectedIndex = 0;
//        }



//        private void AddFile_Click(object sender, RoutedEventArgs e)
//        {
//            string input = OpenFileAndSaveToString();
//            if (input.Length > 0)
//            {
//                byte[] temp = EncryptWithAES(input, int.Parse(KeyLengthCB.Text));
//                using (StreamWriter sw = new StreamWriter(globalFilePath + ".aes"))
//                {
//                    sw.Write(Convert.ToBase64String(temp));
//                }

//            }
//        }
//        private string OpenFileAndSaveToString()
//        {
//            OpenFileDialog ofd = new OpenFileDialog();
//            if (ofd.ShowDialog() == true)
//            {
//                globalFilePath = ofd.FileName;
//                using (StreamReader sr = new StreamReader(ofd.FileName))
//                {
//                    string ret = sr.ReadToEnd();
//                    return ret;
//                }
//            }
//            return null;
//        }

//        private byte[] EncryptWithAES(string input, int keyLength)
//        {
//            byte[] encrypted;


//            UnicodeEncoding ByteConverter = new UnicodeEncoding();
//            byte[] dataToEncrypt = ByteConverter.GetBytes(input);

//            using (Aes aes = Aes.Create())
//            {
//                aes.KeySize = keyLength;
//                byte[] key = aes.Key;
//                byte[] iv = aes.IV;

//                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);

//                using (MemoryStream ms = new MemoryStream())
//                {
//                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
//                    {
//                        using (StreamWriter sw = new StreamWriter(cs))
//                        {
//                            //sw.Write(input);
//                            sw.Write(Convert.ToBase64String(dataToEncrypt));
//                        }
//                        encrypted = ms.ToArray();
//                    }
//                }
//                this.key = key;
//                this.iv = iv;
//                SaveKey(key, iv);
//            }
//            return encrypted;
//        }

//        private void SaveKey(byte[] key, byte[] iv, string path = "key.key")
//        {
//            using (StreamWriter sw = new StreamWriter(path))
//            {
//                sw.WriteLine(Convert.ToBase64String(key));
//                sw.WriteLine(Convert.ToBase64String(iv));
//            }
//        }

//        private void AddCipher_Click(object sender, RoutedEventArgs e)
//        {

//            OpenFileDialog ofd = new OpenFileDialog();

//            if (ofd.ShowDialog() == true)
//            {
//                AesDecypher(ofd.FileName);
//            }
//        }

//        private void AesDecypher(string path)
//        {
//            string plaintext;
//            byte[] EncryptedByteArray = { };

//            using (StreamReader sr = new StreamReader(path))
//            {
//                EncryptedByteArray = Convert.FromBase64String(sr.ReadToEnd());
//            }
//            this.globalFilePath = path;


//            using (Aes aes = Aes.Create())
//            {
//                aes.Key = this.key;
//                aes.IV = this.iv;

//                // Create a decryptor to perform the stream transform.
//                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

//                try
//                {



//                    //Create the streams used for decryption.
//                    using (MemoryStream ms = new MemoryStream(EncryptedByteArray))
//                    {
//                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
//                        {
//                            using (StreamReader sr = new StreamReader(cs))
//                            {
//                                plaintext = sr.ReadToEnd();
//                                //plaintext = 
//                            }
//                        }
//                    }

//                    byte[] dataToDecrypt = Convert.FromBase64String(plaintext);
//                    UnicodeEncoding ByteConverter = new UnicodeEncoding();
//                    //byte[] dataToEncrypt = ByteConverter.GetBytes(input);
//                    string s = ByteConverter.GetString(dataToDecrypt);


//                    //Wrtie to file remove the aes ending
//                    using (StreamWriter sw = new StreamWriter(this.globalFilePath.Substring(0, this.globalFilePath.Length - 4)))
//                    {
//                        sw.Write(s);
//                    }
//                }
//                catch
//                {
//                    MessageBox.Show("Neveljaven vnos");
//                }
//            }
//        }

//        private void AddKey_Click(object sender, RoutedEventArgs e)
//        {
//            OpenFileDialog ofd = new OpenFileDialog();
//            ofd.Filter = "key|*.key";
//            if (ofd.ShowDialog() == true)
//            {
//                using (StreamReader sr = new StreamReader(ofd.FileName))
//                {
//                    this.key = Convert.FromBase64String(sr.ReadLine());
//                    this.iv = Convert.FromBase64String(sr.ReadLine());
//                }
//            }
//        }

//        private void SaveKeyBtn_Click(object sender, RoutedEventArgs e)
//        {
//            SaveFileDialog saveFileDialog = new SaveFileDialog();
//            if (saveFileDialog.ShowDialog() == true)
//            {
//                SaveKey(key, iv, saveFileDialog.FileName);
//            }
//            else
//                SaveKey(key, iv);
//        }
//    }
//}


//REŠITEV RAZBIJE NA BYTE

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using System.Security.Cryptography;
//using System.IO;
//using Microsoft.Win32;

//namespace VIZ_Simunovic_Naloga2
//{


//    public partial class MainWindow : Window
//    {
//        byte[] key;
//        byte[] iv;
//        string globalFilePath = "";

//        List<string> AEScomboBoxItems = new List<string>() { "128", "192", "256" };
//        public MainWindow()
//        {
//            InitializeComponent();
//            getKeyOnStart();
//            SetComboBoxValues();
//        }

//        private void getKeyOnStart()
//        {
//            using (StreamReader sr = new StreamReader("key.key"))
//            {
//                this.key = Convert.FromBase64String(sr.ReadLine());
//                this.iv = Convert.FromBase64String(sr.ReadLine());
//            }
//        }

//        private void SetComboBoxValues()
//        {
//            KeyLengthCB.ItemsSource = AEScomboBoxItems;
//            KeyLengthCB.SelectedIndex = 0;
//        }



//        private void AddFile_Click(object sender, RoutedEventArgs e)
//        {
//            string input = OpenFileAndSaveToString();
//            byte[] temp = EncryptWithAES(input, int.Parse(KeyLengthCB.Text));
//            using (StreamWriter sw = new StreamWriter(globalFilePath + ".aes"))
//            {
//                sw.Write(Convert.ToBase64String(temp));
//            }
//        }
//        private string OpenFileAndSaveToString()
//        {
//            OpenFileDialog ofd = new OpenFileDialog();
//            if (ofd.ShowDialog() == true)
//            {
//                globalFilePath = ofd.FileName;
//                using (StreamReader sr = new StreamReader(ofd.FileName))
//                {
//                    string ret = sr.ReadToEnd();
//                    return ret;
//                }
//            }
//            return null;
//        }

//        private byte[] EncryptWithAES(string input, int keyLength)
//        {
//            byte[] encrypted;


//            UnicodeEncoding ByteConverter = new UnicodeEncoding();
//            byte[] dataToEncrypt = ByteConverter.GetBytes(input);

//            using (Aes aes = Aes.Create())
//            {
//                aes.KeySize = keyLength;
//                byte[] key = aes.Key;
//                byte[] iv = aes.IV;

//                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);

//                using (MemoryStream ms = new MemoryStream())
//                {
//                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
//                    {
//                        using (StreamWriter sw = new StreamWriter(cs))
//                        {
//                            //sw.Write(input);
//                            foreach (var b in dataToEncrypt)
//                            {
//                                sw.Write(b + "-");
//                            }
//                        }
//                        encrypted = ms.ToArray();
//                    }
//                }
//                this.key = key;
//                this.iv = iv;
//                SaveKey(key, iv);
//            }
//            return encrypted;
//        }

//        private void SaveKey(byte[] key, byte[] iv, string path = "key.key")
//        {
//            using (StreamWriter sw = new StreamWriter(path))
//            {
//                sw.WriteLine(Convert.ToBase64String(key));
//                sw.WriteLine(Convert.ToBase64String(iv));
//            }
//        }

//        private void AddCipher_Click(object sender, RoutedEventArgs e)
//        {

//            OpenFileDialog ofd = new OpenFileDialog();

//            if (ofd.ShowDialog() == true)
//            {
//                AesDecypher(ofd.FileName);
//            }
//        }

//        private void AesDecypher(string path)
//        {
//            string plaintext;
//            byte[] EncryptedByteArray = { };

//            using (StreamReader sr = new StreamReader(path))
//            {
//                EncryptedByteArray = Convert.FromBase64String(sr.ReadToEnd());
//            }
//            this.globalFilePath = path;


//            using (Aes aes = Aes.Create())
//            {
//                aes.Key = this.key;
//                aes.IV = this.iv;

//                // Create a decryptor to perform the stream transform.
//                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

//                try
//                {

//                    //Create the streams used for decryption.
//                    using (MemoryStream ms = new MemoryStream(EncryptedByteArray))
//                    {
//                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
//                        {
//                            using (StreamReader sr = new StreamReader(cs))
//                            {
//                                plaintext = sr.ReadToEnd();
//                            }
//                        }
//                    }

//                    string[] tempBytes = plaintext.Split('-');
//                    List<byte> tb = new List<byte>();
//                    foreach (var item in tempBytes)
//                    {
//                        if (item.Length > 0)
//                        {
//                            tb.Add(byte.Parse(item));
//                        }
//                    }


//                    byte[] dataToDecrypt = tb.ToArray();
//                    UnicodeEncoding ByteConverter = new UnicodeEncoding();
//                    //byte[] dataToEncrypt = ByteConverter.GetBytes(input);
//                    string s = ByteConverter.GetString(dataToDecrypt);


//                    //Wrtie to file remove the aes ending
//                    using (StreamWriter sw = new StreamWriter(this.globalFilePath.Substring(0, this.globalFilePath.Length - 4)))
//                    {
//                        sw.Write(s);
//                    }
//                }
//                catch
//                {
//                    MessageBox.Show("Neveljaven vnos");
//                }
//            }
//        }

//        private void AddKey_Click(object sender, RoutedEventArgs e)
//        {
//            OpenFileDialog ofd = new OpenFileDialog();
//            ofd.Filter = "key|*.key";
//            if (ofd.ShowDialog() == true)
//            {
//                using (StreamReader sr = new StreamReader(ofd.FileName))
//                {
//                    this.key = Convert.FromBase64String(sr.ReadLine());
//                    this.iv = Convert.FromBase64String(sr.ReadLine());
//                }
//            }
//        }

//        private void SaveKeyBtn_Click(object sender, RoutedEventArgs e)
//        {
//            SaveFileDialog saveFileDialog = new SaveFileDialog();
//            if (saveFileDialog.ShowDialog() == true)
//            {
//                SaveKey(key, iv, saveFileDialog.FileName);
//            }
//            else
//                SaveKey(key, iv);
//        }
//    }
//}

