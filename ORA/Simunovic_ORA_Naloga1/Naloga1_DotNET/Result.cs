using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga1_DotNET
{
    class Result
    {
        int overallRank, points, divRank, bib;
        string transition1, transition2, overall, division, state;
        Athlete athlete;
        Run run;
        Bike bike;


        public Result(int overallRank = 0, int points = 0, int divRank = 0, int bib = 0, string transition1 = "", string transition2 = "", string overall = "", string division = "", string state = "")
        {
            this.OverallRank = overallRank;
            this.Points = points;
            this.DivRank = divRank;
            this.Bib = bib;
            this.Transition1 = transition1;
            this.Transition2 = transition2;
            this.Overall = overall;
            this.Division = division;
            this.State = state;
        }

        public Result(Athlete athlete, Run run, Bike bike, int overallRank = 0, int points = 0, int divRank = 0, int bib = 0, string transition1 = "", string transition2 = "", string overall = "", string division = "", string state = "")
        {
            this.overallRank = overallRank;
            this.points = points;
            this.divRank = divRank;
            this.bib = bib;
            this.transition1 = transition1;
            this.transition2 = transition2;
            this.overall = overall;
            this.division = division;
            this.state = state;
            this.Athlete = athlete;
            this.Run = run;
            this.Bike = bike;
        }

        public int OverallRank { get => overallRank; set => overallRank = value; }
        public int Points { get => points; set => points = value; }
        public int DivRank { get => divRank; set => divRank = value; }
        public int Bib { get => bib; set => bib = value; }
        public string Transition1 { get => transition1; set => transition1 = value; }
        public string Transition2 { get => transition2; set => transition2 = value; }
        public string Overall { get => overall; set => overall = value; }
        public string Division { get => division; set => division = value; }
        public string State { get => state; set => state = value; }
        internal Athlete Athlete { get => athlete; set => athlete = value; }
        internal Run Run { get => run; set => run = value; }
        internal Bike Bike { get => bike; set => bike = value; }
    }
}
