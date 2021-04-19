using Simunovic_SO_Naloga2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_TaJePraviUnNEDela
{
    class ViewModel
    {
        public List<DisplayValue> Data { get; set; }

        public ViewModel(Dictionary<Alternative, int> values)
        {
            Data = new List<DisplayValue>();
            if (values != null)
            {
                foreach (var item in values)
                {
                    Data.Add(new DisplayValue(item.Key.Name, item.Value));
                }
            }
        }

    }
    class ViewModelParam
    {
        public List<DisplayValue> Data { get; set; }

        public ViewModelParam(List<Parameter> parameters)
        {
            Data = new List<DisplayValue>();
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    Data.Add(new DisplayValue(item.Name, item.Weight));
                }
            }
        }

    }
    class ViewModelLine
    {
        public List<DisplayValueLine> Data { get; set; }

       

        public ViewModelLine()
        {
            Data = new List<DisplayValueLine>();
        }

    }

    class DisplayValue
    {
        public DisplayValue(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public int Value { get; set; }
    }

    class DisplayValueLine
    {
        public DisplayValueLine(int valueX, int valueY)
        {
            ValueX = valueX;
            ValueY = valueY;
        }

        public int ValueX { get; set; }
        public int ValueY { get; set; }
    }
}
