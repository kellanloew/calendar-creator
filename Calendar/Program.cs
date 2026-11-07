using System;
using System.IO;

namespace Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a calendar year.");
            string yearString = Console.ReadLine();

            if (int.TryParse(yearString, out int year) && year > 0 && year < 9999)
            {
                var liturgicalYear = new LiturgicalYear(year);
                File.WriteAllText("calendar_" + year + ".html", HtmlRenderer.Render(liturgicalYear));
            }
            else
            {
                Console.WriteLine("Please enter a year between 1 and 9998.");
                Console.ReadLine();
            }
        }
    }
}
