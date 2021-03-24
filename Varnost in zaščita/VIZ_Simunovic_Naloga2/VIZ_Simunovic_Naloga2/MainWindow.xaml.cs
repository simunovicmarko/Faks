using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Security.Cryptography;
using System.IO;
using Microsoft.Win32;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.OpenSsl;
using BCrypt.Net;
//using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Infrastructure;

namespace VIZ_Simunovic_Naloga2
{


    public partial class MainWindow : Window
    {
        byte[] AESkey;
        byte[] AESiv;
        string globalFilePath = "";
        byte[] globalEncrypted;
        //bool TrueIfAESElseRSA;
        RsaKeyParameters privateKey;

        List<string> AEScomboBoxItems = new List<string>() { "128", "192", "256" };
        List<string> RSAcomboBoxItems = new List<string>() { "1024", "2048" };
        public MainWindow()
        {
            InitializeComponent();
            SetComboBoxValues();
        }



        private void SetComboBoxValues()
        {
            KeyLengthCB.ItemsSource = AEScomboBoxItems;
            KeyLengthCB.SelectedIndex = 0;
        }


        private byte[] RSAEncrypt(string input, int keyLength = 1024)
        {

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            RsaKeyPairGenerator rsaKeyPairGenerator = new RsaKeyPairGenerator();
            rsaKeyPairGenerator.Init(new KeyGenerationParameters(new SecureRandom(), int.Parse(KeyLengthCB.Text)));
            AsymmetricCipherKeyPair keyPair = rsaKeyPairGenerator.GenerateKeyPair();

            RsaKeyParameters privateKey = (RsaKeyParameters)keyPair.Private;
            RsaKeyParameters publicKey = (RsaKeyParameters)keyPair.Public;
            this.privateKey = privateKey;

            IAsymmetricBlockCipher cipher = new OaepEncoding(new RsaEngine());
            cipher.Init(true, publicKey);



            byte[] cipherText = cipher.ProcessBlock(inputBytes, 0, inputBytes.Length);
            SaveRSAFile(cipherText);
            SaveRSAKey();
            return cipherText;

        }

        private string RSADecrypt(byte[] input, RsaKeyParameters privateKey)
        {
            IAsymmetricBlockCipher cipher = new OaepEncoding(new RsaEngine());
            cipher.Init(false, privateKey);
            byte[] deciphered = cipher.ProcessBlock(input, 0, input.Length);
            string decipheredText = Encoding.UTF8.GetString(deciphered);
            return decipheredText;
        }
        private string RSADecrypt(string path)
        {
            byte[] EncryptedByteArray = File.ReadAllBytes(path);
            //using (StreamReader sr = new StreamReader(path))
            //{
            //    EncryptedByteArray = Convert.FromBase64String(sr.ReadToEnd());
            //}

            IAsymmetricBlockCipher cipher = new OaepEncoding(new RsaEngine());
            cipher.Init(false, privateKey);
            byte[] deciphered = cipher.ProcessBlock(EncryptedByteArray, 0, EncryptedByteArray.Length);
            string decipheredText = Encoding.UTF8.GetString(deciphered);

            //Wrtie to file remove the aes ending
            using (StreamWriter sw = new StreamWriter(this.globalFilePath.Substring(0, this.globalFilePath.Length - 4)))
            {
                sw.Write(decipheredText);
            }

            return decipheredText;
        }


