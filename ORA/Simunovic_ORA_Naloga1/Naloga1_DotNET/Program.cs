using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.Entity;
using System.Runtime.Serialization;
using System.Threading;


namespace Naloga1_DotNET
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                //TriatlonContext context = new TriatlonContext();
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = ".csv|*.csv";
                ofd.Multiselect = true;
                //StreamWriter sw = new StreamWriter("commands.sql");
                int fileCounter = 0;
                int resultCounter = 0;


                List<Results> results = new List<Results>();
                List<Competition> Competitions = new List<Competition>();
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                int lastInserted = resultCounter;
                int counter = 0;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    watch = System.Diagnostics.Stopwatch.StartNew();
                    foreach (var fileName in ofd.FileNames)
                    {
                        Competition competition = GetCompetition(fileName);

                        ReadCSVAndWriteToFile(fileName, ref resultCounter, ref results, ref competition);

                        fileCounter++;
                        Competitions.Add(competition);

                        counter++;
                        if (resultCounter >= lastInserted + 10000 || counter == ofd.FileNames.Length)
                        {
                            using (TriatlonContext context = new TriatlonContext())
                            {
                                context.Results.AddRange(results);
                                context.competitions.AddRange(Competitions);
                                Console.WriteLine("Inserted " + results.Count);
                                results.Clear();
                                Competitions.Clear();
                                lastInserted = resultCounter;
                                context.SaveChanges();
                            }
                        }
                    }
                    watch.Stop();
                }
                else run = false;


                Console.WriteLine($"Files read {fileCounter}");
                Console.WriteLine($"Results read {resultCounter}");
                Console.WriteLine($"Time taken {watch.ElapsedMilliseconds / 1000.0} seconds");
            }
            //sw.WriteLine($"Time passed {executionTime}");
        }



        static string[] SplitAndParse(string line)
        {
            string[] values = line.Split(',');
            return values;
        }


        static Competition GetCompetition(string path)
        {
            string name = "";
            int index = 0;
            for (int i = path.Length - 1; i > 0; i--)
            {
                //Console.WriteLine(path[i]);
                if (path[i] == '\\')
                {
                    index = i + 1;
                    break;
                }
            }

            name = path.Substring(index);
            name = name.Substring(0, name.Length - 4);
            string[] strings = name.Split('_');

            return new Competition(strings[1], strings[2]);
        }




        static void ReadCSVAndWriteToFile(string path, ref int resultCounter, ref List<Results> results, ref Competition competition)
        {
            List<string> lines = new List<string>();
            bool first = true;
            //List<Results> resultss = new List<Results>();

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string[] values = SplitAndParse(reader.ReadLine());
                    if (!first)
                    {

                        if (values.Length == 20)
                        {
                            //string name, genderRank, divRank, overallRank, bib, division, age, state, country, profession, points, swim, swimDistance, t1, bike, bikeDistance, t2, run, runDistance, overall;


                            for (int i = 0; i < values.Length; i++)
                            {
                                if (values[i] == "---")
                                {
                                    values[i] = null;
                                }
                            }

                            Results results1 = new Results(values);
                            //results1.Competitions.Add(competition);
                            results1.competition = competition;
                            results.Add(results1);
                            //competition.results.Add(results1);
                            //competition.results.Add(results1);
                        }
                        resultCounter++;
                    }
                    else first = false;
                }

                //foreach (var res in resultss)
                //{
                //    context.Results.Add(res);
                //    context.Results.
                //}
                //context.Results.AddRange(resultss);
                //context.SaveChanges();
            }
        }
    }




    
}


//static void ReadCSVAndWriteToFile(string path, StreamWriter sw, ref int resultCounter, MySqlConnection connection)
//{
//    List<string> lines = new List<string>();
//    bool first = true;
//    //List<MySqlCommand> commands = new List<MySqlCommand>();

//    //connection.Open();


