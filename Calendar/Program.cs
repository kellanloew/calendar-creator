using System;

namespace Calendar
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a calendar year.");
            string yearString = Console.ReadLine();
            int year;
            
            if(Int32.TryParse(yearString, out year))
            {
                CalendarData calendarData = new CalendarData(year);
                // WriteAllText creates a file, writes the specified string to the file,
                System.IO.File.WriteAllText("t.html", calendarData.CreateSaintDays());
            }
            else
            {
                Console.WriteLine("Please enter a year greater than 0.");
                Console.ReadLine();
            }
        }
    }

    struct BasicCalendarDate
    {
        public int Date { get; set; }
        public string Saint { get; set; }
        public bool IsHolyDay { get; set; }
        public BasicCalendarDate(int date, string saint = "", bool isHolyDay = false)
        {
            Date = date;
            Saint = saint;
            IsHolyDay = isHolyDay;
        }
    }
}
