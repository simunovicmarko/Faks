using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SO_Simunovic_Naloga1
{

    struct ReturnValue
    {
        public string name;
        public int value;

        public override string ToString()
        {
            return name + "(" + value + ")";
        }
    }
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ".csv|*.csv";
            ofd.Multiselect = false;
            string fileName = "prodaja.csv";

            //Lines from CSV
            List<string> lines = new List<string>();

            if (ofd.ShowDialog() == DialogResult.OK)
                fileName = ofd.FileName;

            lines = ReadCSV(fileName);
            Console.WriteLine($"Prebrano iz datoteke {fileName} \n");


            //Parsed lines into numbers
            List<int[]> numberLines = new List<int[]>();

            //Alternative names
            List<string> alternatives = new List<string>();

            int[,] matrix;

            //Get numbers and alternative names
            bool first = true;
            foreach (var line in lines)
            {
                if (!first)
                    numberLines.Add(SplitAndParse(line));
                else
                {
                    alternatives = getAlternatives(line);
                    first = false;
                }
            }


            matrix = BuildMatrix(numberLines, alternatives.Count);

            Output(matrix, alternatives);
            Visualise(matrix, alternatives);

            Console.ReadKey();
        }

        static void Visualise(int[,] matrix, List<string> alts)
        {
            Chart chart = new Chart();
            chart.ChartAreas.Add("Area");
            chart.ChartAreas["Area"].AxisX.Minimum = 0;
            chart.ChartAreas["Area"].AxisX.Maximum = 1;
            chart.ChartAreas["Area"].AxisX.Interval = 0.1;
            chart.ChartAreas["Area"].AxisX.Title = "h";
            chart.ChartAreas["Area"].AxisY.Title = "Vrednost alternativ";
            chart.Titles.Add("Vrednotenje s Hurwiczevim kriterijem");


            Legend legend = new Legend();
            legend.Name = "Legenda";
            legend.IsDockedInsideChartArea = true;
            legend.Docking = Docking.Right;
            chart.Legends.Add(legend);


            double[,] result = new double[11, matrix.GetLength(1)];
            int st = 0;
            //Getting the result matrix
            for (double i = 0; i <= 1; i += 0.1)
            {
                double[] temp = (HurwiczToArray(matrix, i));
                for (int j = 0; j < temp.Length; j++)
                {
                    result[st, j] = temp[j];
                }
                st++;
            }

            result = TransponeMatrix(result);

            //Adding to chart
            for (int i = 0; i < result.GetLength(0); i++)
            {
                chart.Series.Add(alts.ElementAt(i));
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    chart.Series[alts.ElementAt(i)].Points.AddXY(j / 10.0, result[i, j]);
                }
                chart.Series[alts.ElementAt(i)].ChartType = SeriesChartType.Line;
                chart.Series[alts.ElementAt(i)].MarkerStyle = MarkerStyle.Circle;
                chart.Series[alts.ElementAt(i)].MarkerSize = 10;
            }

            chart.Width = 1000;
            chart.Height = 500;
            chart.SaveImage("Chart.png", ChartImageFormat.Png);
            Console.WriteLine();
            Console.WriteLine("Graf Hurwitzovega kriterija je bil shranjen v datoteko chart.png.");
        }

        static void Output(int[,] matrix, List<string> alternatives)
        {
            Console.WriteLine("Optimist " + Optimist(matrix, alternatives));
            Console.WriteLine("Pesimist " + Pesimist(matrix, alternatives));
            Console.WriteLine("Laplace  " + Laplace(matrix, alternatives));
            Console.WriteLine("Savage   " + Savage(matrix, alternatives));
            Console.WriteLine();
            Console.WriteLine("Hurwiczov kriterij");
            CallHurwicz(matrix, alternatives);

        }

        static void CallHurwicz(int[,] matrix, List<string> alts)
        {
            List<List<double>> resultMatrix = new List<List<double>>();
            for (double i = 0; i <= 1; i += 0.1)
            {
                resultMatrix.Add(Hurwicz(matrix, i));
            }

            int maxLength = int.MinValue;
            foreach (var item in alts)
                if (item.Length > maxLength)
                    maxLength = item.Length;

            foreach (var item in resultMatrix)
                foreach (var num in item)
                    if (num.ToString("0.00").Length > maxLength)
                        maxLength = num.ToString("0.00").Length;




            float d = 0;
            Console.Write("h    ");
            foreach (var item in alts)
            {
                //Setting all outputs to same length and outputting
                string temp = item;
                while (temp.Length < maxLength)
                {
                    temp += " ";
                }
                Console.Write(temp + "  ");
            }
            Console.WriteLine();
            foreach (var line in resultMatrix)
            {
                Console.Write("{0:0.0##}   ", d);
                foreach (double number in line)
                {
                    //Setting all outputs to same length and outputting
                    string temp = number.ToString("0.00");
                    while (temp.Length < maxLength)
                    {
                        temp += " ";
                    }
                    Console.Write(temp + "  ");
                }
                Console.WriteLine();
                d += 0.1f;
            }
        }

        static List<double> Hurwicz(int[,] matrix, double h)
        {
            matrix = TransponeMatrix(matrix);
            List<double> results = new List<double>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxInRow = int.MinValue;
                //Find max value in row
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxInRow)
                    {
                        maxInRow = matrix[i, j];
                    }
                }
                double res = 0;
                //If element is the same as max in row calculate it time the h. Else calculate it time 1 - h
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != maxInRow)
                    {
                        res += matrix[i, j] * (1 - h);
                    }
                    else
                        res += matrix[i, j] * h;
                }
                results.Add(res);
            }
            return results;
        }

        static double[] HurwiczToArray(int[,] matrix, double h)
        {
            matrix = TransponeMatrix(matrix);
            double[] results = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxInRow = int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxInRow)
                    {
                        maxInRow = matrix[i, j];
                    }
                }
                double res = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != maxInRow)
                    {
                        res += matrix[i, j] * (1 - h);
                    }
                    else
                        res += matrix[i, j] * h;
                }
                results[i] = res;
            }
            return results;
        }

        static ReturnValue Optimist(int[,] matrix, List<string> alts)
        {
            List<int> numbers = new List<int>();
            int[,] transposed = TransponeMatrix(matrix);

            for (int i = 0; i < transposed.GetLength(0); i++)
            {
                int max = 0;
                for (int j = 0; j < transposed.GetLength(1); j++)
                {
                    if (transposed[i, j] > max)
                    {
                        max = transposed[i, j];
                    }
                }
                numbers.Add(max);
            }

            int maximum = numbers.Max();
            int altIndex = numbers.IndexOf(maximum);
            ReturnValue rv = new ReturnValue();
            rv.value = maximum;
            rv.name = alts.ElementAt(altIndex);
            return rv;
        }

        static ReturnValue Pesimist(int[,] matrix, List<string> alts)
        {
            List<int> numbers = new List<int>();
            int[,] transposed = TransponeMatrix(matrix);

            for (int i = 0; i < transposed.GetLength(0); i++)
            {
                int min = int.MaxValue;
                for (int j = 0; j < transposed.GetLength(1); j++)
                {
                    if (transposed[i, j] < min)
                    {
                        min = transposed[i, j];
                    }
                }
                numbers.Add(min);
            }

            int maximum = numbers.Max();
            int altIndex = numbers.IndexOf(maximum);
            ReturnValue rv = new ReturnValue();
            rv.value = maximum;
            rv.name = alts.ElementAt(altIndex);
            return rv;
        }

        static ReturnValue Laplace(int[,] matrix, List<string> alts)
        {
            List<int> numbers = new List<int>();
            int[,] transposed = TransponeMatrix(matrix);

            for (int i = 0; i < transposed.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < transposed.GetLength(1); j++)
                {
                    sum += transposed[i, j];
                }
                numbers.Add(sum / transposed.GetLength(1));
            }
            int maximum = numbers.Max();
            int altIndex = numbers.IndexOf(maximum);
            ReturnValue rv = new ReturnValue();
            rv.value = maximum;
            rv.name = alts.ElementAt(altIndex);
            return rv;
        }


        static ReturnValue Savage(int[,] matrix, List<string> alts)
        {
            int[,] regrets = new int[matrix.GetLength(0), matrix.GetLength(1)];
            List<int> leastRegrets = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                List<int> numbers = new List<int>();
                int maxInRow = int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxInRow)
                    {
                        maxInRow = matrix[i, j];
                    }
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    //numbers.Add(maxInRow - matrix[i, j]);
                    regrets[i, j] = maxInRow - matrix[i, j];
                }
            }

            int[,] transposedRegrets = TransponeMatrix(regrets);
            for (int i = 0; i < transposedRegrets.GetLength(0); i++)
            {
                int best = int.MinValue;
                for (int j = 0; j < transposedRegrets.GetLength(1); j++)
                {
                    if (transposedRegrets[i, j] > best)
                    {
                        best = transposedRegrets[i, j];
                    }
                }
                leastRegrets.Add(best);
            }

            int minimum = leastRegrets.Min();
            int altIndex = leastRegrets.IndexOf(minimum);
            ReturnValue rv = new ReturnValue();
            rv.value = minimum;
            rv.name = alts.ElementAt(altIndex);
            return rv;
        }

        static int Optimist(int[,] matrix)
        {
            List<int> numbers = new List<int>();
            int[,] transposed = TransponeMatrix(matrix);

            for (int i = 0; i < transposed.GetLength(0); i++)
            {
                int max = 0;
                for (int j = 0; j < transposed.GetLength(1); j++)
                {
                    if (transposed[i, j] > max)
                    {
                        max = transposed[i, j];
                    }
                }
                numbers.Add(max);
            }
            return numbers.Max();
        }

        static int Pesimist(int[,] matrix)
        {
            List<int> numbers = new List<int>();
            int[,] transposed = TransponeMatrix(matrix);

            for (int i = 0; i < transposed.GetLength(0); i++)
            {
                int min = int.MaxValue;
                for (int j = 0; j < transposed.GetLength(1); j++)
                {
                    if (transposed[i, j] < min)
                    {
                        min = transposed[i, j];
                    }
                }
                numbers.Add(min);
            }

            return numbers.Max();
        }

        static int Laplace(int[,] matrix)
        {
            List<int> numbers = new List<int>();

            int[,] transposed = TransponeMatrix(matrix);

            for (int i = 0; i < transposed.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < transposed.GetLength(1); j++)
                {
                    sum += transposed[i, j];
                }
                numbers.Add(sum / transposed.GetLength(1));
            }

            return numbers.Max();
        }


        static int Savage(int[,] matrix)
        {
            int[,] regrets = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int[] leastRegrets = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                List<int> numbers = new List<int>();
                int maxInRow = int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxInRow)
                    {
                        maxInRow = matrix[i, j];
                    }
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    //numbers.Add(maxInRow - matrix[i, j]);
                    regrets[i, j] = maxInRow - matrix[i, j];
                }
            }

            int[,] transposedRegrets = TransponeMatrix(regrets);
            for (int i = 0; i < transposedRegrets.GetLength(0); i++)
            {
                int best = int.MinValue;
                for (int j = 0; j < transposedRegrets.GetLength(1); j++)
                {
                    if (transposedRegrets[i, j] > best)
                    {
                        best = transposedRegrets[i, j];
                    }
                }
                leastRegrets[i] = best;
            }

            return leastRegrets.Min();
        }


        static int[,] BuildMatrix(List<int[]> numberList, int width)
        {
            int[,] matrix = new int[numberList.Count, width];
            for (int i = 0; i < numberList.Count; i++)
            {
                for (int j = 0; j < numberList[i].Length; j++)
                    matrix[i, j] = numberList[i][j];
            }
            return matrix;
        }

        static T[,] TransponeMatrix<T>(T[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            T[,] result = new T[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                    result[j, i] = matrix[i, j];
            }

            return result;
        }
        static List<string> ReadCSV(string pot)
        {
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(pot))
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
            }
            return lines;
        }

        static List<string> getAlternatives(string line)
        {
            List<string> alts = new List<string>();
            var cols = line.Split(',');

            bool first = true;
            foreach (var col in cols)
            {
                if (!first)
                {
                    alts.Add(col);
                }
                else
                    first = false;
            }

            return alts;
        }
        static int[] SplitAndParse(string line)
        {
            string[] values = line.Split(',');
            int[] numbers = new int[values.Length - 1];
            for (int i = 1; i < values.Length; i++)
            {
                numbers[i - 1] = int.Parse(values[i]);
            }
            return numbers;
        }
    }
}

