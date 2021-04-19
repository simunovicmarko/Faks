using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Simunovic_SO_Naloga2
{
    public class Alternative
    {
        public Alternative() { }
        public Alternative(string name)
        {
            this.Name = name;
        }

        public Alternative(string name, ObservableCollection<Parameter> parameters)
        {
            Name = name;
            Parameters = parameters;
            FillDictionary();
        }

        public string Name { get; set; }

        public int Points { get; set; }

        public ObservableCollection<Parameter> Parameters { get; set; }

        public Dictionary<Parameter, int> ParamPointDictionary = new Dictionary<Parameter, int>();


        private void FillDictionary()
        {
            foreach (var param in Parameters)
            {
                ParamPointDictionary.Add(param, 0);
            }
        }

    }

    
}