//    //string ret = "";
//    using (StreamReader reader = new StreamReader(path))
//    {
//        while (!reader.EndOfStream)
//        {
//            string[] values = SplitAndParse(reader.ReadLine());
//            if (!first)
//            {

//                if (values.Length == 20)
//                {
//                    string name, genderRank, divRank, overallRank, bib, division, age, state, country, profession, points, swim, swimDistance, t1, bike, bikeDistance, t2, run, runDistance, overall;


//                    for (int i = 0; i < values.Length; i++)
//                    {
//                        if (values[i] == "---")
//                        {
//                            values[i] = "null";
//                        }
//                    }

//                    name = values[0];
//                    genderRank = values[1];
//                    divRank = values[2];
//                    overallRank = values[3];
//                    bib = values[4];
//                    division = values[5];
//                    age = values[6];
//                    state = values[7];
//                    country = values[8];
//                    profession = values[9];
//                    points = values[10];
//                    swim = values[11];
//                    swimDistance = values[12];
//                    t1 = values[13];
//                    bike = values[14];
//                    bikeDistance = values[15];
//                    t2 = values[16];
//                    run = values[17];
//                    runDistance = values[18];
//                    overall = values[19];

//                    //string mainQuerry = $"insert into Results(name, gender_rank, div_rank, overall_rank, bib, division, age, state, country, profession, points, swim, swim_distance, t1,bike, bike_distance, t2, run, run_distance, overall) values " +
//                    //    $"('{name}', '{genderRank}', '{divRank}', '{overallRank}', '{bib}', '{division}', '{age}', '{state}', '{country}', '{profession}', '{points}', '{swim}', '{swimDistance}', '{t1}'," +
//                    //    $" '{bike}', '{bikeDistance}', '{t2}', '{run}', '{runDistance}', '{overall}');";

//                    string mainQuerry = $"insert into Results(name, gender_rank, div_rank, overall_rank, bib, division, age, state, country, profession, points, swim, swim_distance, t1,bike, bike_distance, t2, run, run_distance, overall) values " +
//                      "(@name, @genderRank, @divRank, @overallRank, @bib, @division, @age, @state, @country, @profession, @points, @swim, @swimDistance, @t1, @bike, @bikeDistance, @t2, @run, @runDistance, @overall)";


//                    MySqlCommand command = new MySqlCommand();

//                    command.CommandText = mainQuerry;
//                    command.Connection = connection;
//                    command.Parameters.AddWithValue("@name", name);
//                    command.Parameters.AddWithValue("@genderRank", genderRank);
//                    command.Parameters.AddWithValue("@divRank", divRank);
//                    command.Parameters.AddWithValue("@overallRank", overallRank);
//                    command.Parameters.AddWithValue("@bib", bib);
//                    command.Parameters.AddWithValue("@division", division);
//                    command.Parameters.AddWithValue("@age", age);
//                    command.Parameters.AddWithValue("@state", state);
//                    command.Parameters.AddWithValue("@country", country);
//                    command.Parameters.AddWithValue("@profession", profession);
//                    command.Parameters.AddWithValue("@points", points);
//                    command.Parameters.AddWithValue("@swim", swim);
//                    command.Parameters.AddWithValue("@swimDistance", swimDistance);
//                    command.Parameters.AddWithValue("@t1", t1);
//                    command.Parameters.AddWithValue("@bike", bike);
//                    command.Parameters.AddWithValue("@bikeDistance", bikeDistance);
//                    command.Parameters.AddWithValue("@t2", t2);
//                    command.Parameters.AddWithValue("@run", run);
//                    command.Parameters.AddWithValue("@runDistance", runDistance);
//                    command.Parameters.AddWithValue("@overall", overall);


//                    //command.ExecuteNonQuery();


//                    resultCounter++;

//                    //sw.WriteLine(mainQuerry);
//                    //Console.WriteLine(resultCounter);
//                }
//            }
//            else
//                first = false;
//        }
//    }
//}