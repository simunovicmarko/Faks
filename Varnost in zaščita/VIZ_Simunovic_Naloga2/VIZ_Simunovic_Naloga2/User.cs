using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIZ_Simunovic_Naloga2
{
    public class User
    {

        public User() { }

        public User(string userName, string hashedValue, string salt, HashTypes algorithm)
        {
            UserName = userName;
            HashedValue = hashedValue;
            Salt = salt;
            Algorithm = algorithm;
        }

        public User(string userName, string hashedValue, string salt, HashTypes algorithm, int numberOfIterations = 10)
        {
            UserName = userName;
            HashedValue = hashedValue;
            Salt = salt;
            Algorithm = algorithm;
            NumberOfIterations = numberOfIterations;
        }

        [Key]
        public int ID { get; set; }

        [Index("UserNameIndex",IsUnique = true)]
        [MaxLength(200)]
        public string UserName { get; set; }
        public string HashedValue { get; set; }
        public string Salt { get; set; }
        public HashTypes Algorithm { get; set; }

        public int NumberOfIterations { get; set; }
    }
}
