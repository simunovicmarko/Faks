namespace Simunovic_SO_Naloga2
{
    class Parameter
    {
        public Parameter()
        {

        }
        public Parameter(int weight, string name)
        {
            this.Weight = weight;
            this.Name = name;
        }

        public override string ToString()
        {
            return Name + "\n" + Weight;
        }


        public string Name { get; set; }
        public int Weight { get; set; }
    }
}
