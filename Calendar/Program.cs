﻿using System;
using System.IO;

namespace Calendar
{
    static class Environment
    {
        public static int LowestPriority = 4;
    }

    class Program
    {
        public int LowestPriority = 4;
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a calendar year.");
            string yearString = Console.ReadLine();
            int year;

            if (Int32.TryParse(yearString, out year))
            {
                CalendarData calendarData = new CalendarData(year);
                File.WriteAllText("calendar_"+yearString+".html", calendarData.ReturnPreHTML() + calendarData.CreateSaintDays() + "</body></html>");
            }
            else
            {
                Console.WriteLine("Please enter a year greater than 0.");
                Console.ReadLine();
            }
        }
    }
}
