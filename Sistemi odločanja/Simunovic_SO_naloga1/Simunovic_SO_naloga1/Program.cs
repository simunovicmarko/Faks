using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Simunovic_SO_naloga1
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
        static void Main(string[] args)
        {
            List<string> lines = ReadCSV("prodaja.csv");
            List<int[]> numberLines = new List<int[]>();
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
        }

        static void Output(int [,] matrix, List<string> alternatives)
        {
            Console.WriteLine("Optimist " + Optimist(matrix, alternatives));
            Console.WriteLine("Pesimist " + Pesimist(matrix, alternatives));
            Console.WriteLine("Laplace  " + Laplace(matrix, alternatives));
            Console.WriteLine("Savage   " + Savage(matrix, alternatives));
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




            float d = 0;
            Console.Write("h    ");
            foreach (var item in alts)
            {
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
                    Console.Write("{0:0.00##}         ", number);
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
                results.Add(res);
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

        static int[,] TransponeMatrix(int[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            int[,] result = new int[h, w];

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
            List<List<int>> parsedValues = new List<List<int>>();
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
