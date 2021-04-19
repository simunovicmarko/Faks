using System.Collections.Generic;

namespace Simunovic_SO_Naloga2
{
    class Alternative
    {
        public Alternative() { }
        public Alternative(string name)
        {
            //this.Points = points;k
            this.Name = name;
        }

        public Alternative(string name, List<Parameter> parameters)
        {
            Name = name;
            Parameters = parameters;
        }

        public string Name { get; set; }

        //public int Points { get; set; }

        public List<Parameter> Parameters { get; set; }

        public IEnumerable<ParamterAndPoints> GetParamterAndPoints()
        {
            foreach (var paramter in Parameters)
            {
                ParamterAndPoints paramterAndPoint = new ParamterAndPoints();
                paramterAndPoint.parameter = paramter;
                paramterAndPoint.point = 0;
                yield return paramterAndPoint;
            }
        }


    }

    struct ParamterAndPoints
    {
        public Parameter parameter;
        public int point;
    }
}