        private void SaveRSAKey()
        {
            TextWriter textWriter = new StringWriter();
            PemWriter pemWriter = new PemWriter(textWriter);

            pemWriter.WriteObject(privateKey);
            string s = textWriter.ToString();

            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    sw.Write(s);
                }
            }
        }

        private RsaKeyParameters GetRSAKeyFromString(string input)
        {
            TextReader textReader = new StringReader(input);
            PemReader pemReader = new PemReader(textReader);
            object o = pemReader.ReadObject();
            AsymmetricCipherKeyPair pkp = (AsymmetricCipherKeyPair)o;
            this.privateKey = (RsaKeyParameters)pkp.Private;
            return (RsaKeyParameters)pkp.Private;
        }
        private void GetAESKeyFromString(string input)
        {


            using (StreamReader sr = new StreamReader(input))
            {
                this.AESkey = Convert.FromBase64String(sr.ReadLine());
                this.AESiv = Convert.FromBase64String(sr.ReadLine());
            }


            //this.privateKey = (RsaKeyParameters)pkp.Private;
        }





        private void SaveAESFile(byte[] temp)
        {
            using (StreamWriter sw = new StreamWriter(globalFilePath + ".aes"))
            {
                sw.Write(Convert.ToBase64String(temp));
            }
        }
        private void SaveRSAFile(byte[] temp)
        {
            File.WriteAllBytes(globalFilePath + ".rsa", temp);
            //using (StreamWriter sw = new StreamWriter(globalFilePath + ".rsa"))
            //{
            //    sw.Write(Convert.ToBase64String(temp));
            //}
        }

        private string GetStringFromPath(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string ret = sr.ReadToEnd();
                return ret;
            }
        }



        private void SaveAESKey(byte[] key, byte[] iv, string path = "key.aesKey")
        {

            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "|*.aesKey";
            if (sfd.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(Convert.ToBase64String(key));
                    sw.WriteLine(Convert.ToBase64String(iv));
                }
            }
        }




        private byte[] AESEncrypt(string input, int keyLength)
        {
            byte[] encrypted;


            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes(input);

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = keyLength;
                byte[] key = aes.Key;
                byte[] iv = aes.IV;

                aes.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(input);
                        }
                        encrypted = ms.ToArray();
                    }
                }
                this.AESkey = key;
                this.AESiv = iv;
                //SaveAESKey(key, iv);
            }
            SaveAESFile(encrypted);
            return encrypted;
        }
        private byte[] AESEncrypt(int keyLength, string path)
        {
            byte[] encrypted;



            byte[] dataToEncrypt = File.ReadAllBytes(path);

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = keyLength;
                byte[] key = aes.Key;
                byte[] iv = aes.IV;

                //aes.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    }
                    encrypted = ms.ToArray();
                }
                this.AESkey = key;
                this.AESiv = iv;
                SaveAESKey(key, iv);
            }

            File.WriteAllBytes(globalFilePath + ".aes", encrypted);
            return encrypted;
        }


        private void AESDecrypt(string path)
        {
            byte[] EncryptedByteArray = File.ReadAllBytes(path);


            this.globalFilePath = path;


            using (Aes aes = Aes.Create())
            {
                aes.Key = this.AESkey;
                aes.IV = this.AESiv;


                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] temps;


                //Create the streams used for decryption.
                using (MemoryStream ms = new MemoryStream(EncryptedByteArray))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(EncryptedByteArray, 0, EncryptedByteArray.Length);
                        cs.Close();
                    }
                    temps = ms.ToArray();
                }


                File.WriteAllBytes(this.globalFilePath.Substring(0, this.globalFilePath.Length - 4), temps);
            }
        }


        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                globalFilePath = ofd.FileName;
                if (ofd.FileName.Substring(ofd.FileName.Length - 3) == "aes")
                    EncryptionTypteCB.SelectedIndex = 0;
                else if (ofd.FileName.Substring(ofd.FileName.Length - 3) == "rsa")
                    EncryptionTypteCB.SelectedIndex = 1;
            }
            Cipher.IsEnabled = true;
            Decipher.IsEnabled = true;
            HashButton.IsEnabled = true;

        }



        private void AddKey_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "key|*.key";
            if (ofd.ShowDialog() == true)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    this.AESkey = Convert.FromBase64String(sr.ReadLine());
                    this.AESiv = Convert.FromBase64String(sr.ReadLine());
                }
            }
        }
        private void RSAItem_Selected(object sender, RoutedEventArgs e)
        {
            KeyLengthCB.ItemsSource = null;
            KeyLengthCB.ItemsSource = RSAcomboBoxItems;
            KeyLengthCB.SelectedIndex = 0;
        }

        private void AESItem_Selected(object sender, RoutedEventArgs e)
        {
            KeyLengthCB.ItemsSource = null;
            KeyLengthCB.ItemsSource = AEScomboBoxItems;
            KeyLengthCB.SelectedIndex = 0;
        }

        private void Cipher_Click(object sender, RoutedEventArgs e)
        {
            string toEncrypt;
            byte[] encrypted;
            try
            {
                using (StreamReader sr = new StreamReader(globalFilePath))
                {
                    toEncrypt = sr.ReadToEnd();
                }
                if (EncryptionTypteCB.Text == "AES")
                {
                    encrypted = AESEncrypt(int.Parse(KeyLengthCB.Text), globalFilePath);
                    MessageBox.Show("Datoteka je bila uspešno šifrirana in shranjena v \n" + globalFilePath + ".aes");
                }
                else
                {
                    encrypted = RSAEncrypt(toEncrypt, int.Parse(KeyLengthCB.Text));
                    MessageBox.Show("Datoteka je bila uspešno šifrirana in shranjena v \n" + globalFilePath + ".rsa");
                }

                globalEncrypted = encrypted;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Poskus šifriranja ni uspel\n\nPodrobnosti\n" + exception.Message);
            }

        }

        private void SaveKeyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EncryptionTypteCB.Text == "AES")
            {
                SaveAESKey(AESkey, AESiv);
            }
            else
                SaveRSAKey();
        }

        private void AddRSAKey_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "|*.rsaKey";
            if (ofd.ShowDialog() == true)
            {

                try
                {
                    string keyString = GetStringFromPath(ofd.FileName);
                    GetRSAKeyFromString(keyString);
                    if (globalFilePath != null && globalFilePath.Length > 0)
                    {
                        Decipher.IsEnabled = true;
                    }

                    keyAdded.Content = "Dodan ključ: RSA";
                }
                catch (Exception exception)
                {

                    MessageBox.Show("Uvoz ključa ni uspel\n\nPodrobnosti:\n" + exception.Message);
                }
            }
        }

        private void AddAESKey_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "|*.aesKey";
            if (ofd.ShowDialog() == true)
            {
                try
                {
                    GetAESKeyFromString(ofd.FileName);
                    if (globalFilePath != null && globalFilePath.Length > 0)
                    {
                        Decipher.IsEnabled = true;
                    }
                    keyAdded.Content = "Dodan ključ: AES";
                }
                catch (Exception exception)
                {

                    MessageBox.Show("Uvoz ključa ni uspel\n\nPodrobnosti:\n" + exception.Message);
                }

            }
        }

        private void Decipher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EncryptionTypteCB.Text == "AES")
                {
                    AESDecrypt(globalFilePath);
                }
                else
                    RSADecrypt(globalFilePath);

                MessageBox.Show("Datoteka je bila uspešno dešifrirana in shranjena v \n" + globalFilePath.Substring(globalFilePath.Length - 4));

            }
            catch (Exception exception)
            {

                MessageBox.Show("Poskus dešifriranja ni uspel\n\nPodrobnosti\n" + exception.Message);
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        private byte[] GetAllBytesFromGlobalFilePath()
        {
            return File.ReadAllBytes(globalFilePath);
        }

        HashTypes hashType = 0;

        //enum HashTypes
        //{
        //    MD5,
        //    SHA1,
        //    SHA256,
        //    bCrypt
        //}

        private byte[] MD5Hash()
        {
            byte[] hash;
            byte[] from = GetAllBytesFromGlobalFilePath();

            using (MD5 md5 = MD5.Create())
                hash = md5.ComputeHash(from);
            return hash;
        }
        private byte[] MD5Hash(byte[] from)
        {
            byte[] hash;
            //byte[] from = GetAllBytesFromGlobalFilePath();

            using (MD5 md5 = MD5.Create())
                hash = md5.ComputeHash(from);
            return hash;
        }


        private byte[] SHA1Hash()
        {
            byte[] hash;
            byte[] from = GetAllBytesFromGlobalFilePath();

            using (SHA1 sha = SHA1.Create())
                hash = sha.ComputeHash(from);
            return hash;
        }
        private byte[] SHA1Hash(byte[] from)
        {
            byte[] hash;
            //byte[] from = GetAllBytesFromGlobalFilePath();

            using (SHA1 sha = SHA1.Create())
                hash = sha.ComputeHash(from);
            return hash;
        }

        private byte[] SHA256Hash()
        {
            byte[] hash;
            byte[] from = GetAllBytesFromGlobalFilePath();

            using (SHA256 sha = SHA256.Create())
                hash = sha.ComputeHash(from);
            return hash;
        }
        private byte[] SHA256Hash(byte[] from)
        {
            byte[] hash;
            //byte[] from = GetAllBytesFromGlobalFilePath();

            using (SHA256 sha = SHA256.Create())
                hash = sha.ComputeHash(from);
            return hash;
        }

        private byte[] BCryptHash(int iterations = 10)
        {
            byte[] hash;
            byte[] from = GetAllBytesFromGlobalFilePath();

            string fromString = Encoding.UTF8.GetString(from);
            string hashString;

            hashString = BCrypt.Net.BCrypt.HashPassword(fromString, iterations);

            hash = Encoding.UTF8.GetBytes(hashString);

            return hash;
        }
        private byte[] BCryptHash(byte[] from, int iterations = 10)
        {
            byte[] hash;
            //byte[] from = GetAllBytesFromGlobalFilePath();

            string fromString = Encoding.UTF8.GetString(from);
            string hashString;

            hashString = BCrypt.Net.BCrypt.HashPassword(fromString, iterations);

            hash = Encoding.UTF8.GetBytes(hashString);

            return hash;
        }

        private void HashTypteCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            hashType = (HashTypes)HashTypteCB.SelectedIndex;

            if (hashType == HashTypes.bCrypt)
            {
                IterationLabel.Visibility = Visibility.Visible;
                IterationsInt.Visibility = Visibility.Visible;
            }
            else
            {
                if (IterationLabel != null && IterationsInt != null)
                {
                    IterationLabel.Visibility = Visibility.Hidden;
                    IterationsInt.Visibility = Visibility.Hidden;
                }
            }
        }

        private void HashButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] hashed = HashMethodRename();
            string hashedString = BitConverter.ToString(hashed).Replace("-", string.Empty);

            HashedValueTB.Text = "Zgoščena vrednost: \n" + hashedString;


        }

        private byte[] HashMethodRename()
        {
            byte[] hashed = { };
            switch (hashType)
            {
                case HashTypes.MD5:
                    hashed = MD5Hash();
                    break;
                case HashTypes.SHA1:
                    hashed = SHA1Hash();
                    break;
                case HashTypes.SHA256:
                    hashed = SHA256Hash();
                    break;
                case HashTypes.bCrypt:
                    hashed = BCryptHash(int.Parse(IterationsInt.Text));
                    break;
            }

            return hashed;
        }
        private byte[] HashMethodRename(byte[] from)
        {
            byte[] hashed = { };
            switch (hashType)
            {
                case HashTypes.MD5:
                    hashed = MD5Hash(from);
                    break;
                case HashTypes.SHA1:
                    hashed = SHA1Hash(from);
                    break;
                case HashTypes.SHA256:
                    hashed = SHA256Hash(from);
                    break;
                case HashTypes.bCrypt:
                    hashed = BCryptHash(from, int.Parse(IterationsInt.Text));
                    break;
            }

            return hashed;
        }
        private byte[] HashMethodRename(byte[] from, HashTypes hashType)
        {
            byte[] hashed = { };
            switch (hashType)
            {
                case HashTypes.MD5:
                    hashed = MD5Hash(from);
                    break;
                case HashTypes.SHA1:
                    hashed = SHA1Hash(from);
                    break;
                case HashTypes.SHA256:
                    hashed = SHA256Hash(from);
                    break;
                case HashTypes.bCrypt:
                    hashed = BCryptHash(from, int.Parse(IterationsInt.Text));
                    break;
            }

            return hashed;
        }
        private byte[] HashMethodRename(byte[] from, HashTypes hashType, int numberOfIterations)
        {
            byte[] hashed = { };
            switch (hashType)
            {
                case HashTypes.MD5:
                    hashed = MD5Hash(from);
                    break;
                case HashTypes.SHA1:
                    hashed = SHA1Hash(from);
                    break;
                case HashTypes.SHA256:
                    hashed = SHA256Hash(from);
                    break;
                case HashTypes.bCrypt:
                    hashed = BCryptHash(from, numberOfIterations);
                    break;
            }

            return hashed;
        }


        private void CheckPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (!TextBoxesEmpty())
            {
                MessageBox.Show("Vnesite vse potrebne parametre");
                return;
            }

            try
            {
                User user;

                using (UserContext context = new UserContext())
                {
                    user = context.Users.Where(user => user.UserName == UserNameTB.Text).Single();
                }
                string password = PasswordTB.Password;
                string salt = user.Salt;
                string passwordPlusSalt = password + salt;
                byte[] toHash = Encoding.UTF8.GetBytes(passwordPlusSalt);

                byte[] hashed = { };
                if (user.Algorithm == HashTypes.bCrypt)
                {
                    hashed = HashMethodRename(toHash, user.Algorithm, user.NumberOfIterations);
                }
                else
                    hashed = HashMethodRename(toHash, user.Algorithm);

                string hashedString = BitConverter.ToString(hashed).Replace("-", string.Empty);


                if (hashedString == user.HashedValue)
                {

                    MessageBox.Show($"Uporabnik z uporabniškim imenom {user.UserName} najden");
                }
                else
                    MessageBox.Show($"Uporabnik z uporabniškim imenom {user.UserName} ni najden");
            }
            catch (Exception)
            {
                MessageBox.Show($"Uporabnik ni bil najden");
            }


        }

        private bool TextBoxesEmpty()
        {
            return (UserNameTB.Text.Length > 0 && PasswordTB.Password.Length > 0);
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (!TextBoxesEmpty())
            {
                MessageBox.Show("Vnesite vse potrebne parametre");
                return;
            }


            string password = PasswordTB.Password;
            string salt = GenerateSalt();
            string passwordPlusSalt = password + salt;
            byte[] toHash = Encoding.UTF8.GetBytes(passwordPlusSalt);
            byte[] hashed = HashMethodRename(toHash);
            if (hashType == HashTypes.bCrypt)
            {
                hashed = HashMethodRename(toHash, hashType, int.Parse(IterationsInt.Text));
            }
            string hashedString = BitConverter.ToString(hashed).Replace("-", string.Empty);

            using (UserContext context = new UserContext())
            {
                try
                {
                    if (hashType == HashTypes.bCrypt)
                    {
                        int numberOfITerations = int.Parse(IterationsInt.Text);
                        context.Users.Add(new User(UserNameTB.Text, hashedString, salt, hashType, numberOfITerations));
                    }
                    else
                        context.Users.Add(new User(UserNameTB.Text, hashedString, salt, hashType));

                    context.SaveChanges();
                    MessageBox.Show("Uspešno dodan uporabnik");
                }
                catch (DbUpdateException)
                {
                    MessageBox.Show("Uporabnik s tem uporabniškim imenom že obstaja");
                }
                catch (Exception)
                {
                    MessageBox.Show("Prišlo je do ne znane napake");
                }
            }
        }

        public string GenerateSalt(int length = 10)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnoprstuvzxyq0123456789";
            string salt = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return salt;
        }
    }



    public class UserContext : DbContext
    {
        public UserContext() : base("Users")
        {
            Database.SetInitializer<UserContext>(new BazaInitializier());
        }

        public DbSet<User> Users { get; set; }

    }




    public class BazaInitializier : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            base.Seed(context);
        }
    }
}
