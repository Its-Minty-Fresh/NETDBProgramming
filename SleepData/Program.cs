using System;
using System.IO;
using System.Collections.Generic;

namespace SleepData
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // ask for input
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            // input response
            string resp = Console.ReadLine();

            // specify path for data file
            string file = AppDomain.CurrentDomain.BaseDirectory + "data.txt";

            if (resp == "1")
            {
                // create data file

                // ask a question
                Console.WriteLine("How many weeks of data is needed?");
                // input the response (convert to int)
                int weeks = int.Parse(Console.ReadLine());

                // determine start and end date
                DateTime today = DateTime.Now;

                // we want full weeks sunday - saturday
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);

                // subtract # of weeks from endDate to get startDate
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));

                // random number generator
                Random rnd = new Random();

                // create file
                StreamWriter sw = new StreamWriter(file);
                // loop for the desired # of weeks
                while (dataDate < dataEndDate)
                {
                    // 7 days in a week
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {
                        // generate random number of hours slept between 4-12 (inclusive)
                        hours[i] = rnd.Next(4, 13);
                    }
                    // M/d/yyyy,#|#|#|#|#|#|#
                    //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    // add 1 week to date
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();
            }
            else if (resp == "2")
            {
                Console.Clear();
                string dayFormat = "    {0,-3}{1,-3}{2,-3}{3,-3}{4,-3}{5,-3}{6,-3}{7,-4}{8,-4}";

                Console.WriteLine("\n");
                StreamReader sr = new StreamReader(file);
                while (!sr.EndOfStream)
                {

                    string entry = sr.ReadLine();
                    string[] week = entry.Split(',');
                    string[] day = week[1].Split('|');


                    for (int i = 0; i < week.Length - 1; i++)
                    {
                        DateTime date = Convert.ToDateTime(week[0]);
                        Console.WriteLine("  Week of  {0:MMM, dd, yyyy}",date);

                        int total = 0;
                        for (int t = 0; t < day.Length; t++)
                        {
                            total += Int32.Parse(day[t]);
                        }
                        int avg = total / 7;

                        Console.WriteLine(dayFormat, "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa", "Tot","Avg");
                        Console.WriteLine(dayFormat, "--", "--", "--", "--", "--", "--", "--", "---","---");
                        Console.WriteLine(dayFormat, day[0], day[1], day[2], day[3], day[4], day[5], day[6], total, avg);
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
