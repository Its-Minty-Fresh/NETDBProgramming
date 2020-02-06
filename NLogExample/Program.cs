using System;
using NLog;
using System.IO;
using System.Collections.Generic;

namespace NLogExample
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // create NLog configuration
            var config = new NLog.Config.LoggingConfiguration();

            // define targets
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "log_file.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // specify minimum log level to maximum log level and target (console, file, etc.)
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);

            // apply NLog configuration
            NLog.LogManager.Configuration = config;

            // create instance of LogManager
            var logger = NLog.LogManager.GetCurrentClassLogger();

            // log sample messages
            logger.Trace("Sample trace message");
            logger.Debug("Sample debug message");
            logger.Info("Sample informational message");
            logger.Warn("Sample warning message");
            logger.Error("Sample error message");
            logger.Fatal("Sample fatal error message");

            // NLog supports structured messages
            var fruit = new[] { "bananas", "apples", "pears" };
            logger.Info("I like to eat {Fruit}", fruit);

            // Example of logging an exception
            try
            {
                int x = 10;
                int y = 0;
                Console.WriteLine(x / y);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            Console.ReadKey();
            Console.ReadLine();

            string movieFormat = "{0,-10}\t{1,-50}\t{2,-50}";
            List<Movies> movies = LoadMovies();

            foreach(Movies m in movies)
            {
                string title;
                if(m.GetTitle().Length > 50)
                {
                    title = m.GetTitle().Remove(46) + "...";
                }
                else
                {
                    title = m.GetTitle();
                }
                Console.WriteLine(movieFormat, m.GetMovideID(), title, m.GetGenre());
            }

            Console.ReadLine();
        }


        static List<Movies> LoadMovies()
        {
            string file = "movies.csv";
            List<Movies> movies = new List<Movies>();
            if (File.Exists(file))
            {
                StreamReader movieReader = new StreamReader(file);
                while (!movieReader.EndOfStream)
                {
                    string movieRow = movieReader.ReadLine();
                    string[] movieAttributes = movieRow.Split(',');
                    int movieID = Int32.Parse(movieAttributes[0]);
                    string title = movieAttributes[1];
                    string genre = movieAttributes[2];

                    Movies movie = new Movies(movieID, title, genre);
                    movies.Add(movie);
                }
                movieReader.Close();
            }
            return movies;
        }

        class Movies
        {
            private int MovieID { get; set; }
            private string Title { get; set; }
            private string Genre { get; set; }


            public Movies()
            {
                this.MovieID = 0;
                this.Title = "";
                this.Genre = "";
            }

            public Movies(int movieID, string title, string genre)
            {
                this.MovieID = movieID;
                this.Title = title;
                this.Genre = genre;
            }

            public void SetMovieID(int movieID)
            {
                this.MovieID = movieID;
            }

            public int GetMovideID()
            {
                return this.MovieID;
            }

            public void SetTitle(string title)
            {
                this.Title = title;
            }

            public string GetTitle()
            {
                return this.Title;
            }

            public void SetGenre(string genre)
            {
                this.Genre = genre;
            }

            public string GetGenre()
            {
                return this.Genre;
            }


            public override string ToString()
            {
                string mv = this.MovieID.ToString();
                mv = mv + ",";
                mv = mv + this.Title;
                mv = mv + ",";
                mv = mv + this.Genre;

                return mv;
            }

        }
    }
}
