using System.Data.Entity;


namespace Naloga1_DotNET
{
    //[DataContract]
    public class TriatlonContext : DbContext
    {

        public TriatlonContext() : base("Triatlon")
        {
            Database.SetInitializer<TriatlonContext>(new BazaInitializier());
        }

        public DbSet<Results> Results { get; set; }
        public DbSet<Competition> competitions { get; set; }
        public DbSet<User> users { get; set; }

    }

    public class BazaInitializier : DropCreateDatabaseIfModelChanges<TriatlonContext>
    {
        protected override void Seed(TriatlonContext context)
        {
            base.Seed(context);
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