using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleClientForECTServer
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            client.BaseAddress = new Uri("https://localhost:44351/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            UserInterface();
        }

        static async Task CheckAsync(DateIntervalForm form)
        {
            try
            {
                Console.WriteLine("Intersectionals date intervals:");
                var intervals = await GetDateIntervals(form);
                foreach (var i in intervals)
                    Console.WriteLine(i.StartDate + " + " + i.EndDate);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        static async Task AddAsync(DateIntervalForm form)
        {
            try
            {
                Console.WriteLine("Sentdng form to the server...");
                HttpResponseMessage response = await client.PostAsJsonAsync("/Date", form);
                if (response.IsSuccessStatusCode)
                    Console.WriteLine("Sent successful");
                else
                    Console.WriteLine("Something went wrong, try again");
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        static void UserInterface()
        {
            Console.Clear();
            Console.WriteLine("1. Add dates interval into database (enter 'add')");
            Console.WriteLine("2. Check dates intervals for intersection (enter 'check')");
            Console.WriteLine("3. Enter 'quit' to exit the program.");

            switch (Console.ReadLine().ToLower())
            {
                case "add":
                    Add();
                    UserInterface();
                    break;
                case "check":
                    Check();
                    UserInterface();
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                default:
                    UserInterface();
                    break;
            }
        }

        static void Add()
        {
            Console.Clear();

            DateIntervalForm requestForm = DateIntervalFormCreater();
            AddAsync(requestForm).GetAwaiter().GetResult();

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        static void Check()
        {
            Console.Clear();

            DateIntervalForm requestForm = DateIntervalFormCreater();

            CheckAsync(requestForm).GetAwaiter().GetResult();

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        static DateIntervalForm DateIntervalFormCreater()
        {
            Console.WriteLine("Enter date interval form:");

            return new DateIntervalForm
            {
                StartYear = YearWriter("start"),
                StartMonth = MonthWriter("start"),
                StartDay = DayWriter("start"),
                EndYear = YearWriter("end"),
                EndMonth = MonthWriter("end"),
                EndDay = DayWriter("end")
            };
        }

        static int YearWriter(string date)
        {
            int year;
            Console.Write($"Enter {date} date year (yyyy): ");
            if (int.TryParse(Console.ReadLine(), out year) && year >= 1 && year <= 9999)
                return year;
            else
            {
                Console.WriteLine("Year must be a number bigger than 0 and lower than 10000 ");
                return YearWriter(date);
            }
        }

        static int MonthWriter(string date)
        {
            int month;
            Console.Write($"Enter {date} date month (mm): ");
            if (int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12)
                return month;
            else
            {
                Console.WriteLine("Month must be a number from 1 to 12");
                return MonthWriter(date);
            }
        }

        static int DayWriter(string date)
        {
            int day;
            Console.Write($"Enter {date} date day (dd): ");
            if (int.TryParse(Console.ReadLine(), out day) && day >= 1 && day <= 31)
                return day;
            else
            {
                Console.WriteLine("Day must be a number from 1 to 31");
                return DayWriter(date);
            }
        }

        static async Task<List<DateInterval>> GetDateIntervals(DateIntervalForm form)
        {
            List<DateInterval> dates = null;

            HttpResponseMessage response = await client.PutAsJsonAsync("/Date", form);

            dates = await response.Content.ReadAsAsync<List<DateInterval>>();

            return dates;
        }
    }
}
