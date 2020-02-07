/*
Download initial movie data file
Create movie Console Application to see all movies in the file and to add movies to the file Check for duplicate values!
Implement Exception Handling
Implement NLog framework
*/



using System;
using NLog;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace NLogExample
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            /*
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
            */
       
            // Why is my program.cs not going to git?

            List<Movies> movies = LoadMovies();

            int selection = 0;
            do
            {
                selection = MainMenu();
                if (selection == 1)
                {
                    Console.Clear();
                    movies = ViewMovies(movies);
                }
                if (selection == 2)
                {
                    Console.Clear();
                    movies = CreateMovie(movies);
                    SaveMovie(movies);
                }
            } while (selection != 5);


        }


        static int MainMenu()
        {
            int selection = 0;

            Console.WriteLine("    What would you like to do?\n\n" +
                "    1) View Movies\n" +
                "    2) Add Movies\n" +
                "    5) Quit");

            Console.Write("    ");
            string resp = Console.ReadLine();
            while (!Int32.TryParse(resp, out selection) || (selection < 0 || selection > 9))
            {
                Console.Write("    Please Enter a valid response 1 - 5 ");
                resp = Console.ReadLine();
            }
            Console.Clear();
            return selection;
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

        static List<Movies> ViewMovies(List<Movies> movies)
        {

            string movieFormat = "{0,-10}\t{1,-50}\t{2,-50}";

            foreach (Movies m in movies)
            {
                string title;
                if (m.GetTitle().Length > 50)
                {
                    title = m.GetTitle().Remove(46) + "...";
                }
                else
                {
                    title = m.GetTitle();
                }
                Console.WriteLine(movieFormat, m.GetMovideID(), title, m.GetGenre());
            }

            Console.WriteLine("    Press any key to return to the main menu...");
            Console.ReadLine();
            Console.Clear();

            return movies;
        }


        static List<Movies> CreateMovie(List<Movies> movie)
        {
            List<string> duplicateTitle = new List<string>();
            foreach (Movies m in movie)
            {
                duplicateTitle.Add(m.GetTitle().ToUpper());
            }


            Console.WriteLine("    Please enter the Movie Title:");
            string title = Console.ReadLine();


            while(duplicateTitle.Contains(title.ToUpper()))
            {
                Console.WriteLine("    " + title + " Already exists in the database. Please enter a new movie!");
                title = Console.ReadLine();
            }

            Console.WriteLine("    Please enter the Movie Genre:");
            string genre = Console.ReadLine();

            int ticketID = 0;
            foreach (Movies m in movie)
            {
                ticketID = movie.Max(a => a.GetMovideID()) + 1;
            }

            Movies newMovie = new Movies(ticketID, title, genre);
            movie.Add(newMovie);

            return movie;
        }

        static void SaveMovie(List<Movies> movie)
        {
            StreamWriter newMovie = new StreamWriter("movies.csv");
            foreach (Movies m in movie)
            {
                string mv = m.ToString();
                newMovie.WriteLine(movie);
            }
            newMovie.Close();
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
